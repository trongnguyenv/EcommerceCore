using City_Shop.ViewModel.Catalog.ProductImages;
using City_Shop.ViewModel.Catalog.Products;
using City_Shop.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace City_Shop.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<ProductViewModel> GetById(int productId, string languageId);

        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewCount(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest productImage);

        Task<List<ProductImageViewModel>> GetListImages(int productId);
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
    }
}