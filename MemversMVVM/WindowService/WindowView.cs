using MemversMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemversMVVM.WindowService
{
    public class WindowShow : IWindowShow
    {
        public void CloseWindow()
        {

        }
        private bool state = false;

        public void ShowWindow<T>(T viewModel)
        {
            if (viewModel == null)
                return;

            var window = App.Current.Windows.OfType<RegisterView>()
                .FirstOrDefault(x => x.Content?.GetType() == viewModel.GetType());
            if (window == null)
            {
                    window = new RegisterView { DataContext = viewModel };
                    window.Title = "회원등록";
                    window.Owner = App.Current.Windows[0];
                    window.Show();


             
                state = window.Activate();


            }



        }

        public int ShowDialog<T>(T viewModel)
        {
            if (viewModel == null)
                return 0;



            var window = App.Current.Windows.OfType<RegisterView>()
                              .FirstOrDefault(x => x.Content?.GetType() == viewModel.GetType());
            if (window == null)
            {
                window = new RegisterView { DataContext = viewModel };
                window.Title = "회원등록";
                window.Owner = App.Current.Windows[0];
                window.ShowDialog();


                return 1;

            }

            return 0;

        }

    }
}
