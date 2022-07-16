using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionGlobalTile : GlobalTile
    {
        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
            switch(type)
            {
                case TileID.ShadowOrbs:
                    if (!NPC.downedBoss1) return false;
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
