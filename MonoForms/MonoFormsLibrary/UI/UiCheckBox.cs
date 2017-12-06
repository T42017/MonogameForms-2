﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoFormsLibrary.UI
{
    public class UiCheckBox:BaseUiComponent
    {
        public Texture2D _guiCheckBox;
        public bool IsChecked = false;

        public UiCheckBox(Game game, Vector2 position, string text, SpriteFont font, EventHandler clickEvent) : base(game, position, true, clickEvent, text, font)
        {
            _guiCheckBox = Game.Content.Load<Texture2D>("UnCheckedBox");
        }

        public void Check()
        {
            _guiCheckBox = Game.Content.Load<Texture2D>("checkedBox");
            IsChecked = true;
        }
        public void UnChecked()
        {
            _guiCheckBox = Game.Content.Load<Texture2D>("UnCheckedBox");
            IsChecked = false;
        }

        public override void Update() { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            float guiScale = 0.3f;
            float guiWidth = _guiCheckBox.Width * guiScale;
            float guiHeight = -_guiCheckBox.Height * guiScale;

            Vector2 textSize = Font.MeasureString(Text);
            spriteBatch.Draw(_guiCheckBox, Position - new Vector2(guiWidth / 2f, guiHeight / 2f), null, Color.White, 0f, new Vector2(), guiScale, SpriteEffects.None, 0f);
            spriteBatch.DrawString(Font, Text, Position - textSize / 2, Color.Black, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}