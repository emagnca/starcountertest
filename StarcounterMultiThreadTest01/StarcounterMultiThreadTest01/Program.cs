using System;
using Starcounter;
using System.Text;
using System.Threading.Tasks;
using StarcounterMultiThreadTest01.Model;

namespace StarcounterMultiThreadTest01
{
    class Program
    {
        public const long maxId = 1000;
        public const int winId = 10;
        public const int numberofthreads = 4;
        static void Main()
        {
            DbSession dbs = new DbSession();
            byte schedulerCount = Db.Environment.SchedulerCount;
            
            byte schedId = 0;
            if (schedulerCount > numberofthreads)
            {
                if (schedId < numberofthreads)
                {
                    dbs.RunAsync(DoWork2, schedId);
                    schedId++;
                }
                if (schedId < numberofthreads)
                {
                    dbs.RunAsync(DoWork3, schedId);
                    schedId++;
                }
                if (schedId < numberofthreads)
                {
                    dbs.RunAsync(DoWork1, schedId);
                    schedId++;
                }
                if (schedId < numberofthreads)
                {
                    dbs.RunAsync(DoWork4, schedId);
                    schedId++;
                }
                if (schedId < numberofthreads)
                {
                    dbs.RunAsync(DoWork5, schedId);
                    schedId++;
                }
            }

        }
        static void DoWork1()
        {
            Console.WriteLine("worker thread: insert data into table Person.");
            DbAdministration DbAdmin = new DbAdministration();

            DbAdmin.DbDelete();

            for (long i = 0; i < maxId; i++)
            {
                DbAdmin.DbInsert(i, "Albert", "Einstein");
            }

            Console.WriteLine("worker thread: terminating gracefully after fill the table Person");

        }

        static void DoWork2()
        {
            Handle.GET("/list2", () =>
            {
                DbAdministration DbAdmin = new DbAdministration();
                string text = "";
                string header;
                header = "<!DOCTYPE html><link rel='stylesheet' href='quote.css'/><title>Hello</title>";
                long rem = 0;
                long uplim = Math.DivRem(maxId, winId, out rem);
                for (long id = 0; id < uplim; id++)
                {
                    Person p = DbAdmin.DbGetPerson(id);
                    //Person p = Db.SQL("SELECT P FROM Person P WHERE P.Id=?", id).First;
                    text += "Id: " + id + " Person: " + p.FullName + "<BR>";
                }
                return header + text;
            });
        }

        static void DoWork3()
        {
            Handle.GET("/list3", () =>
            {
                DbAdministration DbAdmin = new DbAdministration();
                string text = "";
                string header;
                header = "<!DOCTYPE html><link rel='stylesheet' href='quote.css'/><title>Hello</title>";
                long rem = 0;
                long startlim = Math.DivRem(maxId, winId, out rem);
                long endlim = startlim + startlim;
                for (long id = startlim; id < endlim; id++)
                {
                    Person p = DbAdmin.DbGetPerson(id);
                    //Person p = Db.SQL("SELECT P FROM Person P WHERE P.Id=?", id).First;
                    text += "Id: " + id + " Person: " + p.FullName + "<BR>";
                }
                return header + text;
            });
        }

        static void DoWork4()
        {
            Handle.GET("/list4", () =>
            {
                DbAdministration DbAdmin = new DbAdministration();
                string text = "";
                string header;
                header = "<!DOCTYPE html><link rel='stylesheet' href='quote.css'/><title>Hello</title>";
                long rem = 0;
                long startlim = Math.DivRem(maxId, winId, out rem);
                startlim = startlim + startlim;
                long endlim = startlim + startlim + startlim;
                for (long id = startlim; id < endlim; id++)
                {
                    Person p = DbAdmin.DbGetPerson(id);
                    //Person p = Db.SQL("SELECT P FROM Person P WHERE P.Id=?", id).First;
                    text += "Id: " + id + " Person: " + p.FullName + "<BR>";
                }
                return header + text;
            });
        }

        static void DoWork5()
        {
            Handle.GET("/list5", () =>
            {
                DbAdministration DbAdmin = new DbAdministration();
                string text = "";
                string header;
                header = "<!DOCTYPE html><link rel='stylesheet' href='quote.css'/><title>Hello</title>";
                long rem = 0;
                long startlim = Math.DivRem(maxId, winId, out rem);
                startlim = startlim + startlim + startlim;
                long endlim = startlim + startlim + startlim + startlim;
                for (long id = startlim; id < endlim; id++)
                {
                    Person p = DbAdmin.DbGetPerson(id);
                    text += "Id: " + id + " Person: " + p.FullName + "<BR>";
                }
                return header + text;
            });
        }

    }

}