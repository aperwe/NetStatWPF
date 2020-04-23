using System;
using System.Collections.Generic;
using System.Linq;

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
            var pipa = from mainTableRow in MainTable.Cast<MainTableRow>()
                       join netStatDataRecordTableRow in NetStatDataRecordTable.Cast<NetStatDataRecordTableRow>() on mainTableRow.ID equals netStatDataRecordTableRow.ID
                       join ipv4StatisticsTableRow in IPv4StatisticsTable.Cast<IPv4StatisticsTableRow>() on netStatDataRecordTableRow.ID equals ipv4StatisticsTableRow.ID
                       select new IPv4OverTime() { ID = mainTableRow.ID, When = mainTableRow.TimeStamp, PacketsReceived = ipv4StatisticsTableRow.PacketsReceived };
            return pipa;
        }
    }
    public class IPv4OverTime
    {
        public Int64 ID { get; set; }
        public DateTime When { get; set; }
        public Int64 PacketsReceived { get; set; }
    }
}