using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV_CHBHXM.DTO
{
    [Serializable]
    public class PlanData
    {
        private List<PlanItem> prices;
        public List<PlanItem> Prices { get => prices; set => prices = value; }
    }
}
