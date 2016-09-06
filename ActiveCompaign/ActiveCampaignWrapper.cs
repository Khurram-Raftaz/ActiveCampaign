using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ActiveCompaignWrapper
/// </summary>
public class ActiveCampaignWrapper
{
	public ActiveCampaignWrapper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string AddContactToActiveCompaign(string firstName, string lastName, string email, string serviceType)
    {
        string response = "";
        ActiveCampaignConnectorService connection = new ActiveCampaignConnectorService("https://qualitycompliancesystems.api-us1.com", "e4f341aba40906c3bb4f67dc12dfc057c4ae422278d0970bef91e78a61e9244e662604a1");
        bool testConnection = connection.TestConnection();
        if (testConnection)
        {
            ActiveCampaign.Services.ContactService cs = new ActiveCampaign.Services.ContactService(connection);
            response = cs.AddNewContact(firstName, lastName, email, serviceType);
        }
        else
        {
            response = "Unable to connect to Api";
        }
        return response;
    }
    public string UnSubscribeFromActiveCompaign(string email, string serviceType)
    {
        string response = "";
        ActiveCampaignConnectorService connection = new ActiveCampaignConnectorService("https://qualitycompliancesystems.api-us1.com", "e4f341aba40906c3bb4f67dc12dfc057c4ae422278d0970bef91e78a61e9244e662604a1");
        bool testConnection = connection.TestConnection();
        if (testConnection)
        {
            ActiveCampaign.Services.ContactService cs = new ActiveCampaign.Services.ContactService(connection);
            response = cs.UnSubscribe(email, serviceType);
        }
        else
        {
            response = "Unable to connect to Api";
        }
        return response;
    }
    public string SubscribeToActiveCompaign(string email, string serviceType)
    {
        string response = "";
        ActiveCampaignConnectorService connection = new ActiveCampaignConnectorService("https://qualitycompliancesystems.api-us1.com", "e4f341aba40906c3bb4f67dc12dfc057c4ae422278d0970bef91e78a61e9244e662604a1");
        bool testConnection = connection.TestConnection();
        if (testConnection)
        {
            ActiveCampaign.Services.ContactService cs = new ActiveCampaign.Services.ContactService(connection);
            response = cs.Subscribe(email, serviceType);
        }
        else
        {
            response = "Unable to connect to Api";
        }
        return response;
    }
}