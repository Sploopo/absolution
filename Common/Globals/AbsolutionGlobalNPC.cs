using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.Tiles;
using Terraria.GameContent.Personalities;
using CalamityMod.World;
using CalamityMod.NPCs;
using FargowiltasSouls;
using AbsolutionCore.Content.NPCs;
using AbsolutionCore.Common.Systems;
using FargowiltasSouls.Toggler;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(NPC npc)
        {
            base.SetDefaults(npc);
        }

        public override void OnKill(NPC npc)
        {
            if(npc.type == ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("ShadowChampion").Type)
            {
                NPC.SetEventFlagCleared(ref AbsolutionWorld.DownedShadowChamp, -1);
            } else if(npc.type == ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("WillChampion").Type)
            {
                NPC.SetEventFlagCleared(ref AbsolutionWorld.DownedWillChamp, -1);
            } else if(npc.type == ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("TrojanSquirrel").Type)
            {
                NPC.SetEventFlagCleared(ref AbsolutionWorld.DownedTrojanSquirrel, -1);
            } else if(npc.type == ModLoader.GetMod("CalamityMod").Find<ModNPC>("PhantomSpirit").Type && !AbsolutionConfig.Instance.UnboundMode)
            {
                CalamityMod.CalamityMod.ghostKillCount--;
            }
        }

        public override void PostAI(NPC npc)
        {
            switch(npc.type)
            {
                case NPCID.VoodooDemon:
                    if (!FargoSoulsWorld.downedDevi && !AbsolutionConfig.Instance.UnboundMode) npc.active = false;
                    break;
                default:
                    break;
            }
            // kill true eyes during providence
            Toggle t = Main.player[Main.myPlayer].GetModPlayer<FargoSoulsPlayer>().Toggler.Toggles["MasoTrueEye"];
            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Providence.Providence>() && (Main.player[Main.myPlayer].GetModPlayer<FargoSoulsPlayer>().MutantPresence ? false : t.ToggleBool))
            {
                SoulCheck.SetToggleValue(Main.player[Main.myPlayer], "MasoTrueEye", false);
                Main.NewText("The True Eyes of Cthulhu left due to Providence's presence!", 255, 33, 0);
            }
        }
    }
}
