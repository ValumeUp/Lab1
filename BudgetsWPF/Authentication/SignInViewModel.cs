﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using BudgetsWPF.Navigation;
using BudgetsWPF.Wallets;
using lab1_1;
using Models.Users;
using Prism.Commands;
using Services;

namespace BudgetsWPF.Authentication
{
    public class SignInViewModel : INotifyPropertyChanged, INavigatable<AuthNavTypes>
    {
        private AuthenticationUser _authUser = new AuthenticationUser();
        private Action _gotoSignUp;
        private Action _gotoWalletsView;
        private bool _isEnabled = true;
        private MainNavTypes _type;

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


        public string Login
        {
            get
            {
                return _authUser.Login;
            }
            set
            {
                if (_authUser.Login != value)
                {
                    _authUser.Login = value;
                    OnPropertyChanged(nameof(Login));
                    SignInCommand.RaiseCanExecuteChanged();
                }

            }
        }

        public string Password
        {
            get
            {
                return _authUser.Password;
            }
            set
            {
                if (_authUser.Password != value)
                {
                    _authUser.Password = value;
                    OnPropertyChanged(nameof(Password));
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand SignInCommand { get; }
        public DelegateCommand CloseCommand { get; }
        public DelegateCommand SignUpCommand { get; }


        public SignInViewModel(Action gotoSignUp, Action gotoWalletsView)
        {
            SignInCommand = new DelegateCommand(SignIn, IsSignInEnabled);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
            _gotoSignUp = gotoSignUp;
            SignUpCommand = new DelegateCommand(_gotoSignUp);
            _gotoWalletsView = gotoWalletsView;

        }

        private bool IsSignInEnabled()
        {

            return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password);
        }

        private async void SignIn()
        {
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Login or password is empty");
            }
            else
            {

                var authService = new AuthenticationService();
                User user = null;
                try
                {
                    IsEnabled = false;
                    user = await Task.Run(() => authService.Authenticate(_authUser));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign in failed {ex.Message}");
                    return;
                }
                finally // is done independently from exception
                {
                    IsEnabled = true;
                }
                MessageBox.Show($"Sign in was successful for user {user.FirstName} {user.LastName}");
                _gotoWalletsView.Invoke();
                WalletsViewModel.UpdateWalletsCollection(); // here collection of wallets for concrete user is updated because constuctor does it only one time
            }
        }

        public AuthNavTypes Type
        {
            get
            {
                return AuthNavTypes.SignIn;
            }
        }



        public void ClearSensitiveData()
        {
            Password = "";
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}