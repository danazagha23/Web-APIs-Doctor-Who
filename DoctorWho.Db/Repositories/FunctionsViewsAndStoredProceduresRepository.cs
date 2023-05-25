using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class FunctionsViewsAndStoredProceduresRepository
    {
        public static void Ex_Companions_Function(int EpisodeId)
        {
            using var context = new DoctorWhoDbContext();
            var companions = context.Companions.Select(c => context.Companions_Function(EpisodeId)).FirstOrDefault();
            Console.WriteLine(companions);
        }

        public static void Ex_Enemies_Function(int EpisodeId)
        {
            using var context = new DoctorWhoDbContext();
            var enemies = context.Enemies.Select(e => context.Enemies_Function(EpisodeId)).FirstOrDefault();
            Console.WriteLine(enemies);
        }
        public static void Ex_ViewEpisodes()
        {
            using var context = new DoctorWhoDbContext();
            var Results = context.ViewEpisodes.ToList();

            foreach (var result in Results)
            {
                Console.WriteLine(
                     result.Title, result.DoctorName, result.AuthorName, result.Companions, result.Enemies);
            }
        }
        public static void Ex_spSummariseEpisodes()
        {
            using var context = new DoctorWhoDbContext();

            var Companions = context.ThreeMostFrequentlyAppearingCompanions.FromSqlRaw("EXEC spSummariseEpisodesCompanions").ToList();
            foreach (var companion in Companions)
            {
                Console.WriteLine(companion.Three_Most_Frequently_Appearing_Companions);
            }

            var Enemies = context.ThreeMostFrequentlyAppearingEnemies.FromSqlRaw("EXEC spSummariseEpisodesEnemies").ToList();
            foreach (var enemy in Enemies)
            {
                Console.WriteLine(enemy.Three_Most_Frequently_Appearing_Enemies);
            }
        }
    }
}
