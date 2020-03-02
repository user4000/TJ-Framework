using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TJFramework.Tools;
using TJFramework.Standard;

namespace TJFramework
{
  public class TJAlertService
  {
    private int ConstDx { get; } = 10;

    private int ConstDy { get; } = 10;

    private int ScreenHeight { get => Screen.PrimaryScreen.WorkingArea.Height; }

    private int ScreenWidth { get => Screen.PrimaryScreen.WorkingArea.Width; }

    private int AlertHeaderMaxLength { get; } = 200;

    private int AlertMessageMaxLength { get; } = 2000;

    private PopupCloseInfo AlertCloseInfo { get; } = null;

    private TJService Service { get; } = null;

    private Container ContainerForAlerts { get; } = new Container();

    private TJAlertPainter Painter { get; } = new TJAlertPainter();

    private TJAlert PreviousAlert { get; set; } = null;

    private ConcurrentQueue<TJAlert> QueueAlert { get; } = new ConcurrentQueue<TJAlert>();

    internal TJAlertService(TJService HostService, RadForm OwnerOfContainer)
    {
      Service = HostService;
      AlertCloseInfo = new PopupCloseInfo(RadPopupCloseReason.Mouse, this);
      ContainerForAlerts.Add(OwnerOfContainer);
    }

    public void ShowAlert(TJMessage Message)
    {
      TJAlert Alert = new TJAlert(ContainerForAlerts)
      {
        CaptionText = Message.Header.Length > AlertHeaderMaxLength ? Message.Header.StringLeft(AlertHeaderMaxLength) : Message.Header,
        ContentText = Message.Text.Length > AlertMessageMaxLength ? Message.Text.StringLeft(AlertMessageMaxLength) : Message.Text,
        AutoCloseDelay = Message.AutoCloseDelay > 0 ? Message.AutoCloseDelay : TJFrameworkManager.FrameworkSettings.SecondsAlertAutoClose
      };

      Painter.SetColor(Alert, Message.MessageType);
      SetAlertPicture(Alert, Message);
      SetAlertFont(Alert);

      CheckDelaySeconds(Alert, Message);
      CheckPosition(Alert, Message);
      CheckAlertPinButton(Alert, Message.FlagShowPinButton);
      CheckAlertHasIndividualSize(Alert, Message);
      CheckAlertPinned(Alert, Message.FlagPinned);
      CheckAlertCloseOnClick(Alert, Message.FlagCloseOnClick);

      Alert.Show();

      CorrectAlertPosition(Alert, Message.AlertControl);
      MoveAlertToScreenCenter(Alert, Message.AlertPosition, Message.AlertControl);
      CheckAlertHasOffset(Alert, Message.AlertOffset);
      CheckPreviousAlert(Alert);
      CheckQueue(Alert);
      PreviousAlert = Alert;
    }

    private void CheckQueue(TJAlert Alert)
    {
      if (TJFrameworkManager.FrameworkSettings.LimitNumberOfAlerts)
      {
        QueueAlert.Enqueue(Alert);
        if (QueueAlert.Count > TJFrameworkManager.FrameworkSettings.MaxAlertCount)
          if (QueueAlert.TryDequeue(out TJAlert item))
          {
            item?.Hide(); item?.Dispose();
          }
      }
    }

    private void CheckPreviousAlert(TJAlert Alert)
    {
      if (PreviousAlert == null) return;
      if (TJTool.SquareOfDistance(PreviousAlert.Popup.Location, Alert.Popup.Location) < 25)
      {
        PreviousAlert.Popup.Location = new Point(PreviousAlert.Popup.Location.X - 30, PreviousAlert.Popup.Location.Y - 30);
      }
    }

    private void CheckAlertCloseOnClick(TJAlert Alert, bool FlagCloseOnClick)
    {
      if (FlagCloseOnClick) Alert.Popup.Click += (s, e) => Alert.Popup.ClosePopup(AlertCloseInfo);
    }

    private void SetAlertFont(TJAlert Alert)
    {
      Alert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = TJFrameworkManager.FrameworkSettings.FontAlertCaption;
      Alert.Popup.AlertElement.ContentElement.Font = TJFrameworkManager.FrameworkSettings.FontAlertText;
    }

