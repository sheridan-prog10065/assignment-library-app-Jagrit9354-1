using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class PaperBook : Book
    {
        private const int MAX_BORROW_DAYS = 30;
        private const float LATE_PENALTY_PER_DAY = 0.25f;
        public PaperBook(string bookName, string bookISBN) : base(bookName, bookISBN)
        {
        }

        public void BorrowBook() 
        {
            //TODO: Return a library asset object
        }

        public void ReturnBook(int libID) 
        {
            //Return: Timespan, int, decimal
        }
    }
}
