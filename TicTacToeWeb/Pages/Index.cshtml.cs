using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeData;
using TicTacToeWeb.Utils;

namespace TicTacToeWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private const string _gameKey = "game";

        [BindProperty]
        public Game TicTacToeGame { get; set; }

        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public bool IsGameFinished { get {
                return !string.IsNullOrEmpty(Message);
            } 
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            TicTacToeGame = HttpContext.Session.Get<Game>(_gameKey);

            if(TicTacToeGame == null)
            {
                TicTacToeGame = new Game();
            }

            if(Request.QueryString.HasValue)
            {
                if(!string.IsNullOrEmpty(Request.Query["restart"]))
                {
                    TicTacToeGame = new Game();
                } else {
                    var row = int.Parse(Request.Query["row"]);
                    var col = int.Parse(Request.Query["col"]);

                    var gameResult = TicTacToeGame.PlaceCheckMark(row, col);

                    switch (gameResult)
                    {
                        case GameResultEnum.Continue:
                            break;
                        case GameResultEnum.Duece:
                            Message = "Duece";
                            break;
                        case GameResultEnum.XWon:
                            Message = "X won";
                            break;
                        case GameResultEnum.OWon:
                            Message = "O won";
                            break;
                    }
                }
            }

            HttpContext.Session.Set<Game>(_gameKey, TicTacToeGame);
        }

        public string GetFieldImage(int row, int col)
        {
            if(TicTacToeGame == null)
            {
                return string.Empty;
            }

            var field = TicTacToeGame.GetFieldValue(row, col);

            switch (field)
            {
                case FieldTypeEnum.Empty:
                    return string.Empty;
                case FieldTypeEnum.X:
                    return "<img src=\"/img/x.png\"/>";
                case FieldTypeEnum.O:
                    return "<img src=\"/img/o.png\"/>";
                default:
                    return string.Empty;
            }
        }
    }
}
