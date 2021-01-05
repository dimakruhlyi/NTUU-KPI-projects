using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ComServer
{
    [Guid("F53DD0D3-448C-43CD-B3C3-C115E6EFBAC5")]
    public interface IDataLayer
    {        
        DataTable GetTable(string ConStr, string Table);
        List<string> GetTables(string ConStr, string db);
    }
}
