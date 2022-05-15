using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using ClickerClass;

namespace AbsolutionCore.Content.Clicker.Items.Accessories
{
    public class IdlistSoul : ModItem
    {
        public override string Texture => "AbsolutionCore/Placeholder";
        public override void SetStaticDefaults()
        {
            ClickerCompat.RegisterClickerItem(this);
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Idlist's Soul");
            Tooltip.SetDefault("'I think it's safe to say you've got it made'\n30% increased clicker damage\n15% increased clicker crit chance\n35% increased clicker radius\nEffects of Gamer Crate, Chocolate Milk n' Cookies and Master Keychain");
        }

        public override void SetDefaults()
        {
            Item.value = 3;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ClickerPlayer clickerPlayer = player.GetModPlayer<ClickerPlayer>();
            ClickerCompat.SetDamageAdd(player, 0.3f);
            ClickerCompat.SetClickerCritAdd(player, 15);
            ClickerCompat.SetClickerRadiusAdd(player, 0.7f);
            clickerPlayer.clickerBonusPercent -= 0.10f;
            clickerPlayer.EnableClickEffect("ClickerClass:ChocolateChip");
            clickerPlayer.accGlassOfMilk = true;
            clickerPlayer.accCookie2 = true;
            clickerPlayer.accCookieItem = Item;
            clickerPlayer.accHandCream = true;
            clickerPlayer.accEnchantedLED2 = true;
            clickerPlayer.accHotKeychain = true;
            clickerPlayer.EnableClickEffect(ClickEffect.ClearKeychain);
            clickerPlayer.EnableClickEffect(ClickEffect.StickyKeychain);
        }
    }
}
