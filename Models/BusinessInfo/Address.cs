
using System.ComponentModel.DataAnnotations;

namespace AspNetMVCRazor.Models.BusinessInfo
{
    public class Address
    {
        [Display(Name = "Street Number:")]
        public int StreetNumber { get; set; }
        [Display(Name = "Street Name:")]
        public string StreetName { get; set; }

    }
}