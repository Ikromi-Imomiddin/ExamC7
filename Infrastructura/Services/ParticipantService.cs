using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Services;

public class ParticipantServices : IParticipantService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ParticipantServices(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto participant)
    {
        try
        {
            Participant mapped = _mapper.Map<Participant>(participant);
            await _context.Participants.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddParticipantDto>(participant);
        }
        catch (System.Exception ex)
        {
            return new Response<AddParticipantDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<List<GetParticipantDto>>> GetParticipant()
    {
       var participants = await (from pr in _context.Participants
        join gr in _context.Groups
        on pr.GroupId equals gr.Id
        join lc in _context.Locations
        on pr.LocationId equals lc.Id
        orderby gr.CreatedAt descending
        select new GetParticipantDto
        {
            Email = pr.Email,
            FullName = pr.FullName,
            Group = gr.GroupNick,
            Location = lc.Title,
            Phone = pr.Phone,
            Id = pr.Id
        }).ToListAsync();
        
        return new Response<List<GetParticipantDto>>(participants);
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
}