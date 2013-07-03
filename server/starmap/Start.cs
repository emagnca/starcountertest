using System;
using Starcounter;
using starmap.Model;

class Start
{
    static void Main()
    {
        Db.Transaction(() =>
        {
            var o = new TrackingObject() { FirstName = "Albert", LastName = "Einstein" };
            new Quote() { Person = albert, Text = "Make things as simple as possible, but not simpler" };
        });
    }
}
