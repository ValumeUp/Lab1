using System;
using System.Windows;
using System.Windows.Controls;

namespace BudgetsWPF.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        private SignUpViewModel _viewModel;
        public SignUpView( Action goToSignIn)
        {
            _viewModel = new SignUpViewModel(goToSignIn);
            InitializeComponent();
            this.DataContext = _viewModel;
           
        }


        private void TbPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = TbPassword.Password;
        }
    }
}
