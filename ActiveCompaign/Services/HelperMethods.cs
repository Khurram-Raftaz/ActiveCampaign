using System;
using System.Collections.Generic;
using System.Globalization;

namespace ActiveCampaign.Services
{
  public class HelperMethods
  {
    public static bool? GetNullableBool(IReadOnlyDictionary<string, object> resource, string propertyName)
    {
      if (HelperMethods.CheckIfPropertyExistsInResource(resource, propertyName))
        return new bool?();
      if (HelperMethods.CheckIfPropertyIsNull(resource, propertyName))
        return new bool?();
      return new bool?(resource[propertyName].ToString() == "1");
    }

    public static bool GetBool(IReadOnlyDictionary<string, object> resource, string propertyName)
    {
      return resource[propertyName].ToString() == "1";
    }

    public static string GetString(IReadOnlyDictionary<string, object> resource, string propertyName)
    {
      if (HelperMethods.CheckIfPropertyExistsInResource(resource, propertyName))
        return (string) null;
      if (HelperMethods.CheckIfPropertyIsNull(resource, propertyName))
        return (string) null;
      return resource[propertyName].ToString();
    }

    public static int? GetNullableInt(IReadOnlyDictionary<string, object> resource, string propertyName)
    {
      if (HelperMethods.CheckIfPropertyExistsInResource(resource, propertyName))
        return new int?();
      if (HelperMethods.CheckIfPropertyIsNull(resource, propertyName))
        return new int?();
      return new int?(int.Parse(resource[propertyName].ToString(), (IFormatProvider) CultureInfo.InvariantCulture));
    }

    public static int GetInt(IReadOnlyDictionary<string, object> resource, string propertyName)
    {
      return int.Parse(resource[propertyName].ToString(), (IFormatProvider) CultureInfo.InvariantCulture);
    }

    public static DateTime? GetNullableDateTime(IReadOnlyDictionary<string, object> resource, string propertyName)
    {
      if (HelperMethods.CheckIfPropertyExistsInResource(resource, propertyName))
        return new DateTime?();
      if (HelperMethods.CheckIfPropertyIsNull(resource, propertyName))
        return new DateTime?();
      DateTime result;
      if (DateTime.TryParse(resource[propertyName].ToString(), out result))
        return new DateTime?(result);
      return new DateTime?();
    }

    public static DateTime GetDateTime(IReadOnlyDictionary<string, object> resource, string propertyName)
    {
      return DateTime.Parse(resource[propertyName].ToString(), (IFormatProvider) CultureInfo.InvariantCulture);
    }

    public static bool CheckIfPropertyIsNull(IReadOnlyDictionary<string, object> resource, string propertyName)
    {
      return resource[propertyName] == null;
    }

    public static bool CheckIfPropertyExistsInResource(IReadOnlyDictionary<string, object> resource, string propertyName)
    {
      return !resource.ContainsKey(propertyName);
    }
  }
}
