using System.Data;
using System.Numerics;
using Raylib_cs;

string Scene = "Cavern";
int PlayerX = 520;
int PlayerY = 400;
Vector2 VectorBackground = new(0, 0);
Vector2 PlayerVector= new(PlayerX,PlayerY);

Raylib.InitWindow(1200, 900, "The Thing");
Raylib.SetTargetFPS(60);

Texture2D Scene1 = Raylib.LoadTexture("Cavern.png");
Texture2D Scene2 = Raylib.LoadTexture("ExitFromCavern.png");
Texture2D BoreTexture = Raylib.LoadTexture("Bore.png");
// to be moved1


// to be moved2

while (!Raylib.WindowShouldClose())
{
    // to be moved if can 1

/*
Console.WriteLine(PlayerY);
Console.WriteLine(PlayerX);
*/
    Rectangle Border1 = new(0, 0, 1200, 100);
    Rectangle Border2 = new(1000, 100, 200, 150);
    Rectangle Border3 = new(0, 100, 150, 1100);
    Rectangle Border4 = new(150, 710, 1040, 190);
    Rectangle Border5 = new(1050, 500, 150, 400);
    Rectangle CaveExit = new(1135, 150, 65, 450);
    Rectangle Player = new(PlayerX, PlayerY, 100, 100);
    Rectangle Bore = new(PlayerX, PlayerY, BoreTexture.Width,BoreTexture.Height);

    Rectangle CaveEntrance=new(10,400,100,100);


    // to be moved if can 2

    Rectangle Background = new(0, 0, 1200, 900);

    Raylib.BeginDrawing();

    if (Scene == "Cavern")
    {
        Raylib.DrawTextureRec(Scene1, Background, VectorBackground, Color.White);
        // to be moved if can 1
        levels();
        // to be moved if can2
    }
    if (Scene == "ExitFromCavern")
    {
        Raylib.DrawTextureRec(Scene2, Background, VectorBackground, Color.White);
        // to be moved if can 1
        levels();
        // to be moved if can2
    }
    Raylib.EndDrawing();

    // to be moved1
    int PlayerSpd = 4;


    if (Raylib.IsKeyDown(KeyboardKey.D))
    {
        PlayerX += PlayerSpd;
    }
    if (Raylib.IsKeyDown(KeyboardKey.A))
    {
        PlayerX -= PlayerSpd;
    }
    if (Raylib.IsKeyDown(KeyboardKey.W))
    {
        PlayerY -= PlayerSpd;
    }
    if (Raylib.IsKeyDown(KeyboardKey.S))
    {
        PlayerY += PlayerSpd;
    }
   
   if (Scene=="Cavern"){
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
    // to be moved2
}




/*Console.WriteLine($"{PlayerY}");
   Console.WriteLine($"{PlayerX}");*/

void levels()
{
    Rectangle Border1 = new(0, 0, 1200, 100);
    Rectangle Border2 = new(1000, 100, 200, 150);
    Rectangle Border3 = new(0, 100, 150, 1100);
    Rectangle Border4 = new(150, 710, 1040, 190);
    Rectangle Border5 = new(1050, 500, 150, 400);
    Rectangle CaveExit = new(1135, 150, 65, 450);
    Rectangle Player = new(PlayerX, PlayerY, 100, 100);
    Rectangle Goblingo = new(200,200,150,150);
    Rectangle Ghoul=new(400,400,90,90);
    Rectangle CaveEntrance=new(10,400,100,100);
    Rectangle Bore = new(PlayerX, PlayerY, BoreTexture.Width,BoreTexture.Height);

    Raylib.DrawRectangleRec(Player, Color.Black);
    Raylib.ClearBackground(Color.RayWhite);
    Raylib.DrawTextureRec(BoreTexture,Bore,PlayerVector,Color.RayWhite);


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
        Raylib.DrawRectangleRec(Goblingo,Color.DarkGreen);
        Raylib.DrawRectangleRec(Ghoul,Color.SkyBlue);
        Raylib.DrawRectangleRec(CaveEntrance,Color.Blank);

     





    }

}
//Rectanglecreation.Creating();
//Methods.Collision();
//Moving.Move();