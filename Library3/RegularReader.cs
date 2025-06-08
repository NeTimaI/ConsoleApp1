using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3
{
    public class RegularReader : Reader
    {
        public DateTime RegistrationDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public RegularReader(string name, string surname, string cardNumber, string issueDate, int loanDays, decimal deposit, string registrationDate)
            : base(name, surname, cardNumber, issueDate, loanDays, deposit)
        {
            if (!DateTime.TryParse(registrationDate, out var parsedDate))
                throw new ArgumentException("Неверный формат даты записи");

            RegistrationDate = parsedDate;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            return new[]
            {
            baseInfo[0],
            baseInfo[1],
            $"Дата записи: {RegistrationDate:d}, Адрес: {Address}, Телефон: {Phone}"
        };
        }
    }
}