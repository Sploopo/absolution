using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.Clicker;
using AbsolutionCore.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using ClickerClass;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string tooltip;

            if(item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul").Type)
            {
                tooltip = "Provides the Clicker Class with a multitude of buffs (see Force of Technology tooltip for more information)";
            } else if(item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").Type)
            {
                tooltip = "Effects of Gamer Crate, Chocolate Milk n' Cookies and Master Keychain";
            } else
            {
                return;
            }

            TooltipLine line = new TooltipLine(Mod, "AbsolutionTooltip", $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] " + tooltip); // DO NOT CHANGE THE NAME OF THIS TOOLTIP
            line.OverrideColor = new Color(188, 102, 255);
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
            if(item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul").Type)
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
    }
}
