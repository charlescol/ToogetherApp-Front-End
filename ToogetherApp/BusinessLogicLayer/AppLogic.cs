using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BusinessLogicLayer
{
    public static class AppLogic
    {
        public static DataLayer.SQLLite.DatabaseHandler Connection { get; private set; }
        public static PrivateUser User { get; set; }
        public static void Initialize(DataLayer.SQLLite.ISQLLite db)
        {
            Connection = new DataLayer.SQLLite.DatabaseHandler(db);
        }
    }
}
