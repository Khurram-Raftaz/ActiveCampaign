// Decompiled with JetBrains decompiler
// Type: ActiveCampaign.Models.NewContactList
// Assembly: ActiveCampaign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B732A39-7F2E-43E4-B7C5-91A9F4429CA3
// Assembly location: C:\Users\khurram.raftaz\Desktop\Temp\ActiveCampaign-master\ActiveCampaign-master\WebApplication1\bin\ActiveCampaign.dll

using System.Collections.Generic;

namespace ActiveCampaign.Models
{
  public class NewContactList
  {
    public string Name { get; set; }

    public IEnumerable<string> SubscriptionNotify { get; set; }

    public IEnumerable<string> UnsubscriptionNotify { get; set; }

    public string DefaultRecipientName { get; set; }

    public IEnumerable<string> CarbonCopyList { get; set; }

    public string Slug { get; set; }

    public bool UseAnalyticsRead { get; set; }

    public string AnalyticsUA { get; set; }

    public bool UseAnalyticsLink { get; set; }

    public string SenderAddress { get; set; }

    public string SenderPostalCode { get; set; }

    public string SenderCountry { get; set; }

    public string SenderUrl { get; set; }

    public string SenderReminder { get; set; }

    public string SenderCity { get; set; }

    public string SenderName { get; set; }
  }
}
