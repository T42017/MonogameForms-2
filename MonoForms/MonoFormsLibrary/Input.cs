using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoFormsLibrary
{
    public class Input
    {
        #region Public instance property
        public static Input Instance => _instance ?? (_instance = new Input());
        #endregion

        #region Private fields
        private static Input _instance;
        public KeyboardState KeyboardState = Keyboard.GetState();
        public KeyboardState LastKeyboardState;
        public MouseState MouseState;
        #endregion

        #region Public constructors
        private Input() { }
        #endregion

        #region Public methods
        public void Update()
        {
            LastKeyboardState = KeyboardState;
            KeyboardState = Keyboard.GetState();
        }

        public string[] GetKeyboardCharacters()
        {
            List<Keys> keys = new List<Keys>(KeyboardState.GetPressedKeys());
            List<Keys> lastKeys = new List<Keys>(LastKeyboardState.GetPressedKeys());

            keys.RemoveAll(key => ((int)key) < 65 || ((int)key) > 90);
            lastKeys.RemoveAll(key => ((int)key) < 65 || ((int)key) > 90);

            return (from t in keys where !lastKeys.Exists(key => key.Equals(t)) select t.ToString()).ToArray();
        } 
        #endregion
    }
}