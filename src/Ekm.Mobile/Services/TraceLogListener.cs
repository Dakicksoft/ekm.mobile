using System.Diagnostics;
using Xamarin.Forms.Internals;

namespace Ekm.Mobile.Services
{
  public class TraceLogListener : LogListener
  {
    public override void Warning(string category, string message) =>
        Trace.WriteLine($"  {category}: {message}");
  }
}