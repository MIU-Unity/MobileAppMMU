using System;

namespace Gameplay
{
    public class Difficult
    {
        private const int MAX_DIFFICULTY = 3;
        
        private static int _currentDifficulty = 0;
        
        public static int Get()
        {
            return _currentDifficulty;
        }
        
        public static void Set(int value)
        {
            if (value < 0 || value > MAX_DIFFICULTY)
                throw new Exception($"Invalid difficulty. Value must be between 0 and {MAX_DIFFICULTY}");
            
            _currentDifficulty = value;
        }
    }
}
