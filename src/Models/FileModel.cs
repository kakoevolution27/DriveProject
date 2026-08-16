using Microsoft.EntityFrameworkCore;

public class File
{
    public int Id { get; set; }
    public string? Filename { get; set; }
    public string? MimeType { get; set; }
    public double Size { get; set; }
    public DateTime UploadedAt { get; set; }
    public Status Status { get; set; }

    public int UserId { get; set; }
    
    // Propriedade de navegação
    public User? User { get; set; }
}

public enum Status
{
    Pending,
    done,
    Canceled,
    paused
}