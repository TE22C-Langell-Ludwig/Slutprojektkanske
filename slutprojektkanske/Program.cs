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



int F = Random.Shared.Next(-500, 500);
int G = Random.Shared.Next(-500, 500);
int GhoulY = 400;
int GoblingoY = 200;
int Ghoulmovementmultiplier = -1;
int Goblingomovementmultiplier =-1;
int blåbär=0;



// Själva Main delen där koden är
while (!Raylib.WindowShouldClose())
{
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

    int PlayerSpd = 3 + Lives;
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
        Rectangle[] Borders = { Border1, Border2, Border3, Border4, Border5 };
        for (int i = 0; i < Borders.Length; i++)
        {
            Borders[1] = Border1;
            if (Raylib.CheckCollisionRecs(Player, Borders[i]))
            {
                PlayerX = 520;
                PlayerY = 400;
            }
        }
    }
    if (Scene == "Cavern" && Raylib.CheckCollisionRecs(Player, CaveExit))
    {
        Scene = "ExitFromCavern";
        PlayerX = 130;
        PlayerY = 400;
        GhoulY=400;
        GoblingoY=200;

    }
    if (Raylib.CheckCollisionRecs(Player, CaveEntrance))
    {
        Scene = "Cavern";
        PlayerX = 1000;
        PlayerY = 340;
    }
}


// Koden för levlar och vad som ska ritas 


F = Random.Shared.Next(-500, 500);
G = Random.Shared.Next(-500, 500);
void levels(){
    if (GameOver == false)
    {
        Vector2 PlayerVector = new(PlayerX, PlayerY);
        Rectangle Border1 = new(0, 0, 1200, 100);
        Rectangle Border2 = new(1000, 100, 200, 150);
        Rectangle Border3 = new(0, 100, 150, 1100);
        Rectangle Border4 = new(150, 710, 1040, 190);
        Rectangle Border5 = new(1050, 500, 150, 400);
        Rectangle CaveExit = new(1135, 150, 65, 450);
        Rectangle Areaup = new(350, 0, 300, 50);
        Rectangle AreaRight = new(1160, 250, 40, 250);
        Rectangle Player = new(PlayerX, PlayerY, 100, 100);
        Rectangle Goblingo = new(800, GoblingoY, 150, 150);
        Vector2 Blåbärvector= new(F+ 500,G + 500);
        Rectangle Ghoul = new(400, GhoulY, 90, 90);

        GhoulY += (4 * Ghoulmovementmultiplier);
        if (GhoulY > 700)
        {
            Ghoulmovementmultiplier = -1;
            GhoulY += (4 * Ghoulmovementmultiplier);
        }
        else if (GhoulY < 150)
        {
            Ghoulmovementmultiplier = 1;
            GhoulY += (4 * Ghoulmovementmultiplier);
        }
        
        GoblingoY += (2 * Goblingomovementmultiplier);
        if (GoblingoY > 600)
        {
            Goblingomovementmultiplier = -1;
            GoblingoY += (2 * Goblingomovementmultiplier);
        }
        else if (GoblingoY < 150)
        {
            Goblingomovementmultiplier = 1;
            GoblingoY += (2 * Goblingomovementmultiplier);
        }
        Rectangle CaveEntrance = new(10, 400, 100, 100);
        if (Lives >= 3)
        {
            Raylib.DrawCircle(170, 100, 20, Color.Red);
        }
        if (Lives >= 2)
        {
            Raylib.DrawCircle(110, 100, 20, Color.Red);
        }
        if (Lives >= 1)
        {
            Raylib.DrawCircle(50, 100, 20, Color.Red);
        }
        Raylib.DrawText($"{blåbär}/3 Blåbär hämtade",800,750,30,Color.Blue);
        Raylib.DrawRectangleRec(Player, Color.Blank);
        Raylib.ClearBackground(Color.RayWhite);
        //ändrar vilken bild som ritas beroende på en bool som ändras när jag går vänster eller höger
        if (Direction == true)
        {
            Raylib.DrawTextureV(BoreLeftTexture, PlayerVector, Color.RayWhite);
        }
        else if (Direction == false)
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
        else if (Scene == "ExitFromCavern")
        {
            Raylib.DrawRectangleRec(Goblingo, Color.DarkGreen);
            Raylib.DrawRectangleRec(Ghoul, Color.SkyBlue);
            Raylib.DrawRectangleRec(CaveEntrance, Color.Blank);
            Raylib.DrawRectangleRec(AreaRight, Color.Red);
            Raylib.DrawRectangleRec(Areaup, Color.Red);



                Raylib.DrawCircleV(Blåbärvector,30,Color.DarkBlue);

if (Raylib.CheckCollisionCircleRec(Blåbärvector,30,Player)){

F = Random.Shared.Next(-500, 500);
G = Random.Shared.Next(-460, 350);

blåbär++;

}
if (Raylib.CheckCollisionCircleRec(Blåbärvector,30,CaveExit)){
    
F = Random.Shared.Next(-500, 500);
G = Random.Shared.Next(-460, 350);

}
                //Raylib.DrawCircle(500 + F, 500 + G, 30, Color.DarkBlue);


            if (Raylib.CheckCollisionRecs(Ghoul, Player) == true)
            {
                Lives--;
                F = Random.Shared.Next(-500, 500);
                G = Random.Shared.Next(-460, 350);
                Scene = "Cavern";
                PlayerX = 520;
                PlayerY = 400;
                GhoulY=400;
                GoblingoY=200;


                if (Raylib.CheckCollisionRecs(Ghoul, Player) == true && Lives <= 0)
                {
                    GameOver = true;
                }
            }
            if (Raylib.CheckCollisionRecs(Goblingo, Player) == true)
            {
                Lives = Lives - 2;
                F = Random.Shared.Next(-500, 500);
                G = Random.Shared.Next(-480, 350);
                Scene = "Cavern";
                PlayerX = 520;
                PlayerY = 400;
                GoblingoY=200;
                GhoulY=400;


                if (Raylib.CheckCollisionRecs(Goblingo, Player) == true && Lives <= 0)
                {
                    GameOver = true;
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
            blåbär=0;
            Scene = "Cavern";
            PlayerX = 520;
            PlayerY = 400;
            GameOver = false;
        }
    }
    
    }