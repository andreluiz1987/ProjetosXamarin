using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeLocker.Library.Repository.Table
{
    class UserTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        public DateTime LockDate { get; set; }

        public string LockDateCurrent { get; set; }

        [MaxLength(256)]
        public string FileName { get; set; }
    }
}
