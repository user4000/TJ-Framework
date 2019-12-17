using System.IO;
using Newtonsoft.Json;

namespace TJFramework.ApplicationSettings
{
  public class TJStandardJSONSettings<T> where T : new()
  {
    internal const string DefaultFolderUserSettings = TJStandardApplicationSettings.DefaultFolderUserSettings; // "settings";
    internal const string FrameworkSettingsFileName = DefaultFolderUserSettings + @"\framework_settings.json";

    internal virtual void Save(string fileName = FrameworkSettingsFileName)
    {
      using (StreamWriter file = File.CreateText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
        serializer.Serialize(file, this);
      }
    }

    internal static void Save(T Settings, string fileName = FrameworkSettingsFileName)
    {
      using (StreamWriter file = File.CreateText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
        serializer.Serialize(file, Settings);
      }
    }

    internal static T Load(string fileName = FrameworkSettingsFileName)
    {
      T t = default(T);
      using (StreamReader file = File.OpenText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer();
        t = (T)serializer.Deserialize(file, typeof(T));
      }
      return t;
    }
  }
}
