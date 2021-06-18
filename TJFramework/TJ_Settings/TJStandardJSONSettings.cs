using System.IO;
using Newtonsoft.Json;

namespace TJFramework.ApplicationSettings
{
  public class TJStandardJsonSettings<T> where T : new()
  {
    public const string DefaultFolderUserSettings = TJStandardApplicationSettings.DefaultFolderUserSettings; // "settings";

    public const string FrameworkSettingsFileName = DefaultFolderUserSettings + @"\framework_settings.txt";

    internal virtual void Save(string fileName = FrameworkSettingsFileName)
    {
      fileName = TJFrameworkManager.CheckIfSettingSubFolderIsSpecified(fileName);
      using (StreamWriter file = File.CreateText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
        serializer.Serialize(file, this);
      }
    }

    internal static void Save(T Settings, string fileName = FrameworkSettingsFileName)
    {
      fileName = TJFrameworkManager.CheckIfSettingSubFolderIsSpecified(fileName);
      using (StreamWriter file = File.CreateText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
        serializer.Serialize(file, Settings);
      }
    }

    internal static T Load(string fileName = FrameworkSettingsFileName)
    {
      fileName = TJFrameworkManager.CheckIfSettingSubFolderIsSpecified(fileName);
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
