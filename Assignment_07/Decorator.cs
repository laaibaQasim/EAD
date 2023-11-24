
namespace DesignPattern
{
    //EXAMPLE-1
    using System;
    // Component interface: Coffee
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    // Concrete Component: SimpleCoffee
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple Coffee";
        }

        public double GetCost()
        {
            return 1.0;
        }
    }

    // Decorator: CoffeeDecorator
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee decoratedCoffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            this.decoratedCoffee = coffee;
        }

        public virtual string GetDescription()
        {
            return decoratedCoffee.GetDescription();
        }

        public virtual double GetCost()
        {
            return decoratedCoffee.GetCost();
        }
    }

    // Concrete Decorator 1: MilkDecorator
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee)
            : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, Milk";
        }

        public override double GetCost()
        {
            return base.GetCost() + 10;
        }
    }

    // Concrete Decorator 2: SugarDecorator
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee)
            : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, Sugar";
        }

        public override double GetCost()
        {
            return base.GetCost() + 5;
        }
    }


    //EXAMPLE-2
    // Component interface: TextComponent
    public interface ITextComponent
    {
        string GetText();
    }

    // Concrete Component: PlainText
    public class PlainText : ITextComponent
    {
        private string text;

        public PlainText(string text)
        {
            this.text = text;
        }

        public string GetText()
        {
            return text;
        }
    }

    // Decorator: TextDecorator
    public abstract class TextDecorator : ITextComponent
    {
        protected ITextComponent decoratedText;

        public TextDecorator(ITextComponent textComponent)
        {
            this.decoratedText = textComponent;
        }

        public virtual string GetText()
        {
            return decoratedText.GetText();
        }
    }

    // Concrete Decorator 1: BoldDecorator
    public class BoldDecorator : TextDecorator
    {
        public BoldDecorator(ITextComponent textComponent)
            : base(textComponent)
        {
        }

        public override string GetText()
        {
            return $"<b>{base.GetText()}</b>";
        }
    }

    // Concrete Decorator 2: ItalicDecorator
    public class ItalicDecorator : TextDecorator
    {
        public ItalicDecorator(ITextComponent textComponent)
            : base(textComponent)
        {
        }

        public override string GetText()
        {
            return $"<i>{base.GetText()}</i>";
        }
    }

}
