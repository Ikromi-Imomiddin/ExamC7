using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class GroupController
{
    private readonly IGroupServices _GroupService;

    public GroupController(IGroupServices GroupService)
    {
        _GroupService = GroupService;
    }

    [HttpGet("getGroup")]
    public async Task<Response<List<GEtGroupDto>>> GetGroup()
    {
        return await _GroupService.GetGroups();
    }


    [HttpPost("insertGroup")]
    public async Task<Response<AddGroupDto>> AddGroup(AddGroupDto group)
    {
        return await _GroupService.AddGroups(group);
    }
    [HttpPut("updateGroup")]
    public async Task<Response<AddGroupDto>> UpdateGroup(AddGroupDto Group)
    {
        return await _GroupService.UpdateGroups(Group);
    }
    [HttpDelete("deleteGroup")]
    public async Task<Response<string>> DaleteGroup(int id)
    {
        return await _GroupService.DaleteGroups(id);
    }
}
