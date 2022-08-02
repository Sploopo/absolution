using Microsoft.Xna.Framework;
using FargowiltasSouls;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AbsolutionCore.Common.Systems;
using Terraria.Audio;
using FargowiltasSouls.NPCs;
using CalamityMod;
using CalamityMod.CalPlayer;

namespace AbsolutionCore.Content.General.Items
{
    public class SigilOfChampionsButAwesome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sigil of Champions");
            Tooltip.SetDefault("Summons the Champions\nSummons vary depending on time and biome\nRight click to check for possible summons\nNot consumed on use");
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.rare = ItemRarityID.Purple;
            Item.maxStack = 1;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
            Item.value = Item.buyPrice(1);
        }

        public override bool CanUseItem(Player player)
        {
            List<int> bosses = new List<int>(new int[] {
                ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("CosmosChampion").Type,
                ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("EarthChampion").Type,
                ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("LifeChampion").Type,
                ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("NatureChampion").Type,
                ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("ShadowChampion").Type,
                ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("SpiritChampion").Type,
                ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("TerraChampion").Type,
                ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("TimberChampion").Type,
                ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("WillChampion").Type
            });

            for (int i = 0; i < Main.maxNPCs; i++) //no using during another champ fight
            {
                if (Main.npc[i].active && bosses.Contains(i) && bosses.Contains(Main.npc[i].type))
                    return false;
            }
            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            CalamityPlayer calamityPlayer = player.GetModPlayer<CalamityPlayer>();
            if (player.ZoneUndergroundDesert)
            {
                if (player.altFunctionUse == 2)
                    Main.NewText(DownedBossSystem.downedProvidence ? "A strong spirit stirs..." : "Your call is muffled by the force of a goddess...", new Color(175, 75, 255));
                else
                    if (DownedBossSystem.downedProvidence) NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("SpiritChampion").Type);
            }
            else if (player.ZoneUnderworldHeight)
            {
                if (player.altFunctionUse == 2)
                    Main.NewText(DownedBossSystem.downedGuardians ? "The core of the planet rumbles..." : "Your call is muffled by the force of guardians...", new Color(175, 75, 255));
                else
                    if (DownedBossSystem.downedGuardians) NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("EarthChampion").Type);
            }
            else if (player.Center.Y >= Main.worldSurface * 16) //is underground
            {
                if (player.ZoneSnow)
                {
                    if (player.altFunctionUse == 2)
                        Main.NewText(DownedBossSystem.downedProvidence ? "A verdant wind is blowing..." : "Your call is muffled by the force of a goddess...", new Color(175, 75, 255));
                    else
                        if (DownedBossSystem.downedProvidence) NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("NatureChampion").Type);
                }
                else
                {
                    if (player.altFunctionUse == 2)
                        Main.NewText(DownedBossSystem.downedAstrumDeus ? "The stones tremble around you..." : "Your call is muffled by the force of nightmares...", new Color(175, 75, 255)); // deus is here because no abaddon yet
                    else
                        if (DownedBossSystem.downedAstrumDeus) NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("TerraChampion").Type);
                }
            }
            else //above ground
            {
                if (player.ZoneSkyHeight)
                {
                    if (player.altFunctionUse == 2)
                        Main.NewText(AbsolutionWorld.DownedShadowChamp && AbsolutionWorld.DownedWillChamp ? "The stars are aligning..." : "The true champion will not answer until the rest are defeated...", new Color(175, 75, 255));
                    else
                        if (AbsolutionWorld.DownedShadowChamp && AbsolutionWorld.DownedWillChamp) NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("CosmosChampion").Type);
                }
                else if (player.ZoneBeach && !calamityPlayer.ZoneSulphur)
                {
                    if (player.altFunctionUse == 2)
                        Main.NewText(DownedBossSystem.downedRavager ? "Metallic groans echo from the depths..." : "Your call is muffled by the force of blood...", new Color(175, 75, 255));
                    else
                        if (DownedBossSystem.downedRavager) NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("WillChampion").Type);
                }
                else if (player.ZoneHallow && Main.dayTime)
                {
                    if (player.altFunctionUse == 2)
                        Main.NewText(DownedBossSystem.downedProvidence ? "A wave of warmth passes over you..." : "Your call is muffled by the force of a goddess...", new Color(175, 75, 255));
                    else
                        if (DownedBossSystem.downedProvidence) NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("LifeChampion").Type);
                }
                else if ((player.ZoneCorrupt || player.ZoneCrimson) && !Main.dayTime) //night
                {
                    if (player.altFunctionUse == 2)
                        Main.NewText((DownedBossSystem.downedCeaselessVoid || DownedBossSystem.downedSignus || DownedBossSystem.downedStormWeaver) ? "The darkness of the night feels deeper..." : "Your call is muffled by the force of a sentinel...", new Color(175, 75, 255));
                    else
                        if (DownedBossSystem.downedCeaselessVoid || DownedBossSystem.downedSignus || DownedBossSystem.downedStormWeaver) NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("ShadowChampion").Type);
                }
                else if (!player.ZoneHallow && !player.ZoneCorrupt && !player.ZoneCrimson
                    && !player.ZoneDesert && !player.ZoneSnow && !player.ZoneJungle && !calamityPlayer.ZoneSulphur && Main.dayTime) //purity day
                {
                    if (player.altFunctionUse == 2)
                        Main.NewText("You are surrounded by the rustling of trees...", new Color(175, 75, 255));
                    else
                        NPC.SpawnOnPlayer(player.whoAmI, ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("TimberChampion").Type);
                }
                else //nothing to summon
                {
                    if (player.altFunctionUse == 2)
                        Main.NewText("Nothing seems to answer the call...", new Color(175, 75, 255));
                }
            }
            return true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.Mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.OverrideColor = Main.DiscoColor;
                }
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Acorn, 5)
            .AddRecipeGroup("IronBar", 5)
            .AddIngredient(ItemID.HellstoneBar, 5)
            .AddIngredient(ItemID.FrostCore, 5)
            .AddIngredient(ItemID.SoulofLight, 5)
            .AddIngredient(ItemID.SoulofNight, 5)
            .AddIngredient(ItemID.AncientBattleArmorMaterial, 5)
            .AddIngredient(ItemID.Coral, 5)
            .AddIngredient(ItemID.LunarBar, 5)

            .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))

            .Register();
        }
    }
}
