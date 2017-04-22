using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameControls.Controls
{
    //public delegate void OnClick(object sender, EventArgs e);

    public class Control
    {
        protected Vector2 _size;
        protected Vector2 _location;

        public Vector2 Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Vector2 Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public Rectangle Bounds
        {
            get { return new Rectangle((int)_location.X, (int)_location.Y, (int)_size.X, (int)_size.Y); }
        }

        public Control()
        {
            _size = new Vector2(10, 10);
            _location = Vector2.Zero;
        }

        public Control(int x, int y, int width, int height)
        {
            _size = new Vector2(width, height);
            _location = new Vector2(x, y);
        }
    }
}
