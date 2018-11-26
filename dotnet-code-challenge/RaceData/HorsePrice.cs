
namespace dotnet_code_challenge
{
    public class HorsePrice
    {
        public int HorseNumber { get; set; }
        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as HorsePrice;

            if (item == null)
            {
                return false;
            }

            return HorseNumber.Equals(item.HorseNumber) &&
                    Price.Equals(item.Price);
        }

        public override int GetHashCode()
        {
            return 23 * HorseNumber.GetHashCode() +
                    Price.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Price: {0}, Horse: {1}\n", Price, HorseNumber);
        }
    };
}
