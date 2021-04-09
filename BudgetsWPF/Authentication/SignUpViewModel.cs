using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Prism.Commands;

namespace BudgetsWPF.Authentication
{
    public class SignUpViewModel:INotifyPropertyChanged
    {
        private RegistrationUser _regUser= new RegistrationUser();
        private Action _goToSignIn;
        public SignUpViewModel(Action goToSignIn)
        {
            SignUpCommand = new DelegateCommand(SignUp, IsSignUpEnable);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
            _goToSignIn = goToSignIn;
            SignInCommand = new DelegateCommand(goToSignIn);
        }

        private bool IsSignUpEnable()
        {
            return !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(LastName);
        }

        private void SignUp()
        {



            var authService = new AuthenticationService();
                try
                {
                     authService.RegisterUser(_regUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fail: {ex.Message}");
                    return;
                }
                MessageBox.Show("User successfully registered, please sign in");
                _goToSignIn.Invoke();
                //Todo navigate to main view of app
            
        }

        public string Login
        {
            get { return _regUser.Login; }
            set
            {
                if (_regUser.Login != value)
                {
                    _regUser.Login = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string Password
        {
            get { return _regUser.Password; }
            set {
                if (_regUser.Password != value)
                {
                    _regUser.Password = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string LastName
        {
            get { return _regUser.LastName; }
            set
            {
                if (_regUser.LastName != value)
                {
                    _regUser.LastName= value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand SignUpCommand{ get; }
        public DelegateCommand CloseCommand { get; }
        public DelegateCommand SignInCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}