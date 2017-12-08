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
        Keys[] keysToCheck = new Keys[] {

            Keys.A, Keys.B, Keys.C, Keys.D, Keys.E,
            Keys.F, Keys.G, Keys.H, Keys.I, Keys.J,
            Keys.K, Keys.L, Keys.M, Keys.N, Keys.O,
            Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T,
            Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y,
            Keys.Z, Keys.Back, Keys.Space };

        #region Private fields
        public readonly Texture2D _texture;
        public readonly Texture2D _t; //base for the line texture
        public StringBuilder _text = new StringBuilder();
        private const int _framesBetweenBlicks = 25;
        private int _currentFrame = 0;
        private bool _drawUnderScore = false;
        public float scale = 0.4f;
        public float textureWidth;
        public float textureHeight;
        #endregion

        #region Public properties
        public string Text
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
        public UiTextbox(Game game, Vector2 position, SpriteFont font) : base(game, position, true, true, ClickEvent, font)
        {
            _texture = Game.Content.Load<Texture2D>("button");
            textureWidth = _texture.Width * scale;
            textureHeight = _texture.Height * scale;

            _t = new Texture2D(game.GraphicsDevice, 1, 1);
            _t.SetData<Color>(
                new Color[] { Color.White });
            BoundsRectangle = new Rectangle((int)(Position.X - textureWidth / 2), (int)(Position.Y - textureHeight / 2), (int)textureWidth, (int)textureHeight);
        }
        #endregion

        private static void ClickEvent(object sender, EventArgs eventArgs)
        {
            ((UiCheckBox)sender)?.Toggle();
        }

        #region Private methods
        private void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle = (float)Math.Atan2(edge.Y, edge.X);

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
            if (hasFocus)
            {
                KeyboardState currentKeyboardState = MonoFormsLibrary.Input.Instance.KeyboardState;
                KeyboardState lastKeyboardState = MonoFormsLibrary.Input.Instance.LastKeyboardState;

                foreach (Keys key in keysToCheck)
                {
                    if (CheckKey(key, currentKeyboardState, lastKeyboardState))
                    {
                        AddKeyToText(key, currentKeyboardState, lastKeyboardState);
                        break;
                    }
                }
            }

            if (!IsHighlighted)
            {
                _drawUnderScore = false;
                return;
            }

            _currentFrame++;
            if (_currentFrame < _framesBetweenBlicks) return;

            _currentFrame -= _framesBetweenBlicks;
            _drawUnderScore = !_drawUnderScore;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 textSize = Font.MeasureString(_text);
            spriteBatch.Draw(_texture, Position - new Vector2(textureWidth / 2f, textureHeight / 2f), null, Color.White, 0f, new Vector2(), scale, SpriteEffects.None, 0f);

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