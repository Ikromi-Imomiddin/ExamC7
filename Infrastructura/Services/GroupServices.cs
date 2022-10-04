using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Services;

public class GroupSevices : IGroupServices
{
    private readonly DataContext _context;
    public GroupSevices(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<AddGroupDto>> AddGroups(AddGroupDto model)
    {
        try
        {
            var group = new Group()
            {
                TeamSlogan = model.TeamSlogan,
                NeededMember = model.NeededMember,
                GroupNick = model.GroupNick,
                ChallangeId = model.ChallangeId
            };
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
            return new Response<AddGroupDto>(model);
        }

        catch (Exception ex)
        {

            return new Response<AddGroupDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }

    }
    public async Task<Response<List<GEtGroupDto>>> GetGroups()
    {

        var group = await _context.Groups.Select(G => new GEtGroupDto()
        {
            TeamSlogan = G.TeamSlogan,
            Id = G.Id,
            NeededMember = G.NeededMember,
            GroupNick = G.GroupNick,
            ChallangeId = G.ChallangeId
        }).ToListAsync();
        var response = await _context.Groups.ToListAsync();
        return new Response<List<GEtGroupDto>>(group);


    }
    public async Task<Response<AddGroupDto>> UpdateGroups(AddGroupDto group)
    {
        try
        {
            var record = await _context.Groups.FindAsync(group.Id);
            if (record == null) return new Response<AddGroupDto>(System.Net.HttpStatusCode.NotFound, "No record found");
            record.TeamSlogan = group.TeamSlogan;
            record.NeededMember = group.NeededMember;
            record.GroupNick = group.GroupNick;
            record.ChallangeId = group.ChallangeId;
            await _context.SaveChangesAsync();
            return new Response<AddGroupDto>(group);
        }
        catch (System.Exception ex)
        {
            return new Response<AddGroupDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }

    }

    public async Task<Response<string>> DaleteGroups(int id)
    {
        try
        {
            var record = await _context.Groups.FindAsync(id);
            if (record == null)
                return new Response<string>(System.Net.HttpStatusCode.NotFound, "No record found");
            _context.Groups.Remove(record);
            await _context.SaveChangesAsync();
            return new Response<string>("success");
        }
        catch (System.Exception ex)
        {

            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

        }

    }
}