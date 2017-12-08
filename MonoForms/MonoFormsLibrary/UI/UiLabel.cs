using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoFormsLibrary.UI
{
    public class UiLabel : BaseUiComponent
    {
        #region Public constructors

        public UiLabel(Game game, Vector2 position, string text, SpriteFont font) : base(game, position, false, false,
            null, text, font)
        {
            Vector2 textSize = font.MeasureString(text);
            BoundsRectangle = new Rectangle((int)(Position.X - textSize.X / 2), (int)(Position.Y - textSize.Y / 2), (int) textSize.X, (int) textSize.Y);
        }
        #endregion

        #region Public overrides
        public override void Update() { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, Position - (Font.MeasureString(Text) / 2), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);
        } 
        #endregion
    }
}