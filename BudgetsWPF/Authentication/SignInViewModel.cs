using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using BudgetsWPF.Navigation;
using Models.Users;
using Prism.Commands;
using Services;

namespace BudgetsWPF.Authentication
{
    public class SignInViewModel:INotifyPropertyChanged, INavigatable<AuthNavTypes>
    {
        private AuthenticationUser _authUser= new AuthenticationUser();
        private Action _goToSignUp;
        private Action _goToWallets;
        private bool _isEnabled=true;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

       

        public AuthNavTypes Type
        {
            get
            {
                return AuthNavTypes.SignIn;
            }
        }


        public SignInViewModel(Action goToSighUp, Action goToWallets)
        {
            SignInCommand = new DelegateCommand(SignIn, IsSignInEnable);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
            _goToSignUp = goToSighUp;
            SignUpCommand = new DelegateCommand(_goToSignUp);
            _goToWallets = goToWallets;
        }

        private bool IsSignInEnable()
        {
            return !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password);
        }

        private async void SignIn()
        {
            
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
                MessageBox.Show("Login or password is empty");
            else
            {
                
                var authService = new AuthenticationService();
                User user = null;
                try
                {
                    IsEnabled = false;
                    user = await authService.Authenticate(_authUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fail: {ex.Message}");
                    return;
                }
                finally
                {
                    IsEnabled = true;
                }
                MessageBox.Show($"Successful for user {user.FirstName} {user.LastName}");
                _goToWallets.Invoke();
                //Todo navigate to main view of app
            }
        }

        public string Login
        {
            get { return _authUser.Login; }
            set
            {
                if (_authUser.Login != value)
                {
                    _authUser.Login = value;
                    OnPropertyChanged();
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string Password
        {
            get { return _authUser.Password; }
            set {
                if (_authUser.Password != value)
                {
                    _authUser.Password = value;
                    OnPropertyChanged();
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand SignInCommand{ get; }
        public DelegateCommand SignUpCommand { get; }
        public DelegateCommand CloseCommand { get; }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ClearSensitiveData()
        {
            Password = "";
        }
    }
}