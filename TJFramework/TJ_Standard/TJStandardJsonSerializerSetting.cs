using Newtonsoft.Json;

namespace TJFramework.Tools
{
  internal class TJStandardJsonSerializerSetting
  {
    internal JsonSerializerSettings setting = new JsonSerializerSettings();

    internal TJStandardJsonSerializerSetting() // Constructor //
    {
      setting.Formatting = Formatting.Indented;
      setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      setting.PreserveReferencesHandling = PreserveReferencesHandling.All;
      setting.MaxDepth = 2;
      setting.DateTimeZoneHandling = DateTimeZoneHandling.Local;
      setting.DateFormatHandling = DateFormatHandling.IsoDateFormat;
      setting.DateParseHandling = DateParseHandling.DateTime;
    }
  }
}
