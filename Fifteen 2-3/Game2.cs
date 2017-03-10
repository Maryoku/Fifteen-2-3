using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen_2_3
{
    class Game2 : Game
    {
        public Game2(params int[] values) : base(values)
        {
            int direction;
            int times = Size * 100;

            for (int k = 0; k < times; k++)
            {
                Random Randomize = new Random(DateTime.Now.Millisecond);

                direction = Randomize.Next(0, 4); // Сторона для обмена

                if (direction == 0) // Вверх
                {
                    // Кнопка сверху существует
                    if (Dictionary[0].X - 1 >= 0)
                    {
                        int shuffleValue = Field[Dictionary[0].X - 1, Dictionary[0].Y];
                        Shift(shuffleValue);
                    }
                }
                else if (direction == 1) // Вниз
                {
                    if (Dictionary[0].X + 1 < Size)
                    {
                        int shuffleValue = Field[Dictionary[0].X + 1, Dictionary[0].Y];
                        Shift(shuffleValue);
                    }
                }
                else if (direction == 2) // Влево
                {
                    if (Dictionary[0].Y - 1 >= 0)
                    {
                        int shuffleValue = Field[Dictionary[0].X, Dictionary[0].Y - 1];
                        Shift(shuffleValue);
                    }
                }
                else // Вправо
                {
                    if (Dictionary[0].Y + 1 < Size)
                    {
                        int shuffleValue = Field[Dictionary[0].X, Dictionary[0].Y + 1];
                        Shift(shuffleValue);
                    }
                }
            }
        }

        public bool IsWinner()
        {
            int k = 1;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Field[i, j] != k && Field[Size - 1, Size - 1] != 0)
                    {
                        return false;
                    }

                    k++;
                }
            }

            return true;
        }
    }
}
