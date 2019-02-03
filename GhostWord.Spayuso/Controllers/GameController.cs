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
                return NotFound();
            }
            return Ok(gameIsReady);
            
        }
        
        [Route("addletter")]
        [HttpPost]
        public IActionResult AddLetter(string word)
        {
            if(string.IsNullOrWhiteSpace(word))
            {
                return BadRequest();
            }

            GameModel gameModel;
            var game = this._service.AddLetter(word);

            if(string.Equals(word, game))
            {
                gameModel = new GameModel(game, GameStatus.YouLoose);
            }
            else if(game.Length > word.Length)
            {
                gameModel = new GameModel(game, GameStatus.ContinueGame);
            }
            else
            {
                gameModel = new GameModel(game, GameStatus.YouWin);
                
            }

            return Ok(gameModel);
        }
    }
}
