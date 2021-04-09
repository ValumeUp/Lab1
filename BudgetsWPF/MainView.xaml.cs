using System.Windows.Controls;
using BudgetsWPF.Authentication;
using BudgetsWPF.Wallets;

namespace BudgetsWPF
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            
            Content = new SignInView(GoToSighUp, GoToWalletsView);
        }

        public void GoToSighUp()
        {
            Content = new SignUpView(GoToSignIn);
        }
        public void GoToSignIn()
        {
            Content = new SignInView(GoToSighUp, GoToWalletsView);
        }
        public void GoToWalletsView()
        {
            Content = new WalletsView();
        }
    }
}
