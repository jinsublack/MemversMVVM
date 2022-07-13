using MemversMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemversMVVM.Stores
{
    public class RegisterStore : IRegisterStore
    {
        public event Action<MemberInfo> EventMemberRegister;
        public event Action EventView;
        public event Action EventClear;

        public void RegisterMember(MemberInfo info)
        {
            EventMemberRegister?.Invoke(info);
        }
        
        public void RegisterView()
        {
            EventView?.Invoke();
        }
        public void RegisterClear()
        {
            EventClear?. Invoke();
        }


    }

}
