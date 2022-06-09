﻿using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Game
    {
        private DateTime date;
        private List<User> playersList;
        private List<Board> player1Board;
        private List<Board> player2Board;

        public Game(User player1, User player2)
        {
            this.DateTime = DateTime.Now;
            initializePlayersBoard();
        }

        public void initializePlayersBoard()
        {
            Board player1Shot = new ShotBoard();
            Board player1Ship = new ShipBoard();
            Board player2Shot = new ShotBoard();
            Board player2Ship = new ShipBoard();
        }

        public void Shoot(User whoShoots, int x, int y)
        {
            if (whoShoots.UserId == playersList[0].UserId)
            {
                player2Shot.AddShot(x, y);
            }
            else if (whoShoots.UserId == playersList[1].UserId)
            {
                player1Shot.AddShot(x, y);
            }
        }

        public DateTime DateTime
        {
            get
            {
                return this.date;
            }

            private set
            {
                this.date = value;
            }
        }
        public List<User> PlayersList
        {
            get
            {
                return this.playersList;
            }

        }
        public List<Board> Player1Board
        {
            get
            {
                return this.player1Board;
            }
            private set
            {
                Board value1 = value;
                this.player1Board.Add(value1);
            }

        }
        public List<Board> Player1Board
        {
            get
            {
                return this.player2Board;
            }
            private set
            {
                Board value1 = value;
                this.player2Board.Add(value1);
            }
        }



    }
}
