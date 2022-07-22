using Manage.Model.Context;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Repository.Repository
{
    public class UserRepository : RepositoryBase<SeUser>,IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<bool> CheckPassword(SeUser user,string password)
        {
            if (user.password == password)
                return true;
            return false;
        }

        public async Task<string> CheckUserLogin(string username, string password)
        {
            SeUser seUser = await FindByUsername(username);
            if (seUser == null)
                return "wrong username";
            bool isTrue =  await CheckPassword(seUser,password);
            if (isTrue == false)
                return "wrong password";
            return null;
        }

        public async Task<List<SeUser>> FindAllData()
        {
            List<SeUser> datas = new List<SeUser>();

            datas = await Task.Run(()=> FindAll().Where(u => u.activeflg.Equals("A")).ToList());
            return datas;
        }
        public async Task<SeUser> FindByUsername(string username)
        {
            return await FindByCondition(u => u.username.Equals(username)).FirstOrDefaultAsync();
        }
    }
}
