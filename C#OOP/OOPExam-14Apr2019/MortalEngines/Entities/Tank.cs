using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
   public class Tank : BaseMachine, ITank, IMachine
    {
        private const double InitialHealthPoints = 100;
        private bool defenseMode ;
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }
          private  set
            {
                if (value == true)
                {
                    this.AttackPoints -= 40;
                    this.DefensePoints += 30;
                }
             
                this.defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.defenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;

            }
            else
            {
                this.defenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $" *Defense: {(this.DefenseMode == true ? "ON" : "OFF")}";
        }
    }
}
