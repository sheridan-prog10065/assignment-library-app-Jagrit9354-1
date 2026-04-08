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
        public Library(int id)
        {
            //List of books initialised
            _bookList = new List<Book>();

            //Initializing library Id
            _libGeneratorSeed = id;
        }

        public void CreateDefaultBooks()
        {
            //TODO: Create hardcoded book objects
        }

        public void DetermineLibID() // returns int
        {
            //TODO: Assign a library id 
        }

        public void RegisterBook(string bookName, string bookISBN, string[] authors, BookType bookType, int nCopies) //Returns book object
        {
            //Register books into the library by creating book objects
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
