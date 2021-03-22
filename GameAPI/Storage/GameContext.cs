using GameAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Storage
{
public class GameContext:DbContext
{
     public DbSet<Game> Game{get;set;}
     public DbSet<GamePrompts> GamePrompt{get;set;}
     public DbSet<Prompt> Prompt{get;set;}

    GameContext(){}

    public GameContext(DbContextOptions<GameContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("SqlServer");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Game>().HasKey(x => x.EntityId);
        builder.Entity<GamePrompts>().HasKey(x => x.EntityId);
        builder.Entity<Prompt>().HasKey(x => x.EntityId);
    }
} 

}