using HostAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HostAPI.Storing 
{

public class HostContext:DbContext
{
     public DbSet<Host> Hosts{get;set;}
     public DbSet<Player> Players{get;set;}
     public DbSet<Game> Games{get;set;}

     HostContext(){}

     public HostContext(DbContextOptions<HostContext> options) : base(options) { }

     protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=tcp:flutter.database.windows.net,1433;Initial Catalog=HostAPI;Persist Security Info=False;User ID=sqladmin;Password=pass123!");
        }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Host>().HasKey(host => host.RoomCode);
        builder.Entity<Game>().HasKey(game => game.EntityId);
        builder.Entity<Player>().HasKey(player => player.name);
    }
} 

}