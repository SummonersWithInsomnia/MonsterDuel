using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel.src.VSMode.MonsterDetailCard
{
    public partial class SkillBar : UserControl
    {
        public SkillBar()
        {
            InitializeComponent();
        }

        public void UpdateSkillBar(string skillName, string skillLimit, string skillType)
        {
            lblSkillName.Text = skillName;
            lblSkillLimit.Text = "Limit: " + skillLimit;
            lblSkillType.Text = skillType;
        }
    }
}
