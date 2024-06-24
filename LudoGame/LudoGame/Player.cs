﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    public class Player
    {
        public string name {  get; set; }
        public string color {  get; set; }
        public bool hasFinished {  get; set; }
        public List<Piece> pieces { get; set; }
        public bool canMove { get; set; }

        public Player(string name)
        {
            this.name = name;
           // this.color = color;
            this.pieces = new List<Piece>();
            this.hasFinished = false;
            canMove = false;
        }

    }
}
