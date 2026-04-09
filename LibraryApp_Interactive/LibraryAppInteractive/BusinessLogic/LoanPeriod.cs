using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public struct LoanPeriod
    {
        private DateTime _borrowedOn;
        private DateTime _returnedOn;
        private DateTime _dueDate;
        public LoanPeriod(DateTime borrowedOn, DateTime returnedOn) 
        {
            _borrowedOn = borrowedOn;
            _returnedOn = returnedOn;
        }

        public DateTime BorrowedOn 
        {
            get { return _borrowedOn; }
            set { _borrowedOn = value; }
        }

        public DateTime ReturnedOn
        {
            get { return _returnedOn; }
            set { _returnedOn = value; }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }

        public string LoanDuration 
        {
            get { return $"The book was borrowed from:{_borrowedOn} till:{_returnedOn}"; }
        }

        public TimeSpan LatePeriod
        {
            get { return TimeSpan.Zero; } //TODO: create logic for getter and setter
        }

    }
}
