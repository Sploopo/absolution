using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using AbsolutionCore.Common.Systems;
using FargowiltasSouls;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string tooltip;
            Color[] colors = { new Color(128, 0, 255), new Color(255, 0, 255) };
            Color[] specialColors = { new Color(211, 53, 53), new Color(167, 38, 229) };
            int index = (int)(Main.GameUpdateCount / 60) % 2;
            if (item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("SigilOfChampions").Type) 
            {
                tooltip = "WARNING: This is the wrong version of the Sigil of Champions. Absolution adds a new one.";
            }
            else if (item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("SquirrelCoatofArms").Type && !AbsolutionWorld.UsedSSOTSOTCMG)
            {
                TooltipLine specialLine = new TooltipLine(Mod, "SquirrelCoatTooltip", "The Satanic Scepter of the Sigil of the Corrupted Mutant's Gift burns more intensely while you hold this...");
                specialLine.OverrideColor = Color.Lerp(specialColors[index], specialColors[(index + 1) % 2], (Main.GameUpdateCount % 60) / 60f);
                tooltips.Add(specialLine);
                return;
            }
            else if(item.type == ModContent.ItemType<FargowiltasSouls.Items.Masochist>() || item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.RevengeanceModeItem>()
                || item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.DeathModeItem>() ||
                item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.MaliceModeItem>())
            {
                TooltipLine specialLine = new TooltipLine(Mod, "NoDifficultyChangeTooltip", AbsolutionWorld.UsedSSOTSOTCMG ? "You cannot go back now." : "The item is unusable. It seems to be powering the Satanic Scepter of the Sigil of the Corrupted Mutant's Gift...");
                specialLine.OverrideColor = Color.Lerp(specialColors[index], specialColors[(index + 1) % 2], (Main.GameUpdateCount % 60) / 60f);
                tooltips.Add(specialLine);
                return;
            } else if(item.type == ItemID.ReaverShark && DownedBossSystem.downedHiveMind && DownedBossSystem.downedPerforator)
            {
                tooltip = "Pickaxe power increases to 100% after defeating the Hive Mind or Perforators";
            } else if(item.type == ModContent.ItemType<Content.General.Items.SigilOfChampionsButAwesome>())
            {
                tooltip = "Most Champions are locked behind certain bosses";
            } else if(item.type == ModContent.ItemType<CalamityMod.Items.SummonItems.EidolonTablet>() && DownedBossSystem.downedPlaguebringer)
            {
                tooltip = "Cannot be used before defeating the Plaguebringer Goliath";
            }
            else
            {
                return;
            }

            TooltipLine line = new TooltipLine(Mod, "AbsolutionTooltip", $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] " + tooltip); // DO NOT CHANGE THE NAME OF THIS TOOLTIP
            line.OverrideColor = Color.Lerp(colors[index], colors[(index + 1) % 2], (Main.GameUpdateCount % 60) / 60f);
            tooltips.Add(line);
        }
        public override void SetDefaults(Item item)
        {
            switch(item.type)
            {
                case ItemID.ReaverShark:
                    item.pick = 59;
                    if (DownedBossSystem.downedHiveMind || DownedBossSystem.downedPerforator) item.pick = 100;
                    break;
                case ItemID.SlimeCrown:
                case ItemID.SuspiciousLookingEye:
                case ItemID.WormFood:
                case ItemID.BloodySpine:
                case ItemID.Abeemination:
                case ItemID.DeerThing:
                case ItemID.QueenSlimeCrystal:
                case ItemID.MechanicalEye:
                case ItemID.MechanicalSkull:
                case ItemID.MechanicalWorm:
                case ItemID.LihzahrdPowerCell:
                case ItemID.TruffleWorm:
                case ItemID.CelestialSigil:
                case ItemID.BloodMoonStarter:
                case ItemID.GoblinBattleStandard:
                case ItemID.PirateMap:
                case ItemID.SolarTablet:
                case ItemID.SnowGlobe:
                case ItemID.PumpkinMoonMedallion:
                case ItemID.NaughtyPresent:
                    item.consumable = false;
                    item.maxStack = 9999;
                    break;
                default:
                    break;
            }
        }
        public override bool CanUseItem(Item item, Player player)
        {
            switch(item.type)
            {
                case ItemID.SlimeCrown:
                case ItemID.SuspiciousLookingEye:
                    if (!AbsolutionWorld.DownedTrojanSquirrel) return false;
                    break;
                default:
                    break;
            }
            if (item.type == ModContent.ItemType<FargowiltasSouls.Items.Summons.SquirrelCoatofArms>() && !AbsolutionWorld.UsedSSOTSOTCMG) return false;
            else if ((item.type == ModContent.ItemType<FargowiltasSouls.Items.Masochist>() || item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.RevengeanceModeItem>()
                || item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.DeathModeItem>() ||
                item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.MaliceModeItem>())) return false;
            else if (item.type == ModContent.ItemType<CalamityMod.Items.SummonItems.EidolonTablet>() && DownedBossSystem.downedPlaguebringer) return false;
            return true;
        }

        public override bool? UseItem(Item item, Player player)
        {
            return true;
        }
    }
}
