﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace testProject;

public class Game1 : Game
{
    Texture2D courtTexture;
    Vector2 courtPosition;
    Rectangle? courtRectangle;
    Texture2D playerTexture;
    Vector2 playerPosition;
    Vector2 playerOrigin;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        courtPosition = new Vector2(90, 0);
        courtRectangle = new Rectangle(0, 27, 600, 500);

        playerPosition = new Vector2(710, 260);
        playerOrigin = new Vector2(0, 0);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        courtTexture = Content.Load<Texture2D>("tennisCourt");
        playerTexture = Content.Load<Texture2D>("playerCharacter");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(courtTexture, courtPosition, courtRectangle, Color.White);
        _spriteBatch.Draw(playerTexture, playerPosition, null, Color.White, 3.14f, playerOrigin, 1, SpriteEffects.None, 1);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
