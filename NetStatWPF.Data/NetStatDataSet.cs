using System;
using System.Collections.Generic;

namespace NetStatWPF.Data
{
    partial class NetStatDataSet
    {
        partial class IPv4StatisticsTableDataTable
        {
            public IPv4StatisticsTableRow AddIPv4StatisticsTableRow(NetStatDataRecordTableRow topRecord, NetStatDataRecord.IPv4StatisticsClass rowData)
            {
                var ipv4Record = AddIPv4StatisticsTableRow(topRecord,
                                    PacketsReceived: rowData.PacketsReceived,
                                    ReceivedHeaderErrors: rowData.ReceivedHeaderErrors,
                                    ReceivedAddressErrors: rowData.ReceivedAddressErrors,
                                    DatagramsForwarded: rowData.DatagramsForwarded,
                                    UnknownProtocolsReceived: rowData.UnknownProtocolsReceived,
                                    ReceivedPacketsDiscarded: rowData.ReceivedPacketsDiscarded,
                                    ReceivedPacketsDelivered: rowData.ReceivedPacketsDelivered,
                                    OutputRequests: rowData.OutputRequests,
                                    RoutingDiscards: rowData.RoutingDiscards,
                                    DiscardedOutputPackets: rowData.DiscardedOutputPackets,
                                    OutputPacketNoRoute: rowData.OutputPacketNoRoute,
                                    ReassemblyRequired: rowData.ReassemblyRequired,
                                    ReassemblySuccessful: rowData.ReassemblySuccessful,
                                    ReassemblyFailures: rowData.ReassemblyFailures,
                                    DatagramsSuccessfullyFragmented: rowData.DatagramsSuccessfullyFragmented,
                                    DatagramsFailingFragmentation: rowData.DatagramsFailingFragmentation,
                                    FragmentsCreated: rowData.FragmentsCreated);
                return ipv4Record;
            }
        }
        partial class IPv6StatisticsTableDataTable
        {
            public IPv6StatisticsTableRow AddIPv6StatisticsTableRow(NetStatDataRecordTableRow topRecord, NetStatDataRecord.IPv6StatisticsClass rowData)
            {
                var newRecord = AddIPv6StatisticsTableRow(topRecord,
                                    PacketsReceived: rowData.PacketsReceived,
                                    ReceivedHeaderErrors: rowData.ReceivedHeaderErrors,
                                    ReceivedAddressErrors: rowData.ReceivedAddressErrors,
                                    DatagramsForwarded: rowData.DatagramsForwarded,
                                    UnknownProtocolsReceived: rowData.UnknownProtocolsReceived,
                                    ReceivedPacketsDiscarded: rowData.ReceivedPacketsDiscarded,
                                    ReceivedPacketsDelivered: rowData.ReceivedPacketsDelivered,
                                    OutputRequests: rowData.OutputRequests,
                                    RoutingDiscards: rowData.RoutingDiscards,
                                    DiscardedOutputPackets: rowData.DiscardedOutputPackets,
                                    OutputPacketNoRoute: rowData.OutputPacketNoRoute,
                                    ReassemblyRequired: rowData.ReassemblyRequired,
                                    ReassemblySuccessful: rowData.ReassemblySuccessful,
                                    ReassemblyFailures: rowData.ReassemblyFailures,
                                    DatagramsSuccessfullyFragmented: rowData.DatagramsSuccessfullyFragmented,
                                    DatagramsFailingFragmentation: rowData.DatagramsFailingFragmentation,
                                    FragmentsCreated: rowData.FragmentsCreated);
                return newRecord;
            }
        }
        public IEnumerable<IPv4OverTime> IPv4ViewOverTime()
        {
            List<IPv4OverTime> retVal = new List<IPv4OverTime>()
            { new IPv4OverTime{ When = DateTime.Now, PacketsReceived = 18},
                new IPv4OverTime{When = DateTime.Now + TimeSpan.FromSeconds(77), PacketsReceived = 91}};
            return retVal;

        }
    }
    public class IPv4OverTime
    {
        public DateTime When;
        public Int64 PacketsReceived;
    }
}
