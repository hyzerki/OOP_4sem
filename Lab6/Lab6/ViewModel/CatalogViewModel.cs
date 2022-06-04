using Lab6.AppContext;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab6.ViewModel
{
    internal class CatalogViewModel : BaseViewModel
    {
        public ObservableCollection<BookViewModel> Books { get; set; }


        public CatalogViewModel(BaseViewModel? parentViewModel = null) : base(parentViewModel)
        {
            ApplicationContext db = new ApplicationContext();
            Books = new ObservableCollection<BookViewModel>(db.Books.Select(b => (BookViewModel)b).ToList());
            foreach (BookViewModel b in Books)
            {
                b.IsInCart = db.CartItems.Any(c => c.BookId.Equals(b.Id));
                b.ParentViewModel = this;
            }
        }
    }
}
