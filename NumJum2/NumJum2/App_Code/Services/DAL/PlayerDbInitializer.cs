using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.Entity;
using NumJum2.Domain;
using NumJum2.Services;

namespace NumJum2.Services.DAL
{
    public class PlayerDbInitializer : DropCreateDatabaseAlways<PlayerDbContext>
    {
        protected override void Seed(PlayerDbContext context)
        {
            // Build players to seed database
            List<int> scores1 = new List<int>() { 4, 15, 32, 40 };
            List<int> scores2 = new List<int>() { 1, 4, 7 };
            List<int> scores3 = new List<int>() { 23, 56 };

            Player player1 = new Player("Link", false, 4, scores1);
            Player player2 = new Player("Zelda", false, 3, scores2);
            Player player3 = new Player("Mario", false, 2, scores3);

            // Load into database
            Factory loadFactory = Factory.GetInstance();
            IPlayerSvc loadSVC = (IPlayerSvc)
                loadFactory.GetService(typeof(IPlayerSvc).Name);

            loadSVC.SavePlayerToDb(player1);
            loadSVC.SavePlayerToDb(player2);
            loadSVC.SavePlayerToDb(player3);

            base.Seed(context);
        }
    }
}
