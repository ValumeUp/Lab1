using BudgetsWPF.Authentication;
using BudgetsWPF.Navigation;
using BudgetsWPF.Wallets;

namespace BudgetsWPF
{
    public class MainViewModel:NavigationBase<MainNavTypes>

    {
        
        public MainViewModel()
        {
            Navigate(MainNavTypes.Auth);
        }

        

        protected override INavigatable<MainNavTypes> CreateViewModel(MainNavTypes type)
        {
            if (type == MainNavTypes.Auth)
            {
                return new AuthViewModel(() => Navigate(MainNavTypes.Wallets));
            }
            else
            {
                return new WalletsViewModel();
            }
        }
    }
}
