using ELearning.Dto.V1.Request;
using ELearning.Dto.V1.Response;
using ELearning.Entities;
using ELearning.Services;
using ELearning.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Infrastructure.Implementation
{
    public class TitleRepository : ITitleServices
    {
        private IUnitOfWork unitOfWork { get; set; }
        public TitleRepository(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        public async Task<ApiResponse<List<TitleResponse>>> GetAll()
        {
            var result = await unitOfWork.TitleServices.GetAsync();

            var response = new ApiResponse<List<TitleResponse>>();
            if (result.Count > 0)
            {
                response.Success = true;
                result.ForEach(p => response.Data.Add(new TitleResponse() { ID = p.ID, Name = p.Name, IsActive = p.IsActive }));
            }
            else
            {
                response.Success = false;
                response.Message = Resource.NoRecord;
            }

            return response;
        }
        public async Task<ApiResponse<TitleResponse>> GetById(int Id)
        {
            var result = await unitOfWork.TitleServices.GetByIdAsync(Id);

            var response = new ApiResponse<TitleResponse>();

            if (result != null)
            {
                response.Success = true;
                response.Data = new TitleResponse() { ID = result.ID, Name = result.Name, IsActive = result.IsActive };
            }
            else
            {
                response.Success = false;
                response.Message = Resource.NoRecord;
            }

            return response;
        }
        public async Task<ApiResponse<TitleResponse>> CreateAsync(TitleRequest req)
        {
            // TO DO: Duplicate name validation check

            Titles title = new Titles()
            {
                Name = req.Name,
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            unitOfWork.TitleServices.InsertAsync(title);
            var result = await unitOfWork.SaveAsync();

            var response = new ApiResponse<TitleResponse>();
            if (result)
            {
                response.Success = true;
                response.Message = Resource.Added;
                response.Data = new TitleResponse() { ID = title.ID, Name = title.Name, IsActive = title.IsActive };
            }
            else
            {
                response.Success = false;
                response.Message = Resource.Failed;
            }

            return response;
        }
        public async Task<ApiResponse<List<Titles>>> BulkAsync(List<TitleRequest> req)
        {
            var titles = new List<Titles>();

            req.ForEach(p => titles.Add(new Titles() { Name = p.Name }));

            unitOfWork.TitleServices.InsertRangeAsync(titles);

            var result = await unitOfWork.SaveAsync();

            var response = new ApiResponse<List<Titles>>();
            if (result)
            {
                response.Success = true;
                response.Message = Resource.Added;
                response.Data = titles;
            }
            else
            {
                response.Success = false;
                response.Message = Resource.Failed;
            }

            return response;
        }
        public async Task<ApiResponse<TitleResponse>> UpdateAsync(int id, TitleRequest req)
        {
            var exist = await unitOfWork.TitleServices.CheckIfExistAsync(t => t.Name == req.Name && t.ID != id);

            var response = new ApiResponse<TitleResponse>();
            if (exist)
            {
                response.Success = false;
                response.Message = Resource.Exist;
                return response;
            }
            else
            {
                var title = await unitOfWork.TitleServices.GetByIdAsync(id);

                if (title == null)
                {
                    response.Success = false;
                    response.Message = Resource.NoRecord;
                    return response;
                }
                else
                {
                    title.ModifiedDate = DateTime.Now;
                    title.Name = req.Name;
                    title.IsActive = req.IsActive;

                    unitOfWork.TitleServices.UpdateAsync(title);

                    var result = await unitOfWork.SaveAsync();
                    if (result)
                    {
                        response.Success = true;
                        response.Message = Resource.Added;
                        response.Data = new TitleResponse() { ID = title.ID, Name = title.Name, IsActive = title.IsActive };
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = Resource.Failed;
                    }
                    return response;
                }
            }
        }

    }
}
