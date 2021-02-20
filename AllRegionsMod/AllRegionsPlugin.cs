using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;
using AllRegionsMod.RegionsPlugin;

namespace AllRegionsMod
{
    [BepInPlugin(Id, Name, Version)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    [ReactorPluginSide(PluginSide.ClientOnly)]
    public class UnifyPlugin : BasePlugin
    {
        public const string Id = "reactor.AllRegionsMod";
        private const string Name = "All Regions Mod";
        private const string Version = "1.0.0";

        public Harmony Harmony { get; } = new Harmony(Id);

        public override void Load()
        {
            RegionsPatch.Patch();

            Harmony.PatchAll();
        }
        [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
        public static class VersionPatch
        {
            public static void Postfix(VersionShower __instance)
            {
                __instance.text.Text += "\n\n\n\n\n\n\n Modded by [2E64FEFF]Netika#9523";
                __instance.text.Text += "\n\n\n\n\n\n\n\n DM me in Discord for mod ideas";
            }
            [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
            public static class PingPatch
            {
                public static void Postfix(PingTracker __instance)
                {
                    __instance.text.Text += "\n Modded by [2E64FEFF]Netika#9523";
                    __instance.text.Text += "\n\n current regions = [2EFE2EFF]2";
                }
            }
        }
    }
}
