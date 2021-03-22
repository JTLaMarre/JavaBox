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
        /// Get a Game with ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(long ID)
        {
            return Ok(await _repo.Get<Game>(ID));
        }

        /// <summary>
        /// Deletes a Game by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(long ID)
        {
            Game Game = await _repo.Get<Game>(ID);
            await Task.Run(() =>_repo.Delete<Game>(Game.EntityId));
            await Task.Run(() =>_repo.Save());

            return Ok();
        }

        /// <summary>
        /// Inserts a New Game
        /// </summary>
        /// <param name="Game"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Post([FromBody] Game Game)
        {
            await Task.Run(() => _repo.Insert<Game>(Game));
            await Task.Run(() => _repo.Save());

            return Accepted(Game);
        }
        
        /// <summary>
        /// Updates an Existing Game
        /// </summary>
        /// <param name="Game"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Game Game)
        {
            await Task.Run(()=>_repo.Update<Game>(Game));
            await Task.Run(()=>_repo.Save());
            return Accepted(Game);
        }
    }
}