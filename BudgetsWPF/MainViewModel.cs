using BudgetsWPF.Authentication;
using BudgetsWPF.Navigation;
using BudgetsWPF.Wallet_categories;
using BudgetsWPF.Wallets;

namespace BudgetsWPF
{
    public class MainViewModel : NavigationBase<MainNavTypes>
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
                if (type == MainNavTypes.Wallets)
                {
                    return new WalletsViewModel(() => Navigate(MainNavTypes.Auth),
                        () => Navigate(MainNavTypes.AddWallet),
                        () => Navigate(MainNavTypes.AddCategory),
                        () => Navigate(MainNavTypes.DeleteCategory));
                }

                else if (type == MainNavTypes.AddWallet)
                {
                    return new AddWalletViewModel(() => Navigate(MainNavTypes.Wallets));
                }
                else if (type == MainNavTypes.AddCategory)
                {
                    return new AddUserCategoryViewModel(() => Navigate(MainNavTypes.Wallets));
                }
                else
                {
                    return new DeleteUserCategoryViewModel(() => Navigate(MainNavTypes.Wallets));
                }
            }

        }


    }
}
//tyhdrhthtf