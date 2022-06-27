namespace API.Auth;

public class User
{
    public int Id { get; set; } = default(int);
    public string Username { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    public List<Project.Project> Projects { get; set; } = new();
}