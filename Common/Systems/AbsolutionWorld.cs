using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AbsolutionCore.Common.Systems
{
    public class AbsolutionWorld : ModSystem
    {
        public static bool GuardianFreed = false;
        public static bool GuardianGivenThanks = false;
        public static bool DownedGuardian = false;
        public static string GuardianName = "ERROR";

        public static bool DownedShadowChamp = false;
        public static bool DownedWillChamp = false;
        public static bool DownedTrojanSquirrel = false;

        public static bool UsedSSOTSOTCMG = false;

        public override void SaveWorldData(TagCompound tag)
        {
            tag.Add("guardianFreed", GuardianFreed);
            tag.Add("guardianGivenThanks", GuardianGivenThanks);
            tag.Add("downedGuardian", DownedGuardian);
            tag.Add("guardianName", GuardianName);
            tag.Add("downedShadowChamp", DownedShadowChamp);
            tag.Add("downedWillChamp", DownedWillChamp);
            tag.Add("downedTrojanSquirrel", DownedTrojanSquirrel);
            tag.Add("usedSSOTSOTCMG", UsedSSOTSOTCMG);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            GuardianFreed = tag.Get<bool>("guardianFreed");
            GuardianGivenThanks = tag.Get<bool>("guardianGivenThanks");
            DownedGuardian = tag.Get<bool>("downedGuardian");
            GuardianName = tag.Get<string>("guardianName");
            DownedShadowChamp = tag.Get<bool>("downedShadowChamp");
            DownedWillChamp = tag.Get<bool>("downedWillChamp");
            DownedTrojanSquirrel = tag.Get<bool>("downedTrojanSquirrel");
            UsedSSOTSOTCMG = tag.Get<bool>("usedSSOTSOTCMG");
        }
    }
}
