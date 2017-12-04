using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL1
{
    public abstract class Unit:GameVisibleEntity
    {
        int hp;
        int mp;
        int stm;
        int damage;

        Sprite2D sprite2D;
        public Unit(Sprite2D sprite2D,int hp=100, int mp=100, int stm=100):base(sprite2D)
        {
            this.damage = 200;
            this.hp = hp;
            this.mp = mp;
            this.stm = stm;
            this.sprite2D = sprite2D;
        }
        public override void Draw(GameTime gameTime, object handler)
        {
            //var spriteBatch = handler as SpriteBatch;
            sprite2D.Draw(gameTime, handler);
        }
        public override void Update(GameTime gameTime)
        {
            sprite2D.Update(gameTime);
        }
        public void Attack(Unit unit)
        {
            unit.BeDameged(this.damage);
        }
        public void BeDameged(int dmg)
        {
            hp = hp - (int)Math.Sqrt((dmg * 0.75f) + 10);
        }
    }
}
