
namespace BrainfuckInterpreter
{
    public class Interpreter
    {
        private int[] _memory;
        private int _pointer;
        private int _currentCell => _memory[_pointer];
        
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
            while (codePointer < _code.Length)
            {
                char ch = _code[codePointer];
                if (ch == Chars.Open)
                {
                    
                }
                codePointer++;
            }
        }        
        
    }
}