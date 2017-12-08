using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoFormsLibrary.UI;

namespace MonoForms
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public int WindowWidth, WindowHeight;
        public Menu Menu1;
        public bool MoveUp = true;
        public UiButton Btn;
        public bool hasClicked;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            WindowWidth = graphics.PreferredBackBufferWidth;
            WindowHeight = graphics.PreferredBackBufferHeight;
            // TODO: Add your initialization logic here
           
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

            SpriteFont font = Content.Load<SpriteFont>("file");

            UiProgressBar progressbar = new UiProgressBar(this, new Vector2(0, 200), 51, font);
            UiTextbox textbox = new UiTextbox(this, new Vector2(0, -100), font);
            UiRadio radio = new UiRadio(this, new Vector2(0, -200), "hejsan", font);
            UiCheckBox box = new UiCheckBox(this, new Vector2(0, 0), "checkbox", font);

            UiButton btn = new UiButton(this, new Vector2(0, 100), "Hej", font,
            delegate (object sender, EventArgs args)
            {
                progressbar.Procent += (MoveUp ? 2 : -3);

                switch (progressbar.Procent)
                {
                    case 100:
                        MoveUp = false;
                        break;
                    case 0:
                        MoveUp = true;
                        break;

                }
                if (box.IsChecked)
                    textbox.IsVisible = false;
                else
                    textbox.IsVisible = true;
            });

            Menu1 = new Menu();
            Menu1.Add(btn);
            Menu1.Add(textbox);
            Menu1.Add(radio);
            Menu1.Add(box);
            Menu1.Add(progressbar);
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

            Menu1.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            Menu1.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
