using Domain.Dtos;

namespace Infrastructura.Services;

public interface IChallangeServices
{
    Task<Response<AddChallangeDto>> AddChallange(AddChallangeDto model);
    Task<Response<List<GEtChallangeDto>>> GetChallange();
    Task<Response<AddChallangeDto>> UpdateChallange(AddChallangeDto challange);
    Task<Response<GEtChallangeDto>> GetChallangeByMapperById(int id);
    Task<Response<string>> DaleteChallange(int id);

}
