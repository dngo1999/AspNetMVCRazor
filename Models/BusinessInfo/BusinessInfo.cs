using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetMVCRazor.Models.BusinessInfo
{
    public class BusinessInfo
    {
        public int BusinessInfoId { get; set; }
        [Display(Name = "Business Name:")]
        public string BusinessInfoName { get; set; }
        [Display(Name = "Public or Private:")]
        public int BusinessInfoPublic { get; set; }
    }

}