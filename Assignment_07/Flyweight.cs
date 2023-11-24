
namespace DesignPattern
{
    //EXAMPLE-1
    // Flyweight interface: CharacterFlyweight
    public interface ICharacterFlyweight
    {
        void Display(int fontSize);
    }

    // Concrete Flyweight: Character
    public class Character : ICharacterFlyweight
    {
        private char symbol;

        public Character(char symbol)
        {
            this.symbol = symbol;
        }

        public void Display(int fontSize)
        {
            Console.WriteLine($"Character: {symbol}, Font Size: {fontSize}");
        }
    }

    // Flyweight Factory: CharacterFlyweightFactory
    public class CharacterFlyweightFactory
    {
        private Dictionary<char, ICharacterFlyweight> characterFlyweights = new Dictionary<char, ICharacterFlyweight>();

        public ICharacterFlyweight GetCharacter(char symbol)
        {
            if (!characterFlyweights.ContainsKey(symbol))
            {
                characterFlyweights[symbol] = new Character(symbol);
            }

            return characterFlyweights[symbol];
        }
    }

    //EXAMPLE-2

    // Flyweight interface: ButtonFlyweight
    public interface IButtonFlyweight
    {
        void Display(string label, int positionX, int positionY);
    }

    // Concrete Flyweight: ButtonFlyweightImpl
    public class ButtonFlyweightImpl : IButtonFlyweight
    {
        private string appearance;

        public ButtonFlyweightImpl(string appearance)
        {
            this.appearance = appearance;
        }

        public void Display(string label, int positionX, int positionY)
        {
            Console.WriteLine($"Button '{label}' at ({positionX}, {positionY}): Appearance - {appearance}");
        }
    }

    // Flyweight Factory: ButtonFlyweightFactory
    public class ButtonFlyweightFactory
    {
        private Dictionary<string, IButtonFlyweight> buttonFlyweights = new Dictionary<string, IButtonFlyweight>();

        public IButtonFlyweight GetButtonFlyweight(string appearance)
        {
            // Use the existing flyweight if it exists, or create a new one if not
            if (!buttonFlyweights.ContainsKey(appearance))
            {
                buttonFlyweights[appearance] = new ButtonFlyweightImpl(appearance);
            }

            return buttonFlyweights[appearance];
        }
    }

}
