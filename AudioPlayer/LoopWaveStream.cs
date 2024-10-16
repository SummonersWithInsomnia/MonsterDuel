using NAudio.Wave;

namespace MonsterDuel
{
    public class LoopWaveStream : WaveStream
    {
        private WaveStream loopWaveStream;

        public LoopWaveStream(WaveStream source)
        {
            loopWaveStream = source;
        }
        
        public override WaveFormat WaveFormat => loopWaveStream.WaveFormat;

        public override long Length => long.MaxValue;

        public override long Position
        {
            get => loopWaveStream.Position;
            set => loopWaveStream.Position = value;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = loopWaveStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    loopWaveStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                loopWaveStream.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}