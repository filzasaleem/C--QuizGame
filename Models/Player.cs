namespace QuizGame;

public class Player
{
    public string Name { get; set; } = string.Empty;
    public int Score { get; private set; } = 0;
    public int Chances { get; set; } = 0;

    public int AddScore()
    {
        return Score++;
    }
    
}
