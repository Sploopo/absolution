using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using Redemption;
using Redemption.Globals;
using Terraria;
using Terraria.DataStructures;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AbsolutionCore.Common.Systems
{
    public class AbsolutionLists : ModSystem
    {
        // ENEMY LISTS
        public static List<int> Armed = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.Anahita>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresBody>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresGaussNuke>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresLaserCannon>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresPlasmaFlamethrower>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresTeslaCannon>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCatastrophe>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.FearlessGoldfishWarrior>(),
            ModContent.NPCType<ThoriumMod.NPCs.DarksteelKnight>(),
            ModContent.NPCType<ThoriumMod.NPCs.AncientCharger>(),
            ModContent.NPCType<ThoriumMod.NPCs.AncientArcher>(),
            ModContent.NPCType<ThoriumMod.NPCs.AncientPhalanx>(),
            ModContent.NPCType<ThoriumMod.NPCs.Buried.TheBuriedWarrior>(),
            ModContent.NPCType<ThoriumMod.NPCs.Buried.TheBuriedWarrior1>(),
            ModContent.NPCType<ThoriumMod.NPCs.Buried.TheBuriedWarrior2>(),
            ModContent.NPCType<ThoriumMod.NPCs.Buried.BuriedSpawn>(),
            ModContent.NPCType<ThoriumMod.NPCs.Buried.BuriedVolley>(),
            ModContent.NPCType<ThoriumMod.NPCs.GoblinTrapper>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.FrostBurntFlayer>(),
            ModContent.NPCType<ThoriumMod.NPCs.ScissorStalker>(),
            ModContent.NPCType<ThoriumMod.NPCs.Lich.LichHeadless>(),
        };

        public static List<int> Cold = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.AuroraSpirit>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CryoSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Cryon>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.IceClasper>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Rimehound>(),
            ModContent.NPCType<CalamityMod.NPCs.Cryogen.Cryogen>(),
            ModContent.NPCType<CalamityMod.NPCs.Cryogen.CryogenShield>(),
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.AnahitasIceShield>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.BlizzardBat>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.BoreanHopper>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.BoreanMyte1>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.BoreanStrider>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.BoreanStriderBase>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.BoreanStriderPopped>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.FrostBurnt>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.FrostBurntFlayer>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.SnowElemental>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blizzard.SnowyOwl>(),
            ModContent.NPCType<ThoriumMod.NPCs.Scouter.CryoCore>(),
            ModContent.NPCType<ThoriumMod.NPCs.Coolmera>(),
            ModContent.NPCType<ThoriumMod.NPCs.ChilledSpitter>(),
            ModContent.NPCType<ThoriumMod.NPCs.Coldling>(),
            ModContent.NPCType<ThoriumMod.NPCs.SnowBall>(),
            ModContent.NPCType<ThoriumMod.NPCs.SnowEater>(),
            ModContent.NPCType<ThoriumMod.NPCs.SnowFlinxMatriarch>(),
            ModContent.NPCType<ThoriumMod.NPCs.SnowSinga>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrostWormHead>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrostWormBody>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrostWormTail>(),
            ModContent.NPCType<ThoriumMod.NPCs.Freezer>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrostFang>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrostFangBase>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrostFangWall>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrozenFace>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrozenGross>(),
        };

        public static List<int> Demon = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.BrimstoneElemental.Brimling>(),
            ModContent.NPCType<CalamityMod.NPCs.BrimstoneElemental.BrimstoneElemental>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.CalamityEye>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.CharredSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.CultistAssassin>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.DespairStone>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.HeatSpirit>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.Scryllar>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.ScryllarRage>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.SoulSlurper>(),
            ModContent.NPCType<CalamityMod.NPCs.CalClone.CalamitasClone>(),
            ModContent.NPCType<CalamityMod.NPCs.CalClone.Cataclysm>(),
            ModContent.NPCType<CalamityMod.NPCs.CalClone.Catastrophe>(),
            ModContent.NPCType<CalamityMod.NPCs.CalClone.SoulSeeker>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.BrimstoneHeart>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SepulcherArm>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SepulcherHead>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SepulcherBody>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SepulcherBodyEnergyBall>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SepulcherTail>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SoulSeekerSupreme>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCataclysm>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCatastrophe>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCalamitas>(),
            ModContent.NPCType<ThoriumMod.NPCs.BoneFlayer>(),
            ModContent.NPCType<ThoriumMod.NPCs.HellBringerMimic>(),
            ModContent.NPCType<ThoriumMod.NPCs.InfernalHound>(),
            ModContent.NPCType<ThoriumMod.NPCs.MoltenMortar>(),
            ModContent.NPCType<ThoriumMod.NPCs.Beholder.EnemyBeholder>(),
            ModContent.NPCType<ThoriumMod.NPCs.Beholder.FallenDeathBeholder>(),
            ModContent.NPCType<ThoriumMod.NPCs.Beholder.FallenDeathBeholder2>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Abyssion>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.AbyssionCracked>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.AbyssionReleased>(),
        };

        public static List<int> Dragonlike = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WildBumblefuck>(),
            ModContent.NPCType<CalamityMod.NPCs.Bumblebirb.Bumblefuck>(),
            ModContent.NPCType<CalamityMod.NPCs.Bumblebirb.Bumblefuck2>(),
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.Leviathan>(),
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.LeviathanStart>(),
            ModContent.NPCType<CalamityMod.NPCs.OldDuke.OldDuke>(),
            ModContent.NPCType<CalamityMod.NPCs.Yharon.Yharon>(),
            ModContent.NPCType<ThoriumMod.NPCs.Thunder.TheGrandThunderBirdv2>(),
            ModContent.NPCType<ThoriumMod.NPCs.Thunder.Hatchling>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.WillChampion>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.NatureChampion>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.NatureChampionHead>(),
        };

        public static List<int> Hallowed = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ScornEater>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ProfanedEnergyBody>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ProfanedEnergyLantern>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ImpiousImmolator>(),
            ModContent.NPCType<CalamityMod.NPCs.ProfanedGuardians.ProfanedGuardianCommander>(),
            ModContent.NPCType<CalamityMod.NPCs.ProfanedGuardians.ProfanedGuardianDefender>(),
            ModContent.NPCType<CalamityMod.NPCs.ProfanedGuardians.ProfanedGuardianHealer>(),
            ModContent.NPCType<CalamityMod.NPCs.Providence.Providence>(),
            ModContent.NPCType<CalamityMod.NPCs.Providence.ProvSpawnDefense>(),
            ModContent.NPCType<CalamityMod.NPCs.Providence.ProvSpawnHealer>(),
            ModContent.NPCType<CalamityMod.NPCs.Providence.ProvSpawnOffense>(),
            ModContent.NPCType<ThoriumMod.NPCs.DissonanceSeer>(),
            ModContent.NPCType<ThoriumMod.NPCs.Spectrumite>(),
            ModContent.NPCType<ThoriumMod.NPCs.GlitteringGolem>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Challengers.LifeChallenger>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.LifeChampion>(),
        };

        public static List<int> Hot = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Sunskater>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.HeatSpirit>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.CharredSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.Ravager.RavagerBody>(),
            ModContent.NPCType<CalamityMod.NPCs.Ravager.FlamePillar>(),
            ModContent.NPCType<CalamityMod.NPCs.Yharon.Yharon>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ScornEater>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ProfanedEnergyBody>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ProfanedEnergyLantern>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ImpiousImmolator>(),
            ModContent.NPCType<CalamityMod.NPCs.ProfanedGuardians.ProfanedGuardianCommander>(),
            ModContent.NPCType<CalamityMod.NPCs.ProfanedGuardians.ProfanedGuardianDefender>(),
            ModContent.NPCType<CalamityMod.NPCs.ProfanedGuardians.ProfanedGuardianHealer>(),
            ModContent.NPCType<CalamityMod.NPCs.Providence.Providence>(),
            ModContent.NPCType<CalamityMod.NPCs.Providence.ProvSpawnDefense>(),
            ModContent.NPCType<CalamityMod.NPCs.Providence.ProvSpawnHealer>(),
            ModContent.NPCType<CalamityMod.NPCs.Providence.ProvSpawnOffense>(),
            ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertScourgeHead>(),
            ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertScourgeBody>(),
            ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertScourgeTail>(),
            ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertNuisanceBody>(),
            ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertNuisanceHead>(),
            ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertNuisanceTail>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Cnidrion>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Stormlion>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCataclysm>(),
            ModContent.NPCType<ThoriumMod.NPCs.Thunder.TheGrandThunderBirdv2>(),
            ModContent.NPCType<ThoriumMod.NPCs.Thunder.Hatchling>(),
            ModContent.NPCType<ThoriumMod.NPCs.HellBringerMimic>(),
            ModContent.NPCType<ThoriumMod.NPCs.InfernalHound>(),
            ModContent.NPCType<ThoriumMod.NPCs.MoltenMortar>(),
            ModContent.NPCType<ThoriumMod.NPCs.FlamekinCaster>(),
            ModContent.NPCType<ThoriumMod.NPCs.BatOutaHell>(),
            ModContent.NPCType<ThoriumMod.NPCs.Scouter.PyroCore>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.SlagFury>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.EarthChampion>(),
        };

        public static List<int> Infected = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.Melter>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.PestilentSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.PlaguebringerMiniboss>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.PlagueCharger>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.PlagueChargerLarge>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.Plagueshell>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.Viruling>(),
            ModContent.NPCType<CalamityMod.NPCs.PlaguebringerGoliath.PlaguebringerGoliath>(),
            ModContent.NPCType<CalamityMod.NPCs.PlaguebringerGoliath.PlagueHomingMissile>(),
            ModContent.NPCType<CalamityMod.NPCs.PlaguebringerGoliath.PlagueMine>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.AcidEel>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.NuclearToad>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.Radiator>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.Skyfin>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.FlakCrab>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.IrradiatedSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.Orthocera>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.SulphurousSkater>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.Trilobite>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.CragmawMire>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.GammaSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.Mauler>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.NuclearTerror>(),
            ModContent.NPCType<CalamityMod.NPCs.OldDuke.OldDuke>(),
            ModContent.NPCType<CalamityMod.NPCs.OldDuke.SulphurousSharkron>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.Omnicide>(),
        };

        public static List<int> IsSlime = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.AeroSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.BloomSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrimulanBlightSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CryoSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.EbonianBlightSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.PerennialSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.AstralSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.Crags.CharredSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.PestilentSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.NuclearToad>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.Radiator>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.IrradiatedSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.CragmawMire>(),
            ModContent.NPCType<CalamityMod.NPCs.AcidRain.GammaSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveBlob>(),
            ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveBlob2>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.CorruptSlimeSpawn>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.CorruptSlimeSpawn2>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.CrimsonSlimeSpawn>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.CrimsonSlimeSpawn2>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.CrimulanSlimeGod>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.EbonianSlimeGod>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodCore>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SplitCrimulanSlimeGod>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SplitEbonianSlimeGod>(),
            ModContent.NPCType<ThoriumMod.NPCs.LivingHemorrhage>(),
            ModContent.NPCType<ThoriumMod.NPCs.Clot>(),
            ModContent.NPCType<ThoriumMod.NPCs.GildedSlime>(),
            ModContent.NPCType<ThoriumMod.NPCs.GildedSlimeMini>(),
            ModContent.NPCType<ThoriumMod.NPCs.GraniteFusedSlime>(),
            ModContent.NPCType<ThoriumMod.NPCs.SpaceSlime>(),
            ModContent.NPCType<ThoriumMod.NPCs.GelatinousCube>(),
            ModContent.NPCType<ThoriumMod.NPCs.GelatinousSludge>(),
            ModContent.NPCType<ThoriumMod.NPCs.BloodMoon.BloodDrop>(),
        };

        public static List<int> Plantlike = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.PerennialSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.BloomSlime>(),
            ModContent.NPCType<ThoriumMod.NPCs.Bloom.CorpseBloom>(),
            ModContent.NPCType<ThoriumMod.NPCs.Bloom.CorpsePetal>(),
            ModContent.NPCType<ThoriumMod.NPCs.Bloom.CorpseWeed>(),
            ModContent.NPCType<ThoriumMod.NPCs.MahoganyEnt>(),
            ModContent.NPCType<ThoriumMod.NPCs.StrangeBulb>(),
            ModContent.NPCType<ThoriumMod.NPCs.BloomMahoganyEnt>(),
            ModContent.NPCType<ThoriumMod.NPCs.Scouter.BioCore>(),
            ModContent.NPCType<ThoriumMod.NPCs.MudMan>(),
        };

        public static List<int> Dark = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.EbonianBlightSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.HiveMind.DankCreeper>(),
            ModContent.NPCType<CalamityMod.NPCs.HiveMind.DarkHeart>(),
            ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveBlob>(),
            ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveBlob2>(),
            ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveTumor>(),
            ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveMind>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.EbonianSlimeGod>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SplitEbonianSlimeGod>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.CorruptSlimeSpawn>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.CorruptSlimeSpawn2>(),
            ModContent.NPCType<CalamityMod.NPCs.CeaselessVoid.CeaselessVoid>(),
            ModContent.NPCType<CalamityMod.NPCs.CeaselessVoid.DarkEnergy>(),
            ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>(),
            ModContent.NPCType<CalamityMod.NPCs.Signus.CosmicLantern>(),
            ModContent.NPCType<CalamityMod.NPCs.Signus.CosmicMine>(),
            ModContent.NPCType<ThoriumMod.NPCs.SnowEater>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrostWormBody>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrostWormHead>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrostWormTail>(),
            ModContent.NPCType<ThoriumMod.NPCs.TheInnocent>(),
            ModContent.NPCType<ThoriumMod.NPCs.TheStarved>(),
            ModContent.NPCType<ThoriumMod.NPCs.ChilledSpitter>(),
            ModContent.NPCType<ThoriumMod.NPCs.VileFloater>(),
            ModContent.NPCType<ThoriumMod.NPCs.HorrificCharger>(),
            ModContent.NPCType<ThoriumMod.NPCs.Freezer>(),
            ModContent.NPCType<ThoriumMod.NPCs.GoblinSpiritGuide>(),
            ModContent.NPCType<ThoriumMod.NPCs.ShadowflameRevenant>(),
            ModContent.NPCType<ThoriumMod.NPCs.Beholder.FallenDeathBeholder>(),
            ModContent.NPCType<ThoriumMod.NPCs.Beholder.FallenDeathBeholder2>(),
            ModContent.NPCType<ThoriumMod.NPCs.Beholder.EnemyBeholder>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.ShadowChampion>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.ShadowOrb>(),
        };

        public static List<int> Blood = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrimulanBlightSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorBodyLarge>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorBodyMedium>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorBodySmall>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorHeadLarge>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorHeadMedium>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorHeadSmall>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorTailLarge>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorTailMedium>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorTailSmall>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorCyst>(),
            ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorHive>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.CrimulanSlimeGod>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SplitCrimulanSlimeGod>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.CrimsonSlimeSpawn>(),
            ModContent.NPCType<CalamityMod.NPCs.SlimeGod.CrimsonSlimeSpawn2>(),
            ModContent.NPCType<CalamityMod.NPCs.Ravager.RavagerBody>(),
            ModContent.NPCType<CalamityMod.NPCs.Ravager.RavagerClawLeft>(),
            ModContent.NPCType<CalamityMod.NPCs.Ravager.RavagerClawRight>(),
            ModContent.NPCType<CalamityMod.NPCs.Ravager.RavagerHead>(),
            ModContent.NPCType<CalamityMod.NPCs.Ravager.RavagerHead2>(),
            ModContent.NPCType<CalamityMod.NPCs.Ravager.RavagerLegLeft>(),
            ModContent.NPCType<CalamityMod.NPCs.Ravager.RavagerLegRight>(),
            ModContent.NPCType<ThoriumMod.NPCs.BloodMoon.BloodMage>(),
            ModContent.NPCType<ThoriumMod.NPCs.BloodMoon.Warg>(),
            ModContent.NPCType<ThoriumMod.NPCs.BloodMoon.GorgedEye>(),
            ModContent.NPCType<ThoriumMod.NPCs.BloodMoon.BloodMage>(),
            ModContent.NPCType<ThoriumMod.NPCs.Biter>(),
            ModContent.NPCType<ThoriumMod.NPCs.Coolmera>(),
            ModContent.NPCType<ThoriumMod.NPCs.LivingHemorrhage>(),
            ModContent.NPCType<ThoriumMod.NPCs.Clot>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrozenFace>(),
            ModContent.NPCType<ThoriumMod.NPCs.FrozenGross>(),
            ModContent.NPCType<ThoriumMod.NPCs.Coldling>(),
            ModContent.NPCType<ThoriumMod.NPCs.EpiDermon>(),
            ModContent.NPCType<ThoriumMod.NPCs.Blister>(),
            ModContent.NPCType<ThoriumMod.NPCs.BlisterPod>(),
            ModContent.NPCType<ThoriumMod.NPCs.Bat.Viscount>(),
            ModContent.NPCType<ThoriumMod.NPCs.Bat.ViscountBaby>(),
        };

        public static List<int> Inorganic = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.AeroSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.BloomSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CryoSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.PerennialSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.Aries>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.AstralachneaGround>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.AstralachneaWall>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.AstralProbe>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.AstralSeekerSpit>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.AstralSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.Atlas>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.BigSightseer>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.FusionFeeder>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.Hadarian>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.HiveEnemy>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.Hiveling>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.Mantis>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.Nova>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.SmallSightseer>(),
            ModContent.NPCType<CalamityMod.NPCs.Astral.StellarCulex>(),
            ModContent.NPCType<CalamityMod.NPCs.AstrumAureus.AstrumAureus>(),
            ModContent.NPCType<CalamityMod.NPCs.AstrumAureus.AureusSpawn>(),
            ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusBody>(),
            ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusHead>(),
            ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusTail>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Horse>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Cryon>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerAmber>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerAmethyst>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerCrystal>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerDiamond>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerEmerald>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerRuby>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerSapphire>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerTopaz>(),
            ModContent.NPCType<CalamityMod.NPCs.CalClone.CalamitasClone>(),
            ModContent.NPCType<CalamityMod.NPCs.CalClone.Cataclysm>(),
            ModContent.NPCType<CalamityMod.NPCs.CalClone.Catastrophe>(),
            ModContent.NPCType<ThoriumMod.NPCs.GraniteEradicator>(),
            ModContent.NPCType<ThoriumMod.NPCs.GraniteFusedSlime>(),
            ModContent.NPCType<ThoriumMod.NPCs.GraniteSurger>(),
            ModContent.NPCType<ThoriumMod.NPCs.EarthenBat>(),
            ModContent.NPCType<ThoriumMod.NPCs.EarthenGolem>(),
            ModContent.NPCType<ThoriumMod.NPCs.GlitteringGolem>(),
            ModContent.NPCType<ThoriumMod.NPCs.HellBringerMimic>(),
            ModContent.NPCType<ThoriumMod.NPCs.LifeCrystalMimic>(),
            ModContent.NPCType<ThoriumMod.NPCs.LihzardMimic>(),
            ModContent.NPCType<ThoriumMod.NPCs.LihzardPotMimic1>(),
            ModContent.NPCType<ThoriumMod.NPCs.LihzardPotMimic2>(),
            ModContent.NPCType<ThoriumMod.NPCs.MyceliumMimic>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.DepthMimic>(),
            ModContent.NPCType<ThoriumMod.NPCs.Spectrumite>(),
            ModContent.NPCType<ThoriumMod.NPCs.TempleGuardian>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.TerraChampion>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.TerraChampionBody>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.TerraChampionTail>(),
        };

        public static List<int> Robotic = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WulfrumAmplifier>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WulfrumDrone>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WulfrumGyrator>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WulfrumHovercraft>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WulfrumRover>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ShockstormShuttle>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.Melter>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.PestilentSlime>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.PlaguebringerMiniboss>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.PlagueCharger>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.PlagueChargerLarge>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.Plagueshell>(),
            ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.Viruling>(),
            ModContent.NPCType<CalamityMod.NPCs.PlaguebringerGoliath.PlaguebringerGoliath>(),
            ModContent.NPCType<CalamityMod.NPCs.PlaguebringerGoliath.PlagueHomingMissile>(),
            ModContent.NPCType<CalamityMod.NPCs.PlaguebringerGoliath.PlagueMine>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresGaussNuke>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresLaserCannon>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresPlasmaFlamethrower>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresTeslaCannon>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresBody>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Apollo.Apollo>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Artemis.Artemis>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Thanatos.ThanatosBody1>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Thanatos.ThanatosBody2>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Thanatos.ThanatosHead>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Thanatos.ThanatosTail>(),
            ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Draedon>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ArmoredDiggerBody>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ArmoredDiggerHead>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ArmoredDiggerTail>(),
            ModContent.NPCType<ThoriumMod.NPCs.Scouter.BioCore>(),
            ModContent.NPCType<ThoriumMod.NPCs.Scouter.CryoCore>(),
            ModContent.NPCType<ThoriumMod.NPCs.Scouter.PyroCore>(),
            ModContent.NPCType<ThoriumMod.NPCs.Scouter.ThePrimeScouter>(),
            ModContent.NPCType<ThoriumMod.NPCs.LostProbe>(),
            ModContent.NPCType<ThoriumMod.NPCs.UFO>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.WillChampion>(),
        };

        public static List<int> Skeleton = new List<int>
        {
            // somehow calamity doesn't add any skeletons
            ModContent.NPCType<ThoriumMod.NPCs.Illusionist>(), // these are (mini)bosses which don't apply to keeper's circlet despite being humanoid
            ModContent.NPCType<ThoriumMod.NPCs.Lich.Lich>(),
            ModContent.NPCType<ThoriumMod.NPCs.Lich.LichHeadless>(),
        };

        public static List<int> SkeletonHumanoid = new List<int>
        {
            ModContent.NPCType<ThoriumMod.NPCs.AncientArcher>(),
            ModContent.NPCType<ThoriumMod.NPCs.AncientCharger>(),
            ModContent.NPCType<ThoriumMod.NPCs.AncientPhalanx>(),
            ModContent.NPCType<ThoriumMod.NPCs.BigBone>(),
            ModContent.NPCType<ThoriumMod.NPCs.DarksteelKnight>(),
            ModContent.NPCType<ThoriumMod.NPCs.Shambler>(),
        };

        public static List<int> Spirit = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.PhantomSpirit>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.PhantomSpiritL>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.PhantomSpiritM>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.PhantomSpiritS>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.OverloadedSoldier>(),
            ModContent.NPCType<CalamityMod.NPCs.Polterghast.Polterghast>(),
            ModContent.NPCType<CalamityMod.NPCs.Polterghast.PhantomFuckYou>(),
            ModContent.NPCType<CalamityMod.NPCs.Polterghast.PolterghastHook>(),
            ModContent.NPCType<CalamityMod.NPCs.Polterghast.PolterPhantom>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.AngerSpirit>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.Aquaius>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.AquaiusBubble>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.DespairSpirit>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.DreadSpirit>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.LucidBubble>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.Omnicide>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.RealityBreaker>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.SlagFury>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.SpiritChampion>(),
            ModContent.NPCType<FargowiltasSouls.NPCs.Champions.SpiritChampionHand>(),
        };

        public static List<int> Undead = new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCataclysm>(),
            ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCatastrophe>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.OverloadedSoldier>(),
            ModContent.NPCType<ThoriumMod.NPCs.BloodMoon.Abomination>(),
            ModContent.NPCType<ThoriumMod.NPCs.BloodMoon.PatchWerk>(),
            ModContent.NPCType<ThoriumMod.NPCs.BloodMoon.GraveLimb>(),
            ModContent.NPCType<ThoriumMod.NPCs.BloodMoon.SeveredLegs>(),
        };

        public static List<int> Wet = new List<int> // god no
        {
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.Anahita>(),
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.LeviathanStart>(),
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.Leviathan>(),
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.AquaticAberration>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.Bloatfish>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.BobbitWormHead>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.BobbitWormSegment>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.BoxJellyfish>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.ChaoticPuffer>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.ColossalSquid>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.Cuttlefish>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.DevilFish>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.DevilFishAlt>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.EidolonWyrmBody>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.EidolonWyrmBodyAlt>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.EidolonWyrmHead>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.EidolonWyrmTail>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.GiantSquid>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.GulperEelBody>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.GulperEelBodyAlt>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.GulperEelHead>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.GulperEelTail>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.Laserfish>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.LuminousCorvina>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.MirageJelly>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.MorayEel>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.OarfishBody>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.OarfishHead>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.OarfishTail>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.ReaperShark>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.ToxicMinnow>(),
            ModContent.NPCType<CalamityMod.NPCs.Abyss.Viperfish>(),
            ModContent.NPCType<CalamityMod.NPCs.AdultEidolonWyrm.AdultEidolonWyrmBody>(),
            ModContent.NPCType<CalamityMod.NPCs.AdultEidolonWyrm.AdultEidolonWyrmBodyAlt>(),
            ModContent.NPCType<CalamityMod.NPCs.AdultEidolonWyrm.AdultEidolonWyrmHead>(),
            ModContent.NPCType<CalamityMod.NPCs.AdultEidolonWyrm.AdultEidolonWyrmTail>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.BabyGhostBell>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.BlindedAngler>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.Clam>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.EutrophicRay>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.GhostBell>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.GiantClam>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.GiantClam>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.SeaFloaty>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.SeaMinnow>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.SeaSerpent1>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.SeaSerpent2>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.SeaSerpent3>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.SeaSerpent4>(),
            ModContent.NPCType<CalamityMod.NPCs.SunkenSea.SeaSerpent5>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Frogfish>(),
            ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.FearlessGoldfishWarrior>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.AbyssalAngler>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.AbyssalAngler2>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.AbyssalSpawn>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Abyssion>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.AbyssionCracked>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.AbyssionReleased>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.AquaticHallucination>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Barracuda>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Blobfish>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Blowfish>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.BlueLobster>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.CrownofThorns>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.FeedingFrenzy>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.FeedingFrenzy2>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.GiantIsopod>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.GigaClam>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Globee>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Hammerhead>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Kraken>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.ManofWar>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.MorayBody>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.MorayHead>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.MorayTail>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Octopus>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.PutridSerpent>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Sharptooth>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.VampireSquid>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.VoltEelBody>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.VoltEelHead>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.VoltEelTail>(),
            ModContent.NPCType<ThoriumMod.NPCs.Depths.Whale>(),
            ModContent.NPCType<ThoriumMod.NPCs.QueenJelly.QueenJelly>(),
            ModContent.NPCType<ThoriumMod.NPCs.QueenJelly.DistractJelly>(),
            ModContent.NPCType<ThoriumMod.NPCs.QueenJelly.SpittingJelly>(),
            ModContent.NPCType<ThoriumMod.NPCs.QueenJelly.ZealousJelly>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.Aquaius>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.AquaiusBubble>(),
            ModContent.NPCType<ThoriumMod.NPCs.Primordials.LucidBubble>(),
        };

        // ITEM LISTS
        List<int> MeldWeapons = new List<int>()
        {
            ModContent.ItemType<CalamityMod.Items.Weapons.Magic.TomeofFates>(),
            ModContent.ItemType<CalamityMod.Items.Tools.GenesisPickaxe>(),
            ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.GodsBellows>(),
            ModContent.ItemType<CalamityMod.Items.Weapons.Magic.CosmicRainbow>(),
            ModContent.ItemType<CalamityMod.Items.Weapons.Melee.EntropicClaymore>(),
            ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.ShardofAntumbra>(),
            ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.StarofDestruction>(),
            ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.LuminousStriker>(),
        };

        List<int> BluntSwing = new List<int>();
        List<int> Arcane = new List<int>();
        List<int> Fire = new List<int>();
        List<int> Water = new List<int>();
        List<int> Ice = new List<int>();
        List<int> Earth = new List<int>();
        List<int> Wind = new List<int>();
        List<int> Thunder = new List<int>();
        List<int> Holy = new List<int>();
        List<int> Shadow = new List<int>();
        List<int> Nature = new List<int>();
        List<int> Poison = new List<int>();
        List<int> WBlood = new List<int>();
        List<int> Psychic = new List<int>();
        List<int> Celestial = new List<int>();
        List<int> NoElement = new List<int>();
        public override void Load()
        {
            Append(ref Inorganic, Robotic);
            Append(ref Skeleton, SkeletonHumanoid);
            Append(ref Shadow, MeldWeapons);
            Append(ref Celestial, MeldWeapons);

            Append(ref NPCLists.Armed, Armed);
            Append(ref NPCLists.Blood, Blood);
            Append(ref NPCLists.Cold, Cold);
            Append(ref NPCLists.Dark, Dark);
            Append(ref NPCLists.Demon, Demon);
            Append(ref NPCLists.Dragonlike, Dragonlike);
            Append(ref NPCLists.Hallowed, Hallowed);
            Append(ref NPCLists.Hot, Hot);
            Append(ref NPCLists.Infected, Infected);
            Append(ref NPCLists.Inorganic, Inorganic);
            Append(ref NPCLists.IsSlime, IsSlime);
            Append(ref NPCLists.Plantlike, Plantlike);
            Append(ref NPCLists.Robotic, Robotic);
            Append(ref NPCLists.Skeleton, Skeleton);
            Append(ref NPCLists.SkeletonHumanoid, SkeletonHumanoid);
            Append(ref NPCLists.Spirit, Spirit);
            Append(ref NPCLists.Undead, Undead);
            Append(ref NPCLists.Wet, Wet);

            Append(ref ItemLists.BluntSwing, BluntSwing);
            Append(ref ItemLists.Arcane, Arcane);
            Append(ref ItemLists.Fire, Fire);
            Append(ref ItemLists.Water, Water);
            Append(ref ItemLists.Ice, Ice);
            Append(ref ItemLists.Earth, Earth);
            Append(ref ItemLists.Wind, Wind);
            Append(ref ItemLists.Thunder, Thunder);
            Append(ref ItemLists.Holy, Holy);
            Append(ref ItemLists.Shadow, Shadow);
            Append(ref ItemLists.Nature, Nature);
            Append(ref ItemLists.Poison, Poison);
            Append(ref ItemLists.Blood, WBlood);
            Append(ref ItemLists.Psychic, Psychic);
            Append(ref ItemLists.Celestial, Celestial);
            Append(ref ItemLists.NoElement, NoElement);
        }
        private static void Append(ref List<int> original, List<int> thisList)
        {
            foreach(int item in thisList)
            {
                original.Add(item);
            }
        }
    }
}
