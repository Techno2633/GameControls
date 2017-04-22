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
    public class Button : Control
    {
        private Texture2D _unselectedTexture;
        private Texture2D _selectedTexture;
        private bool isSelected;
        private ContentManager _contentManager;

        public event EventHandler OnClick;

        public Button(int x, int y, int width, int height, IServiceProvider contentServiceProvider, string contentRootDirectory) : base(x, y, width, height)
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

        public void Update(MouseState mouseState)
        {
            if (Bounds.Contains(new Point(mouseState.X, mouseState.Y)))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (OnClick != null)
                    {
                        OnClick(this, new EventArgs());
                    }
                }

                isSelected = true;
            }
            else
            {
                isSelected = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, float layerDepth)
        {
            Draw(spriteBatch, 1f, layerDepth: layerDepth);
        }

        public void Draw(SpriteBatch spriteBatch, float scale = 1, float rotation = 0, SpriteEffects spriteEffects = SpriteEffects.None, [Range(0,1)] float layerDepth = 0)
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
    }
}
