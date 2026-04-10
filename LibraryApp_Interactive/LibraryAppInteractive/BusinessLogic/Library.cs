using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Library
    {
        //List of books
        private List<Book> _bookList;
        //Library id generator seed
        private int _libGeneratorSeed;
        //Default start ID value
        private const int DEFAULT_LIBID_START = 100;

        public Library()
        {
            //List of books initialised
            _bookList = new List<Book>();
            _libGeneratorSeed = DEFAULT_LIBID_START;
            //Generate default books
            CreateDefaultBooks();
        }

        // Library.cs - read only, nobody can replace the list from outside
        public IEnumerable<Book> BookList
        {
            get { return _bookList; }
        }

        public void CreateDefaultBooks()
        {
            // create a paper book
            PaperBook paperBook = new PaperBook("Lord of the Rings", "978-0261102385");
            paperBook.Authors.Add("J.R.R. Tolkien");

            for (int i = 0; i < 5; i++)
            {
                LibraryAsset asset = new LibraryAsset(paperBook, DetermineLibID());
                asset.Status = AssetStatus.Available;
                paperBook.Assets.Add(asset);
            }
            _bookList.Add(paperBook);

            // create a digital book
            DigitalBook digitalBook = new DigitalBook("Harry Potter", "978-1408898659");
            digitalBook.Authors.Add("J.K. Rowling");

            for (int i = 0; i < 5; i++)
            {
                LibraryAsset asset = new LibraryAsset(digitalBook, DetermineLibID());
                asset.Status = AssetStatus.Available;
                digitalBook.Assets.Add(asset);
            }
            _bookList.Add(digitalBook);
        }

        public int DetermineLibID() // returns int
        {
            int libId = _libGeneratorSeed;
            _libGeneratorSeed++;
            return libId;

        }

        public void RegisterBook(string bookName, string bookISBN, string[] authors, BookType bookType, int nCopies) 
        {
            //Register books into the library by creating book objects
            string bookTpeStr = bookType.ToString();

            Book newBook;

            if (bookTpeStr == "Paper")
            {
                newBook = new PaperBook(bookName, bookISBN);
            }

            else if (bookTpeStr == "Digital")
            {
                newBook = new DigitalBook(bookName, bookISBN);
            }

            else { throw new Exception("Book can only be either Paper or Digital."); };

            foreach (string author in authors)
            {
                newBook.Authors.Add(author);
            }

            // Create nCopies of assets and add each of them to the book
            for (int iAsset = 0; iAsset < nCopies; iAsset++)
            {
                int libId = DetermineLibID();
                LibraryAsset asset = new LibraryAsset(newBook, libId);
                asset.Status = AssetStatus.Available;
                newBook.Assets.Add(asset);
            }

            //Add the book to the book the list
            _bookList.Add(newBook);

        }

        public Book FindBookByName(string bookName) 
        {
            //Compare string of bookname to find the book object.
            foreach(Book curBook in _bookList) 
            {
                if(curBook.Name == bookName) 
                {
                    return curBook;
                }
            }
            return null;
        }

        public Book FindBookByISBN(string bookISBN) 
        {
            //Compare string of bookISBN to find the book object.
            foreach(Book curBook in _bookList) 
            {
                if( curBook.ISBN == bookISBN) 
                {
                    return curBook;
                }
            }
            return null;
        }
    }

    
}
