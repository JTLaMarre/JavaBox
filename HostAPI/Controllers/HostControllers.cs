
using HostAPI.Domain.Models;
using HostAPI.Storing;
using Microsoft.AspNetCore.Mvc;

namespace HostAPI.Client.Controllers
{
    [ApiController]
    public class HostController : ControllerBase
    {
       
       private readonly HostRepository _repo;

       public HostController(HostRepository repo)
       {
           _repo=repo;
       }



        [HttpGet("/host/{RoomCode}")]
        public IActionResult getHost(string RoomCode)
        {
          var host= _repo.GetHost(RoomCode);
           return Ok(host);
        }
        [HttpGet("/host/{RoomCode}/players")]
        public IActionResult getPlayers(string RoomCode)
        {
            var players = _repo.GetPlayers(RoomCode);
            return Ok(players);
        }
        [HttpPost("/host/{RoomCode}/create")]
        public IActionResult createHost(string RoomCode)
        {
            Host host = new Host(RoomCode);            
            _repo.addHost(host);
            return Ok();
        }
        /// <summary>
        /// Maybe we don't need
        /// </summary>
        /// <value></value>
        // Maybe removed why are we keeping up with game in this api---------------------------------------------------------------------
        [HttpPut("/host/{RoomCode}/{Game}")]
        public IActionResult pickGame(string RoomCode, string Game)
        {
            var host = _repo.GetHost(RoomCode);
            host.game.GameName = Game; 
            _repo.Update();
            return Ok();
        }

        [HttpDelete("/host/end/{RoomCode}")]
        public IActionResult endGame(string RoomCode)
        {
            _repo.EndGame(RoomCode);
            return Ok();
        }
    }
}