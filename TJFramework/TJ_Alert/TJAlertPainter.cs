using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TJFramework
{
  internal class TJAlertPainter // Class paints Alert Windows of different types //
  {
    const string mainColorRGB = "#CCDCFC";
    const string borderColorRGB = "#4614DB";
    const string foreColorRGB1 = "#03702B";
    const string backColorRGB1 = "#FCFCFC";
    const string backColorRGB2 = "#FCDEDE";

    private static ColorConverter VxConverter { get; } = new ColorConverter();
    private Color MainColor { get; } = (Color)VxConverter.ConvertFromString(mainColorRGB);
    private Color BorderColor { get; } = (Color)VxConverter.ConvertFromString(borderColorRGB);
    private Color ForeColor { get; } = (Color)VxConverter.ConvertFromString(foreColorRGB1);

    private Color backColorOne { get; } = (Color)VxConverter.ConvertFromString(backColorRGB1);
    private Color backColorTwo { get; } = (Color)VxConverter.ConvertFromString(backColorRGB2);

    private void SetColorForWarning(RadDesktopAlert alert)
    {
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.BackColor = Color.Yellow;
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.GradientStyle = GradientStyles.Solid;
      alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.ForeColor = Color.Brown;

      alert.Popup.AlertElement.BackColor = Color.LightYellow;
      alert.Popup.AlertElement.GradientStyle = GradientStyles.Solid;
      alert.Popup.AlertElement.BorderColor = Color.RosyBrown;
    }

    private void SetColorForError(RadDesktopAlert alert)
    {
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.BackColor = Color.Red;
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.GradientStyle = GradientStyles.Solid;

      alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.ForeColor = Color.FromKnownColor(KnownColor.Brown);
      alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.BackColor = Color.FromKnownColor(KnownColor.Orange);

      alert.Popup.AlertElement.BackColor = backColorOne;
      alert.Popup.AlertElement.BackColor2 = backColorTwo;
      alert.Popup.AlertElement.BorderColor = Color.MediumVioletRed;
    }

    private void SetColorForAlert(RadDesktopAlert alert, Color back1, Color back2, Color border, Color? fore = null, Color? content = null)
    {
      if (fore != null) { alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.ForeColor = (Color)fore; }
      alert.Popup.AlertElement.BackColor = back1;
      alert.Popup.AlertElement.BackColor2 = back2;
      alert.Popup.AlertElement.BorderColor = border;
      if (content != null) { alert.Popup.AlertElement.ContentElement.ForeColor = (Color)content; }
    }

    private void SetStyle(RadDesktopAlert Alert)
    {
      Alert.Popup.AlertElement.ContentElement.TextImageRelation = TextImageRelation.TextBeforeImage;
      Alert.Popup.AlertElement.GradientStyle = GradientStyles.Gel;      
    }

    internal void SetColor(RadDesktopAlert Alert, MsgType MessageType)
    {
      SetStyle(Alert);
      switch ((byte)MessageType)
      {
        case 0: // Debug //
          SetColorForAlert(Alert, MainColor, MainColor, BorderColor); break;
        case 1: // Information //
          SetColorForAlert(Alert, MainColor, MainColor, BorderColor, Color.Blue); break;
        case 2: // Success //
          SetColorForAlert(Alert, MainColor, MainColor, BorderColor, ForeColor); break;
        case 3: // Failure //
          SetColorForAlert(Alert, MainColor, MainColor, Color.RosyBrown, Color.Brown, Color.Blue); break;
        case 4: // Warning //
          SetColorForWarning(Alert); break;
        case 5: // Error //
          SetColorForError(Alert); break;
        default: break;
      }
    }
  }
}
