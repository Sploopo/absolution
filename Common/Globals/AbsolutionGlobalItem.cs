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
            int index = (int)(Main.GameUpdateCount / 60) % 2;
            if (item.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("SigilOfChampions").Type)
            {
                tooltip = "WARNING: This is the wrong version of the Sigil of Champions. Absolution adds a new one.";
            }
            else if (item.type == ModContent.ItemType<FargowiltasSouls.Items.Masochist>())
            {
                tooltip = "Cannot be used, Eternity Mode is automatically enabled. Ignore the message about not using with other modded difficulties.";
            }
            else if (item.type == ModContent.ItemType<CalamityMod.Items.PermanentBoosters.CelestialOnion>() && !AbsolutionConfig.Instance.UnboundMode)
            {
                tooltip = "Cannot be used, Mutant's Pact should be used instead";
            }
            else if (item.type == ItemID.ReaverShark && DownedBossSystem.downedHiveMind && DownedBossSystem.downedPerforator && !AbsolutionConfig.Instance.UnboundMode)
            {
                tooltip = "Pickaxe power increases to 100% after defeating the Hive Mind or Perforators";
            }
            else if (item.type == ModContent.ItemType<Content.Items.SigilOfChampionsButAwesome>())
            {
                tooltip = "Most Champions are locked behind certain bosses";
            }
            else if (item.type == ModContent.ItemType<CalamityMod.Items.SummonItems.EidolonTablet>() && DownedBossSystem.downedPlaguebringer)
            {
                tooltip = "Cannot be used before defeating the Plaguebringer Goliath";
            }
            else if (item.type == ModContent.ItemType<CalamityMod.Items.Materials.TitanHeart>() && !NPC.downedAncientCultist && !AbsolutionConfig.Instance.UnboundMode)
            {
                tooltip = "Cannot summon Astrum Deus before the Lunatic Cultist is defeated";
            }
            else if (item.type == ModContent.ItemType<CalamityMod.Items.SummonItems.Terminus>())
            {
                tooltip = "Absolution currently does not edit the Boss Rush. Support will come in a future update. ";
            }
            else if ((item.type == ModContent.ItemType<Redemption.Items.Usable.Summons.HeartOfThorns>() || item.type == ModContent.ItemType<Redemption.Items.Usable.Summons.DemonScroll>()) && !AbsolutionWorld.DownedTrojanSquirrel && !AbsolutionConfig.Instance.UnboundMode)
            {
                tooltip = "You're not sure how to use this item yet...";
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
                    if(!AbsolutionConfig.Instance.UnboundMode) item.pick = 59;
                    if (DownedBossSystem.downedHiveMind || DownedBossSystem.downedPerforator) item.pick = 100;
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
                    if (!AbsolutionWorld.DownedTrojanSquirrel && !AbsolutionConfig.Instance.UnboundMode) return false;
                    break;
                default:
                    break;
            }
            if (item.type == ModContent.ItemType<FargowiltasSouls.Items.Masochist>() && !AbsolutionConfig.Instance.UnboundMode) return false;
            else if ((item.type == ModContent.ItemType<Fargowiltas.Items.Summons.SlimyCrown>() || item.type == ModContent.ItemType<Fargowiltas.Items.Summons.SuspiciousEye>() 
                || item.type == ModContent.ItemType<ThoriumMod.Items.ThunderBird.GrandFlareGun>() || item.type == ModContent.ItemType<Redemption.Items.Usable.Summons.HeartOfThorns>()
                || item.type == ModContent.ItemType<Redemption.Items.Usable.Summons.DemonScroll>()) && !AbsolutionWorld.DownedTrojanSquirrel && !AbsolutionConfig.Instance.UnboundMode) return false;
            else if (item.type == ModContent.ItemType<CalamityMod.Items.SummonItems.EidolonTablet>() && DownedBossSystem.downedPlaguebringer && !AbsolutionConfig.Instance.UnboundMode) return false;
            else if (item.type == ModContent.ItemType<CalamityMod.Items.PermanentBoosters.CelestialOnion>() && !AbsolutionConfig.Instance.UnboundMode) return false;
            return base.CanUseItem(item, player);
        }
    }
}
