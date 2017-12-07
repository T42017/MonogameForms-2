using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoFormsLibrary.UI
{
    public class UiRadio : BaseUiComponent
    {
        public Texture2D _guiRadio;
        public bool IsChecked = false;
        public float guiScale = 0.2f;
        public float guiWidth;
        public float guiHeight;
        public Rectangle boundsRectangle;

        public UiRadio(Game game, Vector2 position, string text, SpriteFont font) : base(game, position, false, null, text, font)
        {
            _guiRadio = Game.Content.Load<Texture2D>("UnclickedRadio");
            guiWidth = _guiRadio.Width * guiScale;
            guiHeight = _guiRadio.Height * guiScale;
            boundsRectangle = new Rectangle((int) (Position.X - (_guiRadio.Width * guiScale) / 2), (int) (Position.Y - (_guiRadio.Height * guiScale) / 2), (int) (_guiRadio.Width * guiScale), (int) (_guiRadio.Height * guiScale));
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
            _guiRadio = Game.Content.Load<Texture2D>("ClickedRadio");
            IsChecked = true;
        }

        public void UnChecked()
        {
            _guiRadio = Game.Content.Load<Texture2D>("UnclickedRadio");
            IsChecked = false;
        }

        public override void Update() { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 textSize = Font.MeasureString(Text);
            spriteBatch.Draw(_guiRadio, Position - new Vector2(guiWidth / 2f, guiHeight / 2f), null, Color.White, 0f, new Vector2(), guiScale, SpriteEffects.None, 0f);
            spriteBatch.DrawString(Font, Text, Position + new Vector2(_guiRadio.Width/2f, 0) - new Vector2(textSize.X-10, textSize.Y/2), Color.Black, 0, Vector2.Zero, 1f,
            SpriteEffects.None, 0);
        }
    }
}
