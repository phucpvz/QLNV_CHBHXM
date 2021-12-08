using QLNV_CHBHXM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV_CHBHXM.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
            private set => instance = value;
        }

        public QLNV_CHBHXMEntities DB { get; set; }
        
        private DataProvider() 
        {
            DB = new QLNV_CHBHXMEntities();
        }

    }
}
