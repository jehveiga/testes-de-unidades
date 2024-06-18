namespace Store.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount(decimal amount, DateTime expireDate)
        {
            Amount = amount;
            ExpireDate = expireDate;
        }

        public decimal Amount { get; private set; }
        public DateTime ExpireDate { get; private set; }

        public decimal Value()
        {
            if (IsValid())
                return Amount;
            else return 0;
        }

        public bool IsValid()
        {
            return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
        }
    }
}
