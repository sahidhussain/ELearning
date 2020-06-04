using ELearning.Dto.V1.Request;
using ELearning.Dto.V1.Response;
using ELearning.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELearning.Services.Services
{
    public interface ITitleServices
    {
        Task<ApiResponse<TitleResponse>> GetById(int Id);
        Task<ApiResponse<List<TitleResponse>>> GetAll();
        Task<ApiResponse<TitleResponse>> CreateAsync(TitleRequest req);
        Task<ApiResponse<List<Titles>>> BulkAsync(List<TitleRequest> req);
        Task<ApiResponse<TitleResponse>> UpdateAsync(int id, TitleRequest req);
    }
}
