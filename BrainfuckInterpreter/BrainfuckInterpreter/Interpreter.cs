using System;
using System.Collections.Generic;

namespace BrainfuckInterpreter
{
    public class Interpreter
    {
        private List<int> _memory = new List<int>();
        private int _pointer;

        private string _code;
        private int _codePointer;

        private List<Block> _blocks;


        public Interpreter(string code)
        {
            _code = code;
            _blocks = GetBlocks();
        }

        public void Run()
        {
            
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
    }
}