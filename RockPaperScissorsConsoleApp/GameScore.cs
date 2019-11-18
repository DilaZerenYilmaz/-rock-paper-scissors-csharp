namespace RockPaperScissorsConsoleApp
{
    public class GameScore
    {
        private static GameScore _instance;

        private GameScore()
        {
            ComputerWin = 0;
            YouWin = 0;
        }

        public static GameScore GetInstance()
        {
            if (_instance == null)
            {
                return new GameScore();
            }
            else
            {
                return _instance;
            }
        }

        public int ComputerWin { get; set; }
        public int YouWin { get; set; }
    }
}