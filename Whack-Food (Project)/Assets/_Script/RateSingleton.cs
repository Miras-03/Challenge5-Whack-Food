public sealed class RateSingleton
{
    private static RateSingleton instance;

    private float rate;

    public static RateSingleton Instance
    {
        get
        {
            if (instance == null)
                instance = new RateSingleton();
            return instance;
        }
    }

    public float Rate { get => rate; set => rate = value; }
}