using System;
using System.Reflection;
using System.Runtime;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AbsolutionCore.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using Redemption;
using AbsolutionCore.Common.Systems;
using AbsolutionCore.Content.Items;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour.HookGen;

namespace AbsolutionCore
{
	public class AbsolutionCore : Mod
	{
        private static MethodInfo CragBullshit = null;
        public override void PostSetupContent()
        {
            
        }

        public override void Load()
        {
            IL.CalamityMod.NPCs.CalamityGlobalNPC.PreAI += DestroyCalamityVanillaBossChanges;
            IL.CalamityMod.World.DraedonStructures.PlaceHellLab += BenShapiroLab;
            if (!AbsolutionConfig.Instance.UnboundMode)
            {
                IL.CalamityMod.UI.ModeIndicator.ModeIndicatorUI.GetLockStatus += LockCalamityDifficulties;
                IL.CalamityMod.World.UndergroundShrines.SpecialChest += BreakTerminus;
                IL.CalamityMod.Tiles.Astral.AstralBeacon.RightClick += NoDeusPreCultist;
            }

            Type VIDEOJAMES = null;
            Assembly cal = ModLoader.GetMod("CalamityMod").GetType().Assembly;
            foreach(Type t in cal.GetTypes()) { if(t.Name == "BrimstoneCrag") VIDEOJAMES = t; }
            if (VIDEOJAMES != null) CragBullshit = VIDEOJAMES.GetMethod("GenCrags", BindingFlags.Static | BindingFlags.NonPublic);
            if(CragBullshit != null) SuperCraggingHouse += LiberalsBeLikeBrimstoneCrag;
        }

        // il editing
        private static void DestroyCalamityVanillaBossChanges(ILContext il)
        {
            ILCursor mario = new ILCursor(il);
            if (ModLoader.TryGetMod("InfernumMode", out Mod dummy)) return;
            mario.TryGotoNext(MoveType.After, x => x.MatchLdsfld("CalamityMod.World.CalamityWorld", "revenge"));
            if (mario.TryGotoNext(MoveType.After, x => x.MatchLdsfld("CalamityMod.World.CalamityWorld", "revenge"))) // do this twice to get to the second one
            {
                mario.Emit(OpCodes.Pop);
                mario.Emit(OpCodes.Ldc_I4_0);
            }
        }

        private static void LockCalamityDifficulties(ILContext il)
        {
            ILCursor mario = new ILCursor(il);
            if (mario.TryGotoNext(MoveType.After, x => x.MatchLdcI4(0)))
            {
                mario.Emit(OpCodes.Pop);
                mario.Emit(OpCodes.Ldc_I4_1);
            }
            if(mario.TryGotoNext(MoveType.After, x => x.MatchLdstr("[c/919191:Click to select a difficulty mode]")))
            {
                mario.Emit(OpCodes.Pop);
                string ga = ModLoader.TryGetMod("InfernumMode", out Mod dummy) ? $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] [c/919191:Difficulty locked to Infernum Mode]" : $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] [c/919191:Difficulty locked to Death Mode]";
                mario.Emit(OpCodes.Ldstr, ga);
            }
        }
        private static void BreakTerminus(ILContext il)
        {
            ILCursor mario = new ILCursor(il);
            if (mario.TryGotoNext(MoveType.After, x => x.MatchCall(typeof(ModContent).GetMethod("ItemType").MakeGenericMethod(typeof(CalamityMod.Items.SummonItems.Terminus)))))
            {
                mario.Emit(OpCodes.Pop);
                mario.EmitDelegate(ModContent.ItemType<BrokenTerminus>);
            }
        }
        private static void NoDeusPreCultist(ILContext il)
        {
            ILCursor mario = new ILCursor(il);
            if (mario.TryGotoNext(MoveType.After, x => x.MatchStloc(0)))
            {
                mario.EmitDelegate(FunnyCultist);
            }
        }
        private static void LiberalsBeLikeBrimstoneCrag(ILContext il)
        {
            ILCursor mario = new ILCursor(il);
            if (mario.TryGotoNext(MoveType.After, x => x.MatchLdsfld("Terraria.WorldGen", "dungeonX")))
            {
                mario.Emit(OpCodes.Pop);
                mario.Emit(OpCodes.Ldc_I4_7);
            }
        }
        private static void BenShapiroLab(ILContext il)
        {
            ILCursor mario = new ILCursor(il);
            if (mario.TryGotoNext(MoveType.After, x => x.MatchLdsfld("Terraria.Main", "dungeonX")))
            {
                mario.Emit(OpCodes.Pop);
                mario.Emit(OpCodes.Ldc_I4_0);
            }
        }
        
        private static event ILContext.Manipulator SuperCraggingHouse
        {
            add
            {
                HookEndpointManager.Modify(CragBullshit, value);
            }
            remove
            {
                HookEndpointManager.Unmodify(CragBullshit, value);
            }
        }
        private static void FunnyCultist() { if (!NPC.downedAncientCultist) return; }
        private static void Return() { return; }
    }
}