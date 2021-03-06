
using HostAPI.Domain.Models;
using HostAPI.Storing;
using Microsoft.AspNetCore.Mvc;

namespace HostAPI.Client.Controllers
{
    [ApiController]
    public class PlayerController : ControllerBase
    {
       
       private readonly HostRepository _repo;

       public PlayerController(HostRepository repo)
       {
           _repo=repo;
       }

       [HttpPost("/player/{name}/{RoomCode}")]
       public IActionResult addPlayer(string name, string RoomCode)
       {
           Player Hank = new Player();
           Hank.name = name;
           Hank.HostRoomcode = RoomCode;
           _repo.addPlayer(Hank);
           return Ok();
       }
       [HttpGet("/player/{name}")]
       public IActionResult getPlayer(string name)
       {
           return Ok(_repo.GetPlayer(name));
       }
       [HttpPut("/player/{name}/{score}")]
       public IActionResult setScore(int score,string name)
       {
           _repo.setScore(score,name);
           return Ok();
       }


       
      
      
    }
}