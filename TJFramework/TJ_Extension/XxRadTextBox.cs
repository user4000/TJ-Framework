﻿using Telerik.WinControls.UI;

namespace TJFramework.Extensions
{
  public static class XxRadTextBox
  {
    public static void ZzSetValue(this RadTextBox radTextBox, long value) => radTextBox.Text = value.ToString();

    public static void ZzSetValue(this RadTextBox radTextBox, int value) => radTextBox.Text = value.ToString();
  }
}