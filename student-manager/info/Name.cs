namespace student_manager.info
{
    public class Name
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Name(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
