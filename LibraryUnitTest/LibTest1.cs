using Library3;
namespace LibraryUnitTest
{
    public class LibTest
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
        [TestFixture]
        public class RegularReaderTests
        {
            [Test]
            public void GetInfoTest()
            {
                var reader = new RegularReader("Анна", "Петрова", "R200001", "05.06.2024", 30, 1000m, "01.01.2022")
                {
                    Address = "ул. Ленина, д.1",
                    Phone = "+79991112233"
                };

                var info = reader.GetInfo();

                Assert.That(info.Length, Is.EqualTo(3));
                Assert.That(info[2], Is.EqualTo("Дата записи: 01.01.2022, Адрес: ул. Ленина, д.1, Телефон: +79991112233"));

            }
            [Test]
            public void ConstructorTest()
            {
                var reader = new RegularReader("Анна", "Петрова", "R200001", "05.06.2024", 30, 1000m, "01.01.2022");

                Assert.Multiple(() =>
                {
                    Assert.That(reader.Name, Is.EqualTo("Анна"));
                    Assert.That(reader.Surname, Is.EqualTo("Петрова"));
                    Assert.That(reader.RegistrationDate, Is.EqualTo(new DateTime(2022, 1, 1)));
                    Assert.That(reader.Address, Is.Null); // Не задан в конструкторе
                    Assert.That(reader.Phone, Is.Null);   // Не задан в конструкторе
                });
            }

            [Test]
            public void Constructor_ShouldThrowOnInvalidRegistrationDate()
            {
                Assert.Throws<ArgumentException>(() =>
                    new RegularReader("Анна", "Петрова", "R200001", "05.06.2024", 30, 1000m, "invalid-date"));
            }
        }

        [TestFixture]
        public class TemporaryReaderTests
        {
            [Test]
            public void GetInfoTest()
            {
                var reader = new TemporaryReader("Сергей", "Кузнецов", "R300002", "10.06.2024", 7, 300m, "01.09.2024");
                reader.AllowedDepartments.Add("Читальный зал");
                reader.AllowedDepartments.Add("Архив");

                var info = reader.GetInfo();

                Assert.That(info.Length, Is.EqualTo(3));
                Assert.That(info[2], Is.EqualTo("Допуск до: 01.09.2024, Отделы: Читальный зал, Архив"));
            }
            [Test]
            public void ConstructorTest()
            {
                var reader = new TemporaryReader("Сергей", "Кузнецов", "R300002", "10.06.2024", 7, 300m, "01.09.2024");

                Assert.Multiple(() =>
                {
                    Assert.That(reader.AccessEndDate, Is.EqualTo(new DateTime(2024, 9, 1)));
                    Assert.That(reader.AllowedDepartments, Is.Empty);
                });
            }

            [Test]
            public void Constructor_ShouldThrowOnInvalidAccessDate()
            {
                Assert.Throws<ArgumentException>(() =>
                    new TemporaryReader("Сергей", "Кузнецов", "R300002", "10.06.2024", 7, 300m, "invalid-date"));
            }
        }

        [TestFixture]
        public class VisitorTests
        {
            [Test]
            public void GetInfoTest()
            {
                var visitor = new Visitor("Олег", "Миронов", "R400003", "12.06.2024", 1, 100m, "12.06.2024 14:00", "12.06.2024 16:30")
                {
                    IDDocument = "Паспорт РФ №1234567890"
                };

                var info = visitor.GetInfo();

                Assert.That(info.Length, Is.EqualTo(3));
                Assert.That(info[2], Is.EqualTo("Время посещения: 14:00 – 16:30, Удостоверение: Паспорт РФ №1234567890"));
            }

            [Test]
            public void ConstructorTest()
            {
                var visitor = new Visitor("Олег", "Миронов", "R400003", "12.06.2024", 1, 100m, "12.06.2024 14:00", "12.06.2024 16:30");

                Assert.Multiple(() =>
                {
                    Assert.That(visitor.VisitStart, Is.EqualTo(new DateTime(2024, 6, 12, 14, 0, 0)));
                    Assert.That(visitor.VisitEnd, Is.EqualTo(new DateTime(2024, 6, 12, 16, 30, 0)));
                    Assert.That(visitor.IDDocument, Is.Null);
                });
            }

            [Test]
            public void Constructor_ShouldThrowOnInvalidVisitDates()
            {
                Assert.Throws<ArgumentException>(() =>
                    new Visitor("Олег", "Миронов", "R400003", "12.06.2024", 1, 100m, "invalid-time", "12.06.2024 16:30"));

                Assert.Throws<ArgumentException>(() =>
                    new Visitor("Олег", "Миронов", "R400003", "12.06.2024", 1, 100m, "12.06.2024 14:00", "invalid-time"));
            }
        }
    }
}
