using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace TJFramework
{
  public static class TJStandard
  {
    public static char MessageHeaderSeparator { get; } = '|';

    public static string MessageType1 { get; } = "O";
    public static string MessageType2 { get; } = "i";
    public static string MessageType3 { get; } = "a";
    public static string MessageType4 { get; } = "@";
    public static string MessageType5 { get; } = "x";
    public static string MessageType6 { get; } = "r";

    public static Size ZeroSize { get; } = new Size(0, 0);

    public static Point ZeroPoint { get; } = new Point(0, 0);

    public static string GridColumnPrefix { get; } = "Cc";

    public static string GetGridColumnName(string ColumnName) => $"{GridColumnPrefix}{ColumnName}";

    public static string HeaderAndMessage(string header, string message)
    {
      return header + MessageHeaderSeparator + message;
    }

    public static Tuple<string, string> HeaderAndMessage(string MessageWithHeader)
    {
      string header, message; header = message = string.Empty; int count = 0;
      string[] words = MessageWithHeader.Split(MessageHeaderSeparator);
      foreach (string word in words) if (++count == 1) { header = word; } else { message += word; }
      return Tuple.Create(header, message);
    }

    public static int CheckRange(int Variable, int MinValue, int MaxValue)
    {
      if (MinValue > MaxValue) MinValue = MaxValue;
      if (Variable > MaxValue) Variable = MaxValue;
      if (Variable < MinValue) Variable = MinValue;
      return Variable;
    }

    public static List<string> GetFiles(string directory, string subDirectory, string searchPattern, char separator = ' ')
    {
      List<string> result = new List<string>();
      if (directory.Trim() == string.Empty) directory = Environment.CurrentDirectory;
      string Folder = subDirectory.Trim() == string.Empty ? directory : Path.Combine(directory, subDirectory);
      string[] array = searchPattern.Split(separator);
      if (Directory.Exists(Folder))
        foreach (string item in array)
          foreach (string file in Directory.EnumerateFiles(Folder, item))
            result.Add(file);
      return result;
    }
  }
}
