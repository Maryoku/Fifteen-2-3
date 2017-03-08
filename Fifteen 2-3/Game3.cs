using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen_2_3
{
    class Game3 : Game2
    {
        private List<int> History;

        public Game3(params int[] values) : base(values)
        {
            History = new List<int>();
        }

        public override void Shift(int value)
        {
            base.Shift(value);
            History.Add(value);
        }

        /**** Откат ходов ****/
        public void RollbackSteps(int countMovies)
        {
            if (countMovies > History.Count)
                throw new ArgumentException("Некорректное количество шагов для отката");

            int lastMove = 0;
            for (int i = 0; i < countMovies; i++)
            {
                lastMove = History.Last();
                History.Remove(lastMove);
                this.Shift(lastMove);

                // костыль для момента когда мы откат записываем в историю как ход
                lastMove = History.Last();
                History.Remove(lastMove);
            }
        }
        /*********************/
    }
}
