using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using GameState;
using Player.Archetypes;
using Player.Items.Scabbard;
using Player.Items.Shield;
using Player.Items.Sword;
using Player.Items;
using MyTrueGear;
using UnityEngine;
using Menu.Candle;

namespace BrokenEdge_TrueGear
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        internal static new ManualLogSource Log;

        private static TrueGearMod _TrueGear = null;
        private static int itemNumber = -1;

        public override void Load()
        {
            // Plugin startup logic
            Log = base.Log;
            HarmonyLib.Harmony.CreateAndPatchAll(typeof(Plugin));
            _TrueGear = new TrueGearMod();
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }

        [HarmonyPostfix, HarmonyPatch(typeof(SwordController), "OnFinalBodyHit")]
        private static void SwordController_OnFinalBodyHit_Postfix(SwordController __instance, BodyHitEvent hitEvent)
        {
            if (__instance.Archetype.IsLocal)
            {
                //if (__instance.InAwakenedState)
                if (__instance.ItemNumber == itemNumber)
                {
                    Log.LogInfo("--------------------------------------------");
                    if (__instance.IsHeldWithTwoHands)
                    {
                        Log.LogInfo("TwoHandSwordHitBody");
                        _TrueGear.Play("LeftHandMeleeBombHit");
                        _TrueGear.Play("RightHandMeleeBombHit");
                    }
                    else if (__instance.State == ItemBase.ItemState.InLeftHand)
                    {
                        Log.LogInfo("LeftSwordHitBody");
                        _TrueGear.Play("LeftHandMeleeBombHit");
                    }
                    else if (__instance.State == ItemBase.ItemState.InRightHand)
                    {
                        Log.LogInfo("RightSwordHitBody");
                        _TrueGear.Play("RightHandMeleeBombHit");
                    }
                    Log.LogInfo(__instance.ItemNumber);
                }
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(SwordController), "OnFinalScabbardHit")]
        private static void SwordController_OnFinalScabbardHit_Postfix(SwordController __instance)
        {
            if (__instance.Archetype.IsLocal)
            {
                //if (__instance.InAwakenedState)
                if (__instance.ItemNumber == itemNumber)
                {
                    if (__instance.IsHeldWithTwoHands)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("TwoHandSwordHitScabbard");
                        _TrueGear.Play("LeftHandMeleeHit");
                        _TrueGear.Play("RightHandMeleeHit");
                    }
                    else if (__instance.State == ItemBase.ItemState.InLeftHand)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("LeftSwordHitScabbard");
                        _TrueGear.Play("LeftHandMeleeHit");
                    }
                    else if (__instance.State == ItemBase.ItemState.InRightHand)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("RightSwordHitScabbard");
                        _TrueGear.Play("RightHandMeleeHit");
                    }
                    Log.LogInfo(__instance.ItemNumber);
                }
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(SwordController), "OnFinalShieldHit")]
        private static void SwordController_OnFinalShieldHit_Postfix(SwordController __instance, ShieldHitEvent shieldHitEvent)
        {
            if (__instance.Archetype.IsLocal)
            {
                //if (__instance.InAwakenedState)
                if (__instance.ItemNumber == itemNumber)
                {
                    if (__instance.IsHeldWithTwoHands)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("TwoHandSwordHitShield");
                        _TrueGear.Play("LeftHandMeleeHit");
                        _TrueGear.Play("RightHandMeleeHit");
                    }
                    else if (__instance.State == ItemBase.ItemState.InLeftHand)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("LeftSwordHitShield");
                        _TrueGear.Play("LeftHandMeleeHit");
                    }
                    else if (__instance.State == ItemBase.ItemState.InRightHand)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("RightSwordHitShield");
                        _TrueGear.Play("RightHandMeleeHit");
                    }
                    Log.LogInfo(__instance.ItemNumber);
                }
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(SwordController), "OnFinalSwordHit")]
        private static void SwordController_OnFinalSwordHit_Postfix(SwordController __instance)
        {
            if (__instance.Archetype.IsLocal)
            {
                //if (__instance.InAwakenedState)
                if (__instance.ItemNumber == itemNumber)
                {
                    if (__instance.IsHeldWithTwoHands)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("TwoHandSwordHitSword");
                        _TrueGear.Play("LeftHandMeleeHit");
                        _TrueGear.Play("RightHandMeleeHit");
                    }
                    else if (__instance.State == ItemBase.ItemState.InLeftHand)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("LeftSwordHitSword");
                        _TrueGear.Play("LeftHandMeleeHit");
                    }
                    else if (__instance.State == ItemBase.ItemState.InRightHand)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("RightSwordHitSword");
                        _TrueGear.Play("RightHandMeleeHit");
                    }
                    Log.LogInfo(__instance.ItemNumber);
                }
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(SwordController), "Break")]
        private static void SwordController_Break_Postfix(SwordController __instance)
        {
            if (__instance.Archetype.IsLocal)
            {
                if (__instance.IsHeldWithTwoHands)
                {
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo("TwoHandSwordBreak");
                    _TrueGear.Play("LeftHandMeleeBadHit");
                    _TrueGear.Play("RightHandMeleeBadHit");
                }
                else if (__instance.State == ItemBase.ItemState.InLeftHand)
                {
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo("LeftSwordBreak");
                    _TrueGear.Play("LeftHandMeleeBadHit");
                }
                else if (__instance.State == ItemBase.ItemState.InRightHand)
                {
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo("RightSwordBreak");
                    _TrueGear.Play("RightHandMeleeBadHit");
                }
            }
        }




        [HarmonyPostfix, HarmonyPatch(typeof(ScabbardController), "OnFinalBodyHit")]
        private static void ScabbardController_OnFinalBodyHit_Postfix(ScabbardController __instance)
        {
            if (__instance.Archetype.IsLocal)
            {
                if (!__instance.AssociatedSword.InAwakenedState)
                {
                    if (__instance.State == ItemBase.ItemState.InLeftHand)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("LeftScabbardHit");
                        _TrueGear.Play("LeftHandMeleeBombHit");
                    }
                    else if (__instance.State == ItemBase.ItemState.InRightHand)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("RightScabbardHit");
                        _TrueGear.Play("RightHandMeleeBombHit");
                    }
                }
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(ScabbardController), "OnFinalSwordHit")]
        private static void ScabbardController_OnFinalSwordHit_Postfix(ScabbardController __instance)
        {
            if (__instance.Archetype.IsLocal)
            {

                if (!__instance.AssociatedSword.InAwakenedState)
                {
                    if (__instance.State == ItemBase.ItemState.InLeftHand)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("LeftScabbardHit");
                        _TrueGear.Play("LeftHandMeleeHit");
                    }
                    else if (__instance.State == ItemBase.ItemState.InRightHand)
                    {
                        Log.LogInfo("--------------------------------------------");
                        Log.LogInfo("RightScabbardHit");
                        _TrueGear.Play("RightHandMeleeHit");
                    }
                }
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(ScabbardController), "Break")]
        private static void ScabbardController_Break_Postfix(ScabbardController __instance)
        {
            if (__instance.Archetype.IsLocal)
            {

                if (__instance.State == ItemBase.ItemState.InLeftHand)
                {
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo("LeftScabbardBreak");
                    _TrueGear.Play("LeftHandMeleeBadHit");
                }
                else if (__instance.State == ItemBase.ItemState.InRightHand)
                {
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo("RightScabbardBreak");
                    _TrueGear.Play("RightHandMeleeBadHit");
                }
            }
        }



        [HarmonyPostfix, HarmonyPatch(typeof(ShieldController), "OnFinalShieldHit")]
        private static void ShieldController_OnFinalShieldHit_Postfix(ShieldController __instance)
        {
            if (__instance.Archetype.IsLocal)
            {

                if (__instance.State == ItemBase.ItemState.InLeftHand)
                {
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo("LeftShieldHit");
                    _TrueGear.Play("LeftHandMeleeHit");
                    //StopRightSwordHitShield
                }
                else if (__instance.State == ItemBase.ItemState.InRightHand)
                {
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo("RightShieldHit");
                    _TrueGear.Play("RightHandMeleeHit");
                    //StopLeftSwordHitShield
                }

            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(ShieldController), "DisableShield")]
        private static void ShieldController_DisableShield_Postfix(ShieldController __instance)
        {
            if (__instance.Archetype.IsLocal)
            {

                if (__instance.State == ItemBase.ItemState.InLeftHand)
                {
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo("LeftShieldBroken");
                    _TrueGear.Play("LeftHandMeleeBadHit");
                }
                else if (__instance.State == ItemBase.ItemState.InRightHand)
                {
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo("RightShieldBroken");
                    _TrueGear.Play("RightHandMeleeBadHit");
                }
            }
        }


        [HarmonyPostfix, HarmonyPatch(typeof(Archetype), "OnBroken")]
        private static void Archetype_OnBroken_Postfix(Archetype __instance, int playerNumber)
        {
            if (__instance.IsLocal)
            {
                if (playerNumber == __instance.PlayerNumber)
                {
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo("PlayerNoneWeaponBlood");
                    Log.LogInfo("StartHeartBeat");
                    _TrueGear.Play("DefaultDamage");
                    _TrueGear.StartHeartBeat();
                }
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(Archetype), "OnGameEnd")]
        private static void Archetype_OnGameEnd_Postfix(Archetype __instance)
        {
            if (__instance.IsLocal)
            {
                Log.LogInfo("--------------------------------------------");
                Log.LogInfo("StopHeartBeat");
                _TrueGear.StopHeartBeat();
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(Archetype), "OnRoundStart")]
        private static void Archetype_OnRoundStart_Postfix(Archetype __instance)
        {
            if (__instance.IsLocal)
            {
                Log.LogInfo("--------------------------------------------");
                Log.LogInfo("StopHeartBeat");
                _TrueGear.StopHeartBeat();
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(Archetype), "OnFinalBodyHit")]
        private static void Archetype_OnFinalBodyHit_Postfix(Archetype __instance, BodyHitEvent bodyHitEvent)
        {
            if (__instance.IsLocal)
            {
                if (__instance.IsDead)
                {
                    var hitInfo = bodyHitEvent.Body.ColliderName;
                    hitInfo = hitInfo.Replace("Collider_", "");
                    Log.LogInfo("--------------------------------------------");
                    Log.LogInfo($"{hitInfo}Damage");
                    Log.LogInfo("StopHeartBeat");
                    _TrueGear.StopHeartBeat();
                    _TrueGear.Play("PlayerDeath");
                }
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(SwordController), "OnCollisionEnter")]
        private static void SwordController_OnCollisionEnter_Postfix(SwordController __instance, Collision collision)
        {
            if (__instance.Archetype.IsLocal)
            {
                itemNumber = __instance.ItemNumber;
            }
        }

        [HarmonyPostfix, HarmonyPatch(typeof(CandleBase), "Cut")]
        private static void CandleBase_Cut_Postfix(CandleBase __instance)
        {
            Log.LogInfo("--------------------------------------------");
            Log.LogInfo("CandleCut");
            _TrueGear.Play("CandleCut");
        }

        [HarmonyPostfix, HarmonyPatch(typeof(ItemBase), "GetGrabAnimationClip")]
        private static void ItemBase_GetGrabAnimationClip_Postfix(ItemBase __instance)
        {
            if (__instance == null)
            {
                return;
            }
            if (__instance.CurrentHand.IsLeftHand)
            {
                Log.LogInfo("--------------------------------------------");
                Log.LogInfo("LeftHandPickupItem");
                _TrueGear.Play("LeftHandPickupItem");
            }
            else
            {
                Log.LogInfo("--------------------------------------------");
                Log.LogInfo("RightHandPickupItem");
                _TrueGear.Play("RightHandPickupItem");
            }

        }

    }
}
