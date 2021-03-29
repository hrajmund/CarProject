using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace CarProject
{
    class CoinClass
    {
        public CoinClass(Rectangle rec, Rect hitbox)
        {
            this.rec = rec;
            this.hitbox = hitbox;
        }

        private Rectangle rec { get; set; }
        private Rect hitbox { get; set; }

    }
}
