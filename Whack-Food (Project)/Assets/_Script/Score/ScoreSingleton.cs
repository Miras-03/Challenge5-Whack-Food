using ObserverPattern.Score;

public sealed class ScoreSingleton : IScoreObserver
{
    private static ScoreSingleton instance;
    private int score;

    public ScoreSingleton() => Score = 0;

    public void ExecutePoint(int point) => Score+=point;

    public static ScoreSingleton Instance
    {
        get
        {
            if (instance == null)
                instance = new ScoreSingleton();
            return instance;
        }
    }

    public int Score 
    { 
        get => score;
        private set
        {
            if (score > -1)
                score = value;
            else
                score = 0;
        }
    }
}