using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.Clicker;
using AbsolutionCore.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using ClickerClass;
using FargowiltasSouls;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string tooltip;
            Color[] colors = { new Color(128, 0, 255), new Color(255, 0, 255) };
            Color[] specialColors = { new Color(211, 53, 53), new Color(130, 57, 125) };
            int index = (int)(Main.GameUpdateCount / 60) % 2;

            if (item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul").Type)
            {
                tooltip = "Provides the Clicker Class with a multitude of buffs (see Force of Technology tooltip for more information)";
            }
            else if (item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").Type)
            {
                tooltip = "Effects of Gamer Crate, Chocolate Milk n' Cookies and Master Keychain";
            }
            else if (item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("SigilOfChampions").Type) 
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
            else if((item.type == ModContent.ItemType<FargowiltasSouls.Items.Masochist>() || item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.RevengeanceModeItem>()
                || item.type == ModContent.ItemType<FargowiltasSouls.Items.MasochistReal>() || item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.DeathModeItem>() ||
                item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.MaliceModeItem>()) && AbsolutionWorld.UsedSSOTSOTCMG)
            {
                TooltipLine specialLine = new TooltipLine(Mod, "NoDifficultyChangeTooltip", "You cannot go back now.");
                specialLine.OverrideColor = Color.Lerp(specialColors[index], specialColors[(index + 1) % 2], (Main.GameUpdateCount % 60) / 60f);
                tooltips.Add(specialLine);
                return;
            }
            else
            {
                return;
            }

            TooltipLine line = new TooltipLine(Mod, "AbsolutionTooltip", $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] " + tooltip); // DO NOT CHANGE THE NAME OF THIS TOOLTIP
            line.OverrideColor = Color.Lerp(colors[index], colors[(index + 1) % 2], (Main.GameUpdateCount % 60) / 60f);
            tooltips.Add(line);
        }
        public override void UpdateInventory(Item item, Player player)
        {
            base.UpdateInventory(item, player);

            if(item.type == ItemID.CellPhone || item.type == ItemID.PDA)
            {
                ClickerCompat.SetAccessory(player, "ButtonMasher");
            }
        }
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            base.UpdateAccessory(item, player, hideVisual);
            if(item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul").Type || item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("EternitySoul").Type)
            {
                ClickerPlayer clickerPlayer = player.GetModPlayer<ClickerPlayer>();
                clickerPlayer.setMice = true;
                clickerPlayer.clickerBonusPercent -= 0.10f;
                clickerPlayer.setRGB = true;
                ClickerCompat.SetAccessoryItem(player, "SMedal", item);
                clickerPlayer.setPrecursor = true;
                ClickerCompat.SetAccessory(player, "RegalClickingGlove");
                clickerPlayer.EnableClickEffect(ClickEffect.BigRedButton);
                clickerPlayer.setMotherboard = true;
                clickerPlayer.setOverclock = true;
                ClickerCompat.SetAccessoryItem(player, "BottomlessBoxOfPaperclips", item);
            } else if(item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").Type)
            {
                ClickerPlayer clickerPlayer = player.GetModPlayer<ClickerPlayer>();
                clickerPlayer.EnableClickEffect("ClickerClass:ChocolateChip");
                clickerPlayer.accGlassOfMilk = true;
                clickerPlayer.accCookie2 = true;
                clickerPlayer.accCookieItem = item;
                clickerPlayer.accHandCream = true;
                clickerPlayer.accEnchantedLED2 = true;
                clickerPlayer.accHotKeychain = true;
                clickerPlayer.EnableClickEffect(ClickEffect.ClearKeychain);
                clickerPlayer.EnableClickEffect(ClickEffect.StickyKeychain);
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
                || item.type == ModContent.ItemType<FargowiltasSouls.Items.MasochistReal>() || item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.DeathModeItem>() ||
                item.type == ModContent.ItemType<CalamityMod.Items.DifficultyItems.MaliceModeItem>()) && AbsolutionWorld.UsedSSOTSOTCMG) return false;
            return true;
        }

        public override bool? UseItem(Item item, Player player)
        {
            return true;
        }
    }
}
