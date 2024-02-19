using Raylib_cs;

class Colliding{

public static void Collision(){
    int PlayerX = 520;
    int PlayerY = 400;
    Rectangle Border1 = new(0,0,1200,100);
    Rectangle Border2 = new(1000,100,200,150);
    Rectangle Border3 = new (0,100,150,1100);
    Rectangle Border4 = new(150,710,1040,190);
    Rectangle Border5 = new (1050,500,150,400);
    Rectangle Player = new(PlayerX, PlayerY, 100, 100);
    Rectangle Cavern = new(0, 0, 1200, 900);
if (Raylib.CheckCollisionRecs(Player,Border1)){
PlayerX = 520;
PlayerY = 400;
}
if (Raylib.CheckCollisionRecs(Player,Border2)){
PlayerX = 520;
PlayerY = 400;
}
if (Raylib.CheckCollisionRecs(Player,Border3)){
PlayerX = 520;
PlayerY = 400;
}
if (Raylib.CheckCollisionRecs(Player,Border4)){
PlayerX = 520;
PlayerY = 400;
}
if (Raylib.CheckCollisionRecs(Player,Border5)){
PlayerX = 520;
PlayerY = 400;
}

}
}