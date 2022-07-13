using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MemversMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MemversMVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowView : Window
    {
        public WindowView()
        {
            InitializeComponent();

            this.DataContext = App.Current.Services.GetService<WindowViewModel>();

            //this.DataContext = App.Current.Services.GetService<MemberList>();    
        }

    }

}




