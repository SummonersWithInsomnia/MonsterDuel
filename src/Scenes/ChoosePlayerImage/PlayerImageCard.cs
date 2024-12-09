using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class PlayerImageCard : UserControl
{
    private ChoosePlayerImage choosePlayerImage;
    public PlayerImage PlayerImage { get; set; }
    
    private Image choosingImage;
    private Image choosingImageDark;
    
    public PlayerImageCard(ChoosePlayerImage cpi, PlayerImage playerImage)
    {
        InitializeComponent();
        choosePlayerImage = cpi;
        PlayerImage = playerImage;
        
        choosingImage = ImageList.GetImage(PlayerImage.ChoosingImagePath);
        choosingImageDark = ImageList.GetImage(PlayerImage.ChoosingImagePathDark);
        
        pbPlayerImage.Image = choosingImageDark;
    }
    
    private void PlayerImageCard_MouseEnter(object sender, EventArgs e)
    {
        pbPlayerImage.Image = choosingImage;
        BackColor = Color.FromArgb(173, 216, 230);
    }
    
    private void PlayerImageCard_MouseLeave(object sender, EventArgs e)
    {
        pbPlayerImage.Image = choosingImageDark;
        BackColor = Color.White;
    }
    
    private void PlayerImageCard_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            choosePlayerImage.SelectedPlayerImageName = PlayerImage.Name;
        }
        else if (e.Button == MouseButtons.Right)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
        }
    }
}