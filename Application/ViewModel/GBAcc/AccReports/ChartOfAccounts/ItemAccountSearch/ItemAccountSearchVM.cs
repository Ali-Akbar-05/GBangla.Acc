using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.AccReports.ChartOfAccounts.ItemAccountSearch
{
    public class ItemAccountSearchVM
    {
        [Required]
        [Display(Name = "Category")]
        public int AccCategoryID { get; set; }
        [Required]
        [Display(Name = "Sub Category")]
        public int SubCategoryID { get; set; }
        [Required]
        [Display(Name = "Broad Group")]
        public int BroadGroupID { get; set; }
        [Required]
        [Display(Name = "Narrow Group")]
        public int NarrowGroupID { get; set; }
        [Required]
        [Display(Name = "Identityfication")]
        public int IdentificationID { get; set; }
        [Required]
        [Display(Name = "Item")]
        public int ItemID { get; set; }
        public string GLStartDate { get; set; }
        public string GLEndDate { get; set; }
        [Required]
        [Display(Name = "Report Type")]
        public int ReportTypeID { get; set; }
        public List<SelectListItem> DDLAccCategory { get; set; }
        public List<SelectListItem> DDLAccSubCategory { get; set; }
        public List<SelectListItem> DDLAccBroadGroup { get; set; }
        public List<SelectListItem> DDLAccNarroGroup { get; set; }
        public List<SelectListItem> DDLAccIdentification { get; set; }
        public List<SelectListItem> DDLAccItem { get; set; }
        public List<SelectListItem> DDLReportType { get; set; }
    }
}
