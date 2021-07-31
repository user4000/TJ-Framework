using System.Text;

namespace TJFramework.Extensions
{
  public static class XxEncoding
  {
    public static Encoding ZzGetEncoding(string encoding)
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