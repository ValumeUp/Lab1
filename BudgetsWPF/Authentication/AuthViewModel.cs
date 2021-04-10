using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetsWPF.Navigation;
using Prism.Mvvm;

namespace BudgetsWPF.Authentication
{
    public class AuthViewModel:NavigationBase<AuthNavTypes>, INavigatable<MainNavTypes>

    {
        private Action _signInSuccess;
        
        public AuthViewModel(Action SignInSuccess)
        {
            _signInSuccess = SignInSuccess;
            Navigate(AuthNavTypes.SignIn);
        }

        

        protected override INavigatable<AuthNavTypes> CreateViewModel(AuthNavTypes type)
        {
            if (type == AuthNavTypes.SignIn)
            {
                return new SignInViewModel(() => Navigate(AuthNavTypes.SignUp), _signInSuccess);
            }
            else
            {
                return new SignUpViewModel(() => Navigate(AuthNavTypes.SignIn));
            }
        }

        public MainNavTypes Type {
            get
            {
                return MainNavTypes.Auth;
            }
             }
        public void ClearSensitiveData()
        {
            CurrentViewModel.ClearSensitiveData();
        }
    }
}
