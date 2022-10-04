namespace Infrastructura.Services;

public interface IGroupServices
{
    Task<Response<AddGroupDto>> AddGroups(AddGroupDto model);
    Task<Response<List<GEtGroupDto>>> GetGroups();
    Task<Response<AddGroupDto>> UpdateGroups(AddGroupDto group);
    Task<Response<string>> DaleteGroups(int id);
}
