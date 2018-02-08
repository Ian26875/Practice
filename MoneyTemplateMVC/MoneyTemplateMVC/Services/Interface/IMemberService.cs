using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTemplateMVC.Services.Interface
{
    public interface IMemberService
    {
        bool Login(string account, string password);
    }
}
