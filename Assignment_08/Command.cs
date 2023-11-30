namespace DesignPatterns
{
    //EXAMPLE 1
    // Command: ICommand
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    // ConcreteCommand: AddTextCommand
    public class AddTextCommand : ICommand
    {
        private readonly TextEditor textEditor;
        private readonly string addedText;

        public AddTextCommand(TextEditor textEditor, string addedText)
        {
            this.textEditor = textEditor;
            this.addedText = addedText;
        }

        public void Execute()
        {
            textEditor.AddText(addedText);
        }

        public void Undo()
        {
            textEditor.RemoveText(addedText);
        }
    }

    // Receiver: TextEditor
    public class TextEditor
    {
        private string text = string.Empty;

        public void AddText(string addedText)
        {
            text += addedText;
            Console.WriteLine($"Text added: {addedText}. Current text: {text}");
        }

        public void RemoveText(string removedText)
        {
            text = text.Replace(removedText, string.Empty);
            Console.WriteLine($"Text removed: {removedText}. Current text: {text}");
        }

        public string GetText()
        {
            return text;
        }
    }

    // Invoker: UndoManager
    public class UndoManager
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }

        public void UndoCommand()
        {
            command.Undo();
        }
    }

    //EXAMPLE 2
    // Command: OrderCommand
    public interface OrderCommand
    {
        void Execute();
    }

    // ConcreteCommand: CookOrderCommand
    public class CookOrderCommand : OrderCommand
    {
        private readonly Cook cook;
        private readonly string foodItem;

        public CookOrderCommand(Cook cook, string foodItem)
        {
            this.cook = cook;
            this.foodItem = foodItem;
        }

        public void Execute()
        {
            cook.PrepareFood(foodItem);
        }
    }

    // Receiver: Cook
    public class Cook
    {
        public void PrepareFood(string foodItem)
        {
            Console.WriteLine($"Cook is preparing {foodItem}");
        }
    }

    // Invoker: Waiter
    public class Waiter
    {
        private readonly List<OrderCommand> orders = new List<OrderCommand>();

        public void TakeOrder(OrderCommand order)
        {
            orders.Add(order);
        }

        public void PlaceOrders()
        {
            Console.WriteLine("Waiter is placing orders with the Cook:");
            foreach (var order in orders)
            {
                order.Execute();
            }
            orders.Clear();
        }
    }
}