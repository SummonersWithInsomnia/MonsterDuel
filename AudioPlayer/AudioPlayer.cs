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
            sePlayer = new WaveOutEvent();
        }

        public void PlayBGM(string bgmPath)
        {
            bgmReader = new AudioFileReader(bgmPath);
            var loopWaveStream = new LoopWaveStream(bgmReader);
            if (bgmPlayer.PlaybackState != PlaybackState.Playing)
            {
                bgmPlayer.Init(loopWaveStream);
                bgmPlayer.Play();
            }
        }

        public void PlaySE(string sePath)
        {
            seReader = new AudioFileReader(sePath);
            sePlayer.Init(seReader);
            sePlayer.Play();
        }
    }
}