using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Book
    {
        //name of the book
        private string _bookName;
        //ISBN of the book
        private string _bookISBN;
        //List of book authors
        private List<string> _bookAuthorList;
        //List of library assets
        private List<LibraryAsset> _libAssetList;
        public Book(string bookName, string bookISBN)
        {
            _bookName = bookName;
            _bookISBN = bookISBN;
            _bookAuthorList = new List<string>();
            _libAssetList = new List<LibraryAsset>();
        }

        public string Name 
        {
            get { return _bookName; }
            set { if (value == null)
                    throw new ArgumentNullException();

             _bookName = value; }
        }

        public string ISBN
        {
            get { return _bookISBN; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _bookISBN = value;
            }
        }

        public List<string> Authors
        {
            get { return _bookAuthorList; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _bookAuthorList = value;
            }
        }

        public IEnumerable<LibraryAsset> Assets
        {
            get { return _libAssetList; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                //_libAssetList = (LibraryAsset)_libAssetList.Add(value);
            }
        }

        public void CheckAvailability( bool LibraryAsset) 
        {
            //TODO: Check if the book object is available in the collection
        }

        public void BorrowBook()
        {
            //TODO: Return a library asset object
        }

        public void ReturnBook(int libID)
        {
            //TODO: return (TimeSpan, int, decimal)
        }

        public void ReserveBook()
        {
            //TODO: return a library asset object
        }

        private void findLibraryAsset(int libID)
        {
            //TODO: return a library asset object
        }

        private void findNextAvailableAsset() 
        {
            //TODO: return a library asset object
        }


    }
}
