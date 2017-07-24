using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeLocker.Library.Interface
{
    public interface IConfiguration
    {
        string Directory { get; }
        ISQLitePlatform PlatformDevice { get; }
    }
}
