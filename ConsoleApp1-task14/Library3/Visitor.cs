using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3
{
    public class Visitor : Reader
    {
        public DateTime VisitStart { get; set; }
        public DateTime VisitEnd { get; set; }
        public string IDDocument { get; set; }

        public Visitor(string name, string surname, string cardNumber, string issueDate, int loanDays, decimal deposit, string visitStart, string visitEnd)
            : base(name, surname, cardNumber, issueDate, loanDays, deposit)
        {
            if (!DateTime.TryParse(visitStart, out var start))
                throw new ArgumentException("Неверный формат времени прихода");
            if (!DateTime.TryParse(visitEnd, out var end))
                throw new ArgumentException("Неверный формат времени ухода");

            VisitStart = start;
            VisitEnd = end;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            return new[]
            {
            baseInfo[0],
            baseInfo[1],
            $"Время посещения: {VisitStart:t} – {VisitEnd:t}, Удостоверение: {IDDocument}"
        };
        }
    }
}