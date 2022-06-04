using System;

namespace Lab6.Model
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public Book Book { get; set; } = null!;
        public Guid BookId { get; set; }
    }
}
