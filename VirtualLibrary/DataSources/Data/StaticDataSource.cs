using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary.DataSources.Data
{
    class StaticDataSource
    {
        public static LocalDataSource _dataSource = new LocalDataSource();
        public static string currUser;
    }
}
