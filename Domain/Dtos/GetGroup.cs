using System.ComponentModel.DataAnnotations;

public class GEtGroupDto
{
    public int Id { get; set; } 
    public string? GroupNick { get; set; }
    public int ChallangeId { get; set; }
    public string ChallangeName { get; set; }
    public bool NeededMember { get; set; }
    public string? TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<GetParticipantDto> Participants { get; set; }
}
