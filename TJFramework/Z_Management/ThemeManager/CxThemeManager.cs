using System;
using System.IO;
using TJFramework;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Threading.Tasks;
using System.Collections.Generic;
using static TJFramework.Logger.Manager;
using static TJFramework.TJFrameworkManager;

namespace TJFramework.Themes
{
  public class CxThemeManager
  {
    public string FolderThemes { get; } = "themes"; // Стандарт расположения стилей приложения //

    public List<string> ListOfThemes { get; private set; } = new List<string>();


    private string[] FindThemeFiles(string DirectoryName)
    {
      string[] result = new string[0];
      if (Directory.Exists(DirectoryName) == false) return result;
      result = Directory.GetFiles(DirectoryName, "Telerik.WinControls.Themes.*.dll");
      return result;
    }

    private void TryToFindAndLoadTheme()
    {
      string[] themefiles1 = FindThemeFiles(Application.StartupPath); // Ищем темы в папке приложения //
      string[] themefiles2 = FindThemeFiles(Path.Combine(Application.StartupPath, FolderThemes)); // Ищем темы в папке FolderThemes //

      string[] themefiles = themefiles1.Union(themefiles2).ToArray(); // Объединяем массивы удаляя при этом дубликаты (совпадающие значения) //

      foreach (var theme in themefiles)
      {
        var themeAssembly = Assembly.LoadFile(theme);
        var themeType = themeAssembly.GetTypes().Where(t => typeof(RadThemeComponentBase).IsAssignableFrom(t)).FirstOrDefault();
        if (themeType != null)
        {
          RadThemeComponentBase themeObject = (RadThemeComponentBase)Activator.CreateInstance(themeType);
          if (themeObject != null)
          {
            themeObject.Load();
          }
        }
      }

      ListOfThemes = ThemeRepository.AvailableThemeNames.ToList();
    }

    private void TryToApplyTheme(int ThemeIndex = 0)
    {
      if (ListOfThemes.Count < ThemeIndex + 1) return;

      string strTheme = ListOfThemes[ThemeIndex];
      Theme theme = ThemeResolutionService.GetTheme(strTheme);
      if (theme != null)
      {
        ThemeResolutionService.ApplicationThemeName = theme.Name;
      }
    }

    private void TryToApplyTheme(string ThemeName)
    {
      string strTheme = string.Empty;

      foreach (var item in ListOfThemes)
        if (item.Contains(ThemeName))
        {
          strTheme = item;
          break;
        }

      if (string.IsNullOrWhiteSpace(strTheme)) return;

      Theme theme = ThemeResolutionService.GetTheme(strTheme);
      if (theme != null)
      {
        ThemeResolutionService.ApplicationThemeName = theme.Name;
      }
    }

    public void SetApplicationAppearance(string ThemeName, Icon MainFormIcon, Icon NotificationIcon = null)
    {
      if (MainFormIcon != null)
      {
        Service.SetIcons(MainFormIcon, NotificationIcon ?? MainFormIcon);
      }

      if (string.IsNullOrWhiteSpace(ThemeName) == false)
      {
        TryToFindAndLoadTheme();
        TryToApplyTheme(ThemeName);
      }
    }
  }
}