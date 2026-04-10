using BusinessLogic;
using Microsoft.Maui.Graphics.Text;
namespace LibraryAppInteractive;

public partial class LibraryBrowsePage : ContentPage
{
    private Library _library;
    private Book _selectedBook;
    public LibraryBrowsePage()
    {   
        InitializeComponent();
        _library = new Library();
    }

    private void OnSearchBook(object sender, EventArgs e)
    {
        string bookName = _txtSearchName.Text;
        string bookISBN = _txtSearchISBN.Text;



        //Check if atleast one field was filled
        if (string.IsNullOrWhiteSpace(bookName) && string.IsNullOrWhiteSpace(bookISBN))
        {
            DisplayAlertAsync("Error", "Please enter a book name or ISBN", "OK");
            return;
        }

        //Search by name and then by ISBN
        if (!string.IsNullOrWhiteSpace(bookName)) 
        {
            _selectedBook = _library.FindBookByName(bookName);
        }

        if (_selectedBook == null && !string.IsNullOrWhiteSpace(bookISBN))
        { 
            _selectedBook = _library.FindBookByISBN(bookISBN);
        }

        //Show result
        if (_selectedBook != null)
        {
            List<string> assetStrings = new List<string>();
            foreach (LibraryAsset asset in _selectedBook.Assets)
            {
                assetStrings.Add(asset.ToString());
            }
            _lstSearchResults.ItemsSource = assetStrings;
        }
        else
            DisplayAlertAsync("Not Found", "No book found. Please try again", "OK");
    }

    private void OnBorrowBook(object sender, EventArgs e)
    {
        //Book can be borrowed after the user has searched for availability of a book
        if (_selectedBook == null) 
        {
            DisplayAlertAsync("Error", "Please search for a book first!", "OK");
        }

        //Borrow the book from the library asset according to the book type (Paper, Digital).
        try
        {
            LibraryAsset borrowedAsset = _selectedBook.BorrowBook();

            //let the user know the library id to return the book

            DisplayAlertAsync("Success", $"Loan for {_selectedBook.Name}, Confirmed.\n" +
                $"Due on {borrowedAsset.Loan.DueDate.ToShortDateString()}\n" +
                $"Use ID: {borrowedAsset.LibID} when returning.", "OK");

            // refresh the assets list to show updated status
            List<string> assetStrings = new List<string>();
            foreach (LibraryAsset asset in _selectedBook.Assets)
            {
                assetStrings.Add(asset.ToString());
            }
            _lstSearchResults.ItemsSource = assetStrings;
        }
        catch (Exception ex)
        {
            // no available copies
            DisplayAlertAsync("Error", ex.Message, "OK"); 
        }




    }

    private void OnReturnBook(object sender, EventArgs e)
    {
        // check if a book has been selected first
        if (_selectedBook == null)
        {
            DisplayAlertAsync("Error", "Please search for a book first", "OK"); 
            return;
        }

        // parse library ID safely
        if (!int.TryParse(_txtLibraryID.Text, out int libID))
        {
            DisplayAlertAsync("Error", "Please enter a valid library ID", "OK");
            return;
        }

        try
        {
            // return the book and get loan info
            (TimeSpan loanDuration, int daysLate, decimal lateFees) = _selectedBook.ReturnBook(libID);

            // inform user of successful return
            string message = $"'{_selectedBook.Name}' returned successfully.\n" +
                             $"Loan duration: {loanDuration.Days} days.";

            // add late fee info if overdue
            if (daysLate > 0)
                message += $"\nOverdue by {daysLate} days. Late fee: ${lateFees}";

            DisplayAlertAsync("Returned", message, "OK");

            // refresh assets list to show updated status
            List<string> assetStrings = new List<string>();
            foreach (LibraryAsset asset in _selectedBook.Assets)
            {
                assetStrings.Add(asset.ToString());
            }
            _lstSearchResults.ItemsSource = assetStrings;
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Error", ex.Message, "OK");
        } 
    }
}