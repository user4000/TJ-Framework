﻿using System.IO;
using Newtonsoft.Json;

namespace TJFramework.ApplicationSettings
{
  public class TJStandardUserSettingsLoader<T> where T : TJStandardApplicationSettings
  {
    private const string DefaultTextFileName = TJStandardApplicationSettings.DefaultTextFileName ;

    public static T LoadFromJSONFile(string FileName = DefaultTextFileName)
    {
      T t = default(T);
      using (StreamReader file = File.OpenText(FileName))
      {
        JsonSerializer serializer = new JsonSerializer();
        t = (T)serializer.Deserialize(file, typeof(T));
      }
      return t;
    }
  }
}






