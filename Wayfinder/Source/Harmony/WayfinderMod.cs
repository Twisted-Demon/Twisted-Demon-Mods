using System.Reflection;
using Quartz.Settings;
using Wayfinder.Utils;

namespace Wayfinder.Harmony;

public class WayfinderMod : IModApi
{
    public void InitMod(Mod modInstance)
    {
        WLog.Out("Patching Code");
        
        var harmony = new HarmonyLib.Harmony(GetType().ToString());
        harmony.PatchAll(Assembly.GetExecutingAssembly());
        
        
    }
}