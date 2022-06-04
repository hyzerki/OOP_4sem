using System;

namespace Lab6.Model
{
    public class Book
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Pages { get; set; }
        public string Description { get; set; } = null!;
        public byte[] Image { get; set; } = null!;
        public CartItem CartItem { get; set; } = null!;
    }
}
