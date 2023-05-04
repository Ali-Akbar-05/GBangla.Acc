using Application.Common.CommonModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IDropDownService
    {
        public List<SelectListItem> DefaultDDL(bool IsInclude = true, bool isDisibled = false);
        public List<SelectListItem> DDLZeroOneYesNo(bool IsIncludeDefault = false);
        public List<SelectListItem> DDLBoleanYesNo(bool IsIncludeDefault = false);
        public List<SelectListItem> DDLBoleanActive(bool IsIncludeDefault = false);

        public List<SelectListItem> DDLZeroOneActive(bool IsIncludeDefault = false);
        public List<SelectListItem> DDLNumberDuration(int MinNumber, int MaxNumber, bool IsIncludeDefault = false);
        
        public List<SelectListItem> DDLNumberDuration(int MinNumber, int MaxNumber, int duration, bool IsIncludeDefault = false);

        public List<SelectListItem> DDLNumberDuration(decimal MinNumber, decimal MaxNumber, decimal duration, bool IsIncludeDefault = false);
        
        public List<SelectListItem> RenderDDL(List<SelectListItem> listItems, bool IsIncludeDefault = false);

        public List<DropDownItem> RenderDDLCustom(List<DropDownItem> listItems, bool IsIncludeDefault = false);


    }
}
