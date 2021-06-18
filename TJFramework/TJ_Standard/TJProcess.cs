using System.Text;
using System.Diagnostics;
using TJFramework.Extensions;

namespace TJFramework.Standard
{
  public class TJProcess
  {
    public static string Execute(string command, string parameter, string encoding = "CP866")
    {
      string parameters = parameter;
      string output = string.Empty;
      string error = string.Empty;

      Encoding enc = XxEncoding.ZzGetEncoding(encoding);

      ProcessStartInfo psi = new ProcessStartInfo(command, parameters)
      {
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true,
        WindowStyle = ProcessWindowStyle.Normal,
        StandardOutputEncoding = enc
      };

      Process process = Process.Start(psi);

      using (System.IO.StreamReader myOutput = process.StandardOutput)
      {
        output = myOutput.ReadToEnd();
      }

      using (System.IO.StreamReader myError = process.StandardError)
      {
        error = myError.ReadToEnd();
      }

      output = output + " " + error;

      return output;    
    }
  }
}
