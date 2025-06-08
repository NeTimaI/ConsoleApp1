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
        }
        [TestFixture]
        public class ReaderTests
        {
            [Test]
            public void CompareTo_SortsBySurnameThenByName()
            {
                var ivan = new Reader("Иван", "Иванов", "R001", "01.01.2023", 14, 500m);
                var petr = new Reader("Петр", "Алексеев", "R002", "02.01.2023", 7, 300m);
                var anna = new Reader("Анна", "Иванова", "R003", "03.01.2023", 30, 1000m);

                var readers = new List<Reader> { ivan, petr, anna };
                readers.Sort();

                Assert.That(readers[0].Surname, Is.EqualTo("Алексеев"));
                Assert.That(readers[1].Surname, Is.EqualTo("Иванов"));
                Assert.That(readers[2].Surname, Is.EqualTo("Иванова"));
            }
        }
        [TestFixture]
        public class SurnameTests
        {
            [Test]
            public void CompareTo_SortsBySurnameThenByName()
            {
                var ivan = new Reader("Иван", "Иванов", "R001", "01.01.2023", 14, 500m);
                var petr = new Reader("Петр", "Алексеев", "R002", "02.01.2023", 7, 300m);
                var anna = new Reader("Анна", "Иванова", "R003", "03.01.2023", 30, 1000m);

                var readers = new List<Reader> { ivan, petr, anna };
                readers.Sort();

                Assert.That(readers[0].Surname, Is.EqualTo("Алексеев"));
                Assert.That(readers[1].Surname, Is.EqualTo("Иванов"));
                Assert.That(readers[2].Surname, Is.EqualTo("Иванова"));
            }
        }

        [TestFixture]
        public class LibraryTests
        {
            [Test]
            public void ReaderCardNumberComparer_SortsCorrectly()
            {
                var readers = new List<Reader>
        {
            new Reader("Иван", "Иванов", "R002", "01.01.2023", 14, 500m),
            new Reader("Петр", "Петров", "R001", "02.01.2023", 7, 300m),
            new Reader("Анна", "Сидорова", "R003", "03.01.2023", 30, 1000m)
        };

                readers.Sort(new ReaderCardNumberComparer());

                Assert.That(readers[0].CardNumber, Is.EqualTo("R001"));
                Assert.That(readers[1].CardNumber, Is.EqualTo("R002"));
                Assert.That(readers[2].CardNumber, Is.EqualTo("R003"));
            }

            [Test]
            public void Library_ImplementsIEnumerableCorrectly()
            {
                var readers = new Reader[]
                {
            new Reader("Иван", "Иванов", "R001", "01.01.2023", 14, 500m)
                };

                var library = new Library("Главная", "ул. Книжная, 1", readers);

                
                int count = 0;
                foreach (var reader in library)
                {
                    count++;
                    Assert.That(reader, Is.InstanceOf<Reader>());
                }
                Assert.That(count, Is.EqualTo(1));

                count = 0;
                foreach (Reader reader in (System.Collections.IEnumerable)library)
                {
                    count++;
                    Assert.That(reader, Is.InstanceOf<Reader>());
                }
                Assert.That(count, Is.EqualTo(1));
            }

            [Test]
            public void Constructor_RemovesDuplicateReaders()
            {
                var reader1 = new Reader("Иван", "Иванов", "R001", "01.01.2023", 14, 500m);
                var reader2 = new Reader("Иван", "Иванов", "R001", "01.01.2023", 14, 500m);

                var library = new Library("Филиал", "ул. Читальная, 2", new[] { reader1, reader2 });

                Assert.That(library.ReaderCount, Is.EqualTo(1));
            }
        }
        [TestFixture]
        public class ReaderCardNumberComparerTests
        {
            [Test]
            public void SortReadersByCardNumber_AscendingOrder()
            {
                
                var readers = new List<Reader>
        {
            new Reader("Иван", "Иванов", "R005", "01.01.2023", 14, 500m),
            new Reader("Петр", "Петров", "R002", "02.01.2023", 7, 300m),
            new Reader("Анна", "Сидорова", "R001", "03.01.2023", 30, 1000m),
            new Reader("Мария", "Кузнецова", "R004", "04.01.2023", 21, 700m),
            new Reader("Алексей", "Смирнов", "R003", "05.01.2023", 10, 400m)
        };

                var expectedOrder = new[] { "R001", "R002", "R003", "R004", "R005" };
                var comparer = new ReaderCardNumberComparer();

                
                readers.Sort(comparer);

                
                Assert.That(readers.Select(r => r.CardNumber), Is.EqualTo(expectedOrder));
            }

            [Test]
            public void SortReadersByCardNumber_WithNullValues()
            {
                
                var readers = new List<Reader>
        {
            null,
            new Reader("Иван", "Иванов", "R002", "01.01.2023", 14, 500m),
            null,
            new Reader("Петр", "Петров", "R001", "02.01.2023", 7, 300m)
        };

                var expectedOrder = new[] { null, null, "R001", "R002" };
                var comparer = new ReaderCardNumberComparer();

                
                readers.Sort(comparer);

                
                Assert.That(readers.Select(r => r?.CardNumber), Is.EqualTo(expectedOrder));
            }

            [Test]
            public void SortReadersByCardNumber_EmptyList()
            {

                var readers = new List<Reader>();
                var comparer = new ReaderCardNumberComparer();


                Assert.DoesNotThrow(() => readers.Sort(comparer));
            }
        }








    }
}








