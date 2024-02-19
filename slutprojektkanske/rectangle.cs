using Raylib_cs;

class Rectanglecreation{
public static void Creating(){
 int PlayerX = 520;
    int PlayerY = 400;
    Rectangle Border1 = new(0,0,1200,100);
    Rectangle Border2 = new(1000,100,200,150);
    Rectangle Border3 = new (0,100,150,1100);
    Rectangle Border4 = new(150,710,1040,190);
    Rectangle Border5 = new (1050,500,150,400);
    Rectangle NewArea1 = new(1135,150,65,450);
    Rectangle Player = new(PlayerX, PlayerY, 100, 100);
    Rectangle Cavern = new(0, 0, 1200, 900);

    Raylib.DrawRectangleRec(Border1,Color.Blue);
    Raylib.DrawRectangleRec(Border2,Color.Blue);
    Raylib.DrawRectangleRec(Border3,Color.Blue);
    Raylib.DrawRectangleRec(Border4,Color.Blue);
    Raylib.DrawRectangleRec(Border5,Color.Blue);
    Raylib.DrawRectangleRec(NewArea1,Color.Yellow);
    Raylib.DrawRectangleRec(Player, Color.Black);
}
}