// Decompiled with JetBrains decompiler
// Type: ActiveCampaign.Models.ExtendedContactInfo
// Assembly: ActiveCampaign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B732A39-7F2E-43E4-B7C5-91A9F4429CA3
// Assembly location: C:\Users\khurram.raftaz\Desktop\Temp\ActiveCampaign-master\ActiveCampaign-master\WebApplication1\bin\ActiveCampaign.dll

using System;
using System.Collections.Generic;

namespace ActiveCampaign.Models
{
  public class ExtendedContactInfo : BasicContactInfo
  {
    public string Name { get; set; }

    public DateTime? SubscribedDateTime { get; set; }

    public DateTime? UnsubscribedDateTime { get; set; }

    public int? SentCount { get; set; }

    public int? Status { get; set; }

    public int? Responder { get; set; }

    public int? Sync { get; set; }

    public int? BouncedHard { get; set; }

    public int? BouncedSoft { get; set; }

    public DateTime? BouncedDate { get; set; }

    public int? Rating { get; set; }

    public bool? HasGravatar { get; set; }

    public bool? IsDeleted { get; set; }

    public List<BasicContactList> Lists { get; set; }
  }
}
