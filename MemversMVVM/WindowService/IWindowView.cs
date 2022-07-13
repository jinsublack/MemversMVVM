using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemversMVVM.WindowService
{
    public interface IWindowShow
    {
        void ShowWindow<T>(T viewModel);
        int ShowDialog<T> (T viewModel);
        void CloseWindow();
    }
}
