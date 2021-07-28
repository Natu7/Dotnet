using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjAdo.NetEg
{
    class ClientProcedure
    {
        static void Main()
        {
            DataAccessLayer spobject = new DataAccessLayer();
            Console.WriteLine("Enter the CustomeID");
            string cid = Console.ReadLine();
            spobject.CallCustOrders(cid);

        }
    }
}
