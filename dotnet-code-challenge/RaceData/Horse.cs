using System;

namespace dotnet_code_challenge
{
    public class Horse
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as Horse;

            if (item == null)
                return false;

            return Name.Equals(item.Name) && Number.Equals(item.Number);
        }

        public override int GetHashCode()
        {
            return 23 * Name.GetHashCode() +
                    Number.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", Name, Number);
        }
    };
}
