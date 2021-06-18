using TJFramework.Form;
using TJFramework.Logger;
using System.Windows.Forms;
using TJFramework.FrameworkSettings;
using System.Text.RegularExpressions;

namespace TJFramework
{
  public class TJFrameworkManager
  {
    public static FxMain MainForm { get; private set; } = null;

    public static TJService Service { get; } = new TJService();

    public static TJPageView Pages { get => Service.MainPageViewManager; }

    public static TJLoggerConfigurator Logger { get; } = new TJLoggerConfigurator();

    public static TJMessageManager Ms { get; } = new TJMessageManager();

    public static T ApplicationSettings<T>() => (T)(object)Service.CurrentApplicationSettings;

    public static TJStandardFrameworkSettings FrameworkSettings { get; } = new TJStandardFrameworkSettings();

    public static void Run() => Application.Run(CreateMainForm());

    public static FxMain CreateMainForm()
    {
      if (MainForm == null)
      {
        MainForm = new FxMain();
        Service.InitMainForm(MainForm);
        Service.SetEventsForMainForm();
      }
      return MainForm;
    }

    internal static string SettingSubFolderName { get; set; } = string.Empty;

    internal static bool IncorrectCharacter(string testName)
    {
      Regex containsBadCharacter = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidPathChars())) + "]");
      if (containsBadCharacter.IsMatch(testName)) return true;

      containsBadCharacter = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars())) + "]");
      if (containsBadCharacter.IsMatch(testName)) return true;

      return false;
    }

    internal static void SetSubFolderForSettings(string settingSubFolderName)
    {
      SettingSubFolderName = settingSubFolderName.Trim();
      if (IncorrectCharacter(SettingSubFolderName))
      {
        SettingSubFolderName = string.Empty;
        //SettingSubFolderName = Assembly.GetExecutingAssembly().GetName().Name ;
        //MessageBox.Show("Folder name contains incorrect character", "ArgumentName = [settingSubFolderName]");
      }
    }

    internal static string CheckIfSettingSubFolderIsSpecified(string FileName)
    {
      /*
      Example:
      settings\my_file_name.txt    =>   settings\subfolder\my_file_name.txt
      */
      if (SettingSubFolderName != string.Empty) FileName = FileName.Replace(@"\", @"\" + SettingSubFolderName + @"\");
      return FileName;
    }
  }
}

