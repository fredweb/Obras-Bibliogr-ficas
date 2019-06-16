using System;
using System.Linq;

namespace ObrasBiograficas
{
    public class NameAuthor
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        private readonly string[] cases = new[]
        {
            "da", "de", "do", "das", "dos"
        };
        public NameAuthor()
        {

        }

        public NameAuthor(string fullName)
        {
            var nameParts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts == null)
            {
                return;
            }

            for (int i = 0; i < nameParts.Length; i++)
            {
                if (i == 0)
                    FirstName = nameParts[i];
                else if (i == 1)
                {
                    if (cases.Contains(nameParts[i].ToLower()))
                        MiddleName = nameParts[i].ToLower();
                    else
                        LastName = LastName + " " + nameParts[i].ToUpper();
                }
                else
                {
                    var name = cases.Contains(nameParts[i].ToLower()) ? nameParts[i].ToLower() : nameParts[i].ToUpper();
                    LastName = LastName + " " + name;
                }
            }
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstCharToUpper(FirstName)} {MiddleName}".TrimEnd();
        }

        public static string FirstCharToUpper(string FisrtName)
        {
            switch (FisrtName)
            {
                case null: throw new ArgumentNullException(nameof(FisrtName));
                case "": throw new ArgumentException($"{nameof(FisrtName)} cannot be empty", nameof(FisrtName));
                default: return FisrtName.First().ToString().ToUpper() + FisrtName.Substring(1);
            }
        }
    }
}
