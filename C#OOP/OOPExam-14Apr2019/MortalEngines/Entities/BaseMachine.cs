using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private IList<string> targets;
        protected BaseMachine(string name , double attackPoints , double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
             set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if (target== null)
            {
                throw new NullReferenceException("Target cannot be null");
            }
            target.HealthPoints -= this.AttackPoints - target.DefensePoints;
            SetTargetHealthPointsToZero(target);
            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints:f2}")
                .AppendLine($" *Attack: {this.AttackPoints:f2}")
                .AppendLine($" *Defense: {this.DefensePoints:f2}");

            if (this.Targets.Count==0)
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(",",this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
        private void SetTargetHealthPointsToZero(IMachine target)
        {
            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }
        }
    }
}