    private bool EnoughSpaceForPicture(TJMessage Message)
    {
      return (Message.AlertSize == TJStandard.ZeroSize) || (Message.AlertSize.Height == 0) || (Message.AlertSize.Height > 60);
    }

    private void SetAlertPicture(TJAlert Alert, TJMessage Message)
    {
      if ((Message.FlagIcon) && (EnoughSpaceForPicture(Message)))
        Alert.ContentImage = Service.GetImageByMessageType(Message.MessageType);
    }

    private void CheckAlertPinned(TJAlert Alert, bool FlagPinned)
    {
      Alert.IsPinned = FlagPinned;
    }

    private void CheckAlertPinButton(TJAlert Alert, bool FlagShowPinButton)
    {
      Alert.ShowPinButton = FlagShowPinButton;
    }

    private void CheckPosition(TJAlert Alert, TJMessage Message)
    {
      if (Message.AlertControl == null)
      {
        if (Message.AlertPosition == MsgPos.ScreenCenter) // Screen Center position //
          Alert.ScreenPosition = AlertScreenPosition.Manual;
        else
          Alert.ScreenPosition = (AlertScreenPosition)((Message.AlertPosition == MsgPos.Unknown) ? TJFrameworkManager.FrameworkSettings.DefaultAlertPosition : Message.AlertPosition);
      }
      else
      {
        Alert.ScreenPosition = AlertScreenPosition.Manual;
      }
    }

    private void CheckDelaySeconds(TJAlert Alert, TJMessage Message)
    {
      Alert.AutoCloseDelay = Message.AutoCloseDelay > 0 ? Message.AutoCloseDelay : TJFrameworkManager.FrameworkSettings.SecondsAlertAutoClose;
    }

    private void CorrectAlertPosition(TJAlert Alert, Control AlertControl)
    { // If alert window runs out of the screen we should correct its position //

      if (AlertControl == null) return;

      Point p;
      int AlertHeight = Alert.Popup.DisplayRectangle.Height;
      int AlertWidth = Alert.Popup.DisplayRectangle.Width;

      try { p = AlertControl.PointToScreen(Point.Empty); } catch { return; }

      if (p.Y < (ScreenHeight / 2))
        p.Y += AlertControl.Height + ConstDy;
      else
        p.Y -= (AlertHeight + ConstDy);

      if (p.X < 0) p.X = ConstDx;

      if ((p.X + AlertWidth) > ScreenWidth) p.X = ScreenWidth - AlertWidth - ConstDx;

      Alert.Popup.Location = p;
    }

    private void MoveAlertToScreenCenter(TJAlert Alert, MsgPos AlertPosition, Control AlertControl)
    {
      if ((AlertControl == null) && (AlertPosition == MsgPos.ScreenCenter))
        Alert.Popup.Location = new Point
        (
        ScreenWidth / 2 - Alert.Popup.DisplayRectangle.Width / 2,
        ScreenHeight / 2 - Alert.Popup.DisplayRectangle.Height / 2
        );
    }

    private void CheckAlertHasOffset(TJAlert Alert, Point Offset)
    {
      if ((Offset.X == 0) && (Offset.Y == 0)) return;
      Alert.Popup.Location = new Point(Alert.Popup.Location.X + Offset.X, Alert.Popup.Location.Y + Offset.Y);
    }

    private void CheckAlertHasIndividualSize(TJAlert Alert, TJMessage Message)
    {
      if (Message.AlertSize != TJStandard.ZeroSize)
        Alert.FixedSize =
          new Size
          (
            Message.AlertSize.Width <= 10 ? Alert.Popup.Size.Width : Message.AlertSize.Width,
            Message.AlertSize.Height <= 10 ? Alert.Popup.Size.Height : Message.AlertSize.Height
          );
    }

    private string TestQueueAlert()
    {
      string s = string.Empty;
      foreach (var item in QueueAlert)
      {
        s += ((item == null) ? "NULL" : item.GetHashCode().ToString()) + "; ";
      }
      return s;
    }
  }
}
