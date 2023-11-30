namespace DesignPatterns
{
    //EXAMPLE 1
    // Originator: TextEditor
    public class Texteditor
    {
        private string text;

        public Texteditor(string initialText)
        {
            text = initialText;
        }

        public string GetText()
        {
            return text;
        }

        public void SetText(string newText)
        {
            text = newText;
        }

        public TextEditorMemento Save()
        {
            return new TextEditorMemento(text);
        }

        public void Restore(TextEditorMemento memento)
        {
            text = memento.GetText();
        }
    }

    // Memento: TextEditorMemento
    public class TextEditorMemento
    {
        private readonly string text;

        public TextEditorMemento(string text)
        {
            this.text = text;
        }

        public string GetText()
        {
            return text;
        }
    }

    // Caretaker: TextEditorHistory
    public class TextEditorHistory
    {
        private readonly List<TextEditorMemento> history = new List<TextEditorMemento>();

        public void Push(TextEditorMemento memento)
        {
            history.Add(memento);
        }

        public TextEditorMemento Pop()
        {
            if (history.Count == 0)
            {
                return null;
            }

            TextEditorMemento memento = history[^1];
            history.RemoveAt(history.Count - 1);
            return memento;
        }
    }

    //EXAMPLE 2
    // Originator: Document
    public class Document
    {
        private string content;

        public Document(string initialContent)
        {
            content = initialContent;
            Save(); // Save the initial state
        }

        public void Edit(string newContent)
        {
            content = newContent;
            Save(); // Save the edited state
        }

        public void Print()
        {
            Console.WriteLine($"Document Content: {content}");
        }

        public void Restore(DocumentMemento memento)
        {
            content = memento.GetContent();
        }

        public DocumentMemento Save()
        {
            return new DocumentMemento(content);
        }
    }

    // Memento: DocumentMemento
    public class DocumentMemento
    {
        private readonly string content;

        public DocumentMemento(string content)
        {
            this.content = content;
        }

        public string GetContent()
        {
            return content;
        }
    }

    // Caretaker: DocumentHistory
    public class DocumentHistory
    {
        private readonly List<DocumentMemento> history = new List<DocumentMemento>();

        public void Push(DocumentMemento memento)
        {
            history.Add(memento);
        }

        public DocumentMemento Pop()
        {
            if (history.Count == 0)
            {
                return null;
            }

            DocumentMemento memento = history[^1];
            history.RemoveAt(history.Count - 1);
            return memento;
        }
    }

}