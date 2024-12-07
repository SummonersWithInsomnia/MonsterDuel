using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public class BattleController
{
    private readonly Form sourceForm;

    public Battle Battle { get; set; }
    
    public BattleController(Form source, Battle battle)
    {
        sourceForm = source;
        Battle = battle;
    }
    
    public async Task Start()
    {
        sourceForm.Controls.Add(Battle);

        await Battle.Start();
    }
}