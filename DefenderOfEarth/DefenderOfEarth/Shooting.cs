using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefenderOfEarth.Game
{
    class Shooting
    {
        private readonly BulletFactory _bulletFactory;
        private readonly Bullet _bullet;
        private DateTime _shootTime = DateTime.Now;
        private readonly TimeSpan _timeToNextShot = new TimeSpan(0, 0, 0, 0, 300);

        private List<Bullet> _bullets = new List<Bullet>(64);

        public Shooting(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _bullet = bulletFactory.Create();
        }

        public bool Fire(int x, int y)
        {
            if (DateTime.Now - _shootTime > _timeToNextShot)
            {
                Bullet bullet = _bulletFactory.Create();
                bullet.Fire(x, y);
                _bullets.Add(bullet);
                _shootTime = DateTime.Now;
                return true;
            }
            return false;
        }

        public void Move()
        {
            foreach (Bullet bullet in _bullets)
            {
                bullet.Move();
            }
            _bullets.RemoveAll(bullet => bullet.Visible == false);
        }

        public List<Bullet> Bullets
        {
            get { return _bullets.ToList(); }
        }

        public int BulletHeight
        {
            get { return _bullet.Height; }
        }

        public int BulletWidth
        {
            get { return _bullet.Width; }
        }
    }
}
