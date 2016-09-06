// Decompiled with JetBrains decompiler
// Type: ActiveCampaign.Services.ContactService
// Assembly: ActiveCampaign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B732A39-7F2E-43E4-B7C5-91A9F4429CA3
// Assembly location: C:\Users\khurram.raftaz\Desktop\Temp\ActiveCampaign-master\ActiveCampaign-master\WebApplication1\bin\ActiveCampaign.dll

using ActiveCampaign.Models;
using System;
using System.Collections.Generic;

namespace ActiveCampaign.Services
{
  public class ContactService
  {
    private readonly ActiveCampaignConnectorService service;

    public ContactService(ActiveCampaignConnectorService service)
    {
      this.service = service;
    }

    public bool AddContact(BasicContactInfo basicContactInfo, IEnumerable<BasicContactList> contactLists)
    {
      Dictionary<string, string> postParameters = new Dictionary<string, string>()
      {
        {
          "email",
          basicContactInfo.Email
        },
        {
          "first_name",
          basicContactInfo.FirstName
        },
        {
          "last_name",
          basicContactInfo.LastName
        },
        {
          "phone",
          basicContactInfo.Phone
        },
        {
          "orgname",
          basicContactInfo.OrganizationName
        },
        {
          "tags",
          string.Join(",", (IEnumerable<string>) basicContactInfo.Tags)
        }
      };
      foreach (BasicContactList contactList in contactLists)
      {
        postParameters.Add(string.Format("p[{0}]", (object) contactList.Id), contactList.Id.ToString());
        postParameters.Add(string.Format("status[{0}]", (object) contactList.Id), ((int) contactList.Status).ToString());
      }
      return this.service.IsRequestSuccessfull((IReadOnlyDictionary<string, object>) this.service.SendRequest("contact_add", (Dictionary<string, string>) null, postParameters));
    }

    public Dictionary<string, object> SyncContact(BasicContactInfo basicContactInfo, IEnumerable<BasicContactList> contactLists)
    {
      Dictionary<string, string> postParameters = new Dictionary<string, string>()
      {
        {
          "email",
          basicContactInfo.Email
        },
        {
          "first_name",
          basicContactInfo.FirstName
        },
        {
          "last_name",
          basicContactInfo.LastName
        },
        {
          "phone",
          basicContactInfo.Phone
        },
        {
          "orgname",
          basicContactInfo.OrganizationName
        },
        {
          "form",
          basicContactInfo.FormId.ToString()
        },
        {
          "tags",
          string.Join(",", (IEnumerable<string>) basicContactInfo.Tags)
        }
      };
      foreach (BasicContactList contactList in contactLists)
      {
        postParameters.Add(string.Format("p[{0}]", (object) contactList.Id), contactList.Id.ToString());
        postParameters.Add(string.Format("status[{0}]", (object) contactList.Id), contactList.Status.ToString("D"));
        postParameters.Add(string.Format("noresponders[{0}]", (object) contactList.Id), Convert.ToInt32(contactList.Noresponders).ToString());
        postParameters.Add(string.Format("sdate[{0}]", (object) contactList.Id), contactList.SubscribeDate);
        postParameters.Add(string.Format("instantresponders[{0}]", (object) contactList.Id), Convert.ToInt32(contactList.InstantResponders).ToString());
        postParameters.Add(string.Format("lastmessage[{0}]", (object) contactList.Id), Convert.ToInt32(contactList.LastMessage).ToString());
      }
      if (basicContactInfo.Fields != null)
      {
        foreach (Field field in basicContactInfo.Fields)
          postParameters.Add(string.Format("field[{0},0]", field.Id.HasValue ? (object) field.Id.ToString() : (object) field.Name), field.Value);
      }
      return this.service.SendRequest("contact_sync", (Dictionary<string, string>) null, postParameters);
    }
  }
}
