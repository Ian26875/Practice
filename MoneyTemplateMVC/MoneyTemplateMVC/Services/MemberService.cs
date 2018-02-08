using MoneyTemplateMVC.Models;
using MoneyTemplateMVC.Repositories.Interface;
using MoneyTemplateMVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MoneyTemplateMVC.Services
{
    public class MemberService : IMemberService
    {
        private IGeneralRepository<Member> _memberRepository;

        public MemberService(IGeneralRepository<Member> memberRepository)
        {
            this._memberRepository = memberRepository;
        }

        public bool Login(string account, string password)
        {
            var source= this._memberRepository
                .GetAll()
                .SingleOrDefault(x => x.Account == account);
            if (source == null)
            {
                return false;
            }
            var isSame=Crypto.VerifyHashedPassword(source.Password, password);
            return isSame;
        }
    }
}