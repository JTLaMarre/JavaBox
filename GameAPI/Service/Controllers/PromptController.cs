using System.Collections.Generic;
using System.Threading.Tasks;
using GameAPI.Domain.Models;
using GameAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Service.Controllers
{
    [ApiController]
    [Route("rest/prompt")]
    public class PromptController : ControllerBase
    {
        private readonly Repo _repo;
        public PromptController(Repo _repo)
        {
            this._repo = _repo;
        }
        
        /// <summary>
        /// Get all Prompts
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        [ProducesResponseType(typeof(IEnumerable<Prompt>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.Get<Prompt>());
        }

        /// <summary>
        /// Get a Prompt with ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(Prompt), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(long ID)
        {
            return Ok(await _repo.Get<Prompt>(ID));
        }

        /// <summary>
        /// Deletes a Prompt by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(long ID)
        {
            Prompt Prompt = await _repo.Get<Prompt>(ID);
            await Task.Run(() =>_repo.Delete<Prompt>(Prompt.EntityId));
            await Task.Run(() =>_repo.Save());

            return Ok();
        }

        /// <summary>
        /// Inserts a New Prompt
        /// </summary>
        /// <param name="Game"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Post([FromBody] Prompt Prompt)
        {
            await Task.Run(() => _repo.Insert<Prompt>(Prompt));
            await Task.Run(() => _repo.Save());

            return Accepted(Prompt);
        }
        
        /// <summary>
        /// Updates an Existing Prompt
        /// </summary>
        /// <param name="Prompt"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Prompt Prompt)
        {
            await Task.Run(()=>_repo.Update<Prompt>(Prompt));
            await Task.Run(()=>_repo.Save());
            return Accepted(Prompt);
        }
    }
}