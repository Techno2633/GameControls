using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GameControls.Controls
{
    //public delegate void TextChanged(object sender, EventArgs e);

    public class Textbox : Control
    {
        private string _text;
        private ContentManager _contentManager;
        private Texture2D _unselectedTexture;
        private Texture2D _selectedTexture;
        private bool isSelected;

        public event EventHandler TextChanged;
        public event EventHandler OnClick;

        public Textbox(string text, int x, int y, int width, int height, IServiceProvider contentServiceProvider, string contentRootDirectory)
        {
            _contentManager = new ContentManager(contentServiceProvider, contentRootDirectory);
        }

        public void LoadContent(string unselectedTexture, string selectedTexture)
        {
            _unselectedTexture = _contentManager.Load<Texture2D>(unselectedTexture);
            _selectedTexture = _contentManager.Load<Texture2D>(selectedTexture);
        }

        public void UnloadContent()
        {
            _contentManager.Unload();
        }

        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            if (Bounds.Contains(new Point(mouseState.X, mouseState.Y)))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (OnClick != null)
                    {
                        OnClick(this, new EventArgs());
                    }
                    isSelected = true;
                }
            }
            else
            {
                isSelected = false;
            }

            Keys[] k = keyboardState.GetPressedKeys();
        }

        public void Draw(SpriteBatch spriteBatch, float layerDepth)
        {
            Draw(spriteBatch, 1f, layerDepth: layerDepth);
        }

        public void Draw(SpriteBatch spriteBatch, float scale = 1, float rotation = 0, SpriteEffects spriteEffects = SpriteEffects.None, [Range(0, 1)] float layerDepth = 0)
        {
            Draw(spriteBatch, new Vector2(scale), rotation, spriteEffects, layerDepth);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 scale, float rotation = 0, SpriteEffects spriteEffects = SpriteEffects.None, [Range(0, 1)] float layerDepth = 0)
        {
            if (isSelected)
            {
                spriteBatch.Draw(_selectedTexture, _location, null, Color.White, rotation, Vector2.Zero, scale, spriteEffects, layerDepth);
            }
            else
            {
                spriteBatch.Draw(_unselectedTexture, _location, null, Color.White, rotation, Vector2.Zero, scale, spriteEffects, layerDepth);
            }
        }

        private string ConvertKeysToString(Keys[] keys, bool shift, bool capsLock)
        {
            List<char> chars= new List<char>();
            foreach (Keys key in keys)
            {
                char chr;
                switch (key)
                {
                    case Keys.A: chr = 'a'; break;
                    case Keys.Add: chr = '+'; break;
                    case Keys.B: chr = 'b'; break;
                    case Keys.C: chr = 'c';break;
                    case Keys.D: chr = 'd';break;
                    case Keys.Decimal: chr = '.';break;
                    case Keys.Divide: chr = '/';break;
                    case Keys.E: chr = 'e';break;
                    case Keys.F: chr = 'f';break;
                    case Keys.G: chr = 'g';break;
                    case Keys.H: chr = 'h';break;
                    case Keys.I: chr = 'i';break;
                    case Keys.J: chr = 'j';break;
                    case Keys.K: chr = 'k';break;
                    case Keys.L: chr = 'l';break;
                    case Keys.M: chr = 
                }

                if (shift)
                    chr = char.ToUpper(chr);

                chars.Add(chr);
            }
            return new string(chars.ToArray());
        }
    }
}
