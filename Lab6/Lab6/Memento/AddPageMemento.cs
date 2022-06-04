using System.Windows.Media.Imaging;

namespace Lab6.Memento
{
    internal class AddPageMemento
    {
        public AddPageMemento(string name, string author, int pages, string description, BitmapImage image, byte[] imageScreen)
        {
            Name = name;
            Author = author;
            Pages = pages;
            Description = description;
            Image = image;
            ImageScreen = imageScreen;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Pages { get; private set; }
        public string Description { get; private set; }
        public BitmapImage Image { get; private set; }

        public byte[] ImageScreen { get; private set; }

    }
}
