using System.Collections.Generic;

namespace BrainfuckInterpreter
{
    public class BlockManager
    {
        private string _code;
        private List<Block> _blocks;

        public BlockManager(string code)
        {
            _code = code;
            _blocks = GetBlocks();
        }

        private List<Block> GetBlocks()
        {
            Stack<int> stack = new Stack<int>();
            List<Block> blocks = new List<Block>();
            for (int i = 0; i < _code.Length; i++)
            {
                char ch = _code[i];
                if (ch == Chars.Open)
                {
                    stack.Push(i);
                }

                if (ch == Chars.Close)
                {
                    int from = stack.Pop();
                    blocks.Add(new Block(from, i));
                }
            }

            return blocks;
        }

        public int GetFrom(int to)
        {
            foreach (Block block in _blocks)
            {
                if (block.To == to)
                {
                    return block.From;
                }
            }

            throw new BlockException();
        }

        public int GetTo(int from)
        {
            foreach (Block block in _blocks)
            {
                if (block.From == from)
                {
                    return block.To;
                }
            }

            throw new BlockException();
        }
    }
}