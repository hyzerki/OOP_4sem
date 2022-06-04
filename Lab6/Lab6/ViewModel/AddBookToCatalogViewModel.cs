using Lab6.AppContext;
using Lab6.Commands;
using Lab6.Memento;
using Lab6.Model;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Lab6.ViewModel
{
    internal class AddBookToCatalogViewModel : BaseViewModel, IDataErrorInfo
    {
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

        public ICommand AddBookCommand { get; set; }
        public ICommand LoadImageCommand { get; set; }
        public ICommand OnInputCommand { get; set; }
        public ICommand RestoreCommand { get; set; }

        public string Error => throw new NotImplementedException();

        private void OnInput()
        {
            if (ParentViewModel is MainViewModel parent)
            {
                parent.Changes.States.Push(this.SaveState());
            }
        }

        public AddPageMemento SaveState()
        {
            return new AddPageMemento(this.Name, this.Author, this.Pages, this.Description, this.Image, this._imageScreen);
        }

        public void RestoreState()
        {
            if (ParentViewModel is MainViewModel parent)
            {
                AddPageMemento memento = parent.Changes.States.Pop();

                this.Name = memento.Name;
                this.Author = memento.Author;
                this.Pages = memento.Pages;
                this.Description = memento.Description;
                this.Image = memento.Image;
                this._imageScreen = memento.ImageScreen;
            }
        }

        private bool CanRestore()
        {
            if (ParentViewModel is MainViewModel parent)
            {
                return parent.Changes.States.Count > 0;
            }
            return false;
        }


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

        public AddBookToCatalogViewModel(BaseViewModel? parentViewModel = null) : base(parentViewModel)
        {
            AddBookCommand = new DelegateCommand(AddBook, CanAddBook);
            LoadImageCommand = new DelegateCommand(AddImage);
            OnInputCommand = new DelegateCommand(OnInput);
            RestoreCommand = new DelegateCommand(RestoreState, CanRestore);
            if (ParentViewModel is MainViewModel parent)
            {
                parent.Changes.States.Push(this.SaveState());
            }
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
                byte[] scr = null!;
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
            if (ParentViewModel is MainViewModel parent)
            {
                parent.Changes.States.Push(this.SaveState());
            }
        }

        private bool CanAddBook()
        {
            if (_imageScreen is not null)
                return true;
            else
                return false;
        }

        private async void AddBook()
        {
            Book book = new Book { Author = Author, Image = _imageScreen, Description = Description, Name = Name, Pages = Pages };
            ApplicationContext db = new ApplicationContext();
            await db.Books.AddAsync(book);
            await db.SaveChangesAsync();
            if (ParentViewModel is MainViewModel parent)
            {
                parent.SelectedViewModel = new AddBookToCatalogViewModel(parent);
            }
        }
    }
}
