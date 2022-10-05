using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ParticipantController
{
    private readonly IParticipantService _ParticipantService;

    public ParticipantController(IParticipantService ParticipantService)
    {
        _ParticipantService = ParticipantService;
    }

    [HttpGet("getParticipant")]
    public Task<Response<List<GetParticipantDto>>> GetParticipant()
    {
        return _ParticipantService.GetParticipant();
    }


    [HttpPost("insertParticipant")]
    public Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto Participant)
    {
        return _ParticipantService.AddParticipant(Participant);
    }
    [HttpPut("updateParticipant")]
    public Task<Response<Participant>> UpdateParticipant(Participant Participant)
    {
        return _ParticipantService.UpdateParticipant(Participant);
    }
    [HttpDelete("deleteParticipant")]
    public Task<Response<string>> DaleteParticipant(int id)
    {
        return _ParticipantService.DaleteParticipant(id);
    }
}
