﻿using System.Text;

namespace TJFramework
{
  public static class XxEncoding
  {
    public static Encoding GetEncoding(string encoding)
    {
      Encoding enc = null;
      try
      {
        enc = Encoding.GetEncoding(encoding);
      }
      catch
      {
        enc = Encoding.GetEncoding("CP866");
      }
      return enc;
    }
  }
}
