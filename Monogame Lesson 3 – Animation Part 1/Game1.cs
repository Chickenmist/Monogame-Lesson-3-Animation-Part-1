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

        Random _random;

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
            tribbleGreyRect = new Rectangle(300, 10, 100, 100);
            tribbleGreySpeed = new Vector2(2, 2);
            //

            //Brown tribble
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleBrownRect = new Rectangle(300, 10, 100, 100);
            tribbleBrownSpeed = new Vector2(2, 0);
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
            if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth || tribbleGreyRect.Left < 0)
            {
                tribbleGreySpeed.X *= -1;
            }

            if (tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleGreyRect.Top < 0)
            {
                tribbleGreySpeed.Y *= -1;
            }
            //

            //Brown tribble
            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
            if (tribbleBrownRect.Right > _graphics.PreferredBackBufferWidth || tribbleBrownRect.Left < 0)
            {
                tribbleBrownSpeed.X *= -1;
            }
            //

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}