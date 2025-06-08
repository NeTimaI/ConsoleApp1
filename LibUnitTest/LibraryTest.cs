using System.Reflection.PortableExecutable;
using Library;

namespace LibUnitTest
{
    public class Tests
    {
        [TestFixture]
        public class ReaderUnitTests
        {
            [Test]
            public void ConstructorTest()
            {
                var reader = CreateTestReader();

                Assert.That(reader.Name, Is.EqualTo("Иван"));
                Assert.That(reader.Surname, Is.EqualTo("Иванов"));
                Assert.That(reader.CardNumber, Is.EqualTo("R123456"));
                Assert.That(reader.IssueDate.ToShortDateString(), Is.EqualTo("01.06.2024"));
                Assert.That(reader.LoanDuration, Is.EqualTo(TimeSpan.FromDays(14)));
                Assert.That(reader.ReturnDate.ToShortDateString(), Is.EqualTo("15.06.2024"));
                Assert.That(reader.Deposit, Is.EqualTo(500m));
            }

            [Test]
            public void GetInfoTest()
            {
                var reader = CreateTestReader();
                var info = reader.GetInfo();

                Assert.That(info.Length, Is.EqualTo(2));
                Assert.That(info[0], Is.EqualTo("Иван Иванов"));
                Assert.That(info[1], Is.EqualTo("Билет: R123456, Выдано: 01.06.2024, На срок: 14 дн., Возврат до: 15.06.2024, Залог: 500,00 ₽"));
            }

            private Reader CreateTestReader()
            {
                return new Reader("Иван", "Иванов", "R123456", "01.06.2024", 14, 500m);
            }
        }
    }
}