﻿//-----------------------------------------------------------------------------
// File Name   : PasswordChangeVM
// Author      : junlei
// Date        : 1/14/2021 11:55:03 AM
// Description : 
// Version     : 1.0.0      
// Updated     : 
//
//-----------------------------------------------------------------------------
using Prism.Mvvm;
using System.Threading.Tasks;
using System.Windows.Media;
using ThmServerAdapter;
using ThmTPWin.Controllers;

namespace ThmTPWin.ViewModels.LoginViewModels {
    internal class PasswordChangeVM : BindableBase {
        private string _userId;
        public string CurUserId {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _curPwd;
        public string CurPwd {
            get => _curPwd;
            set => SetProperty(ref _curPwd, value);
        }

        private string _newPwd;
        public string NewPwd {
            get => _newPwd;
            set {
                if (SetProperty(ref _newPwd, value)) {
                    if (_newPwd.Length != 10 || _newPwd == _curPwd) {
                        NewPwdBoardColor = Brushes.Red;
                    }
                    else {
                        NewPwdBoardColor = _defaultColor;
                    }
                }
            }
        }

        private string _confirmPwd;
        public string ConfirmPwd {
            get => _confirmPwd;
            set {
                if (SetProperty(ref _confirmPwd, value)) {
                    ConfirmPwdBoardColor = _confirmPwd != _newPwd ? Brushes.Red : _defaultColor;
                }
            }
        }

        private Brush _newPwdBoardColor;
        public Brush NewPwdBoardColor {
            get => _newPwdBoardColor;
            set => SetProperty(ref _newPwdBoardColor, value);
        }

        private Brush _confirmPwdBoardColor;
        public Brush ConfirmPwdBoardColor {
            get => _confirmPwdBoardColor;
            set => SetProperty(ref _confirmPwdBoardColor, value);
        }

        private readonly Brush _defaultColor;
        public PasswordChangeVM(Brush defaultColor) {
            _defaultColor = defaultColor;
            _newPwdBoardColor = defaultColor;
            _confirmPwdBoardColor = defaultColor;

            //CurUserId = ConfigHelper.LoginCfg.TitanLogin.Account;
        }

        public async Task<string> ChangePasswordAsync() {
            return await ThmClient.ChangePasswordAsync(ThmCommon.Models.EProviderType.TITAN, _curPwd, _newPwd);
        }
    }
}
