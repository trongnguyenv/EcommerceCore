using City_Shop.ViewModel.Common;
using System.Collections.Generic;

namespace City_Shop.ViewModel.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}