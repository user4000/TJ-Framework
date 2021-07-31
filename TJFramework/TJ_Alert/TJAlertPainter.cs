using System.Drawing;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace TJFramework
{
  internal class TJAlertPainter // Class paints Alert Windows of different types //
  {
    const string mainColorRGB = "#E6F2FC";
    const string OkColorRGB = "#EBFAFA";
    const string FailColorRGB = "#FAF5FA";

    const string borderColorRGB = "#4614DB";
    const string foreColorRGB1 = "#03702B";
    const string backColorRGB1 = "#FCFCFC";
    const string backColorRGB2 = "#FCDEDE";

    const float AlertOpacity = 0.98f;


    private static ColorConverter VxConverter { get; } = new ColorConverter();

    private Color MainColor { get; } = (Color)VxConverter.ConvertFromString(mainColorRGB);

    private Color BorderColor { get; } = (Color)VxConverter.ConvertFromString(borderColorRGB);

    private Color ForeColor { get; } = (Color)VxConverter.ConvertFromString(foreColorRGB1);

    private Color backColorOne { get; } = (Color)VxConverter.ConvertFromString(backColorRGB1);

    private Color backColorTwo { get; } = (Color)VxConverter.ConvertFromString(backColorRGB2);


    private Color ColorOk { get; } = (Color)VxConverter.ConvertFromString(OkColorRGB);

    private Color ColorOkGrip { get; } = (Color)VxConverter.ConvertFromString("#CCFFE6");

    private Color ColorFail { get; } = (Color)VxConverter.ConvertFromString(FailColorRGB);

    private Color ColorFailGrip { get; } = (Color)VxConverter.ConvertFromString("#FFE6F9");





    private void SetColorForDebug(RadDesktopAlert alert)
    {
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.BackColor = Color.LightGray;
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.GradientStyle = GradientStyles.Solid;
      alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.ForeColor = Color.Navy;

      alert.Popup.AlertElement.BackColor = MainColor;
      alert.Popup.AlertElement.GradientStyle = GradientStyles.Solid;
      alert.Popup.AlertElement.BorderColor = Color.Gray;
    }

    private void SetColorForSuccess(RadDesktopAlert alert)
    {
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.BackColor = ColorOkGrip;
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.GradientStyle = GradientStyles.Solid;
      alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.ForeColor = Color.DarkGreen;

      alert.Popup.AlertElement.BackColor = ColorOk;
      alert.Popup.AlertElement.GradientStyle = GradientStyles.Solid;
      alert.Popup.AlertElement.BorderColor = Color.DarkGreen;
    }

    private void SetColorForFail(RadDesktopAlert alert)
    {
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.BackColor = ColorFailGrip;
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.GradientStyle = GradientStyles.Solid;
      alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.ForeColor = Color.DarkRed;

      alert.Popup.AlertElement.BackColor = ColorFail;
      alert.Popup.AlertElement.GradientStyle = GradientStyles.Solid;
      alert.Popup.AlertElement.BorderColor = Color.RosyBrown;
    }

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
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.BackColor = Color.OrangeRed;
      alert.Popup.AlertElement.CaptionElement.CaptionGrip.GradientStyle = GradientStyles.Solid;

      alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.ForeColor = Color.FromKnownColor(KnownColor.Brown);
      alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.BackColor = Color.FromKnownColor(KnownColor.Orange);

      alert.Popup.AlertElement.BackColor = backColorOne;
      alert.Popup.AlertElement.BackColor2 = backColorTwo;
      alert.Popup.AlertElement.BorderColor = Color.Red;
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
      Alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.TextWrap = true;
      Alert.Opacity = AlertOpacity;
    }

    internal void SetColor(RadDesktopAlert Alert, MsgType MessageType)
    {
      SetStyle(Alert);
      switch ((byte)MessageType)
      {
        case 0: // Debug //
          SetColorForDebug(Alert); break;
        //SetColorForAlert(Alert, MainColor, MainColor, BorderColor); break;
        case 1: // Information //
          SetColorForAlert(Alert, MainColor, MainColor, BorderColor, Color.Blue); break;
        case 2: // Success //
          SetColorForSuccess(Alert); break;
        //SetColorForAlert(Alert, ColorOk, ColorOk, Color.LimeGreen, Color.DarkGreen, Color.Black); break;
        case 3: // Failure //
          SetColorForFail(Alert); break;
        //SetColorForAlert(Alert, MainColor, MainColor, Color.RosyBrown, Color.Brown, Color.Blue); break;
        case 4: // Warning //
          SetColorForWarning(Alert); break;
        case 5: // Error //
          SetColorForError(Alert); break;
        default: break;
      }
    }
  }
}