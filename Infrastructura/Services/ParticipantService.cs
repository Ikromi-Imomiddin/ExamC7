using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Services;

public class ParticipantServices : IParticipantService
{
    private readonly DataContext _context;
    public ParticipantServices(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<Participant>> AddParticipant(Participant Participant)
    {
        await _context.Participants.AddAsync(Participant);
        await _context.SaveChangesAsync();
        return new Response<Participant>(Participant);
    }
    public async Task<Response<List<Participant>>> GetParticipant()
    {
        var response = await _context.Participants.ToListAsync();
        return new Response<List<Participant>>(response);
    }
    public async Task<Response<Participant>> UpdateParticipant(Participant Participant)
    {
        var record = await _context.Participants.FindAsync(Participant.Id);
        if (record == null) return new Response<Participant>(System.Net.HttpStatusCode.NotFound, "No record found");
        record.FullName = Participant.FullName;
        record.Email = Participant.Email;
        record.Phone = Participant.Phone;
        record.Password = Participant.Password;
        await _context.SaveChangesAsync();
        return new Response<Participant>(record);
    }

    public async Task<Response<string>> DaleteParticipant(int id)
    {
        var record = await _context.Participants.FindAsync(id);
        if (record == null)
            return new Response<string>(System.Net.HttpStatusCode.NotFound, "No record found");
        _context.Participants.Remove(record);
        await _context.SaveChangesAsync();
        return new Response<string>("success");
    }

    public Task<Response<Location>> AddLocation(Location Location)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<Location>>> GetLocation()
    {
        throw new NotImplementedException();
    }

    public Task<Response<Location>> UpdateLocation(Location Location)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> DaleteLocation(int id)
    {
        throw new NotImplementedException();
    }
}