
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DL1
{
    class GameButton:GameControl
    {
        public delegate void GameButtonClickHandler(object sender, GameButtonEventArgs e);
        public event GameButtonClickHandler Click;
        bool isPressed = false;
        private object tag;
        

        public GameButton(Sprite2D model) : base(model)
        {
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
                isPressed = true;
            if(ms.LeftButton==ButtonState.Released && isPressed)
            {
                isPressed = false;
                if (this.IsSelected(new Vector2(ms.X, ms.Y)))
                {
                    if (this.Click != null)
                        this.Click(this, new GameButtonEventArgs());
                }
            }
             
        }
        public object Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }
    }
    class GameButtonEventArgs : EventArgs
    {

    }
}
