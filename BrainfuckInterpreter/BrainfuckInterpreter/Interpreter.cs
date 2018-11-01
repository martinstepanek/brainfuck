using System;

namespace BrainfuckInterpreter
{
    public class Interpreter
    {
        private int[] _memory;
        private int _pointer;

        private int _currentCell
        {
            get
            {
                if (_memory.Length <= _pointer || _pointer < 0)
                {
                    throw new MemoryException();
                }

                return _memory[_pointer];
            }
            set { _memory[_pointer] = value; }
        }

        private string _code;

        private BlockManager _blockManager;

        public Interpreter(string code, int memorySize = 1000)
        {
            _memory = new int[memorySize];
            _code = code;
            _blockManager = new BlockManager(_code);
        }

        public void Run()
        {
            int codePointer = 0;
            bool increase;
            while (codePointer < _code.Length)
            {
                increase = true;
                char ch = _code[codePointer];

                BasicCellOperations(ch);

                if (ch == Chars.Open && _currentCell == 0)
                {
                    codePointer = _blockManager.GetTo(codePointer);
                    increase = false;
                }

                if (ch == Chars.Close && _currentCell != 0)
                {
                    codePointer = _blockManager.GetFrom(codePointer);
                    increase = false;
                }

                if (ch == Chars.Print)
                {
                    Console.Write((char) _currentCell);
                }

                if (increase)
                {
                    codePointer++;
                }
            }
        }

        private void BasicCellOperations(char ch)
        {
            if (ch == Chars.Increase)
            {
                _currentCell++;
            }

            if (ch == Chars.Decrease)
            {
                _currentCell--;
            }

            if (ch == Chars.MoveLeft)
            {
                _pointer--;
            }

            if (ch == Chars.MoveRight)
            {
                _pointer++;
            }
        }
    }
}