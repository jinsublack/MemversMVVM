using MemversMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemversMVVM.Stores
{
    public interface IRegisterStore
    {
        event Action<MemberInfo> EventMemberRegister;
        event Action EventView;
        event Action EventClear;

        void RegisterMember(MemberInfo info);
        void RegisterView();
        void RegisterClear();
        

    }
}
