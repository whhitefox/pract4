namespace Pract4
{
    class Program
    {
        static void Main(sring[] args)
        {
            Data data = new Data();
            data.Day = 18;
            data.Month = 10;
            data.Year = 2022;

            List<Zametka> vseZametki = new List<Zametka>();

            Data data1 = new Data();
            data1.Day = 19;
            data1.Month = 10;
            data1.Year = 2022;
            Zametka zametka1 = new Zametka();
            zametka1.Name = "Заметка 1";
            zametka1.Opisanie = "Заметка для тестирования.";
            zametka1.DataViponeniya = data1;
            vseZametki.Add(zametka1);

            Data data2 = new Data();
            data2.Day = 19;
            data2.Month = 10;
            data2.Year = 2022;
            Zametka zametka2 = new Zametka();
            zametka2.Name = "Заметка 2";
            zametka2.Opisanie = "Заметка для тестирования. (Вторая)";
            zametka2.DataViponeniya = data2;
            vseZametki.Add(zametka2);

            Data data3 = new Data();
            data3.Day = 18;
            data3.Month = 10;
            data3.Year = 2022;
            Zametka zametka3 = new Zametka();
            zametka3.Name = "Ежедневник";
            zametka3.Opisanie = "Нужно сделать ежедневник.";
            zametka3.DataViponeniya = data3;
            vseZametki.Add(zametka3);

            Data data4 = new Data();
            data4.Day = 17;
            data4.Month = 10;
            data4.Year = 2022;
            Zametka zametka4 = new Zametka();
            zametka4.Name = "Выспаться";
            zametka4.Opisanie = "Хорошо поспать в свой выходной.";
            zametka4.DataViponeniya = data4;
            vseZametki.Add(zametka4);

            Data data5 = new Data();
            data5.Day = 20;
            data5.Month = 10;
            data5.Year = 2022;
            Zametka zametka5 = new Zametka();
            zametka5.Name = "Прийти на пары";
            zametka5.Opisanie = "Ко второй.";
            zametka5.DataViponeniya = data5;
            vseZametki.Add(zametka5);

            int position = 0;
            ConsoleKeyInfo key;
            do
            {
                List<Zametka> zametki = new List<Zametka>();
                foreach (Zametka zametka in vseZametki)
                {
                    if (zametka.DataViponeniya.Day == data.Day && zametka.DataViponeniya.Month == data.Month && zametka.DataViponeniya.Year == data.Year)
                    {
                        zametki.Add(zametka);
                    }
                }
                if (zametki.Count == 0)
                {
                    position = -1;
                }
                WriteData(data);
                Menu(zametki);
                Strelka(position);

                Console.SetCursorPosition(0, 10);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        data = SledData(data);
                        position = 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        data = PredData(data);
                        position = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        if (zametki.Count > 0)
                        {
                            position -= 1;
                            if (position < 0)
                            {
                                position = zametki.Count - 1;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (zametki.Count > 0)
                        {
                            position += 1;
                            if (position >= zametki.Count)
                            {
                                position = 0;
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (position != -1)
                        {
                            Zametka zametka = zametki[position];
                            ZametkaInfo(zametka);
                        }
                        break;
                }
                Console.Clear();
            } while (key.Key != ConsoleKey.Escape) ;
        }
        static bool Visokosniy(int year)
        {
            if (year % 100 == 0)
            {
                return year % 400 == 0;
            }
            return year % 4 == 0;
        }
        static Data SledData(Data data)
        {
            int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (Visokosniy(data.Year))
            {
                daysInMonth[1] += 1;
            }

            Data newData = new Data();
            newData.Day = data.Day + 1;
            newData.Month = data.Month;
            newData.Year = data.Year;

            if (newData.Day > daysInMonth[newData.Month - 1])
            {
                newData.Day = 1;
                newData.Month += 1;
            }
            if (newData.Month > 12)
            {
                newData.Month = 1;
                newData.Year += 1;
            }

            return newData;
        }
        static Data PredData(Data data)
        {
            int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (Visokosniy(data.Year))
            {
                daysInMonth[1] += 1;
            }

            Data newData = new Data();
            newData.Day = data.Day - 1;
            newData.Month = data.Month;
            newData.Year = data.Year;

            if (newData.Day < 1)
            {
                newData.Month -= 1;
                if (newData.Month < 1)
                {
                    newData.Month = 12;
                    newData.Year -= 1;
                }
                newData.Day = daysInMonth[newData.Month - 1];
            }

            return newData;
        }

        static void WriteData(Data data)
        {
            Console.WriteLine($"<-- {data.Day}.{data.Month}.{data.Year} -->");
        }

        static void Menu(List<Zametka> zametki)
        {
            if (zametki.Count == 0)
            {
                Console.WriteLine("Заметок на этот день нет");
            } else
            {
                foreach (Zametka zametka in zametki)
                {
                    Console.WriteLine($"  {zametka.Name}");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Для завершения программы нажмите Esc.");
        }
        static void Strelka(int position)
        {
            if (position != -1)
            {
                Console.SetCursorPosition(0, position + 1);
                Console.WriteLine("->");
            }
        }

        static void ZametkaInfo(Zametka zametka)
        {
            Console.Clear();
            Data data = zametka.DataViponeniya;
            Console.WriteLine($"Имя: {zametka.Name}");
            Console.WriteLine($"Описание: {zametka.Opisanie}");
            Console.WriteLine($"Дата выполнения: {data.Day}.{data.Month}.{data.Year}");
            Console.WriteLine("");
            Console.WriteLine("Для возвращения в меню нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}