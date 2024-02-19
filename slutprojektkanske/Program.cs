using System.Data;
using System.Numerics;
using Raylib_cs;

string Scene= "Cavern";
Vector2 VectorCavern = new Vector2(0, 0);

Raylib.InitWindow(1200, 900, "The Thing");
Raylib.SetTargetFPS(60);

Texture2D Scene1 = Raylib.LoadTexture("Cavern.png");

// to be moved

int PlayerX = 520;
int PlayerY = 400;

// to be moved

while (!Raylib.WindowShouldClose())
{   
   // to be moved

    Rectangle Border1 = new(0,0,1200,100);
    Rectangle Border2 = new(1000,100,200,150);
    Rectangle Border3 = new (0,100,150,1100);
    Rectangle Border4 = new(150,710,1040,190);
    Rectangle Border5 = new (1050,500,150,400);
    Rectangle NewArea1 = new(1135,150,65,450);
    Rectangle Player = new(PlayerX, PlayerY, 100, 100);

    // to be moved

    Rectangle Cavern = new(0, 0, 1200, 900);

    Raylib.BeginDrawing();

    Moving.Move();
    Colliding.Collision();
    if (Scene == "Cavern"){
    //Rectanglecreation.Creating();
    Raylib.DrawTextureRec(Scene1, Cavern, VectorCavern, Color.White);

// to be moved
 
    

    Raylib.DrawRectangleRec(Border1,Color.Blue);
    Raylib.DrawRectangleRec(Border2,Color.Blue);
    Raylib.DrawRectangleRec(Border3,Color.Blue);
    Raylib.DrawRectangleRec(Border4,Color.Blue);
    Raylib.DrawRectangleRec(Border5,Color.Blue);
    Raylib.DrawRectangleRec(NewArea1,Color.Yellow);
    Raylib.DrawRectangleRec(Player, Color.Black);

// to be moved

    Raylib.ClearBackground(Color.RayWhite);
    Raylib.EndDrawing();
       }
}





 /*Console.WriteLine($"{PlayerY}");
    Console.WriteLine($"{PlayerX}");*/