using System;

namespace ActiveCampaign.Services
{
  public class ExceptionService : Exception
  {
    public ExceptionService(string errorMessage)
      : base(errorMessage)
    {
        var message = errorMessage;
    }
  }
}
