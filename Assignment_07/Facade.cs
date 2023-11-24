
namespace DesignPattern
{
    //EXAMPLE-1
    // Subsystem 1: Audio Player
    public class AudioPlayer
    {
        public void TurnOn()
        {
            Console.WriteLine("Audio Player: Turning on");
        }

        public void PlayAudio(string audioFile)
        {
            Console.WriteLine($"Audio Player: Playing {audioFile}");
        }

        public void TurnOff()
        {
            Console.WriteLine("Audio Player: Turning off");
        }
    }

    // Subsystem 2: Video Player
    public class VideoPlayer
    {
        public void TurnOn()
        {
            Console.WriteLine("Video Player: Turning on");
        }

        public void PlayVideo(string videoFile)
        {
            Console.WriteLine($"Video Player: Playing {videoFile}");
        }

        public void TurnOff()
        {
            Console.WriteLine("Video Player: Turning off");
        }
    }

    // Subsystem 3: Projector
    public class Projector
    {
        public void TurnOn()
        {
            Console.WriteLine("Projector: Turning on");
        }

        public void ProjectContent()
        {
            Console.WriteLine("Projector: Projecting content");
        }

        public void TurnOff()
        {
            Console.WriteLine("Projector: Turning off");
        }
    }

    // Facade: MultimediaFacade
    public class MultimediaFacade
    {
        private AudioPlayer audioPlayer;
        private VideoPlayer videoPlayer;
        private Projector projector;

        public MultimediaFacade()
        {
            audioPlayer = new AudioPlayer();
            videoPlayer = new VideoPlayer();
            projector = new Projector();
        }

        public void StartMovie(string audioFile, string videoFile)
        {
            Console.WriteLine("=== Movie Time ===");
            audioPlayer.TurnOn();
            audioPlayer.PlayAudio(audioFile);
            videoPlayer.TurnOn();
            videoPlayer.PlayVideo(videoFile);
            projector.TurnOn();
            projector.ProjectContent();
        }

        public void StopMovie()
        {
            Console.WriteLine("=== End of Movie ===");
            audioPlayer.TurnOff();
            videoPlayer.TurnOff();
            projector.TurnOff();
        }
    }

    //EXAMPLE-2
    // Subsystem 1: CPU
    public class CPU
    {
        public void Start()
        {
            Console.WriteLine("CPU: Starting");
        }

        public void Execute()
        {
            Console.WriteLine("CPU: Executing");
        }

        public void Stop()
        {
            Console.WriteLine("CPU: Stopping");
        }
    }

    // Subsystem 2: Memory
    public class Memory
    {
        public void Load()
        {
            Console.WriteLine("Memory: Loading data");
        }

        public void Release()
        {
            Console.WriteLine("Memory: Releasing data");
        }
    }

    // Subsystem 3: Disk
    public class Disk
    {
        public void Read()
        {
            Console.WriteLine("Disk: Reading data");
        }

        public void Write()
        {
            Console.WriteLine("Disk: Writing data");
        }
    }

    // Facade: ComputerFacade
    public class ComputerFacade
    {
        private CPU cpu;
        private Memory memory;
        private Disk disk;

        public ComputerFacade()
        {
            cpu = new CPU();
            memory = new Memory();
            disk = new Disk();
        }

        public void StartComputer()
        {
            Console.WriteLine("=== Starting Computer ===");
            cpu.Start();
            memory.Load();
            disk.Read();
            cpu.Execute();
        }

        public void ShutDownComputer()
        {
            Console.WriteLine("=== Shutting Down Computer ===");
            cpu.Stop();
            memory.Release();
            disk.Write();
        }
    }

}
