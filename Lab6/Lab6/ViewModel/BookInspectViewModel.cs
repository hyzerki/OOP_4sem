using Lab6.AppContext;
using Lab6.Commands;
using Lab6.Model;
using System;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using YukariDesktop.Utility;

namespace Lab6.ViewModel
{
    internal class BookInspectViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        string _name = null!;
        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
        string _author = null!;
        public string Author { get => _author; set { _author = value; OnPropertyChanged(nameof(Author)); } }
        int _pages;
        public int Pages { get => _pages; set { _pages = value; OnPropertyChanged(nameof(Pages)); } }
        string _description = null!;
        public string Description { get => _description; set { _description = value; OnPropertyChanged(nameof(Description)); } }
        private BitmapImage _image = null!;
        public BitmapImage Image { get => _image; set { _image = value; OnPropertyChanged(nameof(Image)); } }

        public ICommand EditBookCommand { get; set; }

        public BookInspectViewModel(Guid id, BaseViewModel? parent = null) : base(parent)
        {
            ApplicationContext db = new();
            Book book = db.Books.FirstOrDefault(b => b.Id == id)!;
            Id = book.Id;
            Name = book.Name;
            Author = book.Author;
            Pages = book.Pages;
            Description = book.Description;
            Image = BitmapImageHelper.CreateFromBytes(book.Image);
            EditBookCommand = new DelegateCommand(EditBook);
        }

        private void EditBook()
        {
            if (ParentViewModel is MainViewModel parent)
            {
                parent.SelectedViewModel = new EditBookViewModel(Id, parent);
            }
        }
    }
}
