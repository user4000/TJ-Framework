using System;
using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using TJFramework.ApplicationSettings;
using static TJFramework.TJFrameworkManager;

namespace TJFramework.Form
{
  public partial class FxSettings : RadForm, IEventStartWork, IEventEndWork
  {
    private Font itemFont { get; } = new Font("Verdana", 10);

    private TJStandardApplicationSettings currentSettings { get; set; } = null;

    private TJStandardApplicationSettings loadedSettings { get; set; } = null;

    private bool LoadedSettingsIsUsed { get; set; } = false;

    private byte ValueColumnWidthPercent { get; } = 70;

    private int CountSelectedObjectChanged { get; set; } = 0;

    private int CountThisPageVisited { get; set; } = 0;

    private bool IsFirstTimeCalled { get => CountSelectedObjectChanged < 1; }

    private void MarkFirstTimeCalling() => CountSelectedObjectChanged++;

    private static ColorConverter converter { get; } = new ColorConverter();

    private Color FalseColor { get; } = (Color)converter.ConvertFromString("#FBF3F4");

    private Color TrueColor { get; } = (Color)converter.ConvertFromString("#DFFFE4");

    private TJStandardApplicationSettings GetCurrentSettings() => (TJStandardApplicationSettings)GxProperty.SelectedObject;

    private int GetPropertyGridWidth() => (GxProperty.Width - GxProperty.Padding.Left - GxProperty.Padding.Right);

    private int GetValueColumnWidth() => (int)(GetPropertyGridWidth() * (0.01F * ValueColumnWidthPercent));

    public FxSettings() /* ------------------------------------------  CONSTRUCTOR ------------------------------------------ */
    {
      InitializeComponent();
      //-------------------------------------------------------------------------------------------
      if (TJFrameworkManager.FrameworkSettings.ValueColumnWidthPercent > 0)
        ValueColumnWidthPercent = TJFrameworkManager.FrameworkSettings.ValueColumnWidthPercent;
      //-------------------------------------------------------------------------------------------
      GxProperty.Padding = TJFrameworkManager.FrameworkSettings.PropertyGridPadding;
      BtnSaveSettings.Left = GxProperty.Padding.Left;
      GxProperty.PropertyValueChanged += new PropertyGridItemValueChangedEventHandler(EventPropertyValueChanged);
      GxProperty.ItemFormatting += new PropertyGridItemFormattingEventHandler(EventItemFormatting);
      BtnSaveSettings.Click +=  new EventHandler(BtnSaveSettingsClick);
    }

    private string SaveSettings()
    {
      string error = string.Empty;
      try { GetCurrentSettings().SaveToJsonFile(); }
      catch (Exception ex) { error = ex.Message; };
      return error;
    }

    internal void AcceptLoadedSettings(TJStandardApplicationSettings settings)
    {
      if (settings != null) loadedSettings = settings;
      UseLoadedSettings();
    }

    public void EventStartWork()
    {

    }

    public void EventEndWork()
    {
      SaveSettings();
    }

    private void EventPropertyValueChanged(object sender, PropertyGridItemValueChangedEventArgs e)
    {
      currentSettings = GetCurrentSettings();
      if (currentSettings != null && e.Item != null) currentSettings.PropertyValueChanged(e.Item.Name);
    }

    private void FormatSubItem(PropertyGridItemFormattingEventArgs e, PropertyGridItem item)
    {
      if (item != null)
      {
        if (item.Level > 0)
        {
          e.VisualElement.ForeColor = Color.DarkMagenta;
        }
        else
        {
          e.VisualElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
        }
      }
    }

    private void FormatConstantValue(PropertyGridItemFormattingEventArgs e, PropertyGridItem item)
    {
      if (item != null)
      {
        if (item.ReadOnly && item.Level == 0)
        {
          e.VisualElement.ForeColor = Color.Blue;
        }
        else
        {
          e.VisualElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
        }
        e.VisualElement.Font = itemFont;
      }
    }

    private void FormatBooleanValue(PropertyGridItemFormattingEventArgs e, PropertyGridItem item)
    {
      if (item != null && item.Value != null && item.Level == 0)
      {
        if (item.Value.ToString() == "True")
        {
          e.VisualElement.BackColor = TrueColor;
        }
        else if (item.Value.ToString() == "False")
        {
          e.VisualElement.BackColor = FalseColor;
        }
      }
      else
      {
        e.VisualElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
      }
    }

    private void EventItemFormatting(object sender, PropertyGridItemFormattingEventArgs e)
    {
      PropertyGridItem item = e.Item as PropertyGridItem;
      FormatConstantValue(e, item);
      FormatBooleanValue(e, item);
    }

    private void BtnSaveSettingsClick(object sender, EventArgs e)
    {
      string error = SaveSettings();
      if (error == string.Empty)
      {
        Ms.Message("Settings have been saved.", string.Empty).Wire(BtnSaveSettings).Size(200, 35).NoIcon().Delay(2).Debug();
      }
      else
      {
        Ms.Message("Error! Settings was not saved.", error).Wire(BtnSaveSettings).NoIcon().Delay(15).ToFile().Error();
      }
    }

    internal void EventUserVisitedThisPage()
    {
      SetColumnWidth();
    }

    internal void SetColumnWidth()
    {
      if (IsFirstTimeCalled)
      {
        GxProperty.PropertyGridElement.PropertyTableElement.ValueColumnWidth = GetValueColumnWidth();
        MarkFirstTimeCalling();
      }
    }

    private void UseLoadedSettings()
    {
      if ((LoadedSettingsIsUsed == false) && (loadedSettings != null))
      {
        GxProperty.Visible = false; // <-- Very important for properly working visual effects //
        loadedSettings.LinkToPropertyGrid(this.GxProperty);
        GxProperty.Visible = true; // <-- Very important for properly working visual effects //
        LoadedSettingsIsUsed = true;
      }
    }
  }
}
