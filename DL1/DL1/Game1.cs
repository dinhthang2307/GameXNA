using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DL1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        IList<GameEntities> _entities;
        static Random rnd = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _entities = new List<GameEntities>();
            base.Initialize();
        }
        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //_texture = this.Content.Load<Texture2D>("BG");

            var walkingMans = createWalkingManList();
            _entities.Add(createBackground());
            (_entities as List<GameEntities>).AddRange(walkingMans);
           

        }

        private Island createBackground()
        {
            //load texture
            List<Texture2D> texList = new List<Texture2D>();
            var mapRes = Config.Instance.jsonCfg["map"].ToString();
            var tex = this.Content.Load<Texture2D>(mapRes);
            texList.Add(tex);
            return new Island(new Sprite2D(texList, 0, 0));
        }

        private walkingMan[] createWalkingManList()
        {
            List<walkingMan> r = new List<walkingMan>();
            //Load Texture
            List<Texture2D> textList = new List<Texture2D>();
            var unitTextures = Config.Instance.LoadUnitTextures("walkingMan");
            for(int i = 0; i < unitTextures.Length; i++)
            {
                //Config.Instance.LoadUnitTextures("");
                var tex = this.Content.Load<Texture2D>(Config.Instance.LoadUnitTextures("walkingMan")[i]);
                textList.Add(tex);
            }

            //TODO: Created walkingmanlist
            for(int i = 0; i < 5; i++)
            {
                float x = rnd.Next() % 700;
                float y = rnd.Next() % 500;
                r.Add(new walkingMan(new Sprite2D(textList, x, y)));
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

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //position += new Vector2(1, 1);
            for (int i = 0; i < _entities.Count; i++)
            {
                _entities[i].Update(gameTime);
            }
            base.Update(gameTime);
        }

        Vector2 position = Vector2.Zero;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            //spriteBatch.Draw(_texture, position, Color.White);

            for (int i = 0; i < _entities.Count; i++)
            {
                _entities[i].Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
