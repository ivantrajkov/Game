using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    public class Piece
    {
        public int position {  get; set; }
        public string color {  get; set; }
        public bool isAtHome {  get; set; }
        public bool isFinished {  get; set; }
        public bool canMove { get; set; }

        public Piece(string color)
        {
            position = 0;
            this.color = color;
            canMove = false;
            isFinished = false;
        }

        public override string ToString()
        {
            return String.Format("{0}",color);
        }
    }
}
