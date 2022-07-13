using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MemversMVVM.Models;
using MemversMVVM.Stores;
using MemversMVVM.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MemversMVVM.ViewModels
{
    public class RegisterViewModel : ObservableObject
    {
        private readonly IRegisterStore registerStore = App.Current.Services.GetRequiredService<IRegisterStore>();

        #region Property
        private int id;
        public int ID
        {
            get => this.id;
            set => SetProperty(ref this.id, value);
        }

        private string name = "";
        public string Name
        {
            get => this.name;
            set => SetProperty(ref this.name, value);
        }
        private string birth = "";

        public string Birth
        {
            get => this.birth;
            set => SetProperty(ref this.birth, value);
        }
        private string phone = "";

        public string Phone
        {
            get => this.phone;
            set => SetProperty(ref this.phone, value);
        }
        private string gender;
        public string Gender
        {
            get => this.gender;
            set => SetProperty(ref this.gender, value);
        }

        #endregion

      

        #region Button

        private RelayCommand insertClick;
        public RelayCommand InsertClick
        {
            get
            {
                return this.insertClick = new RelayCommand(this.OnClickInsert);
            }
        }
        private RelayCommand modifyClick;
        public RelayCommand ModifyClick
        {
            get
            {
                return this.modifyClick = new RelayCommand(this.OnClickModify);
            }
        }
        
        #endregion



        #region Event


        public RegisterViewModel()
        {
            registerStore.EventMemberRegister += RegisterStore_SelectMember;
            registerStore.EventClear += RegisterStore_Clear;
        }

        private void RegisterStore_SelectMember(MemberInfo obj)
        {
            ID = obj.Id;
            Name = obj.Name;
            Birth = obj.Birth;
            Gender =obj.Gender;
            Phone = obj.Phone;
        }
        private void RegisterStore_Clear()
        {
            Clear();
        }

        #endregion


        #region Function

        private DBControl DB = new DBControl();

        private void OnClickInsert()
        {
            DB.InsertData(Name, Birth, Gender, Phone);
            Clear();
        
            this.registerStore.RegisterView();
        }

        
        private void OnClickModify()
        {
            DB.ModifyData(ID, Name, Birth, Gender, Phone);
            Clear();
            this.registerStore.RegisterView();
        }

        public void Clear()
        {
            Name = "";
            Phone = "";
            Birth = "";
            Gender = "";
        }

      


        #endregion
    }
}
