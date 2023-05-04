namespace Application.Contracts.GBAcc.Business.POAdvancePayments.Queries.RequestResponseModel
{
    public class AdvancedPoResponseModel
    {
        public long POID { get; set; }
        public string PoNumber { get; set; }
        public int SupplierID { get; set; }
        public decimal AdvanceAmount { get; set; }
    }
}
