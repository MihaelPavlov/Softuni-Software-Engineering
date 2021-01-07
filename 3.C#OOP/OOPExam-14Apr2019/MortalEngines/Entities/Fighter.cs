using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine,IFighter, IMachine
    {
        private const double InitialHealthPoint = 200;
        private bool aggressiveMode; 
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoint)
        {
            this.AggressiveMode = true;
        }
        // TODO: fix the aggressiveMode = becouse its not get the bonus when its initiated
        public bool AggressiveMode
        {
            get
            {
                return this.aggressiveMode;
            }
          private  set
            {
                if (value == true)
                {
                    this.AttackPoints += 50;
                    this.DefensePoints -= 25;
                }
                this.aggressiveMode = value;
            }
        }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.aggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;

            }
            else
            {
                this.aggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $" *Aggressive: {(this.AggressiveMode==true ? "ON" : "OFF")}";
        }
    }
}
