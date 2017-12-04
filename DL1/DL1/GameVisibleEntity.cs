using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL1
{
    //video 5:38
    public class GameVisibleEntity:GameEntities
    {
        AbstractModel _model;
        public GameVisibleEntity(AbstractModel model)
        {
            this._model = model;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _model.Update(gameTime);
        }
        public override void Draw(GameTime gameTime, object handler)
        {
            _model.Draw(gameTime, handler);
        }
    }
}
