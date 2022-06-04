using Lab6.AppContext;
using Lab6.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Lab6.Repository
{
    public class BookRepository : IRepository<Book>
    {
        ApplicationContext db;
        public BookRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(Book item)
        {
            db.Books.Add(item);
        }

        public void Delete(Guid id)
        {
            Book? book = db.Books.Find(id);
            if (book is not null)
                db.Books.Remove(book);
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
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Book Get(Guid id)
        {
            return db.Books.Find(id)!;
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
