using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public class BattleController
{
    private readonly Form sourceForm;

    public Battle Battle { get; set; }
    public List<PictureBox> Gates = new List<PictureBox>();
    
    private BattleMessageBox messageBox = new BattleMessageBox();
    
    public BattleController(Form source, Battle battle, List<PictureBox> gates)
    {
        sourceForm = source;
        Battle = battle;
        Gates = gates;
    }
    
    public async Task Start()
    {
        sourceForm.Controls.Add(messageBox);
        messageBox.Visible = false;
        sourceForm.Controls.Add(Battle);
        
        await Battle.Start(sourceForm, Gates);
        await Task.Delay(1000);
        messageBox.Show($"You are challenged by Summoner {Battle.RightPlayer.Name}!");
    }
}