using System;

namespace BusinessLogic.DomainObjects
{
    public class RotaEntry
    {
        public int Id { get; set; }

        public Engineer Engineer { get; set; }

        public DateTime DateTime { get; set; }

        public int HoursInShift { get; set; }
    }
}
