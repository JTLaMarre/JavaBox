using GameAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Storing 
{

public class GameContext:DbContext
{
     public DbSet<Game> Game{get;set;}
     public DbSet<GamePrompt> GamePrompt{get;set;}
     public DbSet<Prompt> Prompt{get;set;}

    HostContext(){}

    public HostContext(DbContextOptions<GameContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(SqlServer);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.Entity<Host>().HasKey(host => host.RoomCode);
        // builder.Entity<Game>().HasKey(game => game.EntityId);
        // builder.Entity<Player>().HasKey(player => player.name);
    }
} 

}