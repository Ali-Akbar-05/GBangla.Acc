using Application.Common.CommonModels;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services
{
    public class DropDownService : IDropDownService
    {
        public List<SelectListItem> DDLBoleanActive(bool IsIncludeDefault = false)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> DDLBoleanYesNo(bool IsIncludeDefault = false)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> DDLNumberDuration(int MinNumber, int MaxNumber, bool IsIncludeDefault = false)
        {
            var list = new List<SelectListItem>();
            if (IsIncludeDefault == true)
            {
                list = DefaultDDL();
            }
            for (; MinNumber <= MaxNumber; MinNumber += 10)
            {
                list.Add(new SelectListItem() { Text = MinNumber.ToString(), Value = MinNumber.ToString() });
            }

            return list;
        }

        public List<SelectListItem> DDLNumberDuration(int MinNumber, int MaxNumber, int duration, bool IsIncludeDefault = false)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> DDLNumberDuration(decimal MinNumber, decimal MaxNumber, decimal duration, bool IsIncludeDefault = false)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> DDLZeroOneActive(bool IsIncludeDefault = false)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> DDLZeroOneYesNo(bool IsIncludeDefault = false)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> DefaultDDL(bool IsInclude = true, bool isDisibled = false)
        {
            var list = new List<SelectListItem>();
            if (IsInclude)
            {
                list.Add(new SelectListItem() { Text = "Please Select", Value = "", Disabled = isDisibled });
            }
            return list;
        }

        public List<SelectListItem> RenderDDL(List<SelectListItem> listItems, bool IsIncludeDefault = false)
        {
            var list = DefaultDDL(IsIncludeDefault);
            list.AddRange(listItems);
            return list;
        }

        public List<DropDownItem> RenderDDLCustom(List<DropDownItem> listItems, bool IsIncludeDefault = false)
        {
            throw new NotImplementedException();
        }
    }
}
