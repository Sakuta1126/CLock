using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLock
{
    public class Alarm
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public Alarm()
        {
            {

            }
        }

    }
}
