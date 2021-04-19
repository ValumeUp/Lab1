﻿using BudgetsWPF.Navigation;
using lab1_1;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BudgetsWPF.Wallets
{
    public class AddWalletViewModel : BindableBase, INavigatable<MainNavTypes>
    {
        private WalletService _service;

        private Action _gotoWallets;
        private Wallet _wallet;
        private bool _isEnabled = true;

        //public Wallet FromWallet { get { return _wallet; } }


        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged();
            }
        }



        public string Name
        {
            get
            {
                return _wallet.Name;
            }
            set
            {
                _wallet.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get
            {
                return _wallet.Description;
            }
            set
            {
                _wallet.Description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        public decimal Balance
        {
            get
            {
                return _wallet.Balance;
            }
            set
            {
                _wallet.Balance = value;
                RaisePropertyChanged(nameof(Balance));
            }
        }

        public Currency? MainCurrency
        {
            get
            {
                return _wallet.MainCurrency;
            }
            set
            {
                _wallet.MainCurrency = value;
                RaisePropertyChanged(nameof(MainCurrency));
            }
        }


        public AddWalletViewModel(Action gotoWallets)
        {
            _wallet = new Wallet(Guid.NewGuid(), "", 0.0m, "", Currency.USD,
                new ObservableCollection<Transaction>(), new ObservableCollection<Category>(), new List<Guid>());

            _service = new WalletService();
            _gotoWallets = gotoWallets;
            WalletViewCommand = new DelegateCommand(_gotoWallets);
            AddWalletCommand = new DelegateCommand(AddWallet);
        }

        public DelegateCommand WalletViewCommand { get; }
        public DelegateCommand AddWalletCommand { get; }


        //TODO: MAKE ADDING WALLET REALLY ASYNC
        public async void AddWallet()
        {


            try
            {
                IsEnabled = false;

                if (String.IsNullOrWhiteSpace(_wallet.Name))
                {
                    MessageBox.Show("Name of wallet is empty.");
                    return;
                }

                Wallet addWallet = new Wallet(CurrentInformation.User.Guid, _wallet.Name, _wallet.Balance, _wallet.Description, _wallet.MainCurrency,
                    _wallet.Transactions, _wallet.Categories, _wallet.CoOwnersGuid);
                await Task.Run(() => _service.AddOrUpdateWalletAsync(addWallet));
                WalletsViewModel.Wallets.Add(new WalletDetailsViewModel(addWallet));
                CurrentInformation.User.Wallets.Add(addWallet);
                MessageBox.Show($"Wallet {addWallet.Name} added to the list of wallets!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Adding wallet failed {ex.Message}");
            }
            finally // is done independently from exception
            {
                IsEnabled = true;
            }


        }





        public MainNavTypes Type
        {
            get
            {
                return MainNavTypes.AddWallet;
            }
        }

        public void ClearSensitiveData()
        {
            _wallet.Name = "";
            _wallet.Balance = 0.0m;
            _wallet.Description = "";
            _wallet.MainCurrency = Currency.USD;
        }

    }
}
