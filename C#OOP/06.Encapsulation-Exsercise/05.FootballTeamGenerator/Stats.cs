﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Stats
    {
      
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
               
                if (value < Validations.MIN_VALUE || value > Validations.MAX_VALUE)
                {
                    throw new Exception("Endurance should be between 0 and 100.");
                }
                this.endurance = value;
              
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
               
                if (value < Validations.MIN_VALUE || value > Validations.MAX_VALUE)
                {
                    throw new Exception("Sprint should be between 0 and 100.");
                }
                this.sprint = value;

               
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
               
                if (value < Validations.MIN_VALUE || value > Validations.MAX_VALUE)
                {
                    throw new Exception("Dribble should be between 0 and 100.");
                }
                this.dribble = value;

               
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
               

                if (value < Validations.MIN_VALUE || value > Validations.MAX_VALUE)
                {
                    throw new Exception("Passing should be between 0 and 100.");
                }
                this.passing = value;
              
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
          private  set
            {
             
                if (value < Validations.MIN_VALUE || value > Validations.MAX_VALUE)
                {
                    throw new Exception("Shooting should be between 0 and 100.");
                }
                this.shooting = value;

               
            }
        }

        public double AverageStat()
        {
            return ((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
        }
    }
}
