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
        public async Task<SeUser> CheckPassword(string passwword)
        {
            return await FindByCondition(u => u.password.Equals(passwword)).FirstOrDefaultAsync();
        }

        public Task<string> CheckUserLogin(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SeUser>> FindAllData()
        {
            List<SeUser> datas = new List<SeUser>();

            datas = await Task.Run(()=> FindAll().Where(u => u.activeflg.Equals("A")).ToList());
            return datas;
        }

        public async Task<SeUser> FindById(int id)
        {
            return await FindByCondition(u => u.id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<SeUser> FindByUsername(string username)
        {
            return await FindByCondition(u => u.username.Equals(username)).FirstOrDefaultAsync();
        }
    }
}
