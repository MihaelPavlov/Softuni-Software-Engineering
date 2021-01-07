using _08.MilitaryElite.Contracts;
using _08.MilitaryElite.Enumerations;
using _08.MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;


namespace _08.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string firstName, string lastName, int id, decimal salary, string corps)
            : base(firstName, lastName, id, salary)
        {
            this.Corps = TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;
            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);
            if (!parsed)
            {
                throw new InvalidCorpsException();
            }
            return corps;
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps.ToString()}";
        }
    }
}

