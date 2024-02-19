using Raylib_cs;

class Moving{
    
public static void Move()
{
    int PlayerX = 520;
    int PlayerY = 400;
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
}






}