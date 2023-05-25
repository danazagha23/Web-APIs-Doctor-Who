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
        private readonly DoctorWhoDbContext _context;
        public EnemiesRepository(DoctorWhoDbContext context)
        {
            _context = context;
        }
        public void CreateEnemy(string enemyName, string description)
        {
            if (enemyName == null) throw new ArgumentNullException("Cannot create an Enemy with a null EnemyName!");
            _context.Enemies.Add(new Enemy { EnemyName = enemyName, Description = description });
            _context.SaveChanges();
        }
        public void UpdateEnemy(Enemy enemy)
        {
            var existingEnemy = _context.Authors.Find(enemy.EnemyId);
            if (existingEnemy == null)
            {
                throw new InvalidOperationException("Enemy not Found");
            }
            _context.Entry(existingEnemy).CurrentValues.SetValues(enemy);

            _context.SaveChanges();
        }
        public void DeleteEnemy(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException("Cannot remove a null Enemy from the Enemies table");
            _context.Enemies.Remove(enemy);
            _context.SaveChanges();
        }
        public Enemy GetEnemyById(int id)
        {
            var enemy = _context.Enemies.Find(id);
            if (enemy != null) return enemy;
            else throw new NullReferenceException("No enemies with the provided Id exist in the database");
        }
    }
}
