namespace API.Entities;
public class AppUser
{
   public string Id { get; set; } = new Guid().ToString();

   public required string Displayname { get; set; }

   public required string Email { get; set; }


}