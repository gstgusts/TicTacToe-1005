﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeData;

namespace TicTacToeWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Game TicTacToeGame { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            TicTacToeGame = new Game();
        }

        public string GetFieldImage(int row, int col)
        {
            if(TicTacToeGame != null)
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
