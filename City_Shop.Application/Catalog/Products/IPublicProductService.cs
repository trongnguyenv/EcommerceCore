using City_Shop.ViewModel.Catalog.Products;
using City_Shop.ViewModel.Common;
using System.Threading.Tasks;

namespace City_Shop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
    }
}