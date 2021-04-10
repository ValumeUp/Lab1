
using System.Collections.ObjectModel;
using BudgetsWPF.Authentication;
using BudgetsWPF.Navigation;
using Models.Wallets;
using Prism.Mvvm;
using Services;

namespace BudgetsWPF.Wallets
{
    public class WalletsViewModel:BindableBase, INavigatable<MainNavTypes>
    {
        private WalletService _service;
        private WalletDetailsViewModel _currentWallet;
        public ObservableCollection<WalletDetailsViewModel> Wallets { get; set; }

        public WalletDetailsViewModel CurrentWallet {
            get
            {
                return _currentWallet;
            }

            set
            {
                _currentWallet = value;
                RaisePropertyChanged();
            } }
        public MainNavTypes Type {
            get
            {
                return MainNavTypes.Wallets;
            }
        }

        public WalletsViewModel()
        {
            _service = new WalletService();
            Wallets = new ObservableCollection<WalletDetailsViewModel>();
            foreach (var wallet in _service.GetWallets())
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }
        }
        public void ClearSensitiveData()
        {
            
        }
    }
}
