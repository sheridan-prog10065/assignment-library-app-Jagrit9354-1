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

        public List<LibraryAsset> Assets
        {
            get { return _libAssetList; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                //_libAssetList.Add(value);
            }
        }

        public (bool, DateTime) CheckAvailability( )
        {
            foreach (LibraryAsset asset in Assets)
            {
                if (asset.IsAvailable)
                {
                    return (true, DateTime.MinValue);
                }
            }

            // no available asset found - find the earliest due date
            DateTime earliestDueDate = DateTime.MaxValue;
            foreach (LibraryAsset asset in _libAssetList)
            {
                if (asset.Loan.DueDate < earliestDueDate)
                    earliestDueDate = asset.Loan.DueDate;
            }

            return (false, earliestDueDate);
        }

        public virtual LibraryAsset BorrowBook() //Inherited by both book types B
        {
            //Find the next available asset
            LibraryAsset asset = FindNextAvailableAsset();

            //If not available throw exception
            if (asset == null) 
            {
                throw new Exception("No available copies.");
            }
            //Initialize a loan (Implement in the Inherited Classes)

            //Mark the asset as loaned
            asset.Status = AssetStatus.Loaned;
            return asset;
        }

        public virtual (TimeSpan, int, decimal) ReturnBook(int libID) //Inherited by both booktypes 
        {
            LibraryAsset asset = FindLibraryAsset(libID);

            if (asset == null)
            {
                throw new Exception($"No asset found with the {libID}.");
            }
            if(asset.Status != AssetStatus.Loaned)
            {
                throw new Exception($"Asset {libID} is not currently on loan.");
            }

            //Mark the status of the book as available again
            asset.Status = AssetStatus.Available;

            //Calculate the loan duration
            TimeSpan loanDuration = asset.Loan.LoanDuration;
            int daysLate = (int)asset.Loan.LatePeriod.TotalDays;
            daysLate = daysLate < 0 ? 0: daysLate;

            //Return the tuple
            return (loanDuration, daysLate, 0);
        }

        public void ReserveBook() //I don't think this is needed
        {
            //TODO: return a library asset object
        }

        private LibraryAsset FindLibraryAsset(int libID) //Needed for returning a book 
        {
            foreach(LibraryAsset asset in _libAssetList)
            {
                if(asset.LibID == libID)
                {
                    return asset;
                }
            }
            return null;
        }

        private LibraryAsset FindNextAvailableAsset()  
        {
            foreach (LibraryAsset asset in _libAssetList)
            {
                if (asset.IsAvailable)
                {
                    return asset;
                }
                
            }
            return null;
        }


    }
}
