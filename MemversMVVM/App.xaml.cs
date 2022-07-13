using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MemversMVVM.Stores;
using MemversMVVM.ViewModels;
using MemversMVVM.WindowService;
using Microsoft.Extensions.DependencyInjection;

namespace MemversMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() // 생성자 함수
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }
        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //RegisterStore _registerStore = new RegisterStore();

            //services.AddScoped<MainViewModel>();
            //services.AddScoped<LoginViewModel>();
            services.AddScoped<RegisterViewModel>();
            services.AddScoped<WindowViewModel>();

            services.AddSingleton<IRegisterStore, RegisterStore>();
            services.AddSingleton<IWindowShow, WindowShow>();

            //services.AddSingleton<IRegisterStore, RegisterStore2>();
            //services.AddScoped<인터페이스<클래스<>
            


            return services.BuildServiceProvider();
        }

        

    }
}
