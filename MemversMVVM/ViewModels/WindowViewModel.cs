using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MemversMVVM.Stores;

namespace MemversMVVM.ViewModels
{
    public class WindowViewModel : ObservableObject
    {
        private ObservableObject _selectedViewModel;
        public ObservableObject SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
         
        }
       
        public WindowViewModel()
        {
            SelectedViewModel = new LoginViewModel(this);
        }
        

     
        

    }
}
