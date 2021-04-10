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
            InitializeComponent();
            DataContext = new MainViewModel();
            //Content = new AuthView(GoToWalletsView);
        }

        //public void GoToWalletsView()
        //{
        //    Content = new WalletsView();
        //}
    }
}
