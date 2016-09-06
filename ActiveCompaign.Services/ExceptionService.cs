// Decompiled with JetBrains decompiler
// Type: ActiveCampaign.Services.ExceptionService
// Assembly: ActiveCampaign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B732A39-7F2E-43E4-B7C5-91A9F4429CA3
// Assembly location: C:\Users\khurram.raftaz\Desktop\Temp\ActiveCampaign-master\ActiveCampaign-master\WebApplication1\bin\ActiveCampaign.dll

using System;

namespace ActiveCampaign.Services
{
  public class ExceptionService : Exception
  {
    public ExceptionService(string errorMessage)
      : base(errorMessage)
    {
    }
  }
}
