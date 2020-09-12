using System.Collections.Generic;

namespace City_Shop.ViewModel.Common
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}