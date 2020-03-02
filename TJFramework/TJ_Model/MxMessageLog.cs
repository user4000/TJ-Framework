using System;

namespace TJFramework.Standard
{
  [Serializable]
  public class MxMessageLog
  {
    public int IdMessage { get; set; } = 0;
    public string DateMessage { get; set; } = string.Empty;
    public byte TypeMessage { get; set; } = 0;
    public string TypePresentation { get; set; } = string.Empty;
    public string HeaderMessage { get; set; } = string.Empty;
    public string TextMessage { get; set; } = string.Empty;
  }
}
