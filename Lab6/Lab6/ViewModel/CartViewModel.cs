using Lab6.AppContext;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab6.ViewModel
{
    internal class CartViewModel : BaseViewModel
    {
        private ObservableCollection<BookViewModel> _books;
        public ObservableCollection<BookViewModel> Books { get => _books; set { _books = value; OnPropertyChanged(nameof(Books)); } }

        public CartViewModel(BaseViewModel parent) : base(parent)
        {
            using ApplicationContext db = new ApplicationContext();
            _books = new ObservableCollection<BookViewModel>(db.CartItems.Select(c => (BookViewModel)c.Book).ToList());
            foreach (BookViewModel b in Books)
            {
                b.IsInCart = db.CartItems.Any(c => c.BookId.Equals(b.Id));
                b.ParentViewModel = this;
            }
        }

        public void Refresh()
        {
            using ApplicationContext db = new ApplicationContext();
            Books = new ObservableCollection<BookViewModel>(db.CartItems.Select(c => (BookViewModel)c.Book).ToList());
            foreach (BookViewModel b in Books)
            {
                b.IsInCart = db.CartItems.Any(c => c.BookId.Equals(b.Id));
                b.ParentViewModel = this;
            }
        }
    }
}
