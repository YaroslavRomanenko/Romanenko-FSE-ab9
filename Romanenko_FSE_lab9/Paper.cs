namespace Romanenko_FSE_lab9
{
    internal class Paper
    {
        private string _publicationName;
        private Person _publicationAuthor;
        private DateTime _publicationDate;

        public Paper() : this("None", new Person(), DateTime.MinValue) { }

        public Paper(string pubName, Person pubAuthor, DateTime pubDate)
        {
            _publicationName = pubName;
            _publicationAuthor = pubAuthor;
            _publicationDate = pubDate;
        }

        public string PublicationName { get { return _publicationName; } set { _publicationName = value; } }
        public Person PublicationAuthor { get { return _publicationAuthor; } set { _publicationAuthor = value; } }
        public DateTime PublicationDate { get { return _publicationDate; } set { _publicationDate = value; } }

        public override string ToString()
        {
            string result = $"\nPublication Name: {_publicationName}\nPublication Date: {_publicationDate.ToString()}\n-- Author of Publication --{_publicationAuthor.ToString()}";
            return result;
        }

        public virtual object DeepCopy()
        {
            return new Paper(_publicationName, _publicationAuthor, _publicationDate);
        }
    }
}
