using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class LibraryAsset
    {
        //book objects
        private Book _book;
        // Library ID
        private int _libID;
        //Status of the asset
        private AssetStatus _status;
        // Duration of the loan
        private LoanPeriod _loanPeriod;

        public LibraryAsset(Book book, int libID)
        {
            _book = book;
            _libID = libID;
            _status = AssetStatus.Available;
        }

        public override string ToString()
        {
            return $"{_libID}: {_status}";
        }

        public int LibID 
        {
            get { return _libID; }
            set { _libID = value; }
        }

        public AssetStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public LoanPeriod Loan
        {
            get { return _loanPeriod; }
            set { _loanPeriod = value; }
        }

        public bool IsAvailable
        {
            get { return true; } //TODO: Create logic for getter and setters
            //get { if _status.ToString() == "Available") => true; }
        } 
        
    }
}
