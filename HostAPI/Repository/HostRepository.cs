

using System.Collections.Generic;
using System.Linq;
using HostAPI.Domain.Models;

namespace HostAPI.Storing
{
    public class HostRepository
    {
        private HostContext _ctx;

        public HostRepository(HostContext context)
        {
            _ctx = context;
        }
        public void addHost(Host host)
        {
            
            _ctx.Hosts.Add(host);
            _ctx.SaveChanges();
        }
        public void addPlayer(Player player)
        {
            _ctx.Players.Add(player);
            _ctx.SaveChanges();
        }
        public void AddGame(Game game)
        {
            _ctx.Games.Add(game);
            _ctx.SaveChanges();
        }

        public Host GetHost(string RoomCode)
        {
           return  _ctx.Hosts.FirstOrDefault( Host => Host.RoomCode == RoomCode);
        }

        public List<Player> GetPlayers(string RoomCode)
        {
            return _ctx.Players.Where(p => p.HostRoomcode == RoomCode).ToList();
           
        }
        public void setScore(int amount, string name)
        {
            var player = _ctx.Players.FirstOrDefault(p => p.name ==name);
            player.score = amount;
            _ctx.SaveChanges();
        }
        public void EndGame(string RoomCode)
        {
            var Host = GetHost(RoomCode);
            var Players = GetPlayers(RoomCode);
            _ctx.Hosts.Remove(Host);
            _ctx.Players.RemoveRange(Players);
            _ctx.SaveChanges();
        }
        public void Update()
        {
            _ctx.SaveChanges();
        }
    }
}