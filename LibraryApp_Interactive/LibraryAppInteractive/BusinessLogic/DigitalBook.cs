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
        private float _latePenaltyPerDay;


        public DigitalBook(string bookName, string bookISBN, int maxBorrowDays, float latePenaltyPerDay) : base(bookName, bookISBN)
        {
            _maxBorrowDays = maxBorrowDays;
            _latePenaltyPerDay = latePenaltyPerDay;

        }

        private void DetermineLoanLicense() 
        {
            //TODO: determine the loan license
        }

        public override void BorrowBook() 
        {
            //TODO: Override the borrowing functionality for a book
        }

        public override void ReturnBook(int libID) 
        {
            //TODO: return: timespan, int, decimal
        }


    }
}
