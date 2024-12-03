using System.Windows.Forms;

namespace MonsterDuel
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            
            VSBar vsBar = new VSBar();
            
            Controls.Add(vsBar);
            
            vsBar.Start();
        }
    }
}