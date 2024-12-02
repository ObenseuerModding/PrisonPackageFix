using HarmonyLib;
using PrisonPackages.Manager;

namespace PrisonPackages.Patches;
public class SpawnerPatches
{
    [HarmonyPatch(typeof(logic_prefab_spawn), nameof(logic_prefab_spawn.Start))]
    [HarmonyPostfix]
    public static void Postfix(logic_prefab_spawn __instance)
    {
        try
        {

            if (__instance == null)
                return;

            Plugin.Log.LogMessage("Doing the thing now");
            PrisonPackageManager.PatchPrisonPackages(prefabs: __instance.prefabsToSpawn);

        }
        catch (System.Exception ex)
        {
            Plugin.Log.LogWarning($"Exception in patch of logic_prefab_spawn:start\n{ex}");
        }
    }

}
