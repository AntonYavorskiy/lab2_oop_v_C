using System;

namespace lab2_hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 2 ~~~ Вариант 11 ~~~ Выполнил Яворский Антон");
            Console.WriteLine("****************************************************************");
            Klient anton = new Klient("Яворский", 10086, 2000);
            Klient ivan = new Klient("Иванов", 10324, 1999);


            Nomer standart = new Nomer( 3, 1, anton.Fio,anton.Passport, anton.Birth, "Номер занят" );
            Nomer standart2 = new Nomer(1, 1, ivan.Fio, ivan.Passport, ivan.Birth, "Номер занят");
            Nomer free = new Nomer(2, 1, null, 0, 0, "Номер cвободен");
            
           
            Hotel Tourist = new Hotel("Омск", 5, standart.Nomer_k, standart.Floor, anton.Fio, anton.Passport, anton.Birth, standart.Status);
            Hotel Tourist2 = new Hotel("Омск", 5, standart2.Nomer_k, standart2.Floor, ivan.Fio, ivan.Passport, ivan.Birth, standart2.Status);

            Console.WriteLine("         Информация о гостинице:");
            Console.WriteLine(Tourist.GetInfoHotel());


            Console.WriteLine("--------------------------------------");
            Console.WriteLine("             Проживающие: \n" + Tourist.Info_k() + "\n" + Tourist2.Info_k());

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("         Номера готовые к заселению: ");
            if (standart.Now_Stats() == "Номер cвободен") Console.WriteLine(standart.Info_nomera());
            if (standart2.Now_Stats() == "Номер cвободен") Console.WriteLine(standart2.Info_nomera());
            if (free.Now_Stats() == "Номер cвободен") Console.WriteLine(free.Info_nomera());


            Console.ReadKey();
        }

        class Klient
        {
            public string Fio;
            public int Passport;
            public int Birth;

            public Klient (string Fio, int Passport, int Birth)
            {
                this.Fio = Fio;
                this.Passport = Passport;
                this.Birth = Birth;
            }

        }

        class Nomer
        {
            public int Nomer_k;
            public int Floor;
            public Klient Klient;
            public string Status;

            public Nomer(int Nomer_k, int Floor, string Fio, int Passport, int Birth, string Status)
            {
                this.Nomer_k = Nomer_k;
                this.Floor = Floor;
                this.Klient = new Klient(Fio, Passport, Birth);
                this.Status = Status;
            }

            public string Now_Stats()
            {
                return this.Status;
            }

            public string Info_nomera()
            {
                return $"Номер комнаты: {Nomer_k} | Этаж: {Floor} | Статус: {Status}";
            }

           


        }

        class Hotel
        {
            public string Adress;
            public int Num_floors;
            public Nomer Numbers;

            public Hotel (string Adress, int Num_floors, int Nomer_k, int Floor, string Fio, int Passport, int Birth, string Status)
            {
                this.Adress = Adress;
                this.Num_floors = Num_floors;
                this.Numbers = new Nomer(Nomer_k, Floor, Fio, Passport, Birth, Status);
            }

            public string GetInfoHotel()
            {
                return $" Адрес: {Adress} | Кол-во этажей: {Num_floors} ";
            }

             public string Info_k()
            {
                return $" Клиент: {Numbers.Klient.Fio} (Год рождения: {Numbers.Klient.Birth} | Пасспорт: {Numbers.Klient.Passport})| Этаж : {Numbers.Floor} | Комната: {Numbers.Nomer_k}";
            }
        }
    }
}
