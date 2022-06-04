using Lab6.AppContext;
using Lab6.Commands;
using Lab6.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using YukariDesktop.Utility;

namespace Lab6.ViewModel
{
    internal class EditBookViewModel : BaseViewModel, IDataErrorInfo
    {
        public Guid Id { get; set; }
        string _name = string.Empty;
        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
        string _author = string.Empty;
        public string Author { get => _author; set { _author = value; OnPropertyChanged(nameof(Author)); } }
        int _pages;
        public int Pages { get => _pages; set { _pages = value; OnPropertyChanged(nameof(Pages)); } }
        string _description = string.Empty;
        public string Description { get => _description; set { _description = value; OnPropertyChanged(nameof(Description)); } }


        private BitmapImage _image = null!;
        public BitmapImage Image { get => _image; set { _image = value; OnPropertyChanged(nameof(Image)); } }

        private byte[] _imageScreen = null!;

        public ICommand SaveChangesCommand { get; set; }
        public ICommand LoadImageCommand { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(Name):
                        if (Name.Length > 70 || Name.Length == 0)
                        {
                            error = "Length of name is over than 70 chars.";
                        }
                        break;
                    case nameof(Author):
                        if (Name.Length > 70 || Name.Length == 0)
                        {
                            error = "Length of name is over than 70 chars.";
                        }
                        break;
                }
                return error;
            }
        }

        public EditBookViewModel(Guid id, BaseViewModel? parentViewModel = null) : base(parentViewModel)
        {
            ApplicationContext db = new();
            Book book = db.Books.FirstOrDefault(b => b.Id == id)!;
            Id = book.Id;
            Name = book.Name;
            Author = book.Author;
            Pages = book.Pages;
            Description = book.Description;
            Image = BitmapImageHelper.CreateFromBytes(book.Image);

            SaveChangesCommand = new DelegateCommand(SaveChanges);
            LoadImageCommand = new DelegateCommand(AddImage);
        }

        private void AddImage()
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                CheckFileExists = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Filter = "Images (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg;"
            };
            if (openFile.ShowDialog() == true)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(openFile.FileName, UriKind.Relative);
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.EndInit();
                Image = bi;
                byte[] scr = new byte[0];
                switch (Path.GetExtension(openFile.FileName))
                {
                    case ".png":
                        PngBitmapEncoder pe = new PngBitmapEncoder();
                        MemoryStream ms = new MemoryStream();
                        pe.Frames.Add(BitmapFrame.Create(bi));
                        pe.Save(ms);
                        scr = ms.ToArray();
                        break;

                    case ".jpg":
                    case ".jpeg":
                        JpegBitmapEncoder je = new JpegBitmapEncoder();
                        MemoryStream mss = new MemoryStream();
                        je.Frames.Add(BitmapFrame.Create(bi));
                        je.Save(mss);
                        scr = mss.ToArray();
                        break;
                }
                _imageScreen = scr;
            }
        }


        private async void SaveChanges()
        {
            ApplicationContext db = new ApplicationContext();
            Book book = (await db.Books.FirstOrDefaultAsync(b => b.Id == Id))!;
            book.Description = Description;
            book.Name = Name;
            book.Author = Author;
            book.Pages = Pages;
            if (_imageScreen is not null)
            {
                book.Image = _imageScreen;
            }
            await db.SaveChangesAsync();

            if (ParentViewModel is MainViewModel parent)
            {
                parent.SelectedViewModel = new BookInspectViewModel(Id, parent);
            }
        }
    }
}
