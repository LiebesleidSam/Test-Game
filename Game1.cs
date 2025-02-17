using Microsoft.Xna.Framework;
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
    float playerRotation;
    float playerSpeed;
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

        playerPosition = new Vector2(710, _graphics.PreferredBackBufferHeight / 2);
        playerRotation = 3.14f;
        playerSpeed = 100f;

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
        float updatedPlayerSpeed = playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up))
        {
            playerPosition.Y -= updatedPlayerSpeed;
        }

        if (kstate.IsKeyDown(Keys.Down))
        {
            playerPosition.Y += updatedPlayerSpeed;
        }

        if (kstate.IsKeyDown(Keys.Left))
        {
            playerPosition.X -= updatedPlayerSpeed;
        }

        if (kstate.IsKeyDown(Keys.Right))
        {
            playerPosition.X += updatedPlayerSpeed;
        }

        if (playerPosition.X > _graphics.PreferredBackBufferWidth - playerTexture.Width / 2)
        {
            playerPosition.X = _graphics.PreferredBackBufferWidth - playerTexture.Width / 2;
        }
        else if (playerPosition.X < playerTexture.Width / 2)
        {
            playerPosition.X = playerTexture.Width / 2;
        }

        if (playerPosition.Y > _graphics.PreferredBackBufferHeight - playerTexture.Height / 2)
        {
            playerPosition.Y = _graphics.PreferredBackBufferHeight - playerTexture.Height / 2;
        }
        else if (playerPosition.Y < playerTexture.Height / 2)
        {
            playerPosition.Y = playerTexture.Height / 2;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(courtTexture, courtPosition, courtRectangle, Color.White);
        _spriteBatch.Draw(playerTexture, playerPosition, null, Color.White, playerRotation,
            new Vector2(playerTexture.Width / 2, playerTexture.Height / 2), 1, SpriteEffects.None, 0f);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
