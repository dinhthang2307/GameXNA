using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL1
{
    //video 5:38
    public class GameVisibleEntity2D:GameEntities
    {
        Sprite2D _model;

        public GameVisibleEntity2D(Sprite2D model)
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
            base.Draw(gameTime, handler);
            _model.Draw(gameTime, handler);
        }


        public virtual bool IsSelected(Vector2 mousePos)
        {
            return this._model.IsSelected(mousePos);
        }
        public virtual void Select(bool isSelected)
        {
            this._model.Select(isSelected);
        }
        public float Depth
        {
            get { return _model.Depth; }
            set { _model.Depth = value; }
        }
    }
}
