using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NumJum2.Domain;
using System.ComponentModel.DataAnnotations;

namespace NumJum2.Services.DAL
{
    public class PlayerDb
    {
        public int PlayerDbID { get; set; }
        public string PlayerName { get; set; }
        public bool GameStatus { get; set; }
        public int NumScores { get; set; }
    }
}