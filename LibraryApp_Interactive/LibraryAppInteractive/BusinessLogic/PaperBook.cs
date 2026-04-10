using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class PaperBook : Book
    {
        private const int MAX_BORROW_DAYS = 30;
        private const decimal LATE_PENALTY_PER_DAY = 0.25M;
        public PaperBook(string bookName, string bookISBN) : base(bookName, bookISBN)
        {
        }

        public override LibraryAsset BorrowBook() 
        {
            LibraryAsset asset = base.BorrowBook();

            LoanPeriod loan = new LoanPeriod(DateTime.Now, DateTime.MinValue);
            loan.DueDate = DateTime.Now.AddDays(MAX_BORROW_DAYS);
            asset.Loan = loan;
            return asset;
        }

        public override (TimeSpan, int, decimal) ReturnBook(int libID) 
        {
            (TimeSpan loanDuration, int daysLate, decimal _) = base.ReturnBook(libID);

            //Check if the book is overdue and charge the late fees
            decimal lateFees = daysLate * LATE_PENALTY_PER_DAY;

            return (loanDuration, daysLate, lateFees);

        }
    }
}
