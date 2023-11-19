using System;

namespace DesignPatterns
{
    //EXAMPLE 1
    // Abstract Product: Button
    public interface Button
    {
        void Render();
    }

    // Concrete Product: WindowsButton
    public class WindowsButton : Button
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Windows button");
        }
    }

    // Concrete Product: LinuxButton
    public class LinuxButton : Button
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Linux button");
        }
    }

    // Abstract Product: Form
    public interface Form
    {
        void Display();
    }

    // Concrete Product: WindowsForm
    public class WindowsForm : Form
    {
        public void Display()
        {
            Console.WriteLine("Displaying a Windows form");
        }
    }

    // Concrete Product: LinuxForm
    public class LinuxForm : Form
    {
        public void Display()
        {
            Console.WriteLine("Displaying a Linux form");
        }
    }

    // Abstract Factory
    public interface GUIFactory
    {
        Button CreateButton();
        Form CreateForm();
    }

    // Concrete Factory for Windows
    public class WindowsFactory : GUIFactory
    {
        public Button CreateButton()
        {
            return new WindowsButton();
        }

        public Form CreateForm()
        {
            return new WindowsForm();
        }
    }

    // Concrete Factory for Linux
    public class LinuxFactory : GUIFactory
    {
        public Button CreateButton()
        {
            return new LinuxButton();
        }

        public Form CreateForm()
        {
            return new LinuxForm();
        }
    }


    //Example 2
    // Abstract Product: Laptop
    public interface Laptop
    {
        void Display();
    }

    // Concrete Product: MacBook
    public class MacBook : Laptop
    {
        public void Display()
        {
            Console.WriteLine("Displaying a MacBook");
        }
    }

    // Concrete Product: SamsungLaptop
    public class SamsungLaptop : Laptop
    {
        public void Display()
        {
            Console.WriteLine("Displaying a Samsung Laptop");
        }
    }

    // Abstract Product: Smartphone
    public interface Smartphone
    {
        void DisplayInfo();
    }

    // Concrete Product: iPhone
    public class iPhone : Smartphone
    {
        public void DisplayInfo()
        {
            Console.WriteLine("Displaying iPhone information");
        }
    }

    // Concrete Product: SamsungPhone
    public class SamsungPhone : Smartphone
    {
        public void DisplayInfo()
        {
            Console.WriteLine("Displaying Samsung Phone information");
        }
    }

    // Abstract Factory
    public interface ElectronicDeviceFactory
    {
        Laptop CreateLaptop();
        Smartphone CreateSmartphone();
    }

    // Concrete Factory: AppleFactory
    public class AppleFactory : ElectronicDeviceFactory
    {
        public Laptop CreateLaptop()
        {
            return new MacBook();
        }

        public Smartphone CreateSmartphone()
        {
            return new iPhone();
        }
    }

    // Concrete Factory: SamsungFactory
    public class SamsungFactory : ElectronicDeviceFactory
    {
        public Laptop CreateLaptop()
        {
            return new SamsungLaptop();
        }

        public Smartphone CreateSmartphone()
        {
            return new SamsungPhone();
        }
    }

}
