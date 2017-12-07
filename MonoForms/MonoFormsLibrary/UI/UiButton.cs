using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoFormsLibrary.UI
{
    public class UiButton : BaseUiComponent
    {
        #region Private fields
        public Texture2D _texture;
        private Texture2D _highlightTexture;
        public float textureScale = 0.4f;
        public float textureWidth;
        public float textureHeight;
        #endregion

        #region Public constructors
        public UiButton(Game game, Vector2 position, string text, SpriteFont font, EventHandler clickEvent) : base(game, position, true, clickEvent, text, font)
        {
            _texture = Game.Content.Load<Texture2D>("button");
            //_highlightTexture = Game.Content.Load<Texture2D>("playerLife2_red");
            textureWidth = _texture.Width * textureScale;
            textureHeight = _texture.Height * textureScale;
            BoundsRectangle = new Rectangle((int)(Position.X - (_texture.Width * textureScale) / 2), (int)(Position.Y - (_texture.Height * textureScale) / 2), _texture.Width, _texture.Height);
        }
        #endregion

        #region Public overrides
        public override void Update() { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 textSize = Font.MeasureString(Text);
            spriteBatch.Draw(_texture, Position - new Vector2(textureWidth / 2f, textureHeight / 2f), null, Color.White, 0f, new Vector2(), textureScale, SpriteEffects.None, 0f);
            spriteBatch.DrawString(Font, Text, Position - textSize / 2 - new Vector2(45 * textureScale, 0), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);

            if (IsHighlighted)
                spriteBatch.Draw(_highlightTexture, Position - new Vector2(_highlightTexture.Width, _highlightTexture.Height / 2f) - new Vector2(textSize.X / 2, 0), Color.White);
        }
        #endregion
    }
}