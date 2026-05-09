using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class BoardFactory 
{
    public static Board CreateBoard()
    {
        return new Board([
            new StartCell(0,new Vector2(1360f, 960f), 300),
            new PropertyCell(1, new Vector2(1260f, 960f), 60, 50, 0, 6, 20),
            new NachoCell(2, new Vector2(1140f,960f)),
            new PropertyCell(3, new Vector2(1020f,960f), 80, 50, 0, 8, 40),
            new MonsterCell(4, new Vector2(880f,960f),200,50),
            new PropertyCell(5, new Vector2(760f, 960f), 100, 50, 0, 10, 50),
            new PropertyCell(6, new Vector2(640f, 960f), 120, 50, 0, 12, 60),
            new JhonCell(7, new Vector2(480,960f)),
            new PropertyCell(8, new Vector2(480f, 820f), 140, 100, 0,14, 70),
            new LuckyCell(9, new Vector2(480f,700f)),
            new PropertyCell(10, new Vector2(480f, 560), 160, 100, 0, 16, 80),
            new MonsterCell(11, new Vector2(480f,440),200,50),
            new PropertyCell(12, new Vector2(480f, 310f), 180, 100, 0, 18, 90),
            new PropertyCell(13, new Vector2(480f, 180f), 200, 100, 0, 20, 100),
            new DoorCell(14,new Vector2(480f,70f)),
            new PropertyCell(15,  new Vector2(620f, 60f), 220, 150, 0, 22, 110),
            new LuckyCell(16, new Vector2(740f,60f)),
            new PropertyCell(17, new Vector2(860f, 60f), 250, 150, 0, 25, 125),
            new MonsterCell(18, new Vector2(1000f,60f),200,50),
            new PropertyCell(19, new Vector2(1120f, 60f), 300, 150, 0, 30, 150),
            new PropertyCell(20,  new Vector2(1240f, 60f), 340, 150, 0, 34, 170),
            new TheClassCell(21, new Vector2(1370f,60f)),
            new PropertyCell(22, new Vector2(1370f, 180f), 380, 200, 0, 38, 190),
            new LuckyCell(23, new Vector2(1370f,300f)),
            new PropertyCell(24, new Vector2(1370f, 430f), 400, 200, 0, 40, 200),
            new MonsterCell(25, new Vector2(1370f,560f),200,50),
            new PropertyCell(26, new Vector2(1370f, 690f), 450, 200, 0, 45, 225),
            new PropertyCell(27, new Vector2(1370f, 820f), 500, 200, 0, 50, 250),
        ]);
    }
}
