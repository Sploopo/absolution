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

namespace AbsolutionCore.Content.NPCs
{
    [AutoloadHead]
    public class CutsceneGuardian : ModNPC
    {
        public int frame = 0;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 2;
            DisplayName.SetDefault("Guardian");
        }

        public override void SetDefaults()
        {
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 46;
            NPC.aiStyle = -1;
            NPC.defense = 15;
            NPC.lifeMax = 12345;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            NPC.dontTakeDamage = true;
        }

        public override void AI()
        {
            NPC.TargetClosest();
            NPC.GivenName = AbsolutionWorld.GuardianName;
            Player player = Main.player[NPC.target];

            Texture2D bubble = ModContent.Request<Texture2D>("AbsolutionCore/Assets/Textures/TextBubble_Guardian", (AssetRequestMode)2).Value;
            SoundStyle voice2 = CustomSounds.Voice4;
            voice2.Pitch = -0.4f;
            SoundStyle voice = voice2;

            NPC.ai[0]++;
            switch (NPC.ai[1])
            {
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
                    NPC.ai[1] = 0;
                    Main.NewText(Language.GetTextValue("Mods.AbsolutionCore.GuardianKnowledgeChat.TimberExplanation"), new Color(190, 255, 158));
                    NPC.ai[1] = -127;
                    break;
                case 2:
                    frame = 1;
                    EmoteBubble.NewBubble(3, new WorldUIAnchor(NPC), 50);
                    break;
                case 3:
                    frame = 0;
                    break;
                default:
                    break;
            }
        }
    }
}
