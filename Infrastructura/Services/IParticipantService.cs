namespace Infrastructura.Services
{
    public interface IParticipantService
    {
        Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto model);
        Task<Response<List<GetParticipantDto>>> GetParticipant();
        Task<Response<Participant>> UpdateParticipant(Participant Participant);
        Task<Response<string>> DaleteParticipant(int id);
    }
}