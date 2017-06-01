using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace WindowsFormsApplication1
{
    class _global_var
    {
         public static string connection_string = "server=localhost;uid=user1;" + "pwd=user1;database=atestat";
       //  public static string connection_string = "server=192.168.1.113;uid=user_A019" + "pwd=192.168.1.119;database=db_A019";
       //  public static string connection_string = "server=192.168.1.143;Port=9999;uid=user1;" + "pwd=user1;database=atestat";


        #region select list
        public static List<string> select_list = new List<string>
            {
              "SELECT * FROM users",
              "SELECT * FROM achizitii",
              "SELECT * FROM client",
              "SELECT * FROM statie_acumulare",
              "SELECT * FROM salariu",
              "SELECT * FROM angajati"
            };
        public static string users = select_list[0];
        public static string achizitii = select_list[1];
        public static string clienti = select_list[2];
        public static string acumulatori = select_list[3];
        public static string salarii = select_list[4];
        public static string angajati = select_list[5];

        #endregion
    }
}
