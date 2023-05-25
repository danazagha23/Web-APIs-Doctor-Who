using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.IRepositories
{
    public interface IEnemiesRepository
    {
        public void CreateEnemy(string enemyName, string description);
        public void UpdateEnemy(Enemy enemy);
        public void DeleteEnemy(Enemy enemy);
        public Enemy GetEnemyById(int id);

    }
}
