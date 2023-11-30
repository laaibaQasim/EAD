namespace DesignPatterns
{
    //EXAMPLE 1
    // AbstractExpression: IExpression
    public interface IExpression
    {
        int Interpret();
    }

    // TerminalExpression: NumberExpression
    public class NumberExpression : IExpression
    {
        private readonly int number;

        public NumberExpression(int number)
        {
            this.number = number;
        }

        public int Interpret()
        {
            return number;
        }
    }

    // NonTerminalExpression: AdditionExpression
    public class AdditionExpression : IExpression
    {
        private readonly IExpression left;
        private readonly IExpression right;

        public AdditionExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public int Interpret()
        {
            return left.Interpret() + right.Interpret();
        }
    }

    // NonTerminalExpression: MultiplicationExpression
    public class MultiplicationExpression : IExpression
    {
        private readonly IExpression left;
        private readonly IExpression right;

        public MultiplicationExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public int Interpret()
        {
            return left.Interpret() * right.Interpret();
        }
    }

    //EXAMPLE 2
    // AbstractExpression: IQueryExpression
    public interface IQueryExpression
    {
        string Interpret();
    }

    // TerminalExpression: TableExpression
    public class TableExpression : IQueryExpression
    {
        private readonly string tableName;

        public TableExpression(string tableName)
        {
            this.tableName = tableName;
        }

        public string Interpret()
        {
            return tableName;
        }
    }

    // NonTerminalExpression: SelectQueryExpression
    public class SelectQueryExpression : IQueryExpression
    {
        private readonly List<IQueryExpression> columns;
        private readonly TableExpression table;

        public SelectQueryExpression(List<IQueryExpression> columns, TableExpression table)
        {
            this.columns = columns;
            this.table = table;
        }

        public string Interpret()
        {
            string columnList = string.Join(", ", columns.Select(c => c.Interpret()));
            return $"SELECT {columnList} FROM {table.Interpret()}";
        }
    }
}