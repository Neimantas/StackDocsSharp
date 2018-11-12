using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDocsSharp.Services
{
    public interface IDataBase
    {
        SQLiteConnection GetConnection();
    }
}
