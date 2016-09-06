// Decompiled with JetBrains decompiler
// Type: ActiveCampaign.Services.ListService
// Assembly: ActiveCampaign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B732A39-7F2E-43E4-B7C5-91A9F4429CA3
// Assembly location: C:\Users\khurram.raftaz\Desktop\Temp\ActiveCampaign-master\ActiveCampaign-master\WebApplication1\bin\ActiveCampaign.dll

using ActiveCampaign.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ActiveCampaign.Services
{
  public class ListService
  {
    private readonly ActiveCampaignConnectorService service;

    public ListService(ActiveCampaignConnectorService service)
    {
      this.service = service;
    }

    public bool AddContactList(NewContactList newContactList)
    {
      Regex regex = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
      return this.service.IsRequestSuccessfull((IReadOnlyDictionary<string, object>) this.service.SendRequest("list_add", (Dictionary<string, string>) null, new Dictionary<string, string>()
      {
        {
          "name",
          newContactList.Name
        },
        {
          "subscription_notify",
          string.Join(",", newContactList.SubscriptionNotify ?? (IEnumerable<string>) new List<string>())
        },
        {
          "unsubscription_notify",
          string.Join(",", newContactList.UnsubscriptionNotify ?? (IEnumerable<string>) new List<string>())
        },
        {
          "to_name",
          newContactList.DefaultRecipientName ?? "Dear Mr/Mrs"
        },
        {
          "carboncopy",
          string.Join(",", newContactList.CarbonCopyList ?? (IEnumerable<string>) new List<string>())
        },
        {
          "stringid",
          string.IsNullOrWhiteSpace(newContactList.Slug) ? regex.Replace(newContactList.Name, string.Empty) : newContactList.Slug
        },
        {
          "bounceid[]",
          "[1]"
        },
        {
          "sender_name",
          newContactList.SenderName ?? "Company Name"
        },
        {
          "sender_addr1",
          newContactList.SenderAddress ?? "Company Adrress"
        },
        {
          "sender_zip",
          newContactList.SenderPostalCode ?? "Company Post Code"
        },
        {
          "sender_city",
          newContactList.SenderCity ?? "Company City"
        },
        {
          "sender_country",
          newContactList.SenderCountry ?? "Company Country"
        },
        {
          "sender_url",
          newContactList.SenderUrl ?? "http://www.example.com"
        },
        {
          "sender_reminder",
          newContactList.SenderReminder ?? " "
        }
      }));
    }

    public bool DeleteContactList(int listId)
    {
      return this.service.IsRequestSuccessfull((IReadOnlyDictionary<string, object>) this.service.SendRequest("list_add", (Dictionary<string, string>) null, new Dictionary<string, string>()
      {
        {
          "id",
          listId.ToString()
        }
      }));
    }

    public List<ContactList> GetAllLists()
    {
      Dictionary<string, object> dictionary1 = this.service.SendRequest("list_list", new Dictionary<string, string>()
      {
        {
          "ids",
          "all"
        }
      }, (Dictionary<string, string>) null);
      List<ContactList> contactListList1 = new List<ContactList>();
      for (int index = 0; dictionary1.ContainsKey(index.ToString()); ++index)
      {
        Dictionary<string, object> dictionary2 = (Dictionary<string, object>) dictionary1[index.ToString()];
        List<ContactList> contactListList2 = contactListList1;
        ContactList contactList1 = new ContactList();
        contactList1.Id = int.Parse(dictionary2["id"].ToString());
        contactList1.IsPrivate = dictionary2["private"].ToString() == "1";
        contactList1.Name = dictionary2["name"].ToString();
        contactList1.UserId = int.Parse(dictionary2["userid"].ToString());
        contactList1.Cdate = DateTime.Parse(dictionary2["cdate"].ToString(), (IFormatProvider) CultureInfo.InvariantCulture);
        contactList1.SubscriberCount = int.Parse(dictionary2["subscriber_count"].ToString());
        ContactList contactList2 = contactList1;
        contactListList2.Add(contactList2);
      }
      return contactListList1;
    }
  }
}
