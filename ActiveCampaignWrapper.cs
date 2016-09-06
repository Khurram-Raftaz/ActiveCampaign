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
        ActiveCampaignConnectorService connection = new ActiveCampaignConnectorService("yourApiUrl", "ApiKey");
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
        ActiveCampaignConnectorService connection = new ActiveCampaignConnectorService("yourApiUrl", "ApiKey");
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
        ActiveCampaignConnectorService connection = new ActiveCampaignConnectorService("yourApiUrl", "ApiKey");
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