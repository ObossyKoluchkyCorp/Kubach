public class LevelObject
{
    public int x { get; private set; }
    public int y { get; private set; }
    public int z { get; private set; }
    public bool obstacle { get; private set; }

    public LevelObject(int xInput, int yInput, int zInput, bool isObstacleHere)
    {
        x = xInput;
        y = yInput;
        z = zInput;
        obstacle = isObstacleHere;
    }
}