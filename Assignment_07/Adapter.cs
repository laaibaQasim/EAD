
namespace DesignPattern
{
    //EXAMPLE-1

    // Target Interface + Adapter Interface (As both have same functionality so I am using one Interface).
    public interface IForeignElectricalOutlet
    {
        void SupplyPower();
    }

    // Adaptee (Foreign Electrical Outlet)
    public class ForeignElectricalOutlet : IForeignElectricalOutlet
    {
        public void SupplyPower()
        {
            Console.WriteLine("Supplying power to the foreign device.");
        }
    }

    // Adapter
    public class PowerAdapter : IForeignElectricalOutlet
    {
        private readonly ForeignElectricalOutlet foreignOutlet;

        public PowerAdapter(ForeignElectricalOutlet foreignOutlet)
        {
            this.foreignOutlet = foreignOutlet;
        }

        public void SupplyPower()
        {
            Console.WriteLine("Adapter is converting and supplying power.");
            foreignOutlet.SupplyPower();
        }
    }
  

    //EXAMPLE-2

    // Existing Library with Old Interface
    public class OldLibrary
    {
        public void PerformOldOperation()
        {
            Console.WriteLine("Old operation in the existing library.");
        }
    }

    // New Interface to be Adapted
    public interface INewLibrary
    {
        void PerformNewOperation();
    }

    // Adapter for the Existing Library
    public class LibraryAdapter : INewLibrary
    {
        private readonly OldLibrary oldLibrary;

        public LibraryAdapter(OldLibrary oldLibrary)
        {
            this.oldLibrary = oldLibrary;
        }

        public void PerformNewOperation()
        {
            Console.WriteLine("Adapter is converting and performing new operation.");
            oldLibrary.PerformOldOperation();
        }
    }
}
