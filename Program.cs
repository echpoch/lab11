using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba11
{
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class reisy
    {
        public string punkt;
        public int day;
        public int time;

        public reisy(string a, int b, int c)
        {
            punkt = a;
            day = b;
            time = c;
        }


    }
    public class biggest
    {
        public int sumx = 0;
        static public int suma = 0;
        public int find(int[] x)
        {

            for (int i = 0; i < x.Length; i++)
            {
                sumx += x[i];

            }
            if (sumx > suma)
            {

                suma = sumx;
                sumx = 0;

            }
            sumx = 0;
            return suma;
        }
        public int[] a = { 0, 0, 0, 0, 0 };
    }
    class Program
    {
        static void Main(string[] args)
        {
            biggest Biggest = new biggest();
            bool chet(params int[] a2)
            {
                int k = 0;
                for (int i = 0; i < a2.Length; i++)
                    if (a2[i] % 2 == 0)
                        k += 0;
                    else
                        k++;
                if (k == 0)
                    return true;
                else
                    return false;
            }
            string[] months = { "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };
            int n = 5;
            var order = from m in months
                        where m.Length < n
                        select m;
            foreach (string x in order)
            {
                Console.WriteLine(x);
            }
            order = from m in months
                    where m == "июнь" || m == "июль" || m == "август"
                    select m;
            Console.WriteLine("++++++++++++++Лето++++++++++ ");
            foreach (string x in order)
            {
                Console.WriteLine(x);
            }
            order = from m in months
                    orderby m
                    select m;
            Console.WriteLine("++++++++++++++Месяца по алфавиту++++++++++ ");
            foreach (string x in order)
            {
                Console.WriteLine(x);
            }
            order = months.Where(s => (s.Contains('е')) && (s.Length > 4));
            Console.WriteLine("++++++++++++++Есть буква е++++++++++ ");
            foreach (string x in order)
            {
                Console.WriteLine(x);
            }
            reisy a = new reisy("minsk", 1, 10);
            reisy b = new reisy("gomel", 2, 12);
            reisy c = new reisy("brest", 3, 15);
            reisy d = new reisy("vitebsk", 1, 8);


            List<reisy> spisok = new List<reisy>();
            spisok.Add(a);
            spisok.Add(b);
            spisok.Add(c);
            spisok.Add(d);
            IEnumerable<reisy> zapros1 = from x in spisok
                                         where x.punkt == "minsk"
                                         select x;
            foreach (reisy x in zapros1)
            {
                Console.WriteLine(x.punkt + "Рейс в Минск");
            }

            IEnumerable<reisy> zapros2 = from x in spisok
                                         where (x.day == 1 && x.time == spisok.Min(x1 => x1.time))
                                         select x;
            foreach (reisy x in zapros2)
            {
                Console.WriteLine(x.punkt);
            }
            int zapros25 = spisok.Where(x1 => x1.day == 1).Count();

            Console.WriteLine(zapros25);

            IEnumerable<reisy> zapros3 = from x in spisok
                                         where (x.day == 3 && x.day == 5 && x.time == spisok.Max(x1 => x1.time))
                                         select x;
            foreach (reisy x in zapros3)
            {
                Console.WriteLine(x.punkt);
            }
            IEnumerable<reisy> zapros4 = spisok.OrderBy(x1 => x1.time);
            foreach (reisy x in zapros4)
            {
                Console.WriteLine(x.punkt + " " + x.time);
            }
            // string[] hard = { "Apple", "IBM", "Samsung" };
            double zapros5 = spisok.Where(x => x.time > 0).Skip(1).Average(x => x.time);


            Console.WriteLine(zapros5);

            List<Team> teams = new List<Team>()
{
    new Team { Name = "Бавария", Country ="Германия" },
    new Team { Name = "Барселона", Country ="Испания" }
};
            List<Player> players = new List<Player>()
{
    new Player {Name="Месси", Team="Барселона"},
    new Player {Name="Неймар", Team="Барселона"},
    new Player {Name="Роббен", Team="Бавария"}
};

            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                         select new { Name = pl.Name, Team = pl.Team, Country = t.Country };

            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");

            Console.Read();

        }
    }
}

