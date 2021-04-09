using System;
using System.Windows;
using System.Windows.Controls;

namespace BudgetsWPF.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : UserControl
    {
        private SignInViewModel _viewModel;
        public SignInView(Action goToSighUp, Action goToWallets)
        {
            InitializeComponent();
            _viewModel = new SignInViewModel(goToSighUp, goToWallets);
           
            this.DataContext = _viewModel;
           
        }


        private void TbPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = TbPassword.Password;
        }
    }
}
