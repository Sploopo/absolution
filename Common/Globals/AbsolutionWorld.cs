using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionWorld : ModSystem
    {
        public static bool GuardianFreed = false;
        public static bool GuardianGivenThanks = false;

        public override void SaveWorldData(TagCompound tag)
        {
            tag.Add("guardianFreed", GuardianFreed);
            tag.Add("guardianGivenThanks", GuardianGivenThanks);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            GuardianFreed = tag.Get<bool>("guardianFreed");
            GuardianGivenThanks = tag.Get<bool>("guardianGivenThanks");
        }
    }
}
