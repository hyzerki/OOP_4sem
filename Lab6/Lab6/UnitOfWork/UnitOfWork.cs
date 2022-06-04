using Lab6.AppContext;
using Lab6.Repository;
using System;

namespace Lab6.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationContext db = new ApplicationContext();
        private CartRepository cartRepository = null!;
        private BookRepository bookRepository = null!;

        public BookRepository Books
        {
            get
            {
                if (bookRepository is null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public CartRepository CartItems
        {
            get
            {
                if (cartRepository is null)
                    cartRepository = new CartRepository(db);
                return cartRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
