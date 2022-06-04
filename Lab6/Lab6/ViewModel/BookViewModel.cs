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
    internal class BookViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        string _name = null!;
        private bool _isInCart;
        public bool IsInCart { get => _isInCart; set { _isInCart = value; OnPropertyChanged(nameof(IsInCart)); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
        string _author = null!;
        public string Author { get => _author; set { _author = value; OnPropertyChanged(nameof(Author)); } }
        int _pages;
        public int Pages { get => _pages; set { _pages = value; OnPropertyChanged(nameof(Pages)); } }
        string _description = null!;
        public string Description { get => _description; set { _description = value; OnPropertyChanged(nameof(Description)); } }
        private BitmapImage _image = null!;
        public BitmapImage Image { get => _image; set { _image = value; OnPropertyChanged(nameof(Image)); } }

        public static implicit operator BookViewModel(Book book)
        {
            return new BookViewModel { Id = book.Id, Name = book.Name, Author = book.Author, Pages = book.Pages, Description = book.Description, Image = BitmapImageHelper.CreateFromBytes(book.Image) };
        }

        public BookViewModel()
        {
            InspectBookCommand = new DelegateCommand(InspectBook);
            DeleteBookCommand = new DelegateCommand(DeleteBook);
            EditBookCommand = new DelegateCommand(EditBook);
            AddBookToCartCommand = new DelegateCommand(AddToCart);
            RemoveBookFromCartCommand = new DelegateCommand(RemoveFromCart);
        }

        public ICommand InspectBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand EditBookCommand { get; set; }
        public ICommand AddBookToCartCommand { get; set; }
        public ICommand RemoveBookFromCartCommand { get; set; }

        private void EditBook()
        {
            if (ParentViewModel!.ParentViewModel is MainViewModel parent)
            {
                parent.SelectedViewModel = new EditBookViewModel(this.Id, parent);
            }
        }

        private async void DeleteBook()
        {
            ApplicationContext db = new();
            db.Books.Remove(db.Books.FirstOrDefault(b => b.Id == Id)!);
            await db.SaveChangesAsync();
            if (ParentViewModel is CatalogViewModel parent)
            {
                parent.Books.Remove(parent.Books.FirstOrDefault(b => b.Id == Id)!);
            }
        }

        private void AddToCart()
        {
            if (!IsInCart)
            {
                using UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();
                uow.CartItems.Create(new CartItem { Amount = 1, Book = uow.Books.Get(Id) });
                uow.Save();
                IsInCart = true;
            }
        }

        private void RemoveFromCart()
        {
            if (IsInCart)
            {
                using ApplicationContext db = new ApplicationContext();
                db.CartItems.Remove(db.CartItems.First(c => c.BookId.Equals(Id)));
                db.SaveChanges();
                IsInCart = false;
                if (ParentViewModel is CartViewModel parent)
                {
                    parent.Refresh();
                }
            }
        }

        private void InspectBook()
        {
            if (ParentViewModel!.ParentViewModel is MainViewModel parent)
            {
                parent.SelectedViewModel = new BookInspectViewModel(this.Id, parent);
            }
        }
    }
}
