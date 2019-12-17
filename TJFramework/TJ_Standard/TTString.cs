using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace TJFramework
{
  public static class TJString
  {
    public static NumberFormatInfo Nfi { get; } = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();

    private static Random MyRandom { get; } = new Random();

    public const string Empty = "";

    static TJString()
    {
      Nfi.NumberGroupSeparator = " ";
    }

    public static string FormatNumber(long value) => value.ToString("#,##0", Nfi);

    public static bool IsHexOnly(string StringValue)
    {
      // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
      return Regex.IsMatch(StringValue, @"\A\b[0-9a-fA-F]+\b\Z");
    }

    public static string ReplaceMultipleSpaces(string s) // Убирает несколько идущих подряд пробелов и оставляет только один пробел //
    {
      RegexOptions options = RegexOptions.None; Regex regex = new Regex("[ ]{2,}", options); return regex.Replace(s, " ");
    }

    public static string GetOnlyLetterDigitOrSpace(string str) => new string((from c in str where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c) select c).ToArray());

    public static string RandomString(int length)
    {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzйцукенгшщзхъфывапролджэячсмитьбю";
      return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[MyRandom.Next(s.Length)]).ToArray());
    }

    public static string RandomPhrase(int words)
    {
      string phrase = string.Empty;
      for (int i = 0; i < words; i++)
      {
        phrase += RandomString(MyRandom.Next(MyRandom.Next(MyRandom.Next(1, 7), 8), 12));
        if (i + 1 < words) phrase += " "; else phrase += ".";
      }
      return phrase;
    }
  }
}
