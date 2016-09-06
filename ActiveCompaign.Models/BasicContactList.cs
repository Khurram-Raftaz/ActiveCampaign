// Decompiled with JetBrains decompiler
// Type: ActiveCampaign.Models.BasicContactList
// Assembly: ActiveCampaign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B732A39-7F2E-43E4-B7C5-91A9F4429CA3
// Assembly location: C:\Users\khurram.raftaz\Desktop\Temp\ActiveCampaign-master\ActiveCampaign-master\WebApplication1\bin\ActiveCampaign.dll

using ActiveCampaign.Enums;

namespace ActiveCampaign.Models
{
  public class BasicContactList
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public SubscriptionStatus Status { get; set; }

    public bool Noresponders { get; set; }

    public string SubscribeDate { get; set; }

    public bool InstantResponders { get; set; }

    public bool LastMessage { get; set; }
  }
}
