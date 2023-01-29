using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AbsolutionCore.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using AbsolutionCore.Common.Systems;
using AbsolutionCore.Content.Items;
using AbsolutionCore.Content.NPCs.GuardianBoss;
using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace AbsolutionCore
{
	public class AbsolutionCore : Mod
	{
        public override void PostSetupContent()
        {
            
        }

        public override void Load()
        {
            IL.CalamityMod.NPCs.CalamityGlobalNPC.PreAI += DestroyCalamityVanillaBossChanges;
            if (!AbsolutionConfig.Instance.UnboundMode)
            {
                IL.CalamityMod.UI.ModeIndicator.ModeIndicatorUI.GetLockStatus += LockCalamityDifficulties;
                IL.CalamityMod.World.UndergroundShrines.SpecialChest += BreakTerminus;
                IL.CalamityMod.Tiles.Astral.AstralBeacon.RightClick += NoDeusPreCultist;
            }
        }
        
        // il editing
        private static void DestroyCalamityVanillaBossChanges(ILContext il)
        {
            ILCursor mario = new ILCursor(il);
            if (ModLoader.TryGetMod("InfernumMode", out Mod dummy)) return;
            if (mario.TryGotoNext(MoveType.After, x => x.MatchLdsfld("CalamityMod.World.CalamityWorld", "revenge")))
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
            if (mario.TryGotoNext(MoveType.After, x => x.MatchStloc(2)))
            {
                mario.EmitDelegate(FunnyCultist);
            }
        }
        private static void FunnyCultist() // because of emitdelegate shenanigans
        {
            if(!NPC.downedAncientCultist) return;
        }
    }
}