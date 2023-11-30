namespace DesignPatterns
{
    //EXAMPLE 1
    //Iterator and Aggregate Interfaces
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }

    //Concrete Aggregate - Playlist
    public class Playlist : IAggregate<Song>
    {
        private List<Song> _songs = new List<Song>();

        public void AddSong(Song song)
        {
            _songs.Add(song);
        }

        public IIterator<Song> CreateIterator()
        {
            return new PlaylistIterator(this);
        }

        public int Count => _songs.Count;

        public Song this[int index] => _songs[index];
    }

    //Concrete Song Class
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString() => $"{Title} by {Artist}";
    }

    //Concrete Iterator - PlaylistIterator
    public class PlaylistIterator : IIterator<Song>
    {
        private readonly Playlist _playlist;
        private int _index = 0;

        public PlaylistIterator(Playlist playlist)
        {
            _playlist = playlist;
        }

        public bool HasNext()
        {
            return _index < _playlist.Count;
        }

        public Song Next()
        {
            return _playlist[_index++];
        }
    }

    //EXAMPLE 2
    //Define the Book
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    //Define the Iterator and Aggregate interfaces
    public interface IIterator2<T>
    {
        bool HasNext();
        T Next();
    }

    public interface IAggregate2<T>
    {
        IIterator2<T> CreateIterator();
    }

    //Implement a concrete aggregate, Bookshelf, and its iterator
    public class Bookshelf : IAggregate2<Book>
    {
        private List<Book> _books = new List<Book>();

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public IIterator2<Book> CreateIterator()
        {
            return new BookshelfIterator(this);
        }

        private class BookshelfIterator : IIterator2<Book>
        {
            private Bookshelf _bookshelf;
            private int _currentIndex = 0;

            public BookshelfIterator(Bookshelf bookshelf)
            {
                _bookshelf = bookshelf;
            }

            public bool HasNext()
            {
                return _currentIndex < _bookshelf._books.Count;
            }

            public Book Next()
            {
                return _bookshelf._books[_currentIndex++];
            }
        }
    }

}