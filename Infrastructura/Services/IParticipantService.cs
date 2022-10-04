namespace Infrastructura.Services
{
    public interface IParticipantService
    {
        Task<Response<List<Participant>>> GetParticipant();
        Task<Response<Participant>> AddParticipant(Participant Participant);
        Task<Response<Participant>> UpdateParticipant(Participant Participant);
        Task<Response<string>> DaleteParticipant(int id);
    }
}