using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DL1
{
    class GameMenu:GameVisibleEntity2D
    {
        public delegate void GameMenuClickHandler(object sender, GameMenuEventArgs e);
        public event GameMenuClickHandler Click;
        IList<GameButton> buttons = null;
        public GameMenu(Sprite2D model, int numOfButtons) : base(model)
        {
            buttons = new List<GameButton>();
            for(int i = 0; i < numOfButtons; i++)
            {
                var tex = ResManager.Instance.Load("button\\bt1");
                var btn = new GameButton(new Sprite2D(tex, 20f, (tex[0].Height + 10f) * i, 0.9f));
                btn.Tag = i;
                btn.Click += (object sender, GameButtonEventArgs e) =>
                  {
                      if (this.Click != null)
                          this.Click(this, new GameMenuEventArgs(btn)); 
                  };
                buttons.Add(btn);
            }
        }

        public override void Draw(GameTime gameTime, object handler)
        {
            base.Draw(gameTime, handler);
            for(int i=0;i<buttons.Count; i++)
            {
                buttons[i].Draw(gameTime, handler);
            }
        }
        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Update(gameTime);
            }

            base.Update(gameTime);
        }
    }

    class GameMenuEventArgs:EventArgs
    {
        private GameButton _button;
        public GameMenuEventArgs(GameButton button)
        {
            _button = button;
        }

        public GameButton Button
        {
            get
            {
                return _button;
            }
            set
            {
                _button = value;
            }
        }
    }
}