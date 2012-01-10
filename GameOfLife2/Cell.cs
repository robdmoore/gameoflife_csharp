namespace GameOfLife2
{
    public class Cell
    {
        public static bool GetNewState(bool currentState, int numAliveNeighbours)
        {
            return numAliveNeighbours == 3 || (currentState && numAliveNeighbours == 2);
        }
    }
}
