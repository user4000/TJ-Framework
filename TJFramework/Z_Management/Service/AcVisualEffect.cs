using System;
using System.Windows.Forms;

namespace TJFramework
{
  public partial class TJService
  {
    internal void VisualEffectFadeIn()
    {
      if (!TJFrameworkManager.FrameworkSettings.VisualEffectOnStart) return;
      int duration = 200; // in milliseconds
      int steps = 20;
      Timer timer = new Timer() { Interval = duration / steps };
      int currentStep = 0;
      timer.Tick += (arg1, arg2) =>
      {
        MainForm.Opacity = ((double)currentStep) / steps;
        currentStep++;

        if (currentStep >= steps)
        {
          timer.Stop();
          timer.Dispose();
          MainForm.Opacity = 1;          
        }
      };
      timer.Start();
    }

    internal void VisualEffectFadeOut()
    {
      if (!TJFrameworkManager.FrameworkSettings.VisualEffectOnExit) return;

      int duration = 250; // milliseconds //
      int steps = 25;

      if (MainFormIsBeingDisappeared) return;
      MainFormIsBeingDisappeared = true;


      Timer timer = new Timer() { Interval = duration / steps };

      int currentStep = 0;

      timer.Tick += (arg1, arg2) =>
      {
        MainForm.Opacity = 1 - ((double)currentStep) / steps;

        currentStep++;
        if (currentStep > steps / 2) { currentStep++; };
        if (currentStep > 3 * steps / 4) { currentStep++; currentStep++; };

        if (currentStep >= steps)
        {
          timer.Stop();
          timer.Dispose();
        }
      };

      timer.Start();
    }
  }
}
