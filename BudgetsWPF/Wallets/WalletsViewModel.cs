
using System.Collections.ObjectModel;
using System.ComponentModel;
using BudgetsWPF.Navigation;
using Prism.Commands;
using Prism.Mvvm;
using Services;

namespace BudgetsWPF.Wallets
{
    public class WalletsViewModel:BindableBase,INotifyPropertyChanged, INavigatable<MainNavTypes>
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
            //AddWalletCommand = new DelegateCommand(AddWallet);
            _service = new WalletService();
            Wallets = new ObservableCollection<WalletDetailsViewModel>();
            foreach (var wallet in _service.GetWallets())
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }
        }

        private void AddWallet()
        {
            var wallService = new WalletService();
            wallService.JustAdd();

        }
        public DelegateCommand AddWalletCommand { get; }
        public void ClearSensitiveData()
        {
            
        }
    }
}
