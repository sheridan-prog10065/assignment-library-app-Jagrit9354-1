using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace LibraryAppInteractive;

public partial class LibraryAdminPage : ContentPage
{
    private Library _library;
    public LibraryAdminPage()
    {        
        InitializeComponent();
        _library = new Library();
    }

    private void OnRegisterBook(object sender, EventArgs e)
    {
        //Recieve the input for the book data from the admin and add the book and book assets to the library inventory.
        string bookName = _txtBookName.Text;

        string bookISBN = _txtISBN.Text;

        string bookTypeStr = _pckBookType.SelectedItem.ToString();

        string authorName = _txtAuthor.Text;

        // validate fields are not empty
        if (string.IsNullOrWhiteSpace(bookName) ||
            string.IsNullOrWhiteSpace(bookISBN) ||
            string.IsNullOrWhiteSpace(authorName) ||
            string.IsNullOrWhiteSpace(bookTypeStr))
        {
            DisplayAlertAsync("Error", "Please fill in all fields", "OK");
            return;
        }

        string[] authorArray = new string[20];
        authorArray.Append(authorName);

        if (!Enum.TryParse(bookTypeStr, true, out BookType bookType))
        {
            DisplayAlertAsync("Error", "Invalid book type selected", "OK");
            return;
        }

        

        if (!int.TryParse(_txtCopies.Text, out int noOfCopies))
        {
            DisplayAlertAsync("Error", "Please enter a valid number of copies", "OK");
            return;
        }
        

        _library.RegisterBook(bookName, bookISBN, authorArray, bookType, noOfCopies);
    }

    private void OnDisplayBookAssets(object sender, EventArgs e)
    {

    }

    //TODO: On register book method

    //TODO: On display book assets method
}