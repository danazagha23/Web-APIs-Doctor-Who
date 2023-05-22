using DoctorWho.Db.IRepositories;
using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EnemiesRepository : IEnemiesRepository
    {
        public void CreateEnemy(string enemyName, string description)
        {
            if (enemyName == null) throw new ArgumentNullException("Cannot create an Enemy with a null EnemyName!");
            DoctorWhoDbContext.context.Enemies.Add(new Enemy { EnemyName = enemyName, Description = description });
            DoctorWhoDbContext.context.SaveChanges();
        }
        public void UpdateEnemy()
        {
            DoctorWhoDbContext.context.ChangeTracker.DetectChanges();
            DoctorWhoDbContext.context.SaveChanges();
        }
        public void DeleteEnemy(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException("Cannot remove a null Enemy from the Enemies table");
            DoctorWhoDbContext.context.Enemies.Remove(enemy);
            DoctorWhoDbContext.context.SaveChanges();
        }
        public Enemy GetEnemyById(int id)
        {
            var enemy = DoctorWhoDbContext.context.Enemies.Find(id);
            if (enemy != null) return enemy;
            else throw new NullReferenceException("No enemies with the provided Id exist in the database");
        }
    }
}
