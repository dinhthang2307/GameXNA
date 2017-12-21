using DL1.sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        IList<GameVisibleEntity2D> _entities;
        static Random rnd = new Random();
        Matrix matrix = Matrix.Identity;
        int selectedIdx = -1;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _entities = new List<GameVisibleEntity2D>();
            this.IsMouseVisible = true;
            base.Initialize();
            ResManager.Instance.Initialize(this);
        }
        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ResManager.Instance.Initialize(this);
            // TODO: use this.Content to load your game content here
            //_texture = this.Content.Load<Texture2D>("BG");

            var walkingMans = createWalkingManList();
            (_entities as List<GameVisibleEntity2D>).AddRange(walkingMans);
            _entities.Add(createBackground());
            var islandRes = ResManager.Instance.Load(Config.Instance.jsonCfg["map"].ToString());

            _entities.Add(new Island(new Sprite2D(islandRes, 0, 0, 0.1f)));
            var auraRes = ResManager.Instance.Load(Config.Instance.jsonCfg["aura"].Select(v=>v.ToString()).ToArray());

            _entities.Add(new Aura(new Sprite2D (auraRes, (walkingMans[1].X)-22, (walkingMans[1].Y)-45, 0.7f)));

            // var button = new GameButton(new Sprite2D(ResManager.Instance.Load("button\\bt1"), 0f, 0f, 0.9f));
            /*  button.Click += (object sender, GameButtonEventArgs e) =>
               {
                   this.Window.Title = "Đã click nên button";
               };*/

            // _entities.Add(button);
            /*   var menu = new GameMenu(new Sprite2D(ResManager.Instance.Load("button\\bt1"), 0f, 0f, 0.9f), 4);
               menu.Click += (object sender, GameMenuEventArgs e) =>
                {
                    this.Window.Title = $"Nút số {(int)(e.Button.Tag) +1} được bấm";
                };
               _entities.Add(menu);*/
        }

        private Island createBackground()
        {
            //load texture
            List<Texture2D> texList = new List<Texture2D>();
            var mapRes = Config.Instance.jsonCfg["map"].ToString();
            var tex = this.Content.Load<Texture2D>(mapRes);
            texList.Add(tex);
            return new Island(new Sprite2D(texList, 0, 0, 0.1f));
        }

        private walkingMan[] createWalkingManList()
        {
            List<walkingMan> r = new List<walkingMan>();
            //Load Texture
            List<Texture2D> textList = new List<Texture2D>();
            var unitTextures = Config.Instance.LoadUnitTextures("walkingMan");
            for(int i = 0; i < unitTextures.Length; i++)
            {
                var tex = this.Content.Load<Texture2D>(Config.Instance.LoadUnitTextures("walkingMan")[i]);
                textList.Add(tex);
            }

            //TODO: Created walkingmanlist
            for(int i = 0; i < 5; i++)
            {
                float x = rnd.Next() % 700;
                float y = rnd.Next() % 500;
                r.Add(new walkingMan(new Sprite2D(textList, x, y, 0.5f)));
            }

            return r.ToArray();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        float x = 0f;
        float dt = 0.01f;
        protected override void Update(GameTime gameTime)
        {
          
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //TODO: Add your update logic here  
            for (int i = 0; i < _entities.Count; i++)
            {
                _entities[i].Update(gameTime);
            }
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.W))
            {
                x -= 4f;
            }
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed) {
                for (int i = 0; i < _entities.Count; i++)
                {
                    _entities[i].Select(false);
                    if (_entities[i].IsSelected(new Vector2(ms.X, ms.Y))){
                        if(selectedIdx==-1)
                            selectedIdx = i;   
                    }
                }
                if (selectedIdx != -1)
                {
                    for(int i = 0; i < _entities.Count; i++)
                    {
                        if(selectedIdx!=i)
                            _entities[i].Select(false);
                        else
                            _entities[selectedIdx].Select(true);
                    }
                   
                    selectedIdx = -1;
                }
            }
            matrix = Matrix.CreateTranslation(0f, x, 0f);
            base.Update(gameTime);
        }

        //Vector2 position = Vector2.Zero;

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, matrix);

            for (int i = 0; i < _entities.Count; i++)
            {
                _entities[i].Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
