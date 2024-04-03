using Microsoft.EntityFrameworkCore;

namespace kras_lit;
public class  AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Sourse=(localdb)\\MSSQLLocalDb;MSSQLlocalDB;Inital catalog=Userdb");
    }
}