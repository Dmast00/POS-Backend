using POS.Application.Commons.Bases;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;

namespace POS.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryResponseDTO>>> ListCategory(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<CategorySelectResponseRequest>>> ListSelectCategories();
        Task<BaseResponse<CategoryResponseDTO>> CategoryById(int CategoryId);
        Task<BaseResponse<bool>> RegisterCategory(CategoryRequest category); 
        Task<BaseResponse<bool>> EditCategory(int CategoryId,CategoryRequest category);
        Task<BaseResponse<bool>> RemoveCategory(int CategoryId);
    }
}
