namespace BrainfuckInterpreter
{
    public class Block
    {
        public int From;
        public int To;

        public Block(int from, int to)
        {
            From = from;
            To = to;
        }
    }
}