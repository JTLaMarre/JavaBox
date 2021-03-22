using System.Collections.Generic;
using System.Threading.Tasks;
using GameAPI.Domain.Models;
using GameAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Service.Controllers
{
    [ApiController]
    [Route("rest/game")]
    public class GameController : ControllerBase
    {
        private readonly Repo _repo;
        public GameController(Repo _repo)
        {
            this._repo = _repo;
        }
        
        /// <summary>
        /// Get all user accounts available
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        [ProducesResponseType(typeof(IEnumerable<Game>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.Get<Game>());
        }

        /// <summary>
        /// Get a user's account via email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(long ID)
        {
            Game Game = await _repo.Get<Game>(ID);
            return Ok(Game);
        }
    }
}