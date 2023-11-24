
namespace DesignPattern
{
    //EXAMPLE-1

    // Implementor interface: DrawingAPI
    public interface IDrawingAPI
    {
        void DrawCircle(int x, int y, int radius);
    }

    // Concrete Implementor 1: DrawingAPI1
    public class DrawingAPI1 : IDrawingAPI
    {
        public void DrawCircle(int x, int y, int radius)
        {
            Console.WriteLine($"DrawingAPI1: Drawing Circle at ({x}, {y}) with radius {radius}");
        }
    }

    // Concrete Implementor 2: DrawingAPI2
    public class DrawingAPI2 : IDrawingAPI
    {
        public void DrawCircle(int x, int y, int radius)
        {
            Console.WriteLine($"DrawingAPI2: Drawing Circle at ({x}, {y}) with radius {radius}");
        }
    }

    // Abstraction: Shape
    public abstract class Shape
    {
        protected IDrawingAPI drawingAPI;

        protected Shape(IDrawingAPI drawingAPI)
        {
            this.drawingAPI = drawingAPI;
        }

        public abstract void Draw();
    }

    // Refined Abstraction 1: Circle
    public class Circle : Shape
    {
        private int x, y, radius;

        public Circle(int x, int y, int radius, IDrawingAPI drawingAPI)
            : base(drawingAPI)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw()
        {
            drawingAPI.DrawCircle(x, y, radius);
        }
    }
 

    //EXAMPLE-2
    // Implementor interface: CoffeeBrewer
    public interface CoffeeBrewer
    {
        void BrewCoffee();
    }

    // Concrete Implementor 1: DripCoffeeBrewer
    public class DripCoffeeBrewer : CoffeeBrewer
    {
        public void BrewCoffee()
        {
            Console.WriteLine("Brewing coffee using a drip coffee brewer.");
        }
    }

    // Concrete Implementor 2: EspressoMachine
    public class EspressoMachine : CoffeeBrewer
    {
        public void BrewCoffee()
        {
            Console.WriteLine("Brewing coffee using an espresso machine.");
        }
    }

    // Abstraction: CoffeeType
    public abstract class CoffeeType
    {
        protected CoffeeBrewer coffeeBrewer;

        protected CoffeeType(CoffeeBrewer coffeeBrewer)
        {
            this.coffeeBrewer = coffeeBrewer;
        }

        public abstract void Brew();
    }

    // Refined Abstraction 1: Espresso
    public class Espresso : CoffeeType
    {
        public Espresso(CoffeeBrewer coffeeBrewer)
            : base(coffeeBrewer)
        {
        }

        public override void Brew()
        {
            Console.Write("Espresso - ");
            coffeeBrewer.BrewCoffee();
        }
    }

    // Refined Abstraction 2: Latte
    public class Latte : CoffeeType
    {
        public Latte(CoffeeBrewer coffeeBrewer)
            : base(coffeeBrewer)
        {
        }

        public override void Brew()
        {
            Console.Write("Latte - ");
            coffeeBrewer.BrewCoffee();
        }
    }
}
