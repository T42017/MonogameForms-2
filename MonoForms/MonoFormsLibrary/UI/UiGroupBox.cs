using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoFormsLibrary.UI
{
    public class UiGroupBox: BaseUiComponent
    {
        public UiGroupBox(Game game, Vector2 position, string text, SpriteFont font) : base(game, position, false, null, text, font)
        {
            _guiRadio = Game.Content.Load<Texture2D>("UnclickedRadio");
            guiWidth = _guiRadio.Width * guiScale;
            guiHeight = _guiRadio.Height * guiScale;
            boundsRectangle = new Rectangle((int)(Position.X - (_guiRadio.Width * guiScale) / 2), (int)(Position.Y - (_guiRadio.Height * guiScale) / 2), (int)(_guiRadio.Width * guiScale),
                (int)(_guiRadio.Height * guiScale));
        }
        public override void Update() { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
