using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace MewsTextReplacements
{
    [BepInPlugin(MOD_ID, MOD_NAME, MOD_VERSION)]
    public class Main : BasePlugin
    {
        public const string MOD_NAME = "Mew's Text Replacements";
        public const string MOD_ID = "MewsTextReplacements";
        public const string MOD_VERSION = "1.0.0";

        public static string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FailedTexts.txt");

        public static BepInEx.Logging.ManualLogSource Logger;
        public override void Load()
        {
            Logger = Log;
            Harmony.CreateAndPatchAll(typeof(Patches));
            if (!File.Exists(FilePath)) File.Create(FilePath).Close();
            
            Patches.failedTexts = new List<string>();
            using (var reader = new StreamReader(File.OpenRead(FilePath)))
            {
                while (!reader.EndOfStream)
                {
                    Patches.failedTexts.Add(reader.ReadLine());
                }
            }

            Logger.LogMessage($"Loaded {Patches.failedTexts.Count} custom failed text strings");
        }

        class Patches
        {
            static System.Random random;
            static string failedText;
            public static List<string> failedTexts;

            [HarmonyPostfix]
            [HarmonyPatch(typeof(TextMeshProUGUI), nameof(TextMeshProUGUI.Awake))]
            public static void AwakePost(TextMeshProUGUI __instance)
            {
                if (__instance.text == null || string.IsNullOrEmpty(failedText)) return;
                if (__instance.name.ToLower().Contains("failed")) __instance.text = failedText;
            }

            [HarmonyPrefix]
            [HarmonyPatch(typeof(TMP_Text), "set_text")]
            private static bool set_textPrefix(ref string value, TMP_Text __instance)
            {
                if (value == null || __instance.text == null || string.IsNullOrEmpty(failedText)) return true;
                if (__instance.name.ToLower().Contains("failed"))
                {
                    //Logger.LogMessage(__instance.name + " ; " + __instance.text + " ; " + value);
                    value = failedText;
                }
                return true;
            }

            [HarmonyPostfix]
            [HarmonyPatch(typeof(Track), nameof(Track.FailSong))]
            public static void FailSongPostfix()
            {
                if (failedTexts.Count == 0) return;
                //Logger.LogMessage("Failed the song");
                if (random == null) random = new System.Random();
                failedText = failedTexts[random.Next(failedTexts.Count)];
            }
        }
    }
}
