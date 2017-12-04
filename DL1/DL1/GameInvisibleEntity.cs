using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

//video: 5:38- 12L00
namespace DL1
{
    class GameInvisibleEntity:GameEntities
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public virtual void Draw(GameTime gameTime, object handler)
        {

        }
    }
}
