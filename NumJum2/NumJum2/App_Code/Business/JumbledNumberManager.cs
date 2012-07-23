using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumJum2.Domain;
using NumJum2.Services;

namespace NumJum2.Business
{
    public class JumbledNumberManager : Manager
    {
        public int CreateJumbledNumber(JumbledNumber NumJumObj, int difficulty)
        {
            IJumbledNumberSvc jumnumSvc =
                (IJumbledNumberSvc)GetService(typeof(IJumbledNumberSvc).Name);
            
            return jumnumSvc.GetJumbledNumber(NumJumObj, difficulty);
        }

        public bool CheckGameStatus(JumbledNumber NumJumObj)
        {
            IJumbledNumberSvc jumnumSvc =
                (IJumbledNumberSvc)GetService(typeof(IJumbledNumberSvc).Name);

            return jumnumSvc.GetGameStatus(NumJumObj);
        }
    }
}
