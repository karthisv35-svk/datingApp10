public class UserDto
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string Displayname { get; set; }
    public string? ImageUrl { get; set; }
    public required string Token { get; set; }

}