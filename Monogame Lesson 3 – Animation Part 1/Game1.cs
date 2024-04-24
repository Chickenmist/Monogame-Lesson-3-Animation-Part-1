using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Runtime.CompilerServices;

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

        //Sonic Ball
        Texture2D sonicBallTexture;
        Rectangle sonicBallRect;
        Vector2 sonicBallSpeed;
        //

        Texture2D tribbleIntroTexture;
        Rectangle tribbleIntroRect;

        Color bgColor;

        SoundEffect tribbleCoo;

        Song bgm;

        MouseState mouseState;

        enum Screen
        {
            Intro,
            TribbleYard
        }

        Screen screen;

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

            Window.Title = "Tribble Yard";

            screen = Screen.Intro;
            tribbleIntroRect = new Rectangle(0, 0, 800, 600);

            //Gray tribble 
            tribbleGreyRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);
            tribbleGreySpeed = new Vector2(2, 2);
            //

            //Brown tribble
            tribbleBrownRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);
            tribbleBrownSpeed = new Vector2(2, 0);
            //

            //Orange tribble
            tribbleOrangeRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);
            tribbleOrangeSpeed = new Vector2(2, 2);
            //

            //Cream tribble
            tribbleCreamRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);
            tribbleCreamSpeed = new Vector2(0, 2);
            //

            //Sonic Ball
            sonicBallRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);
            sonicBallSpeed = new Vector2(2,2);
            //

            MediaPlayer.Volume = 0.8f;
            MediaPlayer.IsRepeating = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");

            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");

            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");

            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");

            tribbleIntroTexture = Content.Load<Texture2D>("tribble_intro");

            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");

            bgm = Content.Load<Song>("Sonic_2_Drowning");

            sonicBallTexture = Content.Load<Texture2D>("sonicBall");
        }

        private Color GetRandColor()
        {
            return new Color(_random.Next(0, 256), _random.Next(0, 256), _random.Next(0, 256));
        }


        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    Window.Title = "Tribble Yard";
                    bgColor = Color.White;

                    screen = Screen.TribbleYard;
                    MediaPlayer.Play(bgm);
                }

            }
            else if (screen == Screen.TribbleYard)
            {
                // Gray tribble
                tribbleGreyRect.Offset(tribbleGreySpeed);
                if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth)
                {
                    tribbleGreyRect.X = _graphics.PreferredBackBufferWidth - tribbleGreyRect.Width;

                    tribbleGreySpeed = new Vector2(_random.Next(-15, 0), _random.Next(-15, 16));

                    tribbleCoo.Play();
                }
                else if (tribbleGreyRect.Left < 0)
                {
                    tribbleGreyRect.X = 0;

                    tribbleGreySpeed = new Vector2(_random.Next(1, 16), _random.Next(-15, 16));

                    tribbleCoo.Play();
                }

                if (tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight)
                {
                    tribbleGreyRect.Y = _graphics.PreferredBackBufferHeight - tribbleGreyRect.Height;

                    tribbleGreySpeed = new Vector2(_random.Next(-15, 16), _random.Next(-15, 0));

                    tribbleCoo.Play();
                }
                else if (tribbleGreyRect.Top < 0)
                {
                    tribbleGreyRect.Y = 0;

                    tribbleGreySpeed = new Vector2(_random.Next(-15, 16), _random.Next(1, 16));

                    tribbleCoo.Play();
                }
                //

                //Brown tribble
                tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
                if (tribbleBrownRect.Right > _graphics.PreferredBackBufferWidth)
                {
                    tribbleBrownRect.X = _graphics.PreferredBackBufferWidth - tribbleBrownRect.Width;
                    tribbleBrownSpeed = new Vector2(_random.Next(-16, 0), 0);
                    tribbleCoo.Play();
                }
                else if (tribbleBrownRect.Left < 0)
                {
                    tribbleBrownRect.X = 0;
                    tribbleBrownSpeed = new Vector2(_random.Next(1, 16), 0);
                    tribbleCoo.Play();
                }
                //

                //Orange tribble A.K.A the Tribble of Chaos
                tribbleOrangeRect.Offset(tribbleOrangeSpeed);
                if (tribbleOrangeRect.Right > _graphics.PreferredBackBufferWidth || tribbleOrangeRect.Left < 0)
                {
                    bgColor = GetRandColor();

                    tribbleOrangeRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);

                    tribbleCoo.Play();


                    if (tribbleOrangeSpeed.X < 100000 & tribbleOrangeSpeed.X > 0)
                    {
                        tribbleOrangeSpeed.X += 1;
                    }
                    else if (tribbleOrangeSpeed.X > -100000 & tribbleOrangeSpeed.X < 0)
                    {
                        tribbleOrangeSpeed.X -= 1;
                    }

                    tribbleOrangeSpeed.X *= -1;
                }

                if (tribbleOrangeRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleOrangeRect.Top < 0)
                {
                    bgColor = GetRandColor();

                    tribbleOrangeRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);

                    tribbleCoo.Play();

                    if (tribbleOrangeSpeed.Y < 100000 & tribbleOrangeSpeed.Y > 0)
                    {
                        tribbleOrangeSpeed.Y += 1;
                    }
                    else if (tribbleOrangeSpeed.Y > -100000 & tribbleOrangeSpeed.Y < 0)
                    {
                        tribbleOrangeSpeed.Y -= 1;
                    }

                    tribbleOrangeSpeed.Y *= -1;
                }

                if (tribbleOrangeRect.Intersects(tribbleGreyRect) || tribbleOrangeRect.Intersects(tribbleBrownRect) || tribbleOrangeRect.Intersects(tribbleCreamRect))
                {
                    tribbleOrangeRect = new Rectangle(_random.Next(0, _graphics.PreferredBackBufferWidth - 100), _random.Next(0, _graphics.PreferredBackBufferHeight - 100), 100, 100);

                    tribbleCoo.Play();

                    tribbleOrangeSpeed.X *= -1;
                    tribbleOrangeSpeed.Y *= 1;
                }
                //

                //Cream tribble
                tribbleCreamRect.Offset(tribbleCreamSpeed);
                if (tribbleCreamRect.Top > _graphics.PreferredBackBufferHeight)
                {
                    tribbleCoo.Play();

                    tribbleCreamRect.Y = 0 - tribbleCreamRect.Height;

                    tribbleCreamSpeed.Y = _random.Next(1, 16);
                }
                //

                //Sonic Ball
                sonicBallRect.Offset(sonicBallSpeed);
                {
                    if (sonicBallRect.Bottom > _graphics.PreferredBackBufferHeight)
                    {
                        sonicBallRect.Y = _graphics.PreferredBackBufferHeight - sonicBallRect.Height;
                        sonicBallSpeed.Y += 1;
                        sonicBallSpeed.Y *= -1;
                    }

                    if (sonicBallRect.Top < 0)
                    {

                    }
                }
                //
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

                // TODO: Add your drawing code here
            
            GraphicsDevice.Clear(bgColor);
            
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntroTexture, tribbleIntroRect, Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
                _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
                _spriteBatch.Draw(sonicBallTexture, sonicBallRect, Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}