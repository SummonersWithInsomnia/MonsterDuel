using NAudio.Wave;

namespace MonsterDuel
{
    public static class AudioPlayer
    {
        private static WaveOutEvent bgmPlayer = new WaveOutEvent();
        private static WaveOutEvent sePlayer;
        private static AudioFileReader bgmReader;
        private static AudioFileReader seReader;
        
        public static void PlayBGM(string bgmPath)
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
        
        public static void StopBGM()
        {
            bgmPlayer.Stop();
        }

        public static void PlaySE(string sePath)
        {
            sePlayer = new WaveOutEvent();
            seReader = new AudioFileReader(sePath);
            sePlayer.Volume = 1.0f;
            sePlayer.Init(seReader);
            sePlayer.Play();
        }
    }
}