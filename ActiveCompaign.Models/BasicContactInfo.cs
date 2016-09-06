// Decompiled with JetBrains decompiler
// Type: ActiveCampaign.Models.BasicContactInfo
// Assembly: ActiveCampaign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B732A39-7F2E-43E4-B7C5-91A9F4429CA3
// Assembly location: C:\Users\khurram.raftaz\Desktop\Temp\ActiveCampaign-master\ActiveCampaign-master\WebApplication1\bin\ActiveCampaign.dll

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActiveCampaign.Models
{
  public class BasicContactInfo
  {
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string OrganizationName { get; set; }

    public List<string> Tags { get; set; }

    public string IPAddress { get; set; }

    public List<Field> Fields { get; set; }

    public int FormId { get; set; }
  }
}
