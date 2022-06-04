using Lab6.Commands;
using Lab6.DAO;
using Lab6.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Lab6.ViewModel
{
    internal class ADODemoViewModel : BaseViewModel
    {
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books { get => _books; set { _books = value; OnPropertyChanged(nameof(Books)); } }
        private Book _selectedBook = null!;
        public Book SelectedBook { get => _selectedBook; set { _selectedBook = value; OnPropertyChanged(nameof(SelectedBook)); } }
        public List<string> SortList { get; set; } = new List<string> { "Name asc", "Name desc", "Pages asc", "Pages desc" };
        private string _selectedSort = string.Empty;
        public string SelectedSort { get => _selectedSort; set { _selectedSort = value; OnPropertyChanged(nameof(SelectedSort)); } }
        public ICommand SortChangedCommand { get; set; }
        public ICommand DeleteSelectedCommand { get; set; }
        public ADODemoViewModel(BaseViewModel parent) : base(parent)
        {
            _books = new();
            SortChangedCommand = new DelegateCommand(SortChanged);
            DeleteSelectedCommand = new DelegateCommand(DeleteSelected);
            OnInit();
        }

        private async void DeleteSelected()
        {
            using DatabaseAccessObject dao = new DatabaseAccessObject();
            if (await dao.DeleteBook(SelectedBook.Id) != 0)
            {
                Books = new ObservableCollection<Book>(await dao.GetBooks());
            }
        }

        private void SortChanged()
        {
            switch (SelectedSort)
            {
                case "Name asc":
                    Books = new(Books.OrderBy(b => b.Name).ToList<Book>());
                    break;
                case "Name desc":
                    Books = new(Books.OrderByDescending(b => b.Name).ToList<Book>());
                    break;
                case "Pages asc":
                    Books = new(Books.OrderBy(b => b.Pages).ToList<Book>());
                    break;
                case "Pages desc":
                    Books = new(Books.OrderByDescending(b => b.Pages).ToList<Book>());
                    break;
            }
        }

        private async void OnInit()
        {
            using DatabaseAccessObject dao = new DatabaseAccessObject();
            Books = new ObservableCollection<Book>(await dao.GetBooks());
        }

    }
}
