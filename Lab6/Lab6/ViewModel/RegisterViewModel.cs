namespace Lab6.ViewModel
{
    internal class RegisterViewModel : BaseViewModel
    {

        //public ICommand SwitchToLoginCommand { get; }
        //public ICommand RegisterCommand { get; }


        string _password = string.Empty;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }


        //void SwitchToLogin()
        //{
        //    WindowViewModel? parent = (ParentViewModel as WindowViewModel);
        //    if (parent is not null)
        //    {
        //        parent.CurrentViewModel = new LoginViewModel(parent);
        //    }
        //}

        //void Register()
        //{
        //    ApplicationContext dao = new();
        //    SHA512 sHA512 = SHA512.Create();
        //    User.Password = sHA512.ComputeHash(Encoding.Default.GetBytes(Password));
        //    dao.Users.Add(User);
        //    dao.SaveChanges();
        //}

        //public RegisterViewModel(BaseViewModel? parentViewModel = null) : base(parentViewModel)
        //{
        //    SwitchToLoginCommand = new DelegateCommand(SwitchToLogin);
        //    RegisterCommand = new DelegateCommand(Register);
        //    this._user = new User();
        //}
    }
}
