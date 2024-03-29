﻿//-----------------------------------------------------------------------------
// File Name   : LoginTtVM
// Author      : junlei
// Date        : 5/26/2020 8:55:48 AM
// Description : 
// Version     : 1.0.0      
// Updated     : 
//
//-----------------------------------------------------------------------------
using Prism.Mvvm;
using ThmCommon.Config;
using ThmCommon.Models;

namespace ThmTPWin.ViewModels.LoginViewModels {
    public class LoginTtVM : BindableBase, ILoginTabItm {
        public EProviderType Provider { get; } = EProviderType.TT;

        private bool _isChecked = true;
        public bool IsChecked {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }

        private string _accountName;
        public string AccountName {
            get => _ttAccount.Account;
            set {
                if (SetProperty(ref _accountName, value)) {
                    _ttAccount.Account = value;
                }
            }
        }

        private readonly TTLoginCfg _ttAccount;
        public LoginTtVM(TTLoginCfg ttAccount) {
            _ttAccount = ttAccount;
        }

        public bool Check(out string err) {
            err = string.Empty;

            return true;
        }
    }
}
