using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3
{
    public class TemporaryReader : Reader
    {
        public DateTime AccessEndDate { get; set; }
        public List<string> AllowedDepartments { get; set; }

        public TemporaryReader(string name, string surname, string cardNumber, string issueDate, int loanDays, decimal deposit, string accessEndDate)
            : base(name, surname, cardNumber, issueDate, loanDays, deposit)
        {
            if (!DateTime.TryParse(accessEndDate, out var parsedDate))
                throw new ArgumentException("Неверный формат даты окончания допуска");

            AccessEndDate = parsedDate;
            AllowedDepartments = new List<string>();
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var departments = string.Join(", ", AllowedDepartments);
            return new[]
            {
            baseInfo[0],
            baseInfo[1],
            $"Допуск до: {AccessEndDate:d}, Отделы: {departments}"
        };
        }
    }
}