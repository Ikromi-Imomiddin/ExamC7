using System.ComponentModel.DataAnnotations;

public class Participant 
{
    public int Id { get; set; }
    [Required, MaxLength(60)]
    public string? FullName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [Required,MaxLength(13)]
    public string? Phone { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
    public int LocationId { get; set; } 
    public virtual Location Location { get; set; }

    public Participant()
    {
        CreatedAt = DateTime.Now;
    }

}