namespace Romanenko_FSE_lab9
{
    internal class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;

        public Person() : this("None", "None", DateTime.MinValue)
        { }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
        }

        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public DateTime DateOfBirth { get { return _dateOfBirth; } set { _dateOfBirth = value; } }

        public int YearOfBirth
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _dateOfBirth = new DateTime(value, _dateOfBirth.Month, _dateOfBirth.Day);
            }
        }

        public override string ToString()
        {
            string result = $"\nFirst Name: {_firstName}\nLast Name: {_lastName}\nDate of Birth: ";
            if (_dateOfBirth == DateTime.MinValue)
            {
                return result + "None";
            }
            return result + _dateOfBirth.ToString();
        }

        public virtual string ToShortString()
        {
            return _firstName + " " + _lastName;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;

            Person other = (Person)obj;
            return string.Equals(_firstName, other.FirstName, StringComparison.Ordinal) &&
                   string.Equals(_lastName, other.LastName, StringComparison.Ordinal) &&
                   _dateOfBirth == other.DateOfBirth;
        }

        public static bool operator ==(Person left, Person right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_firstName, _lastName, _dateOfBirth);
        }

        public object DeepCopy()
        {
            return new Person(_firstName, _lastName, _dateOfBirth);
        }
    }
}
