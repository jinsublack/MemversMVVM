using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Data.SQLite;
using MemversMVVM.Models;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using System.Windows.Automation.Provider;
using MemversMVVM.Views;
using MemversMVVM.Stores;
using Microsoft.Extensions.DependencyInjection;
using MemversMVVM.WindowService;
using System.Threading;

namespace MemversMVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        private readonly IRegisterStore registerStore = App.Current.Services.GetRequiredService<IRegisterStore>();

        private readonly IWindowShow win = App.Current.Services.GetRequiredService<IWindowShow>();
        private readonly RegisterViewModel registerView = new RegisterViewModel();

        private readonly DBControl DB = new DBControl();

        private readonly WindowViewModel winViewModel;


        #region Property

        private string _selectSearch;
        public string SelectSearch      //선택
        {
            get => _selectSearch;
            set => SetProperty(ref _selectSearch, value);
        }
        private string _search;
        public string Search            //검색
        {
            get => _search;
            set => SetProperty(ref _search, value);
        }
        private RelayCommand _searchclick;
        public RelayCommand SearchClick
        {
            get
            {
                return _searchclick = new RelayCommand(OnClickSearch);
            }
        }

        private MemberInfo selectedCustomer;        //선택그리드 바인딩
        public MemberInfo SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                // 그리드 컨트롤이 선택이 되었을때 실행.
                SetProperty(ref selectedCustomer, value);

                MemberInfo info = new MemberInfo();
                if (value != null)
                {
                    info.Id = selectedCustomer.Id;
                    info.Name = selectedCustomer.Name;
                    info.Birth = selectedCustomer.Birth;
                    info.Gender = selectedCustomer.Gender;
                    info.Phone = selectedCustomer.Phone;
                    this.registerStore.RegisterMember(info);
                }

            }
        }

        private List<MemberInfo> _customerData = new List<MemberInfo>();        //그리드 바인딩
        public List<MemberInfo> CustomerData
        {
            get => _customerData;
            set
            {
                SetProperty(ref _customerData, value);
            }
        }
        #endregion

        #region Button
        // 버튼 이벤트
        private RelayCommand _deleteclick;
        public RelayCommand DeleteClick
        {
            get
            {
                return _deleteclick = new RelayCommand(OnClickDelete);
            }
        }
        private RelayCommand _register;
        public RelayCommand RegisterClick
        {
            get
            {
                return _register = new RelayCommand(OpenRegister);
            }
        }

        private RelayCommand _loadedView;
        public RelayCommand LoadedView
        {
            get
            {
                return _loadedView = new RelayCommand(OnGridView);
            }
        }

        private RelayCommand _imageView;
        public RelayCommand ImaageViewClick
        {
            get
            {
                return _imageView = new RelayCommand(OnClickeImageView);
            }
        }



        #endregion

        #region Event


        public MainViewModel()
        {
            registerStore.EventView += RegisterStore_MemberView;

        }
        private void RegisterStore_MemberView()
        {
            OnGridView();
        }
        #endregion

        #region Function

        private void OnClickeImageView()
        {

        }

        private void OnClickDelete()
        {
            //해당 열 ID
            DB.DeleteData(selectedCustomer.Id);
            OnGridView();
            registerStore.RegisterClear();
        }

        private void OnClickSearch()
        {
            CustomerData = DB.SearchData(SelectSearch, Search);
        }

        public void OnGridView()
        {
            CustomerData = DB.ViewData();
        }



        public void OpenRegister()
        {
            win.ShowWindow(registerView);


            //win.ShowDialog(registerView);
            //IWindowService win;
            //win.ShowWindow(RegisterView);






            //windowService.ShowWindow(new RegisterViewModel());

            //var window = new RegisterView();

            //bool isOpen = IsOpen(window);

            //if( isOpen == false)
            //Window window = Application.LoadComponent(new Uri(RegisterViewModel));

            //Application.Current.Windows.Cast<Window>().Contains(Window) == false;

            //window.Show();

            //var window = App.Current.Windows.OfType<RegisterView>().FirstOrDefault(x => x.ContextMenu?.GetType() == RegisterView.GetType());



            //window.Show();



            //var window = RegisterView();
            //bool check = window.IsActive;

            //if(check == false)
            //    window.Show();

            //Window AAA = Application.LoadComponent(new Uri("RegisterView.xaml", UriKind.Relative));
            //AAA.Visibility = AAA.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible; ;

            //if (RegisterView == null)
            //    return;

            //var window = App.Current.Windows.OfType<RegisterView>().FirstOrDefault(x => x.Content?.GetType() == RegisterView.GetType());
            //Application.Current.Windows.OfType<RegisterView>().FirstOrDefault();

            //var window = App.Current.Windows.OfType<RegisterView>().FirstOrDefault(x=>x.Content?.GetType())

            //window.Visibility = 

        }

        //public static bool IsWindowOpen<T>(string name= "") where T : Window
        //{
        //    return string.IsNullOrEmpty(name)
        //        ? Application.Current.Windows.OfType<T>().Any()
        //        : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        //}

        //public static bool IsOpen(RegisterView window)
        //{
        //    return Application.Current.Windows.Cast<RegisterView>().Any(x => x == window);
        //}


        // 중복실행방지 - Mutex 활용

        #endregion
    }

}

