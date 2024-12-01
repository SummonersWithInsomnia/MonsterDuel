using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace MonsterDuel
{
    public class VSMode
    {
        private Form sourceForm;
        
        private LibVLC libVLC;
        private MediaPlayer mediaPlayer;
        private Media mLoopBackground;

        public int SelectedMonsterCounter;
        private Dictionary<string, bool> selectedMonsters;
        private Dictionary<string, Monster> availableMonsters;

        private MonsterDetailCard monsterDetailCard;
        
        private List<MonsterMiniCard> monsterMiniCards;
        
        private WarningMessageBox confirmSixMonstersWarningMessageBox;
        private Timer confirmSixMonstersMarkCheckerTimer;
        private bool isConfirmSixMonstersWarningMessageBoxOpen;
        
        private List<Monster> monsterPlaceholders;
        private List<MonsterMiniCardWithOrder> monsterMiniCardsWithOrder;
        private Dictionary<string, int> fightingMonsters;
        
        public int SelectedMonsterCounterForOrdering;
        
        // private MonsterMiniCardWithOrder testMonsterMiniCardWithOrder;
        // private MonsterMiniCardWithOrder testMonsterMiniCardWithOrder2;
        
        // Opponent
        private Dictionary<string, bool> opponentSelectedMonsters;
        private Dictionary<int, string> opponentSelectedMonsterIndex;
        private List<OpponentMonsterMiniCard> opponentSelectedMonsterMiniCards;
        
        public VSMode(Form source)
        {
            sourceForm = source;
            
            confirmSixMonstersWarningMessageBox = new WarningMessageBox(sourceForm);
            confirmSixMonstersMarkCheckerTimer = new Timer();
            confirmSixMonstersMarkCheckerTimer.Interval = 50;
            confirmSixMonstersMarkCheckerTimer.Tick += confirmSixMonstersMarkCheckerTimerTick;
            isConfirmSixMonstersWarningMessageBoxOpen = false;

            SelectedMonsterCounter = 0;
            SelectedMonsterCounterForOrdering = 0;
            selectedMonsters = new Dictionary<string, bool>();
            availableMonsters = new Dictionary<string, Monster>();
            
            monsterMiniCards = new List<MonsterMiniCard>();
            
            MonsterList.Init();
            foreach (var item in MonsterList.All)
            {
                if (item.Value.Available)
                {
                    selectedMonsters.Add(item.Key, false);
                    availableMonsters.Add(item.Key, item.Value);
                }
            }

            monsterDetailCard = new MonsterDetailCard(this);
        }
        
        public async Task Start()
        {
            // Game Title Background Video Player
            // Options
            // https://wiki.videolan.org/VLC_command-line_help/
            // - Stop hiding the mouse cursor
            // - No audio
            var options = new string[]
            {
                "--mouse-hide-timeout=2147483647",
                "--no-audio",
                //"--rmtosd-mouse-events",
                //"--mouse-events"
            };
            libVLC = new LibVLC(options);
            
            // https://videolan.videolan.me/vlc/group__libvlc__core.html#gaa3f8e90ec55de9bb63408c6c3680fb2e
            libVLC.SetUserAgent("Monster Duel", "Monster Duel");

            mediaPlayer = new MediaPlayer(libVLC);
            mediaPlayer.EnableMouseInput = false;
            mLoopBackground = new Media(libVLC, "MonsterDuel_Data/video/vs_mode_60.mp4");
            vvBackground.MediaPlayer = mediaPlayer;
            
            // Loop range
            mediaPlayer.PositionChanged += (sender, e) =>
            {
                if (mediaPlayer.Position > 0.88f)
                {
                    mediaPlayer.Position = 0.01f;
                }
            };
            
            AudioPlayer.PlayBGM("MonsterDuel_Data/bgm/vs_mode.mp3");
            await Task.Delay(1700);
            
            List<PictureBox> pbList = await SceneEffect.CuttingInLikeClosingDoor(sourceForm,
                "MonsterDuel_Data/effect/scene/vs_left.png", 
                "MonsterDuel_Data/effect/scene/vs_right.png", 50, 5);
            
            // Topmost of layer
            confirmSixMonstersWarningMessageBox.Visible = true;
            sourceForm.Controls.Add(confirmSixMonstersWarningMessageBox);
            
            sourceForm.Controls.Add(monsterDetailCard);
            
            // Start of Team Configuration
            
            monsterPlaceholders = new List<Monster>();
            monsterPlaceholders.Add(MonsterList.All["V"]);
            monsterPlaceholders.Add(MonsterList.All["Jin"]);
            monsterPlaceholders.Add(MonsterList.All["Jungkook"]);
            monsterPlaceholders.Add(MonsterList.All["Jimin"]);
            monsterPlaceholders.Add(MonsterList.All["Rhaegal"]);
            monsterPlaceholders.Add(MonsterList.All["Visereon"]);
            
            // testMonsterMiniCardWithOrder = new MonsterMiniCardWithOrder();
            // testMonsterMiniCardWithOrder.Location = new Point(90, 161);
            // testMonsterMiniCardWithOrder2 = new MonsterMiniCardWithOrder();
            // testMonsterMiniCardWithOrder2.Location = new Point(470, 161);
            
            monsterMiniCardsWithOrder = new List<MonsterMiniCardWithOrder>();
            int monsterMiniCardWithOrderGapX = 30;
            int monsterMiniCardWithOrderGapY = 30;
            int monsterMiniCardWithOrderX = 90;
            int monsterMiniCardWithOrderY = 211;
            int monsterMiniCardWithOrderCounter = 0;
            
            foreach (var monster in monsterPlaceholders)
            {
                MonsterMiniCardWithOrder mmco = new MonsterMiniCardWithOrder(this, monster, -1);
                mmco.Location = new Point(monsterMiniCardWithOrderX, monsterMiniCardWithOrderY);
                monsterMiniCardWithOrderX += 350 + monsterMiniCardWithOrderGapX;
                monsterMiniCardWithOrderCounter++;

                if (monsterMiniCardWithOrderCounter % 2 == 0)
                {
                    monsterMiniCardWithOrderX = 90;
                    monsterMiniCardWithOrderY += 100 + monsterMiniCardWithOrderGapY;
                }
                
                sourceForm.Controls.Add(mmco);
                monsterMiniCardsWithOrder.Add(mmco);
                mmco.Visible = false;
            }
            
            opponentSelectedMonsters = new Dictionary<string, bool>();
            opponentSelectedMonsterIndex = new Dictionary<int, string>();
            int monsterIndex = 0;
            foreach (var item in MonsterList.All)
            {
                opponentSelectedMonsters.Add(item.Key, false);
                opponentSelectedMonsterIndex.Add(monsterIndex, item.Key);
                monsterIndex++;
            }
            
            int opponentSelectedMonsterCounter = 0;
            while (opponentSelectedMonsterCounter < 6)
            {
                Random random = new Random();
                int index = random.Next(0, opponentSelectedMonsterIndex.Count);
                if (opponentSelectedMonsters[opponentSelectedMonsterIndex[index]])
                {
                    continue;
                }
                
                opponentSelectedMonsters[opponentSelectedMonsterIndex[index]] = true;
                opponentSelectedMonsterCounter++;
            }
            
            opponentSelectedMonsterMiniCards = new List<OpponentMonsterMiniCard>();
            
            int opponentMonsterMiniCardGapY = 5;
            int opponentMonsterMiniCardX = 1000 - 10;
            int opponentMonsterMiniCardY = 77 + 5;
            
            foreach (var item in opponentSelectedMonsters)
            {
                if (item.Value)
                {
                    OpponentMonsterMiniCard omc = new OpponentMonsterMiniCard(this, MonsterList.All[item.Key]);
                    omc.Location = new Point(opponentMonsterMiniCardX, opponentMonsterMiniCardY);
                    opponentMonsterMiniCardY += 80 + opponentMonsterMiniCardGapY;
                    
                    sourceForm.Controls.Add(omc);
                    opponentSelectedMonsterMiniCards.Add(omc);
                    omc.Visible = false;
                }
            }
            
            // End of Team Configuration

            const int xStart = 32;
            const int yStart = 100;
            const int xGap = 32;
            const int yGap = 24;

            int xIndex = xStart;
            int yIndex = yStart;
            int col = 0;
            int row = 0;
            
            foreach (var item in availableMonsters)
            {
                MonsterMiniCard mmc = new MonsterMiniCard(this, item.Value);
                mmc.Location = new Point(xIndex, yIndex);
                
                xIndex += 280 + xGap;
                col++;
                if (col > 3)
                {
                    xIndex = xStart;

                    yIndex += 100 + yGap;
                    row++;
                    col = 0;
                }
                
                sourceForm.Controls.Add(mmc);
                monsterMiniCards.Add(mmc);
            }
            
            sourceForm.Controls.Add(lbTitle);
            sourceForm.Controls.Add(lbInstruction);
            sourceForm.Controls.Add(lbNumberOfSelectedMonsters);
            sourceForm.Controls.Add(lbNext);
            
            sourceForm.Controls.Add(lbYourTeam);
            sourceForm.Controls.Add(lbOpponentTeam);
            sourceForm.Controls.Add(lbNumberOfFightingMonsters);
            sourceForm.Controls.Add(lbStart);
            
            // sourceForm.Controls.Add(testMonsterMiniCardWithOrder);
            // sourceForm.Controls.Add(testMonsterMiniCardWithOrder2);
            
            sourceForm.Controls.Add(vvBackground);
            // Bottommost of layer
            lbYourTeam.Visible = false;
            lbOpponentTeam.Visible = false;
            lbNumberOfFightingMonsters.Visible = false;
            lbStart.Visible = false;
            
            // testMonsterMiniCardWithOrder.Visible = false;
            // testMonsterMiniCardWithOrder2.Visible = false;
            
            mediaPlayer.Play(mLoopBackground);
            
            confirmSixMonstersWarningMessageBox.Visible = false;
            confirmSixMonstersMarkCheckerTimer.Start();
            
            await Task.Delay(6000);
            
            await SceneEffect.CuttingOutLikeOpeningDoor(sourceForm, pbList, 50, 2);

            lbNext.MouseClick += lbNext_MouseClick;
            lbStart.MouseClick += lbStart_MouseClick;

            // Console.WriteLine("lbTitle.Width: " + lbTitle.Width);
            // Console.WriteLine("lbTitle.Height: " + lbTitle.Height);
            // Console.WriteLine("lbInstruction.Width: " + lbInstruction.Width);
            // Console.WriteLine("lbInstruction.Height: " + lbInstruction.Height);
            // Console.WriteLine("lbNumberOfSelectedMonsters.Width: " + lbNumberOfSelectedMonsters.Width);
            // Console.WriteLine("lbNumberOfSelectedMonsters.Height: " + lbNumberOfSelectedMonsters.Height);
            // Console.WriteLine("lbNext.Width: " + lbNext.Width);
            // Console.WriteLine("lbNext.Height: " + lbNext.Height);
        }
        
        private VideoView vvBackground = new VideoView
        {
            Size = new Size(1280, 720),
            Location = new Point(0, 0)
        };
        
        private Label lbTitle = new Label
        {
            AutoSize = true,
            Location = new Point(30, 30),
            Text = "Select Your Monsters",
            Font = new Font("Courier New", 52f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.White
        };
        
        private Label lbInstruction = new Label
        {
            AutoSize = true,
            Location = new Point(30, 633),
            Text = "Left Click: Select or Unselect Monster\nRight Click: Check Details of Monster",
            Font = new Font("Courier New", 24f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.White
        };
        
        private Label lbNumberOfSelectedMonsters = new Label
        {
            AutoSize = true,
            Location = new Point(750, 633),
            Text = "0 / 6",
            Font = new Font("Courier New", 52f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.White
        };
        
        private Label lbNext = new Label
        {
            AutoSize = true,
            Location = new Point(1050, 633),
            Text = "Next",
            Font = new Font("Courier New", 52f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.FromArgb(128, 128, 128)
        };
        
        private Label lbNumberOfFightingMonsters = new Label
        {
            AutoSize = true,
            Location = new Point(750, 633),
            Text = "0 / 3",
            Font = new Font("Courier New", 52f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.White
        };
        
        private Label lbStart = new Label
        {
            AutoSize = true,
            Location = new Point(1050, 633),
            Text = "Start",
            Font = new Font("Courier New", 52f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.FromArgb(128, 128, 128)
        };
        
        private Label lbOpponentTeam = new Label
        {
            AutoSize = true,
            Location = new Point(1000, 50),
            Text = "Opponent Team",
            Font = new Font("Courier New", 24f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.White
        };
        
        private Label lbYourTeam = new Label
        {
            AutoSize = true,
            Location = new Point(350, 130),
            Text = "Your Team",
            Font = new Font("Courier New", 36f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.White
        };

        private void lbNext_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && SelectedMonsterCounter == 6)
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
                confirmSixMonstersWarningMessageBox.Show("Are you sure to confirm these six monsters?\nAfter you confirm, you cannot go back to this page.", "Confirm");
                isConfirmSixMonstersWarningMessageBoxOpen = true;
                lbNext.MouseClick -= lbNext_MouseClick;
            }
            else
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
            }
        }
        
        private void lbStart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && SelectedMonsterCounterForOrdering == 3)
            {
            }
            else
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
            }
        }

        public void AddMonster(Monster monster)
        {
            if (SelectedMonsterCounter == 6)
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
                return;
            }
            
            SelectedMonsterCounter++;
            selectedMonsters[monster.Name] = true;
            
            updateLbNumberOfSelectedMonsters();
        }

        public void RemoveMonster(Monster monster)
        {
            SelectedMonsterCounter--;
            selectedMonsters[monster.Name] = false;
            updateLbNumberOfSelectedMonsters();
        }

        private void updateLbNumberOfSelectedMonsters()
        {
            if (SelectedMonsterCounter == 6)
            {
                lbNext.ForeColor = Color.White;
            }
            else
            {
                lbNext.ForeColor = Color.FromArgb(128, 128, 128);
            }
            
            lbNumberOfSelectedMonsters.Text = SelectedMonsterCounter + " / 6";
        }

        public void MarkMonsterOrder()
        {
            if (SelectedMonsterCounterForOrdering == 3)
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
                return;
            }
            
            SelectedMonsterCounterForOrdering++;
            
            // Update the fighting monsters
            foreach (var mmco in monsterMiniCardsWithOrder)
            {
                fightingMonsters[mmco.Monster.Name] = mmco.Order;
            }
            
            resortMonsterOrder();
            updateLbNumberOfFightingMonsters();
        }
        
        public void UnmarkMonsterOrder()
        {
            SelectedMonsterCounterForOrdering--;
            
            // Update the fighting monsters
            foreach (var mmco in monsterMiniCardsWithOrder)
            {
                fightingMonsters[mmco.Monster.Name] = mmco.Order;
            }
            
            resortMonsterOrder();
            updateLbNumberOfFightingMonsters();
        }

        private void resortMonsterOrder()
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            
            foreach (var item in fightingMonsters)
            {
                if (item.Value == -1)
                {
                    continue;
                }
                temp.Add(item.Value, item.Key);
            }

            if (temp.Count != 0)
            {
                temp = temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                            
                int index = 0;
                foreach (var item in temp)
                {
                    if (item.Key == index)
                    {
                        index++;
                        continue;
                    }
                    
                    fightingMonsters[item.Value] = index;
                    index++;
                }

                foreach (var item in fightingMonsters)
                {
                    foreach (var card in monsterMiniCardsWithOrder)
                    {
                        if (item.Key != card.Monster.Name)
                        {
                            continue;
                        }
                        
                        card.Order = item.Value;
                        card.UpdateOrder();
                    }
                }
            }
        }

        private void updateLbNumberOfFightingMonsters()
        {
            if (SelectedMonsterCounterForOrdering == 3)
            {
                lbStart.ForeColor = Color.White;
            }
            else
            {
                lbStart.ForeColor = Color.FromArgb(128, 128, 128);
            }
            
            lbNumberOfFightingMonsters.Text = SelectedMonsterCounterForOrdering + " / 3";
        }

        public void ShowDetailsOfMonster(Monster monster)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            lbNext.MouseClick -= lbNext_MouseClick;
            lbStart.MouseClick -= lbStart_MouseClick;
            
            monsterDetailCard.Show(monster);
        }

        public void CloseDetailsOfMonster()
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
            lbNext.MouseClick += lbNext_MouseClick;
            lbStart.MouseClick += lbStart_MouseClick;
        }

        private async void confirmSixMonstersMarkCheckerTimerTick(object sender, EventArgs e)
        {
            if (confirmSixMonstersWarningMessageBox.Visible == false && isConfirmSixMonstersWarningMessageBoxOpen)
            {
                isConfirmSixMonstersWarningMessageBoxOpen = false;
                lbNext.MouseClick += lbNext_MouseClick;
            }
            
            if (confirmSixMonstersWarningMessageBox.Result)
            {
                confirmSixMonstersMarkCheckerTimer.Stop();
                await displayTeamConfiguration();
            }
        }

        private async Task displayTeamConfiguration()
        {
            List<PictureBox> pbList = await SceneEffect.CuttingInLikeClosingDoor(sourceForm,
                "MonsterDuel_Data/effect/scene/vs_left.png", 
                "MonsterDuel_Data/effect/scene/vs_right.png", 50, 5);
            
            foreach (var miniCard in monsterMiniCards)
            {
                sourceForm.Controls.Remove(miniCard);
            }
            
            sourceForm.Controls.Remove(lbNumberOfSelectedMonsters);
            sourceForm.Controls.Remove(lbNext);
            
            lbTitle.Text = "Team Configuration";
            lbYourTeam.Visible = true;
            lbOpponentTeam.Visible = true;
            lbNumberOfFightingMonsters.Visible = true;
            lbStart.Visible = true;
            
            // testMonsterMiniCardWithOrder.Visible = true;
            // testMonsterMiniCardWithOrder2.Visible = true;
            
            fightingMonsters = new Dictionary<string, int>();
            foreach (var item in selectedMonsters)
            {
                if (item.Value)
                {
                    fightingMonsters.Add(item.Key, -1);
                }
            }

            foreach (var omc in opponentSelectedMonsterMiniCards)
            {
                omc.Visible = true;
            }
            
            int monsterMiniCardsWithOrderIndex = 0;
            foreach (var item in fightingMonsters)
            {
                Monster monster = availableMonsters[item.Key];
                monsterMiniCardsWithOrder[monsterMiniCardsWithOrderIndex].Switch(monster);
                monsterMiniCardsWithOrderIndex++;
            }
            
            foreach (var mmco in monsterMiniCardsWithOrder)
            {
                mmco.Visible = true;
            }
            
            // Console.WriteLine("lbOpponentTeam.Width: " + lbOpponentTeam.Width);
            // Console.WriteLine("lbOpponentTeam.Height: " + lbOpponentTeam.Height);
            // Console.WriteLine("lbYourTeam.Width: " + lbYourTeam.Width);
            // Console.WriteLine("lbYourTeam.Height: " + lbYourTeam.Height);
            
            await Task.Delay(1000);
            
            await SceneEffect.CuttingOutLikeOpeningDoor(sourceForm, pbList, 50, 2);
        }
    }
}