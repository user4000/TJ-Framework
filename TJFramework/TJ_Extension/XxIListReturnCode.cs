using System.Collections.Generic;

namespace TJFramework
{
  public static class XxIListReturnCode
  {
    public static TTReturnCode ZZFirst<TTReturnCode>(this IList<TTReturnCode> items) where TTReturnCode : new()
    {
      TTReturnCode code = default(TTReturnCode);
      try { code = items[0]; } catch { }
      return code;
    }
  }
}

