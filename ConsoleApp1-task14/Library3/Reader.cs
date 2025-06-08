namespace Library3
{
    public class Reader : IComparable <Reader>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public readonly string CardNumber;
        public List<string> TakenBooks { get; set; }
        public DateTime IssueDate { get; set; }
        public TimeSpan LoanDuration { get; set; }
        public readonly DateTime ReturnDate;
        public decimal Deposit { get; set; }

        public Reader(string name, string surname, string cardNumber, string issueDate, int loanDays, decimal deposit)
        {
            Name = name;
            Surname = surname;
            CardNumber = cardNumber;

            if (!DateTime.TryParse(issueDate, out var parsedIssueDate))
                throw new ArgumentException("Неверный формат даты выдачи");

            IssueDate = parsedIssueDate;
            LoanDuration = TimeSpan.FromDays(loanDays);
            ReturnDate = IssueDate.Add(LoanDuration);

            Deposit = deposit;
            TakenBooks = new List<string>();
        }
        public int CompareTo(Reader other)
        {
            if (other == null) return 1;
            int surnameCompare = string.Compare(Surname, other.Surname, StringComparison.Ordinal);
            if (surnameCompare != 0) return surnameCompare;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        public int GetHashCode(Reader obj)
        {
            return obj.CardNumber?.GetHashCode() ?? 0;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"{Name} {Surname}";
            info[1] = $"Билет: {CardNumber}, Выдано: {IssueDate:d}, На срок: {LoanDuration.Days} дн., Возврат до: {ReturnDate:d}, Залог: {Deposit:C}";

            return info;
        }
    }
}