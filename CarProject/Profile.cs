using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject
{
    class Profile
    {
        private string name;
        private int score;

        public Profile(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public string Name { get => name; set => name = value; }
        public int Score { get => score; set => score = value; }
    }
}
