using Lab6.AppContext;
using Lab6.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Lab6.Repository
{
    public class CartRepository : IRepository<CartItem>
    {
        ApplicationContext db;
        public CartRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(CartItem item)
        {
            db.CartItems.Add(item);
        }

        public void Delete(Guid id)
        {
            CartItem? cartItem = db.CartItems.Find(id);
            if (cartItem is not null)
                db.CartItems.Remove(cartItem);
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

        public CartItem Get(Guid id)
        {
            return db.CartItems.Find(id)!;
        }

        public IEnumerable<CartItem> GetAll()
        {
            return db.CartItems;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(CartItem item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
