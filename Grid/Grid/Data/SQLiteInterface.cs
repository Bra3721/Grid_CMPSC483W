using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grid483W.Data
{
    public interface ISQLiteInterface
    {
        SQLiteConnection GetConnection();
    }
}
