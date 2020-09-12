using City_Shop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace City_Shop.ViewModel.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
