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
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Game>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.Get<Game>());
        }
    }
}