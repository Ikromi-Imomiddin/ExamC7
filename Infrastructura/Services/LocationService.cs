using AutoMapper;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;

public class LocationService : ILocationService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public LocationService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GEtLocationDto>>> GetLocations()
    {
        var location = await (from lo in _context.Locations
                              select new GEtLocationDto()
                              {
                                  Description = lo.Description,
                                  Id = lo.Id,
                                  Title = lo.Title,
                                  Challenges = (from ch in _context.Challanges
                                               where ch.LocationId == lo.Id
                                               select _mapper.Map<GEtChallangeDto>(ch)
                                               ).ToList(),

                              }).ToListAsync();
        return new Response<List<GEtLocationDto>>(location);
    }

    //add location 
    public async Task<Response<AddLocationDto>> AddLocation(AddLocationDto location)
    {
        try
        {
            Location mapped = _mapper.Map<Location>(location);
            await _context.Locations.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddLocationDto>(location);
        }
        catch (System.Exception ex)
        {
            return new Response<AddLocationDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<Location>> GetLocationById(int id)
    {
        var find = await _context.Locations.FindAsync(id);
        return new Response<Location>(find);
    }

    //add location 
    public async Task<Response<AddLocationDto>> UpdateLocation(AddLocationDto location)
    {
        try
        {
            var find = await _context.Locations.FindAsync(location.Id);
            if (find == null) return new Response<AddLocationDto>(System.Net.HttpStatusCode.NotFound, "");

            // if location is found
            find.Description = location.Description;
            find.Title = location.Title;
            await _context.SaveChangesAsync();
            return new Response<AddLocationDto>(location);
        }
        catch (System.Exception ex)
        {
            return new Response<AddLocationDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    //add location 
    public async Task<Response<string>> DeleteLocation(int id)
    {
        try
        {
            var find = await _context.Locations.FindAsync(id);
            if (find == null) return new Response<string>(System.Net.HttpStatusCode.NotFound, "");

            _context.Locations.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("removed successfully");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}

