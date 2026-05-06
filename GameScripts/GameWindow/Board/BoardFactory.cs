using System.Numerics;

namespace MP_POO_FINAL.GameScripts.GameWindow.Board;


public class BoardFactory 
{
    public static Board CreateBoard()
    {
        return new Board([
            
            //START CELL
            new StartCell(0,"START",new Vector2(1360f, 960f), 300),
            
            //PROPERTY CELL
            new PropertyCell(1, "ROBLOX AVENUE", new Vector2(1260f, 960f), "Brown", 60, 50, 6, 20),
            new PropertyCell(3, "ALLEY OF THE ABSENT", new Vector2(1020f,960f), "Brown", 80, 50, 8, 40),
            new PropertyCell(5,"BRAINROT STREET", new Vector2(760f, 960f), "Light Blue", 100, 50, 10, 50),
            new PropertyCell(6, "SONIC ROAD", new Vector2(640f, 960f), "Light Blue", 120, 50, 12, 60),
            new PropertyCell(8,"CANARY ISLAND", new Vector2(510f, 820f), "Pink", 140, 100, 14, 70),
            new PropertyCell(10,"KIKE'S SQUARES", new Vector2(510f, 560), "Pink", 160, 100, 16, 80),
            new PropertyCell(12,"SPANISH SOUP PARK", new Vector2(510f, 310f), "Orange", 180, 100, 18, 90),
            new PropertyCell(13, "ACUSTIC VILLAGE", new Vector2(510f, 180f), "Orange", 200, 100, 20, 100),
            new PropertyCell(15,"IGI'S STATION",  new Vector2(640f, 60f), "Red", 220, 150, 22, 110),
            new PropertyCell(17, "NETFLIX GAMER'S SET-UP", new Vector2(880f, 60f), "Red", 250, 150, 25, 125),
            new PropertyCell(19, "UTAD'S BLACKBOARD", new Vector2(1140f, 60f), "Yellow", 300, 150, 30, 150),
            new PropertyCell(20, "INVI 1ºA USELESS CLASS", new Vector2(1260f, 60f), "Yellow", 340, 150, 34, 170),
            new PropertyCell(22, "TRYHARD STUDIO",  new Vector2(1420f, 180f), "Green", 380, 200, 38, 190),
            new PropertyCell(24, "COOKIE CLICKER'S CASINO", new Vector2(1420f, 430f), "Green", 400, 200, 40, 200),
            new PropertyCell(26,"DELEGATE OFFICE", new Vector2(1420f, 690f), "Dark Blue", 450, 200, 45, 225),
            new PropertyCell(27, "MASON MANSION",  new Vector2(1420f, 820f), "Dark Blue", 500, 200, 50, 250),
            
            //MONSTER CELL
            new MonsterCell(4,"ORIGINAL MONSTER",new Vector2(880f,960f),200,50),
            new MonsterCell(11,"MONSTER WHITE",new Vector2(510f,440),200,50),
            new MonsterCell(18,"JUICED MONSTER",new Vector2(1020f,60f),200,50),
            new MonsterCell(25,"PUNCH MONSTER",new Vector2(1420f,560f),200,50),
            
            //LUCKY CELLS
            new LuckyCell(9,"LUCKY MACHINE", new Vector2(510f,700f)),
            new LuckyCell(16,"LUCKY MACHINE",new Vector2(760f,60f)),
            new LuckyCell(23,"LUCKY MACHINE",new Vector2(1420f,300f)),
            
            //EXTRA CELLS
            new NachoCell(2,"PAY FOR NACHO'S BOARD",new Vector2(1140f,960f)),
            new JhonCell(7,"JHON",new Vector2(520f,960f)),
            new DoorCell(14,"THE DOOR IS CLOSED",new Vector2(510f,70f)),
            new TheClassCell(21,"THE CLASS",new Vector2(1400,60f))
        ]);
    }
}
