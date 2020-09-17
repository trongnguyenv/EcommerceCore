using City_Shop.ViewModel.Common;

namespace City_Shop.ViewModel.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
