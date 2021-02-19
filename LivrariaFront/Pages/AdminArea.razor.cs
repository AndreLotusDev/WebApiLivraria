using LivrariaFront.Components.AdminArea;
using Microsoft.AspNetCore.Components;

namespace LivrariaFront.Pages
{
    public class AdminAreaBase : ComponentBase
    {
        protected AddBook admin;

        protected bool bookState = false;
        protected bool deleteBook = false;
        protected bool dashBoard = false;
        protected bool newCategory = false;

        protected void LoadRegisterBooksArea()
        {
            deleteBook = false;
            dashBoard = false;
            newCategory = false;
            bookState = !bookState;
        }

        protected void LoadDashBoard()
        {
            deleteBook = false;
            dashBoard = !dashBoard;
            newCategory = false;
            bookState = false;
        }

        protected void LoadNewCategory()
        {
            deleteBook = false;
            dashBoard = false;
            newCategory = !newCategory;
            bookState = false;
        }

        protected void LoadDeleteBook()
        {
            deleteBook = !deleteBook;
            dashBoard = false;
            newCategory = false;
            bookState = false;
        }
    }
}
