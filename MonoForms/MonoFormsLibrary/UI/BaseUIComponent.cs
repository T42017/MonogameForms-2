using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoFormsLibrary.UI
{
    public abstract class BaseUiComponent
    {
        #region Protected fields
        protected Game Game;
        #endregion

        #region Public properties
        public Vector2 Position { get; }
        public bool IsHighlighted { get; set; }
        public bool CanBeHighLighted { get; }
        public bool HasClickEvent { get; }
        public string Text { get; set; } = "";
        public SpriteFont Font { get; }
        public EventHandler ClickEvent { get; }
        public Rectangle BoundsRectangle;

        public bool canHaveFocus;
        public bool hasFocus;
        #endregion

        #region Protected constructors
        protected BaseUiComponent(Game game, Vector2 position, bool canBeHighlighted, bool canHaveFocus, EventHandler clickEvent, string text, SpriteFont font)
        {
            Game = game;
            Position = position + new Vector2(1280 / 2f, 720 / 2f);
            CanBeHighLighted = canBeHighlighted;
            ClickEvent = clickEvent;
            Text = text;
            Font = font;

            if (ClickEvent != null)
                HasClickEvent = true;
        }

        protected BaseUiComponent(Game game, Vector2 position, bool canBeHighlighted, bool canHaveFocus, EventHandler clickEvent, SpriteFont font)
        {
            Game = game;
            Position = position + new Vector2(1280 / 2f, 720 / 2f);
            CanBeHighLighted = canBeHighlighted;
            ClickEvent = clickEvent;
            Font = font;

            if (ClickEvent != null)
                HasClickEvent = true;
        }

        protected BaseUiComponent(Game game, Vector2 position, bool canBeHighlighted, bool canHaveFocus, EventHandler clickEvent)
        {
            Game = game;
            Position = position + new Vector2(1280 / 2f, 720 / 2f);
            CanBeHighLighted = canBeHighlighted;
            ClickEvent = clickEvent;

            if (ClickEvent != null)
                HasClickEvent = true;
        }

        protected BaseUiComponent(Game game, Vector2 position)
        {
            Game = game;
            Position = position + new Vector2(1280 / 2f, 720 / 2f);
            CanBeHighLighted = false;
            HasClickEvent = false;
        }
        #endregion

        #region Public abstract methods
        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch); 
        #endregion
    }
}