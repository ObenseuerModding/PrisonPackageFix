using GreenMushLib.Prefabs;
using UnityEngine;

namespace PrisonPackages.Manager;

public static class PrisonPackageManager
{
    public static void PatchPrisonPackages(GameObject[] prefabs)
    {
        var CanOpener = PrefabsManager.GetCollectablePrefabByName("Can opener");

        if (CanOpener == null)
        {
            Plugin.Log.LogError("Unable to locate Can Opener prefab, aborting");
            return;
        }

        if (prefabs.Length == 0)
            return;

        foreach (var item in prefabs)
        {

            bool AddToThisSet = true;

            foreach (Transform child in item.transform)
            {
                if (child.gameObject.name.ToLowerInvariant().Contains("can opener"))
                {
                    Plugin.Log.LogInfo($"Skipping set: {item.name}");
                    AddToThisSet = false;
                    break;
                }
            }

            if (!AddToThisSet)
                continue;

            //We've made it this far so add the can opener to the prefab list
            GameObject opener = GameObject.Instantiate(CanOpener);

            opener.transform.SetParent(item.transform);
            opener.transform.localPosition = new Vector3(0.2688f, 0.0011f, 0.0007f);
            opener.transform.localEulerAngles = new Vector3(0f, 173.4028f, 0f);

            Plugin.Log.LogInfo($"Adding can opener to set: {item.name}");
        }
    }
}
