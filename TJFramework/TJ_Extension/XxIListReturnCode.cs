using System.Collections.Generic;

namespace TJFramework.Extensions
{
  public static class XxIListReturnCode
  {
    public static T ZzFirst<T>(this IList<T> items) where T : new()
    {
      T code = default(T);
      try { code = items[0]; } catch { }
      return code;
    }
  }
}