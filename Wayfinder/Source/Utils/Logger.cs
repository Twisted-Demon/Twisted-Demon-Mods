using System.Runtime.InteropServices;

namespace Wayfinder.Utils;

public static class WLog
{
    public static void Out(string format, params object[] args) => Log.Out("[Wayfinder] " + format, args );
    public static void Warning(string format, params object[] args) => Log.Warning("[Wayfinder] " + format, args );
    public static void Error(string format, params object[] args) => Log.Error("[Wayfinder] " + format, args );
    
    public static void Out(string txt) => Log.Out("[Wayfinder] " + txt);
    public static void Warning(string txt) => Log.Warning("[Wayfinder] " + txt);
    public static void Error(string txt) => Log.Error("[Wayfinder] " + txt);
}