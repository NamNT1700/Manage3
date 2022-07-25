using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Model.DTO.Title;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuTitleRepository : IRepositoryBase<HuTitle>
    {
        public Task<HuTitle> FindByCode(string code);
        public Task<HuTitle> FindById(int id);
        public Task<List<HuTitle>> GetAll();
    }
}
