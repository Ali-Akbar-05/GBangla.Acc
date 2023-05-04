using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Business;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
    public class CBMChequeBookService : ICBMChequeBookService
    {
        private readonly ICBMChequeBookRepository _cbmChequeBookRepository;
        private readonly ICBMChequeRepository cBMChequeRepository;

        public CBMChequeBookService(ICBMChequeBookRepository cbmChequeBookRepository, ICBMChequeRepository _cBMChequeRepository)
        {
            _cbmChequeBookRepository = cbmChequeBookRepository;
            cBMChequeRepository = _cBMChequeRepository;
        }
        public async Task<int> AvailableCheque(int AccountID, CancellationToken cancallationToken)
        {
            return await _cbmChequeBookRepository.AvailableCheque(AccountID,cancallationToken);
        }

        public async Task<RResult> CreateChequeBook(List<CBMChequeBookDTM> model, CancellationToken cancellationToken)
        {
            var result = new RResult();
            foreach (var cheqBook in model)
            {
                var chequeBook = new CBMChequeBook()
                {
                    AccountID= cheqBook.AccountID,
                    Prefix= cheqBook.Prefix,
                    SeriesStart= cheqBook.SeriesStart,
                    SeriesEnd= cheqBook.SeriesEnd,
                    SerialStatus= "Unused",
                };
                result =   await _cbmChequeBookRepository.CreateChequeBook(chequeBook);
                var chequeBookID = result.statusCode;
                var listOfCheque = new List<CBMCheque>();
                if (result.result==1)
                {
                    for (int seriesStart = Convert.ToInt32(cheqBook.SeriesStart); seriesStart <= Convert.ToInt32(cheqBook.SeriesEnd); seriesStart++)
                    {
                        var chque = new CBMCheque()
                        {
                            AccountID = cheqBook.AccountID,
                            ChequeAmount = 0,
                            ChequeBookID = chequeBookID,
                            ChequeNum = seriesStart.ToString(),
                            ChequeComments = "None",
                            SignStatus = 0,
                            ChequeStatusID=1
                        };
                        listOfCheque.Add(chque);
                    }
                    result= await cBMChequeRepository.SaveCBMChequeList(listOfCheque);
                }
              

            }
            return result;
           
        }

        public async Task<List<CBMChequeBookResponseModel>> GetChequeBookList(ChequeBookRequestModel model, CancellationToken cancellationToken)
        {
            return await _cbmChequeBookRepository.GetChequeBookList(model,cancellationToken);
        }
    }
}
