using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class StoreDetailsViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Store name is required")]
        [Display(Name = "Store Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string storename { get; set; }
        [Required(ErrorMessage = "- Select Radious -")]
        [Display(Name = "Delivery Radius")]
        public int radiusid { get; set; }

        [Required(ErrorMessage = "Country is required")]

        [Display(Name = "Select Country")]
        public int countryid { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "Select State")]
        public int stateid { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "Select City")]
        public int cityid { get; set; }

        [Required(ErrorMessage = "Delivery Time is required")]
        [Display(Name = "Estimated Delivery Time")]
        public int deliverytimeid { get; set; }
        [Required(ErrorMessage = "Minimum Amount is required")]
        [Display(Name = "Order Minimum Amount")]
        public decimal orderMinAmount { get; set; }


        [Display(Name = "Packaging Charges")]
        public decimal packagingCharges { get; set; }
        [Display(Name = "Banner Photo")]
        public IFormFile storeBannerPhoto { get; set; }
        public string  storeBannerPhotoName { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Store Time")]
        public string storetime { get; set; }


        public Boolean isdeleted { get; set; }
        [Display(Name = "Promo Code")]
        public string promocode { get; set; }
        [Display(Name = "Discount")]
        public decimal discount { get; set; } = 0;
        [Display(Name = "Account No.")]
        public string accountno { get; set; }
        [Display(Name = "Bank Name")]

        public string bankname { get; set; }
        [Display(Name = "Bank Location")]
        public string banklocation { get; set; }
        [Display(Name = "IFSC Code")]
        public string ifsccode { get; set; }
        [Display(Name = "Store Status")]
        public string status { get; set; }

        [Display(Name = "Commission( % ) ")]

        public decimal adminCommissionPer { get; set; }

        [Display(Name = "Tax Status")]
        public string taxstatus { get; set; }
        [Display(Name = "Tax Percentage")]
        public decimal taxstatusPer { get; set; } = 0;


        public string FromTime { get; set; }
        public string ToTime { get; set; }
    }
}
