using MemversMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MemversMVVM.Views
{
    /// <summary>
    /// Register.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            //this.Title = "RegisterViewModel";
            //Duplicate_execution(Title);
            InitializeComponent();

            this.DataContext = App.Current.Services.GetService<RegisterViewModel>();


        }

       


        //Mutex mutex = null;
        //private void Duplicate_execution(string mutexName)
        //{
        //    try
        //    {
        //        mutex = new Mutex(false, mutexName);
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.Current.Shutdown();
        //    }
        //    if (mutex.WaitOne(0, false))
        //    {
        //        InitializeComponent();
        //    }
        //    else
        //    {
        //        Application.Current.Shutdown();
        //    }
        //}

    }
}
