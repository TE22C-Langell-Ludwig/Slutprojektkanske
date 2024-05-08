using System.Data;
using System.Numerics;
using Raylib_cs;

string scene = "Intro";
int playerX = 520;
int playerY = 400;
int lives = 3;
bool direction = true;
bool gameOver = false;
Vector2 vectorBackground = new(0, 0);

Raylib.InitWindow(1200, 900, "The Thing");
Raylib.SetTargetFPS(60);
// dem 4 bilderna jag har lagt till i spelet
Texture2D scene1 = Raylib.LoadTexture("Cavern.png");
Texture2D scene2 = Raylib.LoadTexture("ExitFromCavern.png");
Texture2D boreLeftTexture = Raylib.LoadTexture("Bore.png");
Texture2D boreRightTexture = Raylib.LoadTexture("BoarRight.png");



int X = Random.Shared.Next(-500, 500);
int Y = Random.Shared.Next(-460, 350);
int ghoulY = 400;
int goblingoY = 200;
int ghoulMovementMultiplier = -1;
int goblingoMovementMultiplier = -1;
int blueBerries = 0;



// Själva Main delen där koden är
while (!Raylib.WindowShouldClose())
{
    //definerar rektanglar som sen används
    Rectangle Border1 = new(0, 0, 1200, 100);
    Rectangle Border2 = new(1000, 100, 200, 150);
    Rectangle Border3 = new(0, 100, 150, 1100);
    Rectangle Border4 = new(150, 710, 1040, 190);
    Rectangle Border5 = new(1050, 500, 150, 400);
    Rectangle CaveExit = new(1135, 150, 65, 450);
    Rectangle Player = new(playerX, playerY, 100, 100);
    Rectangle CaveEntrance = new(10, 400, 100, 100);
    Rectangle Pileofhay = new(360, 290, 90, 90);
    Rectangle Background = new(0, 0, 1200, 900);
//börjar rita
    Raylib.BeginDrawing();
    //kollar vilken scene som ska köras
    if (scene == "Intro")
    {
        Levels();
    }
    if (scene == "Cavern")
    {
        Raylib.DrawTextureRec(scene1, Background, vectorBackground, Color.White);
        Levels();
    }
    if (scene == "ExitFromCavern")
    {
        Raylib.DrawTextureRec(scene2, Background, vectorBackground, Color.White);
        Levels();
    }
    if (scene == "sleepytime")
    {
        Levels();
    }
    Raylib.EndDrawing();
// kod så spelaren så kunna gå och också göra så att spelaren movespeed är baserat delvis på hens health
    int PlayerSpd = 3 + lives;
    if (Raylib.IsKeyDown(KeyboardKey.D))
    {
        playerX += PlayerSpd;
        direction = false;
    }
    if (Raylib.IsKeyDown(KeyboardKey.A))
    {
        playerX -= PlayerSpd;
        direction = true;
    }
    if (Raylib.IsKeyDown(KeyboardKey.W))
    {
        playerY -= PlayerSpd;
    }
    if (Raylib.IsKeyDown(KeyboardKey.S))
    {
        playerY += PlayerSpd;
    }
 // for loop för att checka collsion mellan varje border i grotan som checkar via att kolla genom en 
    if (scene == "Cavern")
    {
        Rectangle[] Borders = { Border1, Border2, Border3, Border4, Border5 };
        for (int i = 0; i < Borders.Length; i++)
        {
            Borders[1] = Border1;
            if (Raylib.CheckCollisionRecs(Player, Borders[i]))
            {
                playerX = 520;
                playerY = 400;
            }
        }
    }
    //kollar så spelaren kan lämna grotan och fienderna är på rätt plats när dem gör det
    if (scene == "Cavern" && Raylib.CheckCollisionRecs(Player, CaveExit))
    {
        scene = "ExitFromCavern";
        playerX = 130;
        playerY = 400;
        ghoulY = 400;
        goblingoY = 200;

    }
    //kollar så spelaren kan gå tillbaka in i grottan
    if (Raylib.CheckCollisionRecs(Player, CaveEntrance))
    {
        scene = "Cavern";
        playerX = 1000;
        playerY = 340;
    }
    //gör så efter man har plockat alla 3 blåbär och är i grottan att man kan nå högen av hö och vinna
    if (Raylib.CheckCollisionRecs(Pileofhay, Player) && blueBerries == 3 && scene == "Cavern")
    {
        playerX = 400;
        playerY = 350;
        scene = "Sleepytime";
    }
}


