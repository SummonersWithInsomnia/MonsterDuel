using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel
{
    public class VSMode
    {
        private Form sourceForm;
        private AudioPlayer audioPlayer;
        
        public VSMode(Form source, AudioPlayer player)
        {
            sourceForm = source;
            audioPlayer = player;
        }
        
        public async Task Start()
        {
            Console.WriteLine("OK");
        }
    }
}