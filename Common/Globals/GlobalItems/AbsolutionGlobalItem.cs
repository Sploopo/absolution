using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.Clicker;
using AbsolutionCore.Content.ThoriumExpansion.Items.Bard;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using ClickerClass;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "ErrorTooltip", "This shouldn't be here! Please tell the devs about what you were doing before you saw this message.");

            if(item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul").Type)
            {
                line = new TooltipLine(Mod, "SoTChangedTooltip", $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] Provides the Clicker Class with a multitude of buffs (see Force of Technology tooltip for more information)");
            } else if(item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").Type)
            {
                line = new TooltipLine(Mod, "SoUChangedTooltip", $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] Effects of Gamer Crate, Chocolate Milk n' Cookies and Master Keychain");
            } else
            {
                return;
            }

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

    public class ModifiedTooltipGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        List<int> ModifiedItems = new List<int>
        {
            ItemID.PDA,
            ItemID.CellPhone,
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").Type,
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul").Type,
        };
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModifiedItems.Contains(entity.type);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "ModifiedRecipe", $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] Recipe modified by Absolution");
            line.OverrideColor = new Color(188, 102, 255);
            tooltips.Add(line);
        }
    }
}
