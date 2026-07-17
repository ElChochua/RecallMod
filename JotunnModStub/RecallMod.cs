using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace RecallMod
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class RecallMod : BaseUnityPlugin
    {
        public const string PluginGUID = "chochua.RecallMod";
        public const string PluginName = "RecallMod";
        public const string PluginVersion = "1.1.0";
        private AssetBundle _recallBundle;
        private GameObject _recallPrefab;
        // Use this class to add your own localization to the game
        // https://valheim-modding.github.io/Jotunn/tutorials/localization.html
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        private void Awake()
        {
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("RecallMod has landed");
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(", ", typeof(RecallMod).Assembly.GetManifestResourceNames())}");
            AssetBundle bundle = AssetUtils.LoadAssetBundleFromResources("recallitem");
            RecallItemContent.Register(bundle);
            RecallHud.Init();
            // To learn more about Jotunn's features, go to
            // https://valheim-modding.github.io/Jotunn/tutorials/overview.html
        }

    }
}