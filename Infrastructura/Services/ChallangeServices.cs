using Domain.Dtos;
using Infrastructura.Services;
using Microsoft.EntityFrameworkCore;

public class ChallangeService : IChallangeServices
{
    private readonly DataContext _context;

    public ChallangeService(DataContext context)
    {
        _context = context;
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
        var Challanges = await _context.Challanges.Select(l=> new GEtChallangeDto()
        {
            Description = l.Description,
            Id = l.Id,
            Title = l.Title
        }).ToListAsync();
        return new Response<List<GEtChallangeDto>>(Challanges);
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

