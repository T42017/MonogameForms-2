using System;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoFormsLibrary.UI
{
    public class UiTextbox : BaseUiComponent
    {
        #region Private fields
        public readonly Texture2D _texture;
        public readonly Texture2D _t; //base for the line texture
        public StringBuilder _text = new StringBuilder();
        private const int _framesBetweenBlicks = 25;
        private int _currentFrame = 0;
        private bool _drawUnderScore = false;
        #endregion

        #region Public properties
#pragma warning disable 108,114
        public string Text

#pragma warning restore 108,114
        {
            get { return _text.ToString(); }
            set
            {
                _text.Clear();
                _text.Append(value);
            }
        }
        #endregion

        #region Public constructors
        public UiTextbox(Game game, Vector2 position, SpriteFont font) : base(game, position, true, null, font)
        {
            _texture = Game.Content.Load<Texture2D>("button");

            _t = new Texture2D(game.GraphicsDevice, 1, 1);
            _t.SetData<Color>(
                new Color[] { Color.White });
        }
        #endregion

        #region Private methods
        private void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle =
                (float)Math.Atan2(edge.Y, edge.X);

            sb.Draw(_t,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                Color.Black, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);
        }
        #endregion

        #region Public overrides
        public override void Update()
        {
            if (!IsHighlighted)
            {
                _drawUnderScore = false;
                return;
            }

            _currentFrame++;
            if (_currentFrame >= _framesBetweenBlicks)
            {
                _currentFrame -= _framesBetweenBlicks;
                _drawUnderScore = !_drawUnderScore;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 textSize = Font.MeasureString(_text);
            spriteBatch.Draw(_texture, Position - new Vector2(_texture.Width / 2f, _texture.Height / 2f), Color.White);

            spriteBatch.DrawString(Font, _text.ToString(), Position - (textSize / 2), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);

            if (!_drawUnderScore) return;

            Vector2 lineDrawPosition = new Vector2(textSize.X / 2, textSize.Y == 0 ? 16 : textSize.Y / 2);
            DrawLine(spriteBatch, Position + lineDrawPosition + new Vector2(0, 0),
                Position + lineDrawPosition + new Vector2(30, 0));
            DrawLine(spriteBatch, Position + lineDrawPosition + new Vector2(0, -1),
                Position + lineDrawPosition + new Vector2(30, -1));
        }
        #endregion



        public void AddKeyToText(Keys key, KeyboardState ckstate, KeyboardState lkstate)
        {
            string newChar = "";

            if (_text.Length >= 20 && key != Keys.Back)
                return;

            switch (key)
            {
                case Keys.A:
                    newChar += "a";
                    break;
                case Keys.B:
                    newChar += "b";
                    break;
                case Keys.C:
                    newChar += "c";
                    break;
                case Keys.D:
                    newChar += "d";
                    break;
                case Keys.E:
                    newChar += "e";
                    break;
                case Keys.F:
                    newChar += "f";
                    break;
                case Keys.G:
                    newChar += "g";
                    break;
                case Keys.H:
                    newChar += "h";
                    break;
                case Keys.I:
                    newChar += "i";
                    break;
                case Keys.J:
                    newChar += "j";
                    break;
                case Keys.K:
                    newChar += "k";
                    break;
                case Keys.L:
                    newChar += "l";
                    break;
                case Keys.M:
                    newChar += "m";
                    break;
                case Keys.N:
                    newChar += "n";
                    break;
                case Keys.O:
                    newChar += "o";
                    break;
                case Keys.P:
                    newChar += "p";
                    break;
                case Keys.Q:
                    newChar += "q";
                    break;
                case Keys.R:
                    newChar += "r";
                    break;
                case Keys.S:
                    newChar += "s";
                    break;
                case Keys.T:
                    newChar += "t";
                    break;
                case Keys.U:
                    newChar += "u";
                    break;
                case Keys.V:
                    newChar += "v";
                    break;
                case Keys.W:
                    newChar += "w";
                    break;
                case Keys.X:
                    newChar += "x";
                    break;
                case Keys.Y:
                    newChar += "y";
                    break;
                case Keys.Z:
                    newChar += "z";
                    break;
                case Keys.Space:
                    newChar += " ";
                    break;
                case Keys.Back:
                    if (_text.Length != 0)
                        _text = _text.Remove(_text.Length - 1, 1);
                    return;
            }
            if (lkstate.IsKeyDown(Keys.RightShift) ||
                ckstate.IsKeyDown(Keys.LeftShift))
            {
                newChar = newChar.ToUpper();
            }
            _text.Append(newChar);
            Debug.WriteLine("Added character");
        }

        public bool CheckKey(Keys theKey, KeyboardState ckstate, KeyboardState lkstate)
        {
            return lkstate.IsKeyDown(theKey) && ckstate.IsKeyUp(theKey);
        }
    }
}