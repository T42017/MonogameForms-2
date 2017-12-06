﻿using System;
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
        private bool textboxedit = false;
        public UiTextbox txtbox;
        public UiButton btn;

        Keys[] keysToCheck = new Keys[] {

            Keys.A, Keys.B, Keys.C, Keys.D, Keys.E,
            Keys.F, Keys.G, Keys.H, Keys.I, Keys.J,
            Keys.K, Keys.L, Keys.M, Keys.N, Keys.O,
            Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T,
            Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y,
            Keys.Z, Keys.Back, Keys.Space };

        KeyboardState currentKeyboardState;
        KeyboardState lastKeyboardState;

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
            // TODO: Add your initialization logic here
            WindowWidth = graphics.PreferredBackBufferWidth;
            WindowHeight = graphics.PreferredBackBufferHeight;
           
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
            btn = new UiButton(this, Vector2.One, "Hej", Content.Load<SpriteFont>("file") ,
                delegate(object sender, EventArgs args)
                {
                    Exit();
                });
            txtbox = new UiTextbox(this, Vector2.One, Content.Load<SpriteFont>("file"));
            // TODO: use this.Content to load your game content here
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

            MouseState mouseState = Mouse.GetState();
            
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Rectangle r = new Rectangle((int)btn.Position.X - btn._texture.Width / 2, (int)btn.Position.Y - btn._texture.Height / 2, btn._texture.Width, btn._texture.Height);
                if (r.Contains(mouseState.Position))
                {
                    Debug.WriteLine("Du är värdelös :P");
                }
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Rectangle r = new Rectangle((int)txtbox.Position.X - txtbox._texture.Width / 2, (int)btn.Position.Y - btn._texture.Height / 2, btn._texture.Width, btn._texture.Height);
                if (r.Contains(mouseState.Position))
                {
                    Debug.WriteLine("click!");
                    textboxedit = true;
                }
            }


            if (textboxedit)
            {
                currentKeyboardState = Keyboard.GetState();

                foreach (Keys key in keysToCheck)
                {
                    if (txtbox.CheckKey(key, currentKeyboardState, lastKeyboardState))
                    {
                        txtbox.AddKeyToText(key, currentKeyboardState, lastKeyboardState);
                        break;
                    }
                }

                base.Update(gameTime);

                lastKeyboardState = currentKeyboardState;
            }

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            btn.Draw(spriteBatch);
            txtbox.Draw(spriteBatch);
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
