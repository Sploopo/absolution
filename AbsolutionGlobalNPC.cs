using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Items.Tiles;

namespace AbsolutionCore
{
    public class AbsolutionGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        Player player = Main.LocalPlayer;
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            switch(npc.type)
            {
                case NPCID.Painter:
                    IItemDropRule rule = new LeadingConditionRule(new YeaPaintingDropCondition());
                    rule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<YeaPainting>()));
                    npcLoot.Add(rule);
                    break;
            }
        }
    }

    public class YeaPaintingDropCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (!info.IsInSimulation)
            {
                return NPC.AnyNPCs(NPCID.HallowBoss) && Main.LocalPlayer.ZoneDesert;
            }
            return false;
        }

        public bool CanShowItemDropInUI() { return true; }
        public string GetConditionDescription() { return "Drops in the Desert while the Empress of Light is alive";  }
    }
}
