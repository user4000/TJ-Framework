using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization.Formatters.Binary;

namespace TJFramework.Tools
{
  public static class TJTool // Auxiliary functions //
  {
    public const string FormatDDMMYYYY = "dd-MM-yyyy HH:mm:ss";

    public const string FormatYYYYMMDD = "yyyy-MM-dd HH:mm:ss";

    public const string Empty = "";

    internal static TJStandardJsonSerializerSetting JsonSerializerSetting { get; } = new TJStandardJsonSerializerSetting();

    public static int Random(int x1, int x2)
    {
      int y1 = new Random().Next(2147040277);
      int y2 = new Random().Next(1115911378);
      return (new Random(((int)((long)DateTime.Now.Millisecond * (701011530150907 - y1)) % (2085017031 - y2))).Next(x1, 1 + x2));
    }

    public static string StringCollectionToString(StringCollection string_collection)
    {
      string f = "";
      for (int i = 0; i < string_collection.Count; i++) { f += string_collection[i]; }
      return f;
    }

    public static string StringLeft(this string value, int string_Length)
    {
      if (string.IsNullOrEmpty(value)) return value;
      string_Length = Math.Abs(string_Length);
      return (value.Length <= string_Length ? value : value.Substring(0, string_Length));
    }

    public static string GetStringBeforeSymbol(string input_string, char symbol)
    {
      string f = "";
      string[] words = input_string.Split(symbol);
      if (words.Length > 0) f = words[0];
      return f;
    }

    public static T DeepClone<T>(T MyObject)
    { // Your class MUST be marked as [Serializable] otherwise it will not work.

      if (!typeof(T).IsSerializable)
      {
        throw new ArgumentException("The type must be serializable.", "source");
      }

      if (Object.ReferenceEquals(MyObject, null))
      {
        return default(T);
      }

      using (var ms = new MemoryStream())
      {
        var formatter = new BinaryFormatter();
        formatter.Serialize(ms, MyObject);
        ms.Position = 0;
        return (T)formatter.Deserialize(ms);
      }
    }

    public static IList<T> CloneList<T>(this IList<T> listToClone) where T : ICloneable
    {
      return listToClone.Select(item => (T)item.Clone()).ToList();
    }

    public static string SerializeObjectToJSON(object MyObject)
    {
      string TryGetObjectType()
      {
        string s1 = ""; string s2 = "";
        try { s1 = MyObject.GetType().ToString(); } catch { }
        try { s2 = MyObject.ToString(); } catch { }
        return $"Error! Could not serialize object {s1} {s2}";
      }
      string json = "null";
      if (MyObject != null)
        try { json = JsonConvert.SerializeObject(MyObject, JsonSerializerSetting.setting); }
        catch { json = TryGetObjectType(); }
      return json;
    }

    public static object DeserializeObjectFromJSON(string json)
    {
      object MyObject = null;
      try { MyObject = JsonConvert.DeserializeObject(json, JsonSerializerSetting.setting); }
      catch { MyObject = null; }
      return MyObject;
    }

    public static void CreateDirectoryForFile(string FileNameWithFolder)
    {
      if (Directory.Exists(Path.GetDirectoryName(FileNameWithFolder)) == false)
        Directory.CreateDirectory(Path.GetDirectoryName(FileNameWithFolder));
    }

    public static int SquareOfDistance(Point a, Point b)
    {
      return ((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
    }
  }
}