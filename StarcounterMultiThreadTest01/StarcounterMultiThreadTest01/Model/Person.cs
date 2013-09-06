using System;
using System.Collections.Generic;
using Starcounter;
using System.Text;
using System.Threading.Tasks;

namespace StarcounterMultiThreadTest01.Model
{
    [Database]
    public class Person
    {
        public long Id;
        public string FirstName;
        public string LastName;
        public string FullName { get { return FirstName + " " + LastName; } }

    }
}
