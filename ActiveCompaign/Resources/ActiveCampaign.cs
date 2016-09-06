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
        if (object.ReferenceEquals((object) ActiveCampaign.resourceMan, (object) null))
          ActiveCampaign.resourceMan = new ResourceManager("ActiveCampaign", typeof (ActiveCampaign).Assembly);
        return ActiveCampaign.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return ActiveCampaign.resourceCulture;
      }
      set
      {
        ActiveCampaign.resourceCulture = value;
      }
    }

    internal static string Invalid_API_key
    {
      get
      {
        return ActiveCampaign.ResourceManager.GetString("Invalid_API_key", ActiveCampaign.resourceCulture);
      }
    }

    internal static string Invalid_API_Url
    {
      get
      {
        return ActiveCampaign.ResourceManager.GetString("Invalid_API_Url", ActiveCampaign.resourceCulture);
      }
    }

    internal ActiveCampaign()
    {
    }
  }
}
