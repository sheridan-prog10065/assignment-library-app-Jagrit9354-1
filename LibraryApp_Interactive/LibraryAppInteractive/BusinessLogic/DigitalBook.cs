using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace BusinessLogic
{
    public class DigitalBook : Book
    {
        private int _maxBorrowDays;
        private decimal _latePenaltyPerDay = 12.23M;


        public DigitalBook(string bookName, string bookISBN) : base(bookName, bookISBN)
        {

        }

        private void DetermineLoanLicense() 
        {
            //TODO: determine the loan license
        }

        public override LibraryAsset BorrowBook()  
        {
            LibraryAsset asset = base.BorrowBook();

            LoanPeriod loan = new LoanPeriod(DateTime.Now, DateTime.MinValue);
            loan.DueDate = DateTime.Now.AddDays(_maxBorrowDays);
            asset.Loan = loan;
            return asset;
        }

        public override (TimeSpan, int, decimal) ReturnBook(int libID) 
        {
            (TimeSpan loanDuration, int daysLate, decimal _) = base.ReturnBook(libID);

            //Calculate late fees and charge the fine
            decimal lateFees = daysLate + _latePenaltyPerDay;

            //Return the tuple
            return (loanDuration, daysLate, lateFees);
        }


    }
}
