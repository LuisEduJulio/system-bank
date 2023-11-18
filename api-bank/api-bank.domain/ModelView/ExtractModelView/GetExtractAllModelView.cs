namespace api_bank.domain.ModelView.ExtractModelView
{
    public class GetExtractAllModelView
    {
        public GetExtractAllModelView()
        {
            GetExtractModelViews = new List<GetExtractModelView>();
        }
        public List<GetExtractModelView> GetExtractModelViews { get; set; }
    }
}