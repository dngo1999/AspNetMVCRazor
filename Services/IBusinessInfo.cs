using AspNetMVCRazor.Models.BusinessInfo;
using System.Collections.Generic;

namespace AspNetMVCRazor.Controllers
{
    public interface IBusinessInfo
    {
        BusinessInfo Add(BusinessInfo model);
        IEnumerable<BusinessInfo> GetAllBusinessInfo();
        IEnumerable<Address> GetAllAddresses();
        BusinessInfo GetById(int id);
    }
}