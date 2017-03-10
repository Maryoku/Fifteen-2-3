using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fifteen_2_3
{
    class Game
    {
        public int[,] Field;
        public int Size;

        public int ZeroX;
        public int ZeroY;

        public Dictionary<int, Coordinate> Dictionary = new Dictionary<int, Coordinate>();

        public Game(params int[] values)
        {
            int count = 0;

            Size = (int)Math.Sqrt(values.Length);

            if (values.Length != Math.Pow(Size, 2))
            {
                throw new ArgumentException("Поле не соответстует правилам");
            }

            this.Field = new int[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (values[count] == 0)
                    {
                        ZeroX = i;
                        ZeroY = j;

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

            for(int i = 0; i < values.Length; i++)
            {
                if (!values.Contains(i))
                {
                    throw new ArgumentException("Числа в игре некорректны");
                }
            }

        }

        private int this[int i, int j]
        {
            get
            {
                return Field[i, j];
            }
        }

        public Coordinate GetLocation(int value) 
        {
            return Dictionary[value];
        }

        public virtual void Shift(int value)
        {
            if (Dictionary[value] - Dictionary[0] == 1)
            {
                Coordinate positionZero = Dictionary[0];
                Field[Dictionary[0].X, Dictionary[0].Y] = value;
                Field[Dictionary[value].X, Dictionary[value].Y] = 0;
                Dictionary[0] = Dictionary[value];
                Dictionary[value] = positionZero;
            }
            else
            {
                throw new ArgumentException("Невозможно передвинуть фишку");
            }
        }


        /**** Дополнительное задание ****/
        public static Game ReadCSV(string file)
        {
            string[] Lines = File.ReadAllLines(file);
            int[] elem = new int[Lines.Length];

            for (int i = 0; i < Lines.Length; i++)
            {
                string s = Lines[i];
                string[] substring = s.Split(';');
                elem[i] = Convert.ToInt32(substring[i]);
            }
            return new Game(elem);
        }

        /************************************/

    }

}
