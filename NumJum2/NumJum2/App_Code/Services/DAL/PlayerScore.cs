using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NumJum2.Services.DAL
{
    public class PlayerScore
    {
        public int PlayerScoreID { get; set; }
        public int PlayerDbID { get; set; }
        public int Score { get; set; }
        public virtual PlayerDb PlayerDb { get; set; }
    }

}