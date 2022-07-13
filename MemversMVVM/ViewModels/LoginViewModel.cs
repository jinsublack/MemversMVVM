using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemversMVVM.Models;
using System.Windows;
using System.Windows.Input;
using MemversMVVM.Views;
using Microsoft.Xaml.Behaviors;
using System.Windows.Navigation;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using MemversMVVM.Stores;

namespace MemversMVVM.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        
        private readonly WindowViewModel winViewModel;

        public LoginViewModel(WindowViewModel viewModel)
        {
            this.winViewModel = viewModel;
        }


        #region Property
        private string _loginID = "";
        public string LoginID
        {
            get => _loginID;
            set => SetProperty(ref _loginID, value);
        }
        private string _loginPW = "";
        public string LoginPW
        {
            get => _loginPW;
            set => SetProperty(ref _loginPW, value);
        }
        #endregion

        #region Button
        private RelayCommand _loginClick;
        public RelayCommand LoginClick
        {
            get
            {
                return this._loginClick = new RelayCommand(this.OnClickLogin);
            }
        }
        #endregion

        #region Function

        private MainViewModel mainView = new MainViewModel();
        public void OnClickLogin()
        {
            LoginModel lg = new LoginModel();

            lg.Login(LoginID, LoginPW);
            if (lg.LoginCheck == true)
                winViewModel.SelectedViewModel = mainView;
        }
         
        #endregion

    }
}
