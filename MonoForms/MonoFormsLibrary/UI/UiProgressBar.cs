using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoFormsLibrary.UI
{
    public class UiProgressBar : BaseUiComponent
    {
        private int _procent;
        public int Procent
        {
            get { return _procent; }
            set
            {
                if (value < 0)
                    _procent = 0;
                else if (value > 100)
                    _procent = 100;
                else
                    _procent = value;
                Text = _procent + "%";
            }
        }

        private Texture2D _progressbarTexture;
        private Texture2D _progressTexture;
        public float Scale = 0.4f;

        public UiProgressBar(Game game, Vector2 position, int procent, SpriteFont font) : base(game, position, false, false, null, "%", font)
        {
            Procent = procent;
            _progressbarTexture = game.Content.Load<Texture2D>("progressbar");
            _progressTexture = game.Content.Load<Texture2D>("progress");
            BoundsRectangle = new Rectangle((int) (Position.X - (_progressbarTexture.Width * Scale) / 2f), (int) (Position.Y - (_progressbarTexture.Height * Scale) / 2f), (int)(_progressbarTexture.Width * Scale), (int)(_progressbarTexture.Height * Scale));
        }

        public override void Update()
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_progressbarTexture,
                Position - new Vector2(_progressbarTexture.Width * Scale / 2f, _progressbarTexture.Height * Scale / 2f),
                null,
                Color.White, 0f,
                Vector2.Zero, Scale,
                SpriteEffects.None, 0f);

            spriteBatch.Draw(_progressTexture,
                Position - new Vector2((_progressTexture.Width * Scale) / 2f, (_progressTexture.Height * Scale) / 2f),
                new Rectangle(0, 0,
                (int) (_progressTexture.Width * (Procent / 100f)),
                (int) _progressTexture.Height),
                Color.White,
                0f,
                Vector2.Zero,
                Scale,
                SpriteEffects.None,
                0f);

            Vector2 textSize = Font.MeasureString(Text);
            spriteBatch.DrawString(Font, Text, Position - textSize / 2, Color.White);
        }
    }
}
