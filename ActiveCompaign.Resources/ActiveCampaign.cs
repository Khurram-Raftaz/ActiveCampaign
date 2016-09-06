// Decompiled with JetBrains decompiler
// Type: ActiveCampaign.Resources.ActiveCampaign
// Assembly: ActiveCampaign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0B732A39-7F2E-43E4-B7C5-91A9F4429CA3
// Assembly location: C:\Users\khurram.raftaz\Desktop\Temp\ActiveCampaign-master\ActiveCampaign-master\WebApplication1\bin\ActiveCampaign.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ActiveCampaign.Resources
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class ActiveCampaign
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) ActiveCampaign.Resources.ActiveCampaign.resourceMan, (object) null))
          ActiveCampaign.Resources.ActiveCampaign.resourceMan = new ResourceManager("ActiveCampaign.Resources.ActiveCampaign", typeof (ActiveCampaign.Resources.ActiveCampaign).Assembly);
        return ActiveCampaign.Resources.ActiveCampaign.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return ActiveCampaign.Resources.ActiveCampaign.resourceCulture;
      }
      set
      {
        ActiveCampaign.Resources.ActiveCampaign.resourceCulture = value;
      }
    }

    internal static string Invalid_API_key
    {
      get
      {
        return ActiveCampaign.Resources.ActiveCampaign.ResourceManager.GetString("Invalid_API_key", ActiveCampaign.Resources.ActiveCampaign.resourceCulture);
      }
    }

    internal static string Invalid_API_Url
    {
      get
      {
        return ActiveCampaign.Resources.ActiveCampaign.ResourceManager.GetString("Invalid_API_Url", ActiveCampaign.Resources.ActiveCampaign.resourceCulture);
      }
    }

    internal ActiveCampaign()
    {
    }
  }
}
