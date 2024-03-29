using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Task1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle currentSquare;
        Texture2D squareTexture, squareTexture2;
        Boolean flyingRight, flyingUp;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            currentSquare = new Rectangle(250, 50, 100, 30);
            this.flyingRight = true;
            this.flyingUp = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            squareTexture = Content.Load<Texture2D>(@"helicopter");
            squareTexture2 = Content.Load<Texture2D>(@"helicopter2");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            if (currentSquare.Location.X == GraphicsDevice.Viewport.Width-currentSquare.Width)
            {
                flyingRight = false;
            }
            else if (currentSquare.Location.X == 0)
            {
                flyingRight = true;
            }

            if (currentSquare.Location.Y == GraphicsDevice.Viewport.Height - currentSquare.Height)
            {
                flyingUp = true;
            }
            else if (currentSquare.Location.Y == 0)
            {
                flyingUp = false;
            }
            

            if (flyingRight == true)
            {
                currentSquare.Offset(5, 0);
            }
            else
            {
                currentSquare.Offset(-5, 0);
            }

            if (flyingUp == true)
            {
                currentSquare.Offset(0, -1);
            }
            else
            {
                currentSquare.Offset(0, 1);
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (flyingRight)
            {
                spriteBatch.Draw(squareTexture2, currentSquare, Color.White);
            }
            else
            {
                spriteBatch.Draw(squareTexture, currentSquare, Color.White);
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
