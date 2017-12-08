using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoFormsLibrary.UI
{
    public class Menu
    {

        private readonly List<BaseUiComponent> _components = new List<BaseUiComponent>();

        private bool HasClickedLeftMouseButton;
        
        public Menu()
        {

        }

        public void Add(BaseUiComponent component)
        {
            _components.Add(component);
        }

        public void RemoveAt(int index)
        {
            _components.RemoveAt(index);
        }

        public void Remove(BaseUiComponent component)
        {
            _components.Remove(component);
        }

        public void RemoveAll()
        {
            _components.RemoveRange(0, _components.Count);
        }

        public BaseUiComponent Get(int index)
        {
            return _components[index];
        }

        public void Update()
        {
            Input.Instance.Update();

            MouseState mouseState = Input.Instance.MouseState;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (!HasClickedLeftMouseButton)
                {
                    foreach (BaseUiComponent comp in _components)
                    {
                        if (comp.BoundsRectangle.Contains(mouseState.Position))
                        {
                            if (comp.HasClickEvent) comp.ClickEvent?.Invoke(comp, EventArgs.Empty);
                            if (comp.canHaveFocus) comp.hasFocus = true;
                        }
                        else
                        {
                            if (comp.canHaveFocus) comp.hasFocus = false;
                        }
                    }
                }
                HasClickedLeftMouseButton = true;
            }
            else
            {
                HasClickedLeftMouseButton = false;
            }

            foreach (BaseUiComponent comp in _components)
            {
                comp.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseUiComponent comp in _components)
            {
                comp.Draw(spriteBatch);
            }
        }
    }
}
