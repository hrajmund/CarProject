using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace CarProject
{
    class CoinsWithHitBoxes
    {

        private Rectangle coin;
        private Rect coinHitBox;

        public CoinsWithHitBoxes(Rectangle coin, Rect coinHitBox)
        {
            this.Coin = coin;
            this.CoinHitBox = coinHitBox;
        }

        public Rectangle Coin { get => coin; set => coin = value; }
        public Rect CoinHitBox { get => coinHitBox; set => coinHitBox = value; }
    }
}
