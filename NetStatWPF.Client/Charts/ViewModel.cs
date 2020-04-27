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
        public double YAxisMin { get; private set; }
        public double YAxisMax { get; private set; }

        public ViewModel(NetStatDataSet rootData)
        {
            Data = rootData.IPv4ViewOverTime();
            var sortedDescending = 
            (from element in Data
                        orderby element.PacketsReceived descending
                        select element.PacketsReceived);

            (YAxisMin, YAxisMax) = (sortedDescending.First(), sortedDescending.Last());
            var delta = YAxisMax - YAxisMin;
            (YAxisMin, YAxisMax) = (YAxisMin - 0.1 * delta, YAxisMax + 0.1 * delta);
        }
    }
}