using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL1
{
    //video 5/38 12:43
    public abstract class AbstractModel
    {
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, Object handler);
    }
}
