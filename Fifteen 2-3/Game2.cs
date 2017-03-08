using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen_2_3
{
    class Game2 : Game
    {
        public Game2(params int[] values)
        {
            /**** Перемешиваем ****/
            int n = values.Length;

            while (n > 1)
            {
                var rand = new Random();

                int k = rand.Next(n--);
                int temp = values[n];
                values[n] = values[k];
                values[k] = temp;
            }
            /**********************/

            int count = 0;

            size = (int)Math.Sqrt(values.Length);

            if (values.Length != Math.Pow(size, 2))
            {
                throw new ArgumentException("Поле не соответстует правилам");
            }

            this.Field = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (values[count] == 0)
                    {
                        zeroX = i;
                        zeroY = j;

                        Field[i, j] = values[count];
                        Dictionary.Add(values[count], new Coordinate(i, j));
                    }
                    else
                    {
                        Field[i, j] = values[count];
                        Dictionary.Add(values[count], new Coordinate(i, j));
                    }

                    count++;
                }
            }
        }

        //public Game2(params int[] values) : base(values)
        //{
        //}

        public bool IsWinner()
        {
            int k = 1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (Field[i, j] != k && Field[size - 1, size - 1] != 0)
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
