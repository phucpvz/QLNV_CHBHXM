using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV_CHBHXM.DTO
{
    public class PlanItem
    {
        private int priceID;
        private DateTime activateTime;

        public int PriceID { get => priceID; set => priceID = value; }
        public DateTime ActivateTime { get => activateTime; set => activateTime = value; }
    }
}
