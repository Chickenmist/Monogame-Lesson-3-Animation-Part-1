using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Lesson_3___Animation_Part_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random _random = new Random();

        //Gray tribble variables
        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;
        //

        //Brown tribble variables
        Texture2D tribbleBrownTexture;
        Rectangle tribbleBrownRect;
        Vector2 tribbleBrownSpeed;
        //

        //Orange tribble variables
        Texture2D tribbleOrangeTexture;
        Rectangle tribbleOrangeRect;
        Vector2 tribbleOrangeSpeed;
        //

        //Cream tribble variables
        Texture2D tribbleCreamTexture;
        Rectangle tribbleCreamRect;
        Vector2 tribbleCreamSpeed;
        //

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            //Gray tribble 
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleGreyRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);
            tribbleGreySpeed = new Vector2(2, 2);
            //

            //Brown tribble
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleBrownRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);
            tribbleBrownSpeed = new Vector2(2, 0);
            //

            //Orange tribble
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleOrangeRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);
            tribbleOrangeSpeed = new Vector2(2, 2);
            //

            //Cream tribble

            //

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Gray tribble
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth)
            {
                tribbleGreyRect.X = _graphics.PreferredBackBufferWidth - tribbleBrownRect.Width;

                tribbleGreySpeed = new Vector2(_random.Next(-15, 0), _random.Next(-15, 16));
            }
            else if (tribbleGreyRect.Left < 0)
            {
                tribbleGreyRect.X = 0;

                tribbleGreySpeed = new Vector2(_random.Next(1, 16), _random.Next(-15, 16));
            }

            if (tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight)
            {
                tribbleGreyRect.Y = _graphics.PreferredBackBufferHeight - tribbleBrownRect.Height;

                tribbleGreySpeed = new Vector2(_random.Next(-15, 16), _random.Next(-15, 0));
            }
            else if (tribbleGreyRect.Top < 0)
            {
                tribbleGreyRect.Y = 0;

                tribbleGreySpeed = new Vector2(_random.Next(-15, 16), _random.Next(1, 16));
            }
            //

            //Brown tribble
            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            if (tribbleBrownRect.Right > _graphics.PreferredBackBufferWidth)
            {
                tribbleBrownRect.X = _graphics.PreferredBackBufferWidth - tribbleBrownRect.Width;
                tribbleBrownSpeed = new Vector2(_random.Next(-16, 0), 0);
            }
            else if (tribbleBrownRect.Left < 0)
            {
                tribbleBrownRect.X = 0;
                tribbleBrownSpeed = new Vector2(_random.Next(1, 16), 0);
            }

            //

            //Orange tribble
            tribbleOrangeRect.Offset(tribbleOrangeSpeed);
            if (tribbleOrangeRect.Right > _graphics.PreferredBackBufferWidth || tribbleOrangeRect.Left < 0)
            {
                tribbleOrangeSpeed.X *= -2;
            }

            if (tribbleOrangeRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleOrangeRect.Top < 0)
            {
                tribbleOrangeSpeed.Y *= -2;
            }
            //

            //Cream tribble

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}