namespace api_bank.domain.ModelView.BankModelView
{
    public class GetBankAllModelView
    {
        public GetBankAllModelView()
        {
            GetBanksModelView = new List<GetBankModelView>();
        }
        public List<GetBankModelView> GetBanksModelView { get; set; }
    }
}