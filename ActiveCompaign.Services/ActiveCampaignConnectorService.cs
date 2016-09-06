// Decompiled with JetBrains decompiler
// Type: ActiveCampaign.Services.ActiveCampaignConnectorService
// Assembly: ActiveCampaign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B732A39-7F2E-43E4-B7C5-91A9F4429CA3
// Assembly location: C:\Users\khurram.raftaz\Desktop\Temp\ActiveCampaign-master\ActiveCampaign-master\WebApplication1\bin\ActiveCampaign.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace ActiveCampaign.Services
{
  public class ActiveCampaignConnectorService
  {
    private readonly JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
    private readonly string _apiUrl;

    public ActiveCampaignConnectorService(string apiUrl, string apiKey)
    {
      if (string.IsNullOrEmpty(apiUrl))
        throw new ArgumentException(ActiveCampaign.Resources.ActiveCampaign.Invalid_API_Url, "apiUrl");
      if (string.IsNullOrEmpty(apiKey))
        throw new ArgumentException(ActiveCampaign.Resources.ActiveCampaign.Invalid_API_key, "apiKey");
      this._apiUrl = this.CreateBaseUrl(apiUrl) + "&api_key=" + apiKey;
    }

    public ActiveCampaignConnectorService(string apiUrl, string apiUser, string apiPassword)
    {
      if (string.IsNullOrEmpty(apiUrl))
        throw new ArgumentException("The reseller or customer API URL was not specified", "apiUrl");
      if (string.IsNullOrEmpty(apiUser))
        throw new ArgumentException("The API username was not specified", "apiUser");
      if (string.IsNullOrEmpty(apiPassword))
        throw new ArgumentException("The API password was not specified", "apiPassword");
      this._apiUrl = this.CreateBaseUrl(apiUrl) + "&api_user=" + apiUser + "&api_pass=" + apiPassword;
    }

    private string CreateBaseUrl(string apiUrl)
    {
      string str = Regex.IsMatch(apiUrl, "/$") ? apiUrl.Substring(0, apiUrl.Length - 1) : apiUrl;
      if (Regex.IsMatch(apiUrl, "https://www.activecampaign.com/"))
        return str + "/api.php?";
      return str + "/admin/api.php?api_output=json";
    }

    public bool TestConnection()
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(this._apiUrl + "&api_action=user_me");
      httpWebRequest.ServicePoint.Expect100Continue = false;
      httpWebRequest.Method = "GET";
      using (HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse())
      {
        using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
          return this.IsRequestSuccessfull((IReadOnlyDictionary<string, object>) this.javaScriptSerializer.Deserialize<Dictionary<string, object>>(streamReader.ReadToEnd()));
      }
    }

    public Dictionary<string, object> SendRequest(string method, Dictionary<string, string> getParameters = null, Dictionary<string, string> postParameters = null)
    {
      if (string.IsNullOrEmpty(method))
        throw new ArgumentException("A valid ActiveCampaign API method was not specified", "method");
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Append(this._apiUrl);
      stringBuilder1.Append("&api_action=" + method);
      if (getParameters != null)
      {
        foreach (KeyValuePair<string, string> getParameter in getParameters)
          stringBuilder1.Append(string.Format("&{0}={1}", (object) getParameter.Key, (object) HttpUtility.UrlEncode(getParameter.Value)));
      }
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(stringBuilder1.ToString());
      if (postParameters != null)
      {
        StringBuilder stringBuilder2 = new StringBuilder();
        foreach (KeyValuePair<string, string> postParameter in postParameters)
          stringBuilder2.Append(string.Format("&{0}={1}", (object) HttpUtility.UrlEncode(postParameter.Key), (object) HttpUtility.UrlEncode(postParameter.Value)));
        string s = stringBuilder2.ToString().Substring(1);
        httpWebRequest.Method = "POST";
        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        httpWebRequest.ContentLength = (long) s.Length;
        using (Stream requestStream = httpWebRequest.GetRequestStream())
          requestStream.Write(Encoding.UTF8.GetBytes(s), 0, s.Length);
      }
      string end;
      using (HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse())
      {
        using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
          end = streamReader.ReadToEnd();
      }
      return this.javaScriptSerializer.Deserialize<Dictionary<string, object>>(end);
    }

    public bool IsRequestSuccessfull(IReadOnlyDictionary<string, object> response)
    {
      if (response["result_code"].ToString() == "1")
        return true;
      throw new ExceptionService(response["result_message"].ToString());
    }
  }
}
