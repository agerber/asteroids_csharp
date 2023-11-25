namespace DefaultNamespace
{
    using System;
    using System.IO;
    using System.Media;
    using System.Threading;
    using System.Threading.Tasks;
    using NAudio.Wave; // NAudio library for advanced audio features

    public class Sound
    {
        private static readonly ThreadPoolExecutor soundExecutor = new ThreadPoolExecutor(5);

        // For individual wav sounds (not looped)
        public static void PlaySound(string filePath)
        {
            soundExecutor.Execute(() =>
            {
                try
                {
                    string fullPath = Path.Combine("sounds", filePath);
                    using (var soundPlayer = new SoundPlayer(fullPath))
                    {
                        soundPlayer.Play();
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            });
        }

        // For looping wav clips
        public static WaveOutEvent ClipForLoopFactory(string fileName)
        {
            WaveOutEvent waveOut = null;
            try
            {
                string relativePath = Path.Combine("sounds", fileName);
                if (!File.Exists(relativePath))
                    throw new FileNotFoundException("No such sound file exists at " + relativePath);

                var audioFileReader = new AudioFileReader(relativePath);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFileReader);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return waveOut;
        }
    }

    internal class ThreadPoolExecutor
    {
        private readonly SemaphoreSlim _semaphore;

        public ThreadPoolExecutor(int maxConcurrent)
        {
            _semaphore = new SemaphoreSlim(maxConcurrent);
        }

        public void Execute(Action action)
        {
            _semaphore.Wait();
            Task.Run(() =>
            {
                try
                {
                    action();
                }
                finally
                {
                    _semaphore.Release();
                }
            });
        }
    }

}