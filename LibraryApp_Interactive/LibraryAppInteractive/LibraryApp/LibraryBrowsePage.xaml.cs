using BusinessLogic;
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

    }

    private void OnReturnBook(object sender, EventArgs e)
    {

    }
}