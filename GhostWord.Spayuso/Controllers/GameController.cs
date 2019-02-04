using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GhostWord.Spayuso.Service;
using GhostWord.Spayuso.Api.Models;
using Microsoft.AspNetCore.Cors;

namespace GhostWord.Spayuso.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;
        public GameController(IGameService service)
        {
            this._service = service;
        }

        [Route("startgame")]
        [HttpPost]
        public IActionResult StartGame()
        {
            var gameIsReady = this._service.StartGame();
            if(!gameIsReady)
            {
                return NotFound(gameIsReady);
            }
            return Ok(gameIsReady);
            
        }
        
        [Route("addletter")]
        [HttpPost]
        public IActionResult AddLetter(string word)
        {
            if(string.IsNullOrWhiteSpace(word))
            {
                return BadRequest("Word to check must be supplied");
            }

            var game = this._service.AddLetter(word);

            return Ok(GetGameModel(word, game));
            
        }

        private static GameModel GetGameModel(string newWord, string gameWord)
        {
            if(String.Equals(newWord, gameWord))
            {
                return new GameModel(gameWord, GameStatus.YouLoose);
            }
            else if (gameWord.Length > newWord.Length)
            {
                return new GameModel(gameWord, GameStatus.ContinueGame);
            }
            else
            {
                return new GameModel(gameWord, GameStatus.YouWin);
            }            
        }
    }
}
