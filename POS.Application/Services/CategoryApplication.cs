using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Commons.Bases;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Application.Interfaces;
using POS.Application.Validators.Category;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IunitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CategoryValidator _validationRules;
        public CategoryApplication(IunitOfWork unitOfWork, IMapper mapper, CategoryValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<BaseEntityResponse<CategoryResponseDTO>>> ListCategory(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<CategoryResponseDTO>>();
            var categories = await _unitOfWork.category.ListCategories(filters);
            if(categories != null)
            {
                response.IsSuccess= true;
                response.Data = _mapper.Map<BaseEntityResponse<CategoryResponseDTO>>(categories);
                response.Message = ReplyMessage.Message_query;
            }
            else
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.Message_query_empty;

            }
            return response;
        }
        public async Task<BaseResponse<IEnumerable<CategorySelectResponseRequest>>> ListSelectCategories()
        {
            var response = BaseResponse<IEnumerable<CategorySelectResponseRequest>>();
            var categories = await _unitOfWork.category.ListSelectCategories();
            if(categories != null)
            {
                response.IsSuccess= true;
                response.Data = _mapper.Map < IEnumerable<CategorySelectResponseRequest>(categories);
                response.Message = ReplyMessage.Message_query;
            }
            else
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.Message_query_empty;
            }
            return response;
        }
        public async Task<BaseResponse<CategoryResponseDTO>> CategoryById(int CategoryId)
        {
            var response = new BaseResponse<CategoryResponseDTO>();
            var categories = await _unitOfWork.category.CategoryById(CategoryId);
            if(categories != null)
            {
                response.IsSuccess= true;
                response.Data = _mapper.Map<CategoryResponseDTO>(categories);
                response.Message = ReplyMessage.Message_query;
            }
            else
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.Message_query_empty;
            }
            return response;
        }
        public async Task<BaseResponse<bool>> RegisterCategory(CategoryRequest category)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(category);
            if(!validationResult.IsValid)
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.Message_validate;
                response.Errors = validationResult.Errors;
                return response;

            }
            var categories = _mapper.Map<Category>(requestDto);
            response.Data = await _unitOfWork.category.RegisterCategory(categories);

            if (response.Data)
            {
                response.IsSuccess= true;
                response.Message = ReplyMessage.Message_save;
            }
            else
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.Message_failed;
            }
            return response;

        }

        public async Task<BaseResponse<bool>> EditCategory(int CategoryId, CategoryRequest category)
        {
            var response = new BaseResponse<bool>();
            var categoryEdit = await CategoryById(CategoryId);
            if(categoryEdit.Data is null) {
            
                response.IsSuccess = false; 
                response.Message= ReplyMessage.Message_query_empty;
            }
            var categories = _mapper.Map<Category>(requestDto);
            categories.CategoryId = CategoryId;

            response.Data = await _unitOfWork.category.EditCategory(categories);

            if(response.Data)
            {
                response.IsSuccess= true;
                response.Message = ReplyMessage.Message_update;
                
            }
            else
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.Message_failed;
            }
            return response;
        }


        public async Task<BaseResponse<bool>> RemoveCategory(int CategoryId)
        {
            var response = BaseResponse<bool>();
            var categories = await CategoryById(CategoryId);
            if(categories.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.Message_query_empty;
                return response;
            }
            response.Data = await _unitOfWork.category.RemoveCategory(CategoryId);

            if(response.Data)
            {
                response.IsSuccess= true;
                response.Message = ReplyMessage.Message_delete;
            }
            else
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.Message_failed;
            }
            return response;
        }
    }
}
