using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmP_gyak_06
{
    internal class Runner
    {
        string name;
        int id, speed, distance = 0;

        public Runner(string name, int id, int speed)
        {
            this.name = name;
            this.id = id;
            this.speed = speed;
        }

        public void RefreshDistance(int seconds)
        {
            distance += speed * seconds;
        }

        public int GetDistance()
        {
            return distance;
        }

        public void Show()
        {
            Console.SetCursorPosition(distance, id);
            Console.Write(name[0]);
        }
    }
}
