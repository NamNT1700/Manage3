using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.OrgTitle;
using Manage.Model.DTO.Title;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuTitleRepository : RepositoryBase<HuTitle>, IHuTitleRepository
    {
        public HuTitleRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<ListOrgTitle>> FindAllOrgAndTitleById(List<ListOrgTitle> listOrgTitles)
        {
            foreach (ListOrgTitle listOrgTitle in listOrgTitles)
            {
                HuTitle huTitle = await FindById(listOrgTitle.TitleId);
                listOrgTitle.Title = huTitle.Name;
            }
            return listOrgTitles;
        }

        public async Task<HuTitle> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
