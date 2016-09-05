using NJLFramework.Base;
using NJLFramework.Database;
using NJLFramework.Model.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NJLFramework.DomainService.Permission
{
    public class CompanyService:IDomainService
    {
        EntityFrameworkRepository<SysCompany> _companyRep;

        public CompanyService(EntityFrameworkRepository<SysCompany> companyRep)
        {
            _companyRep = companyRep;
        }

        /// <summary>
        /// 按条件查询公司
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<SysCompany> Find(Expression<Func<SysCompany,bool>> predicate)
        {
            return _companyRep.Find(predicate).ToList();
        }
    }
}
