namespace DesignPatterns
{
    //EXAMPLE 1
    // Abstract Class: HouseTemplate
    public abstract class HouseTemplate
    {
        // Template method defining the algorithm
        public void BuildHouse()
        {
            BuildFoundation();
            BuildWalls();
            BuildRoof();
            DecorateHouse();
            Console.WriteLine("House is built!");
        }

        // Abstract methods
        protected abstract void BuildFoundation();
        protected abstract void BuildWalls();
        protected abstract void BuildRoof();

        // Hook method
        protected virtual void DecorateHouse()
        {
            Console.WriteLine("Adding basic decoration to the house.");
        }
    }

    // Concrete Class: WoodenHouse
    public class WoodenHouse : HouseTemplate
    {
        protected override void BuildFoundation()
        {
            Console.WriteLine("Building wooden foundation");
        }

        protected override void BuildWalls()
        {
            Console.WriteLine("Building wooden walls");
        }

        protected override void BuildRoof()
        {
            Console.WriteLine("Building wooden roof");
        }

        protected override void DecorateHouse()
        {
            Console.WriteLine("Adding wooden furniture and decorations to the wooden house.");
        }
    }

    // Concrete Class: ConcreteHouse
    public class ConcreteHouse : HouseTemplate
    {
        protected override void BuildFoundation()
        {
            Console.WriteLine("Building concrete foundation");
        }

        protected override void BuildWalls()
        {
            Console.WriteLine("Building concrete walls");
        }

        protected override void BuildRoof()
        {
            Console.WriteLine("Building concrete roof");
        }
    }

    //EXAMPLE 2
    // Abstract Class: WebsiteTemplate
    public abstract class WebsiteTemplate
    {
        // Template method defining the algorithm for building a website
        public void BuildWebsite()
        {
            Console.WriteLine("Building website...");

            // Common steps for all templates
            BuildHeader();
            BuildContent();
            BuildFooter();

            Console.WriteLine("Website construction completed!");
        }

        // Abstract methods to be implemented by subclasses
        protected void BuildHeader()
        {
            Console.WriteLine("Building header");
        }
        protected abstract void BuildContent();
        protected void BuildFooter()
        {
            Console.WriteLine("Building footer");
        }
    }

    // Concrete Class: BasicWebsiteTemplate
    public class BasicWebsiteTemplate : WebsiteTemplate
    { 
        protected override void BuildContent()
        {
            Console.WriteLine("Building basic content");
        }
    }

    // Concrete Class: FancyWebsiteTemplate
    public class FancyWebsiteTemplate : WebsiteTemplate
    {
        protected override void BuildContent()
        {
            Console.WriteLine("Building fancy content with multimedia elements");
        }
    }

}


