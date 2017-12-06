using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL1
{
    abstract class GameControl : GameVisibleEntity2D
    {
        public GameControl(Sprite2D model) : base(model)
        {
        }
    }
}
