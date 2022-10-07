using AutoMapper;
using Domain.Dtos;
using Infrastructura.Services;
using Microsoft.EntityFrameworkCore;

public class ChallangeService : IChallangeServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ChallangeService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<Response<GEtChallangeDto>> GetChallangeByMapperById(int id)
    {
        var result = _mapper.Map<GEtChallangeDto>(await _context.Challanges.FindAsync(id));
        return new Response<GEtChallangeDto>(result);
    }
 


    public async Task<Response<AddChallangeDto>> AddChallange(AddChallangeDto model)
    {
        try
        {
            var challange = new Challange()
            {
                Description = model.Description,
                Title = model.Title
            };
            await _context.Challanges.AddAsync(challange);
            await _context.SaveChangesAsync();
            model.Id = challange.Id;
            return new Response<AddChallangeDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddChallangeDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<List<GEtChallangeDto>>> GetChallange()
    {
       var result = await 
       ( from ch in _context.Challanges
        select new GEtChallangeDto()
        {
            Description = ch.Description,
            Id = ch.Id,
            Title = ch.Title,
            Groups = (
                from g in _context.Groups
                where g.ChallangeId == ch.Id
                select new GEtGroupDto()
                {
                    ChallangeId = ch.Id,
                    Id = ch.Id,
                    GroupNick = g.GroupNick,
                    NeededMember = g.NeededMember,
                    TeamSlogan = g.TeamSlogan
                }).ToList(),

        }
        ).ToListAsync();
        return new Response<List<GEtChallangeDto>>(result);
    }

    public async Task<Response<AddChallangeDto>> UpdateChallange(AddChallangeDto challange)
    {
         try
        {
            var find = await _context.Challanges.FindAsync(challange.Id);
            if (find == null) return new Response<AddChallangeDto>(System.Net.HttpStatusCode.NotFound, "");

            // if Challange is found
            find.Description = challange.Description;
            find.Title = challange.Title;
            await _context.SaveChangesAsync();
            return new Response<AddChallangeDto>(challange);
        }
        catch (System.Exception ex)
        {
            return new Response<AddChallangeDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> DaleteChallange(int id)
    {
        try
        {
            var find = await _context.Challanges.FindAsync(id);
            if (find == null) return new Response<string>(System.Net.HttpStatusCode.NotFound, "");

            _context.Challanges.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("removed successfully");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

}