// Koden för levlar och vad som ska ritas 
void Levels()
{
    //kollar att man inte har dött så spelet vet vad den ska rita
    if (gameOver == false)
    {
        Vector2 PlayerVector = new(playerX, playerY);
        Rectangle Border1 = new(0, 0, 1200, 100);
        Rectangle Border2 = new(1000, 100, 200, 150);
        Rectangle Border3 = new(0, 100, 150, 1100);
        Rectangle Border4 = new(150, 710, 1040, 190);
        Rectangle Border5 = new(1050, 500, 150, 400);
        Rectangle CaveExit = new(1135, 150, 65, 450);
        Rectangle Player = new(playerX, playerY, 100, 100);
        Rectangle Goblingo = new(800, goblingoY, 150, 150);
        Rectangle Ghoul = new(400, ghoulY, 90, 90);
        Rectangle PileOfHay = new(360, 290, 90, 90);
        Rectangle TheOutside = new(-10, -10, 1220, 920);
        Vector2 BlueBerriesVector = new(X + 500, Y + 500);
        Rectangle CaveEntrance = new(10, 400, 100, 100);


        //fiendernas movement
        ghoulY += (4 * ghoulMovementMultiplier);
        if (ghoulY > 700)
        {
            ghoulMovementMultiplier = -1;
            ghoulY += (4 * ghoulMovementMultiplier);
        }
        else if (ghoulY < 150)
        {
            ghoulMovementMultiplier = 1;
            ghoulY += (4 * ghoulMovementMultiplier);
        }

        goblingoY += (2 * goblingoMovementMultiplier);
        if (goblingoY > 600)
        {
            goblingoMovementMultiplier = -1;
            goblingoY += (2 * goblingoMovementMultiplier);
        }
        else if (goblingoY < 150)
        {
            goblingoMovementMultiplier = 1;
            goblingoY += (2 * goblingoMovementMultiplier);
        }

        if (scene != "Intro" && scene != "SleepyTime")
        {
            //ritar up health pointsen i vänster top hörnet och huden som säger hur många blåbär man har hittat so far
            if (lives >= 3)
            {
                Raylib.DrawCircle(170, 100, 20, Color.Red);
            }
            if (lives >= 2)
            {
                Raylib.DrawCircle(110, 100, 20, Color.Red);
            }
            if (lives >= 1)
            {
                Raylib.DrawCircle(50, 100, 20, Color.Red);
            }
            Raylib.DrawText($"{blueBerries}/3 Blueberries", 800, 750, 30, Color.Blue);
            Raylib.DrawRectangleRec(Player, Color.Blank);
            Raylib.ClearBackground(Color.RayWhite);

            //ändrar vilken bild som ritas beroende på en bool som ändras när jag går vänster eller höger
            if (direction == true)
            {
                Raylib.DrawTextureV(boreLeftTexture, PlayerVector, Color.RayWhite);
            }
            else if (direction == false)
            {
                Raylib.DrawTextureV(boreRightTexture, PlayerVector, Color.RayWhite);
            }
        }
        //ritar up så intro sequences finns
        if (scene == "Intro")
        {
            IntroText();
            if (Raylib.IsKeyPressed(KeyboardKey.F))
            {
                scene = "Cavern";
            }
            Raylib.ClearBackground(Color.White);
        }
        if (scene == "Cavern")
        {
            Raylib.DrawRectangleRec(Border1, Color.Blank);
            Raylib.DrawRectangleRec(Border2, Color.Blank);
            Raylib.DrawRectangleRec(Border3, Color.Blank);
            Raylib.DrawRectangleRec(Border4, Color.Blank);
            Raylib.DrawRectangleRec(Border5, Color.Blank);
            Raylib.DrawRectangleRec(CaveExit, Color.Blank);
            if (blueBerries == 3)
            {
                Raylib.DrawRectangleRec(PileOfHay, Color.Yellow);
                 if (Raylib.CheckCollisionRecs(PileOfHay, Player))
                 {
                     scene = "Sleepytime";
                 }
            }
        }
        else if (scene == "ExitFromCavern")
        {
            Raylib.DrawRectangleRec(Goblingo, Color.DarkGreen);
            Raylib.DrawRectangleRec(Ghoul, Color.SkyBlue);
            Raylib.DrawRectangleRec(CaveEntrance, Color.Blank);

            if (blueBerries < 3)
            {
                Raylib.DrawCircleV(BlueBerriesVector, 30, Color.DarkBlue);
            }
            if (Raylib.CheckCollisionCircleRec(BlueBerriesVector, 30, Player) && blueBerries < 3)
            {

                X = Random.Shared.Next(-500, 500);
                Y = Random.Shared.Next(-460, 350);

                blueBerries++;

            }
            if (blueBerries == 3)
            {
                Raylib.DrawText("Now return to the cave.", 400, 750, 30, Color.Yellow);
            }
            if (Raylib.CheckCollisionCircleRec(BlueBerriesVector, 30, CaveExit))
            {

                X = Random.Shared.Next(-500, 500);
                Y = Random.Shared.Next(-460, 350);

            }

            if (Raylib.CheckCollisionRecs(Ghoul, Player) == true)
            {
                lives--;
                X = Random.Shared.Next(-500, 500);
                Y = Random.Shared.Next(-460, 350);
                scene = "Cavern";
                playerX = 520;
                playerY = 400;
                ghoulY = 400;
                goblingoY = 200;


                if (Raylib.CheckCollisionRecs(Ghoul, Player) == true && lives <= 0)
                {
                    gameOver = true;
                }
            }
            if (Raylib.CheckCollisionRecs(Goblingo, Player) == true)
            {
                lives = lives - 2;
                X = Random.Shared.Next(-500, 500);
                Y = Random.Shared.Next(-480, 350);
                scene = "Cavern";
                playerX = 520;
                playerY = 400;
                goblingoY = 200;
                ghoulY = 400;


                if (Raylib.CheckCollisionRecs(Goblingo, Player) == true && lives <= 0)
                {
                    gameOver = true;
                }
            }
            if (Raylib.CheckCollisionRecs(TheOutside, Player) == false)
            {
                gameOver = true;
            }

        }
        else if (scene == "Sleepytime")
        {
            Raylib.DrawText("the boar has now gone to sleep", 200, 200, 20, Color.DarkBrown);
            Raylib.DrawText("thank you for helping him get his food.", 200, 250, 20, Color.DarkBrown);
            Raylib.ClearBackground(Color.White);

        }


    }
    else if (gameOver == true)
    {
        Raylib.ClearBackground(Color.White);
        Raylib.DrawText("You died", 500, 280, 45, Color.RayWhite);
        Raylib.DrawText("Start Again?(Press Q)", 400, 380, 30, Color.RayWhite);
        if (Raylib.IsKeyPressed(KeyboardKey.Q))
        {
            lives = 3;
            blueBerries = 0;
            scene = "Cavern";
            playerX = 520;
            playerY = 400;
            gameOver = false;
        }
    }

}
static void IntroText()
{
    Raylib.DrawText("You are a boar.", 500, 320, 30, Color.DarkBrown);
    Raylib.DrawText("Collect 3 Blueberries.", 500, 370, 30, Color.DarkBrown);
    Raylib.DrawText("Then you can go to sleep.", 500, 420, 30, Color.DarkBrown);
    Raylib.DrawText("Dont get lost outside your cave.", 500, 470, 30, Color.DarkBrown);
    Raylib.DrawText("Press F to start.", 500, 520, 30, Color.DarkBrown);

    Raylib.DrawText("Controls", 150, 300, 30, Color.DarkBrown);
    Raylib.DrawText("W - Move up", 150, 350, 30, Color.DarkBrown);
    Raylib.DrawText("A - Move left", 150, 400, 30, Color.DarkBrown);
    Raylib.DrawText("S - Move down", 150, 450, 30, Color.DarkBrown);
    Raylib.DrawText("D - Move right", 150, 500, 30, Color.DarkBrown);

}