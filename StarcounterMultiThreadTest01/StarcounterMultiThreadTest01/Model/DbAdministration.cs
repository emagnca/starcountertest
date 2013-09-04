using System;
using System.Collections.Generic;
using Starcounter;
using System.Text;
using System.Threading.Tasks;

namespace StarcounterMultiThreadTest01.Model
{
    class DbAdministration
    {
        public void DbInsert(long i, string firstname, string lastname)
        {
            Db.Transaction(() =>
            {
                new Person() { Id = i, FirstName = firstname, LastName = lastname };
            });
        }

        public Person DbGetPerson(long persId)
        {
            Person p = null;
            Db.Transaction(() =>
            {
                p = (Person)Db.SQL("SELECT P FROM Person P WHERE P.Id=?", persId).First;
            });
            return p;
        }

        public void DbDelete()
        {
            Db.Transaction(delegate()
            {
                foreach (Person p in Db.SQL("SELECT p FROM Person p"))
                    p.Delete();

            });
        }

    }
}
