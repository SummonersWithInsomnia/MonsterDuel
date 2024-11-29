using NAudio.Wave;

namespace MonsterDuel
{
    public class AudioPlayer
    {
        private WaveOutEvent bgmPlayer;
        private WaveOutEvent sePlayer;
        private AudioFileReader bgmReader;
        private AudioFileReader seReader;

        public AudioPlayer()
        {
            bgmPlayer = new WaveOutEvent();
        }

        public void PlayBGM(string bgmPath)
        {
            bgmReader = new AudioFileReader(bgmPath);
            var loopWaveStream = new LoopWaveStream(bgmReader);
            if (bgmPlayer.PlaybackState != PlaybackState.Playing)
            {
                bgmPlayer.Init(loopWaveStream);
                bgmPlayer.Volume = 1.0f;
                bgmPlayer.Play();
            }
        }
        
        public void StopBGM()
        {
            bgmPlayer.Stop();
        }

        public void PlaySE(string sePath)
        {
            sePlayer = new WaveOutEvent();
            seReader = new AudioFileReader(sePath);
            sePlayer.Volume = 1.0f;
            sePlayer.Init(seReader);
            sePlayer.Play();
        }
    }
}