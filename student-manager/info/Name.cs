/**
 * File: Name.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Stores a simple name first and last
 *
 * Group Members:
 *    - Emily Ramanna
 *    - James Grau
 *    - Nathaniel Primo
**/

namespace student_manager.info
{
    public class Name
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Creates a full name
        /// </summary>
        /// <param name="first">The desired first name</param>
        /// <param name="last">The desired last name</param>
        public Name(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        /// <summary>
        /// Turns the name to string in the format first last
        /// </summary>
        /// <returns>The stringfyed full name</returns>
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}