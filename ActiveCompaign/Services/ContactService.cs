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
                postParameters.Add(string.Format("p[{0}]", (object)contactList.Id), contactList.Id.ToString());
                postParameters.Add(string.Format("status[{0}]", (object)contactList.Id), ((int)contactList.Status).ToString());
            }
            return this.service.IsRequestSuccessfull((IReadOnlyDictionary<string, object>)this.service.SendRequest("contact_add", (Dictionary<string, string>)null, postParameters));
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
                postParameters.Add(string.Format("p[{0}]", (object)contactList.Id), contactList.Id.ToString());
                postParameters.Add(string.Format("status[{0}]", (object)contactList.Id), contactList.Status.ToString("D"));
                postParameters.Add(string.Format("noresponders[{0}]", (object)contactList.Id), Convert.ToInt32(contactList.Noresponders).ToString());
                postParameters.Add(string.Format("sdate[{0}]", (object)contactList.Id), contactList.SubscribeDate);
                postParameters.Add(string.Format("instantresponders[{0}]", (object)contactList.Id), Convert.ToInt32(contactList.InstantResponders).ToString());
                postParameters.Add(string.Format("lastmessage[{0}]", (object)contactList.Id), Convert.ToInt32(contactList.LastMessage).ToString());
            }
            if (basicContactInfo.Fields != null)
            {
                foreach (Field field in basicContactInfo.Fields)
                    postParameters.Add(string.Format("field[{0},0]", field.Id.HasValue ? (object)field.Id.ToString() : (object)field.Name), field.Value);
            }
            return this.service.SendRequest("contact_sync", (Dictionary<string, string>)null, postParameters);
        }
        public string AddNewContact(string firstName, string lastName, string email, string listTypeId)
        {
            Dictionary<string, string> postParameters = new Dictionary<string, string>()
      {
        {
          "email",
          email
        },
        {
          "first_name",
          firstName
        },
        {
          "last_name",
          lastName
        }
        ,
        {
            "p["+listTypeId+"]",
           listTypeId
        },
        {
        "status["+listTypeId+"]",
        "1"
        }
      };
            var response = this.service.Request((IReadOnlyDictionary<string, object>)this.service.SendRequest("contact_add", (Dictionary<string, string>)null, postParameters));
            return response;
        }

        public string UnSubscribe(string email, string listTypeId)
        {
            Dictionary<string, string> postParameters = new Dictionary<string, string>()
      {
        {
          "email",
          email
        },
        {
            "p["+listTypeId+"]",
           listTypeId
        },
        {
        "status["+listTypeId+"]",
        "2"
        }

      };
            return this.service.Request((IReadOnlyDictionary<string, object>)this.service.SendRequest("contact_sync", (Dictionary<string, string>)null, postParameters));
        }
        public string Subscribe(string email, string listTypeId)
        {
            Dictionary<string, string> postParameters = new Dictionary<string, string>()
      {
        {
          "email",
          email
        },
        {
            "p["+listTypeId+"]",
           listTypeId
        },
        {
        "status["+listTypeId+"]",
        "1"
        }

      };
            return this.service.Request((IReadOnlyDictionary<string, object>)this.service.SendRequest("contact_sync", (Dictionary<string, string>)null, postParameters));
        }
    }
}
