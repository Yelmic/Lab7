using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab7
{
 
    public class Programms
    {
        static string name;
        public double begin;
        public double end;
        public int array;
        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value > 0)
                {
                    year = value;
                }
                else
                {
                    Console.WriteLine("Бред");
                }
            }
        }
        public string name_of_prog;
        internal List<Programms> Spis = new List<Programms>();
        void Add(Programms elem)
        {
            Spis.Add(elem);
            Console.WriteLine($"Мы добавили {elem}");
        }
        void Remove(Programms elem)
        {
            Spis.Remove(elem);
            Console.WriteLine($"Мы удалили {elem}");
        }
        void Output(List<Programms> elem)
        {
            foreach (object list_of_prog in elem)
            {
                Console.WriteLine(list_of_prog);
            }
        }

    }
    ///наследование исключений!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public class PrograExeption : InvalidCastException
    {
        public PrograExeption(string message) : base(message)
        {

        }
    }
    public class YearExeption : InvalidCastException
    {
        public YearExeption(string message) : base(message)
        {

        }
    }
    public class LimitExeption: InvalidCastException
    {
        public string Cause { get; set; }
        public string ExcName { get; set; }
        public string Date { get; set; }
        public LimitExeption(string name, string message)
        {
            Cause = message;
            ExcName = name;
            Date = DateTime.Now.ToLongTimeString();
        }
        public void Info()
        {
            Console.WriteLine($"Error Name: {ExcName}\nReason: {Cause}\nTime: {Date}");
        }
    }
    class Controller
    {
        public enum obj
        {
            Monday = 1,
            Tuesday,
            Whensday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        List<object> list = new List<object>();

        public static void Count()
        {
            Console.WriteLine($"Число рекламных роликов равно {Advertisment.count}");
        }
        public static void Search(List<Programms> spis)
        {
            for (int i = 0; i < spis.Count; i++)
            {
                if (spis[i].Year == 1999)
                {
                    Console.WriteLine(spis[i].name_of_prog);
                }

            }
        }
        public static void Time(double begin, double end)
        {
            double time = end - begin;
            if (time < 1)
            {
                Console.WriteLine((int)(time * 100) + " мин");
            }
            else if (time == 1)
            {
                Console.WriteLine(time + "час(ов)");
            }
            else if (time > 1)
            {
                Console.WriteLine(time);
            }

        }
    }
    class Printer
    {
        public string IAmPrinting(Object obj)
        {
            return obj.ToString();
        }
    }

    struct User
    {
        public string Name;
        public int Age;
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void Info()
        {
            if (Name == null)
            {
                throw new PrograExeption("введите корректное имя");  //Проверка!!!!
            }
            if (Age < 0)
            {
                throw new YearExeption("введите корректный возраст");  // Проверка!!!!!
            }
            Console.WriteLine($"Имя юзера {Name}, его возраст {Age}");
        }
    }
    interface IPerson
    {
        void Move();
    }
    abstract class Movement
    {
        public abstract void Move();
    }
    class Person : Movement, IPerson
    {
        public string name;
        public int age = 18;
        public override void Move()
        {
            Console.WriteLine("Человек идет");
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(name))
            {
                return "Имя не определено";
            }
            return "Продюссера зовут " + name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }


    interface ITVprogram
    {
        void Watch();
        void Show();
    }
    abstract class TVprogram
    {
        public int agelimit;
        public double time;
    }

    class Film : TVprogram, ITVprogram
    {
        public string name;
        public int year;
        public int limit = 16;
        public Film(string a)
        {
            if (a == " " || a == "" || a == null)
            {
                throw new PrograExeption("введите корректное имя ");//проверка!!!!
            }
            else
            {
                name = a;
            }
        }
        public void Watch()
        {
            if (agelimit > limit)
            {
                Console.WriteLine("Вам разрешено смотреть этот фильм");
            }
            else
            {
                Console.WriteLine("Вам рано еще смотреть этот фильм");
            }
        }
        public override string ToString()
        {
            return $"Возрастное ограничение на просмотр этого фильма {agelimit}";
        }
        public virtual void Show()
        {
            Console.WriteLine("\n\nНазвание: " + name + "\n" + "Год: " + year + "\n" + "Продолжительность: " + time + "\n" + "Возрастное ограничение: " + agelimit + "\n");
        }
    }

    class News : TVprogram, ITVprogram
    {
        public string theme;
        public string speackers;
        public int limit = 18;
        public News(int agelimit)
        {
            if(agelimit<=0)
            {
                throw new LimitExeption("Лимит", "Произошло исключение ");//проверка
            }
            limit = agelimit;
        }
        public override string ToString()
        {
            return $"Возрастное ограничение этих новостей {limit}";
        }
        public void Watch()
        {
            if (agelimit > limit)
            {
                Console.WriteLine("Вам разрешено смотреть новости");
            }
            else
            {
                Console.WriteLine("Вам рано смотреть");
            }
        }
        public virtual void Show()
        {
            Console.WriteLine("\n\nТема: " + theme + "\n" + "Ведущие: " + speackers + "\n" + "Продолжительность: " + time + "\n" + "Возрастное ограничение: " + agelimit + "\n");
        }
        public override bool Equals(object obj)
        {
            if (obj == null) 
            {
                Console.WriteLine("Что-то не так");
                return false;
            }

            obj = obj as News;
            if (obj != null)
            {
                Console.WriteLine("Это действительно новости");
                return true;
            }

            Console.WriteLine("Это не новости!");
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    class Filmic : TVprogram, ITVprogram
    {
        public string name;
        public int limit = 12;
        public Filmic(string name, double time, int agelimit)
        {
            this.name = name;
            this.agelimit = agelimit;
            this.time = time;
        }
        public override string ToString()
        {
            return $"Возрастное ограничение этого художественного фильма {limit}";
        }
        public void Watch()
        {
            if (agelimit > limit)
            {
                Console.WriteLine("Вам разрешено смотреть фильм");
            }
            else
            {
                Console.WriteLine("Вам рано смотреть");
            }
        }
        public virtual void Show()
        {
            Console.WriteLine("\n\nНазвание: " + name + "\n" + "Продолжительность: " + time + "\n" + "Возрастное ограничение: " + agelimit + "\n");
        }
    }

    class Cartoon : TVprogram, ITVprogram
    {
        public static string name;
        static int limit = 8;
        
        public override string ToString()
        {
            return $"Возрастное ограничение этого мультфильма {limit}";
        }
        public void Watch()
        {
            if (agelimit > limit)
            {
                Console.WriteLine("Вам можно смотреть мультфильм");
            }
            else
            {
                Console.WriteLine("Вам нельзя это смотреть");
            }
        }
        public virtual void Show()
        {
            Console.WriteLine("\n\nНазвание: " + name + "\n" + "Продолжительность: " + time + "\n" + "Возрастное ограничение: " + agelimit + "\n");
        }
    }
    class Advertisment : TVprogram, ITVprogram
    {
        public static int count;
        public double limit = 4.00;
        static Advertisment()
        {
            count = 0;
        }
        public Advertisment(int agelimit)
        {
            count++;
            this.agelimit = agelimit;
        }
        public override string ToString()
        {
            return $"Максимальное время рекламы {limit}";
        }
        public void Watch()
        {
            if (agelimit < limit)
            {
                Console.WriteLine("Достаточное количество");
            }
            else
            {
                Console.WriteLine("Чересчур рекламы");
            }
        }
        public virtual void Show()
        {
            Console.WriteLine("\n\nПродолжительность рекламы: " + agelimit + "\n");
        }
    }

    sealed class Director : Person, IPerson
    {
        public int Age;
        public string Name { get; set; }
        public string Surname { get; set; }
        public Director(string surname, string name, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public void Information()
        {
            Console.WriteLine("\n\nДанные режиссера: " + Surname + " " + Name + " " + Age);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) 
            {
                Console.WriteLine("Что-то не так");
                return false;
            }

            obj = obj as Director;
            if (obj != null)
            {
                Console.WriteLine("Это действительно режиссер.");
                return true;
            }

            Console.WriteLine("Это не режиссер!");
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            
            try
            {

                Cartoon.name = "wow";
                Debug.Assert(Cartoon.name == "wow", "Uncorrect values");//assert
                int a = 0;
                int b = 100 / a;//1 mistake
                Film movie = new Film(null);//2 mistake
                User person = new User("Pol", -9);
                person.Info();//3 mistake
                string[] stroka = new string[4];
                stroka[5] = "last"; // 4 mistake
                News newsss = new News(0);//5 mistake
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Деление на 0 "+ex.Message);
            }
            catch(PrograExeption ex)
            {
                Console.WriteLine(ex);
            }
            catch (YearExeption ex)
            {
                Console.WriteLine(ex);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch(LimitExeption ex)
            {
                ex.Info();
            }
            finally
            {
                Console.WriteLine("конец !");
            }
            Console.ReadKey();
        }
    }
}
