using System;
using System.Collections.Generic;
using System.Text;

namespace VBM._app_utils
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
