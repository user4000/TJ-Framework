using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Telerik.WinControls.UI;
using Newtonsoft.Json;
using TJFramework.Tools;

namespace TJFramework.ApplicationSettings
{
  [Serializable]
  public abstract class TJStandardApplicationSettings
  {
    //internal const string Empty = "";

    internal const string DefaultFolderUserSettings = "settings";

    internal const string DefaultBinaryFileName = DefaultFolderUserSettings + @"\application_settings.bin";

    internal const string DefaultTextFileName = DefaultFolderUserSettings + @"\application_settings.txt"; 

    internal string TextFileSettings { get; } = "application_settings.txt"; // TODO: User should be able to change settings file name. Use [TJFrameworkManager] for this feature //

    public const string TJStandardDateTimeFull = "yyyy-MM-dd HH:mm:ss";

    public static DateTime TJStandardDateTimeDefaultValue = new DateTime(2000, 01, 01);

    public string GetDateTime(DateTime d) => d.ToString(TJStandardDateTimeFull);

    public DateTime SetDateTime(string DateTimeStringValue, DateTime ValueIfError)
    {
      DateTime d = ValueIfError;
      try { d = DateTime.ParseExact(DateTimeStringValue, TJStandardDateTimeFull, System.Globalization.CultureInfo.InvariantCulture); }
      catch { d = ValueIfError; };
      return d;
    }
    public abstract void EventBeforeSaving();
    public abstract void EventAfterSaving();

    public abstract void PropertyValueChanged(string PropertyName);
    private void CreateDirectoryForSettings(string FileContainingSettings)
    {
      TJTool.CreateDirectoryForFile(FileContainingSettings);
    }

    public void SaveToBinaryFile(string FileContainingSettings = DefaultBinaryFileName)
    {
      CreateDirectoryForSettings(FileContainingSettings);
      EventBeforeSaving();
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      using (MemoryStream ms = new MemoryStream())
      {
        binaryFormatter.Serialize(ms, this);
        ms.Seek(0, SeekOrigin.Begin);
        using (FileStream fs = new FileStream(FileContainingSettings, FileMode.OpenOrCreate, FileAccess.Write))
        {
          ms.CopyTo(fs);
          fs.Flush();
        }
      }
      EventAfterSaving();
    }

    public static TJStandardApplicationSettings LoadFromBinaryFile(TJStandardApplicationSettings PreviousSettings, string FileContainingSettings = DefaultBinaryFileName)
    {      
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream ms = new MemoryStream();
      using (FileStream fs = new FileStream(FileContainingSettings, FileMode.Open, FileAccess.Read))
      {
        byte[] array = new byte[fs.Length];
        fs.Read(array, 0, array.Length);
        fs.Seek(0, SeekOrigin.Begin);
        fs.CopyTo(ms);
      }
      ms.Seek(0, SeekOrigin.Begin);
      object my_object = binaryFormatter.Deserialize(ms);
      TJStandardApplicationSettings settings = (TJStandardApplicationSettings)my_object;    
      return settings;
    }

    public void SaveToJSONFile(string FileContainingSettings = DefaultTextFileName)
    {     
      CreateDirectoryForSettings(FileContainingSettings);
      EventBeforeSaving();

      using (StreamWriter file = File.CreateText(FileContainingSettings))
      {
        JsonSerializer serializer = new JsonSerializer()
        {
          Formatting = Formatting.Indented,
          DateFormatString = TJStandardDateTimeFull
        };
        //serializer.MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead;
        serializer.Serialize(file, this);
      }
      /*if (TJFrameworkManager.Service.UserHasClickedExit==false)*/ EventAfterSaving();
    }

    public void LinkToPropertyGrid(RadPropertyGrid grid) => grid.SelectedObject = this;

  }
}






