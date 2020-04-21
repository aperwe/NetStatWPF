using NetStatWPF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetStatWPF.Data.NetStatDataSet;

namespace NetStatWPF.Client.Charts
{
    public class ViewModel
    {
        public IEnumerable<IPv4OverTime> Data { get; set; }
        public ViewModel(NetStatDataSet rootData)
        {
            //Data = rootData.IPv4ViewOverTime();

            Data = new List<IPv4OverTime> { new IPv4OverTime { When = DateTime.Now, PacketsReceived = 17 }, new IPv4OverTime { When = DateTime.Now + TimeSpan.FromSeconds(7), PacketsReceived = 88 } };
        }
    }
}