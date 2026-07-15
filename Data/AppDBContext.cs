namespace API.Data;

using API.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDBContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
}