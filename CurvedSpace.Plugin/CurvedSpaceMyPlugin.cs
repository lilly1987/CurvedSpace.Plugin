using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurvedSpace.Plugin
{
    internal static class PluginInfo
    {
        public const string PLUGIN_GUID = "CurvedSpace.Plugin";
        public const string PLUGIN_NAME = "CurvedSpace plugin";
        public const string PLUGIN_VERSION = "1.0.0";
    }

    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class CurvedSpaceMyPlugin : BasePlugin
    {
        public Harmony harmony = null;
        public static ManualLogSource logger;

        public override void Load()
        {
            logger = Log;
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            harmony = Harmony.CreateAndPatchAll(typeof(CurvedSpaceMyPlugin));
        }

        public override bool Unload()
        {
            harmony?.UnpatchSelf();
            return base.Unload();
        }

        /// <summary>
        /// 패치할경우 데미지가 전부 0으로 바껴버림
        /// </summary>
        /// <param name="__instance"></param>
        /// <param name="damage"></param>
        /// <param name="damageType"></param>
        // public unsafe bool ReduceHealth(ref float damage, DamageType damageType)
        //[HarmonyPrefix, HarmonyPatch(typeof(Health), "ReduceHealth")]        
        public static void ReduceHealthPre(Health __instance, ref float damage, DamageType damageType)
        {
            //logger.LogInfo($"Health.ReduceHealth : {__instance.IsPlayer()} , {damage} , {damageType}");
            //if (__instance.IsPlayer())
            //{
            //    damage = 0;
            //}
        }
        
        /// <summary>
        /// 패치할경우 데미지가 전부 0으로 바껴버림
        /// </summary>
        /// <param name="__instance"></param>
        /// <param name="damage"></param>
        /// <param name="damageType"></param>
        // public unsafe bool ReduceHealth(ref float damage, DamageType damageType)
        //[HarmonyPostfix, HarmonyPatch(typeof(Health), "ReduceHealth")]        
        public static void ReduceHealthPost(Health __instance, ref float damage, DamageType damageType)
        {
           // logger.LogInfo($"Health.ReduceHealth : {__instance.IsPlayer()} , {damage} , {damageType}");
            //if (__instance.IsPlayer())
            //{
            //    damage = 0;
            //}
        }        
        /*

        /// <summary>
        /// fail
        /// </summary>
        /// <param name="__result"></param>
        //[HarmonyPrefix, HarmonyPatch(typeof(PlayerCS), "_health",MethodType.Setter)]        
        public static void _health(Health __result)
        {
            logger.LogInfo($"PlayerCS.Health.IsPlayer : {__result.IsPlayer()}");
            logger.LogInfo($"PlayerCS.Health.IsMaxHealth : {__result.IsMaxHealth()}");
        }

        /// <summary>
        /// fail
        /// </summary>
        /// <param name="value"></param>
        //[HarmonyPrefix, HarmonyPatch(typeof(PlayerCS), "_health",MethodType.Setter)]        
        public static void _health2(Health value)
        {
            logger.LogInfo($"PlayerCS.Health.IsPlayer : {value.IsPlayer()}");
            logger.LogInfo($"PlayerCS.Health.IsMaxHealth : {value.IsMaxHealth()}");
        }

        public static PlayerCS playerCS;  
        public static Health health;

        //[HarmonyPostfix, HarmonyPatch(typeof(PlayerCS),MethodType.Constructor)]        
        public static void PlayerCS(PlayerCS __instance)
        {
            logger.LogInfo($"PlayerCS");
            playerCS = __instance;
            //logger.LogInfo($"PlayerCS.Health.IsPlayer : {__instance._health.IsPlayer()}");
            //logger.LogInfo($"PlayerCS.Health.IsMaxHealth : {__instance._health.IsMaxHealth()}");
        }
        

        //[HarmonyPostfix, HarmonyPatch(typeof(Health),MethodType.Constructor)]        
        public static void Health(Health __instance)
        {
            logger.LogInfo($"Health");
            health = __instance;
            //logger.LogInfo($"PlayerCS.Health.IsPlayer : {__instance._health.IsPlayer()}");
            //logger.LogInfo($"PlayerCS.Health.IsMaxHealth : {__instance._health.IsMaxHealth()}");
        }
           */

     

    }
}
