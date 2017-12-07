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
                foreach (BaseUiComponent comp in _components)
                {
                    if (comp.HasClickEvent && comp.BoundsRectangle.Contains(mouseState.Position))
                    {
                        comp.ClickEvent?.Invoke(comp, EventArgs.Empty);
                    }
                }
            }

            string[] strs = Input.Instance.GetKeyboardCharacters();

            for (int i = 0; i < strs.Length; i++)
            {
                Debug.WriteLine(strs[i]);
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
