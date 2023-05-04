using Application.Common.Mappings;
using Application.Contracts.GBAcc.Setups.BankContactInfos.Commands.DataTransferModel;
using AutoMapper;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Commands.DataTransferModel
{
   public class CBM_BankAccountDTM:IMapFrom<CBM_BankAccount>
    {
        public int BAccountID { get; set; }
        public string BAccountName { get; set; }
        public int TypeID { get; set; }
        public int? CurrencyID { get; set; }
        public int? BranchID { get; set; }
        public decimal? Limit { get; set; }
        public string LRemarks { get; set; }
        public BankContactInfoDTM BankContactInfo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CBM_BankAccountDTM, CBM_BankAccount>();
        }
    }
}
