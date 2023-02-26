using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ReLogic.Content;
using AbsolutionCore.Common.Systems;
using Terraria.Audio;
using Redemption;
using Redemption.BaseExtension;
using Redemption.Globals;
using Redemption.UI;
using Terraria.GameContent.UI;
using Terraria.GameContent.Bestiary;

namespace AbsolutionCore.Content.NPCs
{
    public class CutsceneGuardian : ModNPC
    {
        public int frame = 0;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 4;
            DisplayName.SetDefault("???");

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }

        public override void SetDefaults()
        {
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 46;
            NPC.aiStyle = -1;
            NPC.defense = 15;
            NPC.lifeMax = 6969;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            NPC.dontTakeDamage = true;
        }

        public override void AI()
        {
            NPC.TargetClosest();
            if(NPC.ai[1] != 0) NPC.GivenName = AbsolutionWorld.GuardianName;
            Player player = Main.player[NPC.target];

            Texture2D bubble = ModContent.Request<Texture2D>("AbsolutionCore/Assets/Textures/TextBubble_Guardian", (AssetRequestMode)2).Value;
            SoundStyle voice2 = CustomSounds.Voice4;
            voice2.Pitch = -0.4f;
            SoundStyle voice = voice2;

            NPC.ai[0]++;
            NPC.ai[3]++;
            switch (NPC.ai[1])
            {
                case 0:
                    player.RedemptionScreen().ScreenFocusPosition = base.NPC.Center;
                    player.RedemptionScreen().lockScreen = true;
                    player.RedemptionScreen().cutscene = true;
                    NPC.LockMoveRadius(player);
                    if (NPC.ai[2] != 1) NPC.LookAtEntity(player);
                    else if (Main.rand.NextBool(12) && NPC.ai[3] >= 7)
                    {
                        NPC.spriteDirection = -NPC.spriteDirection;
                        NPC.direction = -NPC.direction;
                        NPC.ai[3] = 0;
                    }
                    if (NPC.ai[0] == 10 && !Main.dedServ)
                    {
                        frame = 2;
                        DialogueChain chain = new DialogueChain();
                        chain.Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianIntroChat.Chat1"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 0, false,
                            ModContent.Request<Texture2D>("AbsolutionCore/Content/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble, endID: 4))
                            .Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianIntroChat.Chat2"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 0, false,
                            ModContent.Request<Texture2D>("AbsolutionCore/Content/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble, endID: 3))
                            .Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianIntroChat.Chat3"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 0, false,
                            ModContent.Request<Texture2D>("AbsolutionCore/Content/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble, endID: 5))
                            .Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianIntroChat.Chat4A") + " " + AbsolutionWorld.GuardianName + Language.GetTextValue("Mods.AbsolutionCore.GuardianIntroChat.Chat4B"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 0, false,
                            ModContent.Request<Texture2D>("AbsolutionCore/Content/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble))
                            .Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianIntroChat.Chat5"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 0, false,
                            ModContent.Request<Texture2D>("AbsolutionCore/Content/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble))
                            .Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianIntroChat.Chat6"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 30, true,
                            ModContent.Request<Texture2D>("AbsolutionCore/Content/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble, endID: 6));
                        TextBubbleUI.Visible = true;
                        TextBubbleUI.Add(chain);

                        chain.OnEndTrigger += Chain_OnEndTrigger;
                    }
                    break;
                case 1:
                    player.RedemptionScreen().ScreenFocusPosition = base.NPC.Center;
                    player.RedemptionScreen().lockScreen = true;
                    player.RedemptionScreen().cutscene = true;
                    NPC.LockMoveRadius(player);
                    NPC.LookAtEntity(player);

                    if (NPC.ai[0] == 10 && !Main.dedServ)
                    {
                        DialogueChain chain = new DialogueChain();
                        chain.Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianKnowledgeChat.Timber1"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 0, false,
                            ModContent.Request<Texture2D>("AbsolutionCore/Content/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble, endID: 2))
                            .Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianKnowledgeChat.Timber2"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 0, false,
                            ModContent.Request<Texture2D>("AbsolutionCore/Content/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble))
                            .Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianKnowledgeChat.Timber3"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 0, false,
                            ModContent.Request<Texture2D>("AbsolutionCore/Content/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble, endID: 3))
                            .Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianKnowledgeChat.Timber4"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 30, true,
                            ModContent.Request<Texture2D>("AbsolutionCore/Content/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble, endID: 1));
                        TextBubbleUI.Visible = true;
                        TextBubbleUI.Add(chain);

                        chain.OnEndTrigger += Chain_OnEndTrigger;
                    }
                    break;
                default:
                    player.RedemptionScreen().lockScreen = false;
                    player.RedemptionScreen().cutscene = false;
                    int npc = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Guardian>());
                    Main.npc[npc].GivenName = AbsolutionWorld.GuardianName;
                    if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc);
                    NPC.life = 0;
                    break;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = frame * frameHeight;
        }

        private void Chain_OnEndTrigger(Dialogue dialogue, int id)
        {
            switch (id)
            {
                case 1:
                    Main.NewText(Language.GetTextValue("Mods.AbsolutionCore.GuardianKnowledgeChat.TimberExplanation"), new Color(190, 255, 158));
                    NPC.ai[1] = -127;
                    break;
                case 2:
                    frame = 1;
                    EmoteBubble.NewBubble(3, new WorldUIAnchor(NPC), 50);
                    break;
                case 3:
                    NPC.ai[2] = 0;
                    break;
                case 4:
                    frame = 3;
                    NPC.ai[2] = 1;
                    break;
                case 5:
                    frame = 0;
                    NPC.GivenName = AbsolutionWorld.GuardianName;
                    break;
                case 6:
                    NPC.ai[1] = -127;
                    break;
                default:
                    break;
            }
        }
    }
}
