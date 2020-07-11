﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftuniFundamentals.Csharp_Advanced_Classes
{
    class Guild
    {
        //adding fields;
        private string name;
        private int capacity;
        private int index = 0;

        private Dictionary<string,Player> roster;
        HashSet<string> playerClassesInRoster;

        //adding constructors
        public Guild(string name,int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new Dictionary<string, Player>(capacity);
            this.playerClassesInRoster = new HashSet<string>(capacity);
            this.index = -1;
        }

        //adding properties

        public string Name 
        {
            private set
            {
                if(value!=null)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Name or Null");
                }
            }

            get { return this.name; }
        }

        public int Capacity
        {
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Invaid Capacity cannot be 0 or below");
                }
                else
                {
                    this.capacity = value;
                }
            }

            get { return this.capacity; }
        }


        //adding behaviour
        public void AddPlayer(Player currentPlayer)
        {

            if (this.index + 1 <= this.Capacity)
            {
                this.index += 1;
                
                if(this.roster.ContainsKey(currentPlayer.Name))
                {
                    this.index -= 1;
                }
                else
                {
                    this.roster.Add(currentPlayer.Name, currentPlayer);
                    this.playerClassesInRoster.Add(currentPlayer.Class);
                }
                
            }
            else
            {
                throw new IndexOutOfRangeException("Index out  of range or Roster already full");
            }

        }

        public void ExpandGuild(int number)
        {
            if(number>this.Capacity)
            {
                this.Capacity = number;
            }
            else
            {
                throw new ArgumentException("Expand Count cannot be below or equal to current");
            }
        }

        public Player RemovePlayer(string name)
        {
            if(this.roster.ContainsKey(name))
            {
                Player currentRemovedPlayer = this.roster[name];
                this.roster.Remove(name);
                this.index -= 1;
                return currentRemovedPlayer;
            }
            else
            {
                throw new ArgumentException("No such player in the roster");
            }
        }


        public List<Player> KickPlayerByClass(string playerClass)
        {
            if(this.playerClassesInRoster.Contains(playerClass))
            {
                this.playerClassesInRoster.Remove(playerClass);

                //Colletion of removed players with playerClass name
                List<Player> currentRemovedPlayers = new List<Player>();

                // get Dictionary without the players with the className
                this.roster = this.roster.Where(player =>
                {
                    if(player.Value.Class.Equals(playerClass))
                    {
                        currentRemovedPlayers.Add(player.Value);
                        this.roster.Remove(player.Key);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }).ToDictionary(e => e.Key, e=>e.Value);
            }
        }


    }
}
