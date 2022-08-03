using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.DTO.Organization;
using Manage.Model.DTO.OrgTitle;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuOrganizationRepository : RepositoryBase<HuOrganization>, IHuOrganizationRepository
    {
        public HuOrganizationRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<ListOrgTitle>> FindAllOrgAndTitleById(List<ListOrgTitle> listOrgTitles)
        {
            foreach (ListOrgTitle listOrgTitle in listOrgTitles)
            {
                HuOrganization huOrganization = await FindById(listOrgTitle.OrgId);
                listOrgTitle.Org = huOrganization.Name;
            }
            return listOrgTitles;
        }

        public async Task<List<ListOrganization>> FindAllOrganizationById(List<ListOrganization> listOrganizations)
        {
            foreach (ListOrganization listOrganization in listOrganizations)
            {
                HuOrganization huOrganization = await FindById(listOrganization.ParentId);
                listOrganization.Parent = huOrganization.Name;
            }
            return listOrganizations;
        }

        public async Task<HuOrganization> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
