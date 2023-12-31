using AspNetMVCRazor.Models.BusinessInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AspNetMVCRazor.Controllers
{
    public class BusinessInfoService : IBusinessInfo
    {
        private readonly List<Address> addresses = new List<Address>();
        private readonly List<BusinessInfo> biz = new List<BusinessInfo>();
        private BusinessInfoDBContext db = new BusinessInfoDBContext();
        public BusinessInfoService()
        {
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            addresses.Add(new Address { StreetNumber = 123, StreetName = "Main St." });
            addresses.Add(new Address { StreetNumber = 8300, StreetName = "Ganttcress St." });
            addresses.Add(new Address { StreetNumber = 8351, StreetName = "Giverny Circle" });

            return addresses;
        }
        public IEnumerable<BusinessInfo> GetAllBusinessInfo()
        {
            var biz = from b in db.BusinessInfo
                                orderby b.BusinessInfoId
                                select b;
            return biz;
        }

        public BusinessInfo GetById(int id)
        {
            return db.BusinessInfo.Single(record => record.BusinessInfoId == id);
        }

        public BusinessInfo Add(BusinessInfo model)
        {
            model.BusinessInfoId = biz.Max(c => c.BusinessInfoId) + 1;
            biz.Add(model);
            return model;
        }

       
    }
}
