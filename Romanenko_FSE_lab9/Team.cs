using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanenko_FSE_lab9
{
    internal class Team : INameAndCopy, IComparable
    {
        protected string _organizationName;
        protected int _registrationID;

        public Team() : this("None", 0) { }

        public Team(string organizationName, int registrationID)
        {
            _organizationName = organizationName;
            _registrationID = registrationID;
        }

        public int RegistrationID
        {
            get { return _registrationID; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Registration number must be greater than 0");
                }

                _registrationID = value;
            }
        }

        public string Name { get { return _organizationName; } set { _organizationName = value; } }

        public int CompareTo(object? obj)
        {
            if (obj is Team other)
                return _registrationID.CompareTo(other.RegistrationID);
            else
                throw new ArgumentException("Object isn't a Team!");
        }

        public virtual object DeepCopy()
        {
            return new Team(_organizationName, _registrationID);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;

            Team other = (Team)obj;
            return string.Equals(_organizationName, other.Name, StringComparison.Ordinal) &&
                   _registrationID == other.RegistrationID;
        }

        public static bool operator ==(Team left, Team right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Team left, Team right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_organizationName, _registrationID);
        }

        public override string ToString()
        {
            return $"---- Team ----\nOrganization Name: {_organizationName}\nRegistation ID: {_registrationID.ToString()}";
        }

        public virtual string ToShortString()
        {
            return $"{_organizationName} {_registrationID}";
        }
    }
}
