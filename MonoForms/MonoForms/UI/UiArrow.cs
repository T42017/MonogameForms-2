using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoForms;

namespace Asteroid_Death_2_Electric_Boogaloo.UI
{
    public class UiArrow : BaseUiComponent
    {
        #region Private fields
        private int _highlight;
        private string _difficulty;
        private Texture2D _textureLeft;
        private Texture2D _textureRight;
        private Texture2D _texture;
        private SpriteFont _font;
        private Game1 _game;
        #endregion

        #region Public constructors
        public UiArrow(Game1 game, Vector2 position) : base(game, position, false, null)
        {
            _game = game;
            _font = _game.Content.Load<SpriteFont>("diff");
            _textureLeft = _game.Content.Load<Texture2D>("Left");
            _textureRight = _game.Content.Load<Texture2D>("Right");
            _texture = game.Content.Load<Texture2D>("button");
            _highlight = 0;
        }
        #endregion

        #region Public overrides
        public override void Update()
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position - new Vector2(_texture.Width / 2f, _texture.Height / 2f), Color.White);
            spriteBatch.DrawString(_font, _difficulty, Position - new Vector2((_textureLeft.Width / 2f) + 25f, (_textureLeft.Height / 2f)), Color.Black, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);
            spriteBatch.Draw(_textureLeft, Position - new Vector2((_textureLeft.Width / 2f) + 120f, _textureLeft.Height / 2f), Color.White);
            spriteBatch.Draw(_textureRight, Position - new Vector2((_textureRight.Width / 2f) - 120f, _textureRight.Height / 2f), Color.White);
        } 
        #endregion
    }
}