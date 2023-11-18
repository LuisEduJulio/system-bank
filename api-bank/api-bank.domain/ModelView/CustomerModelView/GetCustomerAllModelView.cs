namespace api_bank.domain.ModelView.CustomerModelView
{
    public class GetCustomerAllModelView
    {
        public GetCustomerAllModelView()
        {
            GetCustomersModelView = new List<GetCustomerModelView>();
        }
        public List<GetCustomerModelView> GetCustomersModelView { get; set; }
    }
}