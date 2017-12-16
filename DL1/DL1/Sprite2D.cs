using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL1
{

    
        public class Sprite2D:AbstractModel
        {
            private float _left;
            private float _top;
            private float _width;
            private float _height;
            private int _nCount;
        private float _depth;
            private IList<Texture2D> _textures;

            int idx;
        int _state=0;
        
      
        public Sprite2D(IList<Texture2D> textures, float left, float top, float depth)
            {
                idx = 0;
                _left = left;
                _top = top;
                this._textures = textures;
                _nCount = textures.Count;
                _depth = depth;
            _height = _textures[0].Height;
            _width = _textures[0].Width;
            }
            public override void Update(GameTime gameTime)
            {
                idx = (idx + 1) % _nCount;
            }

            public override void Draw(GameTime gameTime, object handler)
            {
                SpriteBatch spriteBatch = handler as SpriteBatch;
                if(_state==1)
                // spriteBatch.Draw(_textures[idx], new Vector2(_left, _top), new Rectangle(0, 0,(int)_width, (int)_height), Color.Yellow, 0f, Vector2.Zero, 1f, SpriteEffects.None, _depth);
                spriteBatch.Draw(_textures[idx], new Vector2(_left, _top), Color.Blue);
            else
                spriteBatch.Draw(_textures[idx], new Vector2(_left, _top), Color.White);
            //spriteBatch.Draw(_textures[idx], new Vector2(_left, _top), new Rectangle(0, 0, (int)_width, (int)_height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, _depth);
            }
        public bool IsSelected(Vector2 mousePos)
        {
            if (mousePos.X >= this._left && mousePos.X <= this._left + _width &&
                mousePos.Y >= this._top && mousePos.Y <= this._top + _height)
                return true;
            return false;
        }
        public void Select(bool isSelected)
        {
            if (isSelected)
                _state = 1;
            else
                _state = 0;
        }



        #region property
            public float Left { get { return _left; } set { _left = value; } }
            public float Top { get { return _top; } set { _top = value; } }
            public float Width { get { return _width; } set { _width = value; } }
            public float Height { get { return _height; } set { _height = value; } }
            public IList<Texture2D> Textures
            {
                get { return _textures; }
                set
                {
                    _textures = value;

                    if (_textures == null)
                        throw new Exception("Texture can't be null");
                    _width = _textures[0].Width;
                    _height = _textures[0].Height;
                    _nCount = _textures.Count;
                }
            }
            public float Depth
            {
                get
                {
                    return _depth;
                }
                set
                {
                    _depth = value;
                }
            }
        #endregion

    }
}
