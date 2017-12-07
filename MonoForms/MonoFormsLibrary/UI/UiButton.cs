using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoFormsLibrary.UI
{
    public class UiButton : BaseUiComponent
    {
        #region Private fields
        public Texture2D Texture;
        private Texture2D _highlightTexture;
        public float TextureScale = 0.5f;
        public float TextureWidth;
        public float TextureHeight;
        public Rectangle BoundsRectangle;
        #endregion

        #region Public constructors
        public UiButton(Game game, Vector2 position, string text, SpriteFont font, EventHandler clickEvent) : base(game, position, true, clickEvent, text, font)
        {
            Texture = Game.Content.Load<Texture2D>("button");
            //_highlightTexture = Game.Content.Load<Texture2D>("playerLife2_red");
            TextureWidth = Texture.Width * TextureScale;
            TextureHeight = Texture.Height * TextureScale;
            BoundsRectangle = new Rectangle((int)(Position.X - (Texture.Width*TextureScale) / 2), (int)(Position.Y - (Texture.Height*TextureScale) / 2), Texture.Width, Texture.Height);
        }
        #endregion

        #region Public overrides
        public override void Update() { }

        public override void Draw(SpriteBatch spriteBatch)
        {
           Vector2 textSize = Font.MeasureString(Text);
            spriteBatch.Draw(Texture, Position - new Vector2(TextureWidth / 2f, TextureHeight / 2f), null, Color.White, 0f , new Vector2(), TextureScale, SpriteEffects.None, 0f);
            spriteBatch.DrawString(Font, Text, Position - textSize / 2- new Vector2(45*TextureScale,0), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);

            if (IsHighlighted)
                spriteBatch.Draw(_highlightTexture, Position - new Vector2(_highlightTexture.Width, _highlightTexture.Height / 2f) - new Vector2(textSize.X / 2, 0), Color.White);
        } 
        #endregion
    }
}