using System.ComponentModel.DataAnnotations;

public class GetParticipantDto 
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public int GroupId { get; set; }
    public string? Group  { get; set; }
    public int LocationId { get; set; }
    public string? Location { get; set; } 

}