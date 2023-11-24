
namespace DesignPattern
{
    //EXAMPLE-1
    // Subject: Image
    public interface IImage
    {
        void Display();
    }

    // Real Subject: RealImage
    public class RealImage : IImage
    {
        private string filename;

        public RealImage(string filename)
        {
            this.filename = filename;
            LoadImageFromDisk();
        }

        private void LoadImageFromDisk()
        {
            Console.WriteLine($"Loading image from disk: {filename}");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying image: {filename}");
        }
    }

    // Proxy: ProxyImage
    public class ProxyImage : IImage
    {
        private RealImage realImage;
        private string filename;

        public ProxyImage(string filename)
        {
            this.filename = filename;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(filename);
            }
            realImage.Display();
        }
    }


    //EXAMPLE-2
    // Subject: IFile
    public interface IFile
    {
        void Read();
    }

    // Real Subject: RealFile
    public class RealFile : IFile
    {
        private string filename;

        public RealFile(string filename)
        {
            this.filename = filename;
        }

        public void Read()
        {
            Console.WriteLine($"Reading file: {filename}");
        }
    }

    // Proxy: ProtectionProxy
    public class ProtectionProxy : IFile
    {
        private RealFile realFile;
        private string filename;
        private string password;

        public ProtectionProxy(string filename, string password)
        {
            this.filename = filename;
            this.password = password;
        }

        public void Read()
        {
            if (AuthenticateUser())
            {
                if (realFile == null)
                {
                    realFile = new RealFile(filename);
                }
                realFile.Read();
            }
            else
            {
                Console.WriteLine("Access denied. Incorrect password.");
            }
        }

        private bool AuthenticateUser()
        {
            // Simulate authentication logic
            return password == "secret";
        }
    }

}
