﻿using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            private set
            {
                if (value < 0)
                {
                    oxygenLevel = value;
                }
            }
        }

        public IReadOnlyCollection<string> Catch { get; private set; }

        public double CompetitionPoints { get; private set; }

        public bool HasHealthIssues { get; private set; }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;

            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);


        public abstract void RenewOxy();
        

        public void UpdateHealthStatus()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {}, Points earned: {CompetitionPoints} ]";
        }
    }
}
