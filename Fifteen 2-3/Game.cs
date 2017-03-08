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
        public int size;

        public int zeroX;
        public int zeroY;

        public Dictionary<int, Coordinate> Dictionary = new Dictionary<int, Coordinate>();

        public Game(params int[] values)
        {
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

            for(int i = 0; i < values.Length; i++) // а есть ли смысл проверять если вываливается "элемент с таким ключом уже есть"
            {
                if (!values.Contains(i))
                {
                    throw new ArgumentException("Числа в игре некорректны");
                }
            }

        }

        public int this[int i, int j]
        {
            get
            {
                return Field[i, j];
            }
            set // а нужен ли он тут?
            {
                Field[i, j] = value;
            }
        }

        public Coordinate GetLocation(int value) 
            // нет смысла ловить исключения, т.к. вываливается искл dictionary при несущ знач
        {
            return Dictionary[value];
        }

        public virtual void Shift(int value) // под 2-3 переписывать без изменения исходного поля?
        {
            if (Dictionary[value] - Dictionary[0] == 1)
            {
                Coordinate positionZero = Dictionary[0];
                this[Dictionary[0].X, Dictionary[0].Y] = value;
                this[Dictionary[value].X, Dictionary[value].Y] = 0;
                Dictionary[0] = Dictionary[value];
                Dictionary[value] = positionZero;
            }
            else
            {
                throw new ArgumentException("Невозможно передвинуть фишку");
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0} ", Field[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
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
