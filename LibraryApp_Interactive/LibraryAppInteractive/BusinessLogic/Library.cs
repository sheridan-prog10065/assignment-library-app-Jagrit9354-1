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
        }

        public void CreateDefaultBooks()
        {
            //TODO: Create hardcoded book objects
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

        public void FindBookByName(string bookName) 
        {
            //TODO: Search a book from the collection of books.

            //Compare string of bookname to find the book object.
        }

        public void FindBookByISBN(string bookISBN) 
        {
            //TODO: Search a book from the collection.

            //Compare string of bookISBN to find the book object.
        }
    }

    
}
