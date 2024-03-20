using System.Data;
using System.Numerics;
using Raylib_cs;

string Scene = "Cavern";
int PlayerX = 520;
int PlayerY = 400;
int Lives = 3;
bool Direction = true;
bool GameOver = false;
Vector2 VectorBackground = new(0, 0);
//Vector2 PlayerVector= new(PlayerX,PlayerY);

Raylib.InitWindow(1200, 900, "The Thing");
Raylib.SetTargetFPS(60);
// dem 4 bilderna jag har lagt till i spelet
Texture2D Scene1 = Raylib.LoadTexture("Cavern.png");
Texture2D Scene2 = Raylib.LoadTexture("ExitFromCavern.png");
Texture2D BoreLeftTexture = Raylib.LoadTexture("Bore.png");
Texture2D BoreRightTexture = Raylib.LoadTexture("BoarRight.png");

// Själva Main delen där koden är
while (!Raylib.WindowShouldClose())
{
    Vector2 PlayerVector = new(100, 100);
    Rectangle Border1 = new(0, 0, 1200, 100);
    Rectangle Border2 = new(1000, 100, 200, 150);
    Rectangle Border3 = new(0, 100, 150, 1100);
    Rectangle Border4 = new(150, 710, 1040, 190);
    Rectangle Border5 = new(1050, 500, 150, 400);
    Rectangle CaveExit = new(1135, 150, 65, 450);
    Rectangle Player = new(PlayerX, PlayerY, 100, 100);

    Rectangle CaveEntrance = new(10, 400, 100, 100);

    Rectangle Background = new(0, 0, 1200, 900);

    Raylib.BeginDrawing();

    if (Scene == "Cavern")
    {
        Raylib.DrawTextureRec(Scene1, Background, VectorBackground, Color.White);
        levels();
    }
    if (Scene == "ExitFromCavern")
    {
        Raylib.DrawTextureRec(Scene2, Background, VectorBackground, Color.White);
        levels();
    }
    Raylib.EndDrawing();

    int PlayerSpd = 3+Lives;
    if (Raylib.IsKeyDown(KeyboardKey.D))
    {
        PlayerX += PlayerSpd;
        Direction = false;
    }
    if (Raylib.IsKeyDown(KeyboardKey.A))
    {
        PlayerX -= PlayerSpd;
        Direction = true;
    }
    if (Raylib.IsKeyDown(KeyboardKey.W))
    {
        PlayerY -= PlayerSpd;
    }
    if (Raylib.IsKeyDown(KeyboardKey.S))
    {
        PlayerY += PlayerSpd;
    }

    if (Scene == "Cavern")
    {
        if (Raylib.CheckCollisionRecs(Player, Border1))
        {
            PlayerX = 520;
            PlayerY = 400;
        }
        if (Raylib.CheckCollisionRecs(Player, Border2))
        {
            PlayerX = 520;
            PlayerY = 400;
        }
        if (Raylib.CheckCollisionRecs(Player, Border3))
        {
            PlayerX = 520;
            PlayerY = 400;
        }
        if (Raylib.CheckCollisionRecs(Player, Border4))
        {
            PlayerX = 520;
            PlayerY = 400;
        }
        if (Raylib.CheckCollisionRecs(Player, Border5))
        {
            PlayerX = 520;
            PlayerY = 400;
        }
    }
    if (Raylib.CheckCollisionRecs(Player, CaveExit))
    {
        Scene = "ExitFromCavern";
        PlayerX = 130;
        PlayerY = 400;
    }
    if (Raylib.CheckCollisionRecs(Player, CaveEntrance))
    {
        Scene = "Cavern";
        PlayerX = 1000;
        PlayerY = 340;
    }
}


// Koden för levlar och vad som ska ritas 
void levels()
{
    if (GameOver == false)
    {
        int GoblingoY=200;
        int GhoulY=400;
        Vector2 PlayerVector = new(PlayerX, PlayerY);
        Rectangle Border1 = new(0, 0, 1200, 100);
        Rectangle Border2 = new(1000, 100, 200, 150);
        Rectangle Border3 = new(0, 100, 150, 1100);
        Rectangle Border4 = new(150, 710, 1040, 190);
        Rectangle Border5 = new(1050, 500, 150, 400);
        Rectangle CaveExit = new(1135, 150, 65, 450);
        Rectangle Player = new(PlayerX, PlayerY, 100, 100);
        Rectangle Goblingo = new(200, GoblingoY, 150, 150);
        Rectangle Ghoul = new(400, GhoulY, 90, 90);
        Rectangle CaveEntrance = new(10, 400, 100, 100);
        if (Lives >= 3){
            Raylib.DrawCircle(170, 100, 20, Color.Red);
        }
        if (Lives >= 2){
            Raylib.DrawCircle(110, 100, 20, Color.Red);
        }
        if (Lives >= 1){
            Raylib.DrawCircle(50, 100, 20, Color.Red);
        }

        Raylib.DrawRectangleRec(Player, Color.Blank);
        Raylib.ClearBackground(Color.RayWhite);
        if (Direction == true)
        {
            Raylib.DrawTextureV(BoreLeftTexture, PlayerVector, Color.RayWhite);
        }
        if (Direction == false)
        {
            Raylib.DrawTextureV(BoreRightTexture, PlayerVector, Color.RayWhite);
        }

        if (Scene == "Cavern")
        {
            Raylib.DrawRectangleRec(Border1, Color.Blank);
            Raylib.DrawRectangleRec(Border2, Color.Blank);
            Raylib.DrawRectangleRec(Border3, Color.Blank);
            Raylib.DrawRectangleRec(Border4, Color.Blank);
            Raylib.DrawRectangleRec(Border5, Color.Blank);
            Raylib.DrawRectangleRec(CaveExit, Color.Blank);
        }
        if (Scene == "ExitFromCavern")
        {
            Raylib.DrawRectangleRec(Goblingo, Color.DarkGreen);
            Raylib.DrawRectangleRec(Ghoul, Color.SkyBlue);
            Raylib.DrawRectangleRec(CaveEntrance, Color.Blank);
            





            for (int i = 0; i < 5; i++)
            {
                Raylib.DrawCircle(900, 150 + 110 * i, 30, Color.DarkBlue);
            }
            if (Raylib.CheckCollisionRecs(Ghoul, Player) == true)
            {
                Lives--;
                Scene = "Cavern";
                PlayerX = 520;
                PlayerY = 400;
                if (Raylib.CheckCollisionRecs(Ghoul, Player) == true && Lives <= 0)
                {
                    GameOver=true;
                }
            }
            if (Raylib.CheckCollisionRecs(Goblingo, Player) == true)
            {
                Lives=Lives-2;
                Scene = "Cavern";
                PlayerX = 520;
                PlayerY = 400;
                if (Raylib.CheckCollisionRecs(Goblingo, Player) == true && Lives <= 0)
                {
                    GameOver=true;
                }
            }


        }
    }
    else if (GameOver == true)
    {
        Raylib.ClearBackground(Color.White);
        Raylib.DrawText("You died", 500, 280, 45, Color.RayWhite);
        Raylib.DrawText("Start Again?(Press Q)", 400, 380, 30, Color.RayWhite);
        if (Raylib.IsKeyPressed(KeyboardKey.Q))
        {
            Lives = 3;
            Scene = "Cavern";
            PlayerX = 520;
            PlayerY = 400;
            GameOver=false;
        }
    }

}