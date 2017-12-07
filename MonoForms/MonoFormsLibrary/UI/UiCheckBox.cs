using System;
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
        public float guiScale = 0.3f;
        public float guiWidth;
        public float guiHeight;
        public Rectangle boundsRectangle;

        public UiCheckBox(Game game, Vector2 position, string text, SpriteFont font, EventHandler clickEvent) : base(game, position, true, clickEvent, text, font)
        {
            _guiCheckBox = Game.Content.Load<Texture2D>("UnCheckedBox");
            guiWidth = _guiCheckBox.Width * guiScale;
            guiHeight = _guiCheckBox.Height * guiScale;
            boundsRectangle = new Rectangle((int)(Position.X - (_guiCheckBox.Width * guiScale) / 2), (int)(Position.Y - (_guiCheckBox.Height * guiScale) / 2), (int)(_guiCheckBox.Width * guiScale), (int)(_guiCheckBox.Height * guiScale));
        }

        public void Toggle()
        {
            if (IsChecked)
                UnChecked();
            else
            {
                Checked();
            }
        }


        public void Checked()
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
            Vector2 textSize = Font.MeasureString(Text);
            spriteBatch.Draw(_guiCheckBox, Position - new Vector2(guiWidth / 2f, guiHeight / 2f), null, Color.White, 0f, new Vector2(), guiScale, SpriteEffects.None, 0f);
            spriteBatch.DrawString(Font, Text, Position - textSize / 2, Color.Black, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}
