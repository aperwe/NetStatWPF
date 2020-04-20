using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetStatWPF.Data;

namespace NetStatWPF.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOutputParser()
        {
            var testData = " IPv4 StatisticsPackets Received = 18087305Received Header Errors = 0Received Address Errors = 35Datagrams Forwarded = 0Unknown Protocols Received = 0Received Packets Discarded = 6422Received Packets Delivered = 9185993Output Requests = 14917140Routing Discards = 0Discarded Output Packets = 276Output Packet No Route = 0Reassembly Required = 0Reassembly Successful = 0Reassembly Failures = 0Datagrams Successfully Fragmented = 0Datagrams Failing Fragmentation = 0Fragments Created = 0 IPv6 StatisticsPackets Received = 5847Received Header Errors = 0Received Address Errors = 116Datagrams Forwarded = 0Unknown Protocols Received = 0Received Packets Discarded = 3121Received Packets Delivered = 8173Output Requests = 7194Routing Discards = 0Discarded Output Packets = 0Output Packet No Route = 0Reassembly Required = 0Reassembly Successful = 0Reassembly Failures = 0Datagrams Successfully Fragmented = 0Datagrams Failing Fragmentation = 0Fragments Created = 0 ICMPv4 StatisticsReceived SentMessages 340 368Errors 0 0Destination Unreachable 340 368Time Exceeded 0 0Parameter Problems 0 0Source Quenches 0 0Redirects 0 0Echo Replies 0 0Echos 0 0Timestamps 0 0Timestamp Replies 0 0Address Masks 0 0Address Mask Replies 0 0Router Solicitations 0 0Router Advertisements 0 0 ICMPv6 StatisticsReceived SentMessages 214 21Errors 0 0Destination Unreachable 0 0Packet Too Big 0 0Time Exceeded 0 0Parameter Problems 0 0Echos 0 0Echo Replies 0 0MLD Queries 0 0MLD Reports 2 0MLD Dones 0 0Router Solicitations 0 9Router Advertisements 203 0Neighbor Solicitations 1 6Neighbor Advertisements 8 6Redirects 0 0Router Renumberings 0 0 TCP Statistics for IPv4Active Opens = 19796Passive Opens = 721Failed Connection Attempts = 14385Reset Connections = 863Current Connections = 37Segments Received = 9007968Segments Sent = 14458528Segments Retransmitted = 60816 TCP Statistics for IPv6Active Opens = 144Passive Opens = 19Failed Connection Attempts = 40Reset Connections = 0Current Connections = 0Segments Received = 2115Segments Sent = 1698Segments Retransmitted = 14 UDP Statistics for IPv4Datagrams Received = 287014No Ports = 6306Receive Errors = 6Datagrams Sent = 470359 UDP Statistics for IPv6Datagrams Received = 7511No Ports = 3121Receive Errors = 0Datagrams Sent = 5636 ";

            var record = NetStatOutputParser.ParseFromString(testData);

            #region IPv4 Statistics
            Assert.AreEqual(18087305, record.IPv4Statistics.PacketsReceived);
            Assert.AreEqual(6422, record.IPv4Statistics.ReceivedPacketsDiscarded);
            Assert.AreEqual(9185993, record.IPv4Statistics.ReceivedPacketsDelivered);
            Assert.AreEqual(14917140, record.IPv4Statistics.OutputRequests);
            Assert.AreEqual(276, record.IPv4Statistics.DiscardedOutputPackets);
            #endregion

            #region IPv6 Statistics
            //Rest of string from XML: "IPv6 StatisticsPackets Received = 5847Received Header Errors = 0Received Address Errors = 116Datagrams Forwarded = 0Unknown Protocols Received = 0Received Packets Discarded = 3121Received Packets Delivered = 8173Output Requests = 7194Routing Discards = 0Discarded Output Packets = 0Output Packet No Route = 0Reassembly Required = 0Reassembly Successful = 0Reassembly Failures = 0Datagrams Successfully Fragmented = 0Datagrams Failing Fragmentation = 0Fragments Created = 0 ICMPv4 StatisticsReceived SentMessages 340 368Errors 0 0Destination Unreachable 340 368Time Exceeded 0 0Parameter Problems 0 0Source Quenches 0 0Redirects 0 0Echo Replies 0 0Echos 0 0Timestamps 0 0Timestamp Replies 0 0Address Masks 0 0Address Mask Replies 0 0Router Solicitations 0 0Router Advertisements 0 0 ICMPv6 StatisticsReceived SentMessages 214 21Errors 0 0Destination Unreachable 0 0Packet Too Big 0 0Time Exceeded 0 0Parameter Problems 0 0Echos 0 0Echo Replies 0 0MLD Queries 0 0MLD Reports 2 0MLD Dones 0 0Router Solicitations 0 9Router Advertisements 203 0Neighbor Solicitations 1 6Neighbor Advertisements 8 6Redirects 0 0Router Renumberings 0 0 TCP Statistics for IPv4Active Opens = 19796Passive Opens = 721Failed Connection Attempts = 14385Reset Connections = 863Current Connections = 37Segments Received = 9007968Segments Sent = 14458528Segments Retransmitted = 60816 TCP Statistics for IPv6Active Opens = 144Passive Opens = 19Failed Connection Attempts = 40Reset Connections = 0Current Connections = 0Segments Received = 2115Segments Sent = 1698Segments Retransmitted = 14 UDP Statistics for IPv4Datagrams Received = 287014No Ports = 6306Receive Errors = 6Datagrams Sent = 470359 UDP Statistics for IPv6Datagrams Received = 7511No Ports = 3121Receive Errors = 0Datagrams Sent = 5636 ";
            Assert.AreEqual(5847, record.IPv6Statistics.PacketsReceived);
            Assert.AreEqual(116, record.IPv6Statistics.ReceivedAddressErrors);
            Assert.AreEqual(3121, record.IPv6Statistics.ReceivedPacketsDiscarded);
            Assert.AreEqual(8173, record.IPv6Statistics.ReceivedPacketsDelivered);
            Assert.AreEqual(7194, record.IPv6Statistics.OutputRequests);
            #endregion

            #region ICMPv4 Statistics
            //Rest of string from XML: "ICMPv4 StatisticsReceived SentMessages 340 368Errors 0 0Destination Unreachable 340 368Time Exceeded 0 0Parameter Problems 0 0Source Quenches 0 0Redirects 0 0Echo Replies 0 0Echos 0 0Timestamps 0 0Timestamp Replies 0 0Address Masks 0 0Address Mask Replies 0 0Router Solicitations 0 0Router Advertisements 0 0 ICMPv6 StatisticsReceived SentMessages 214 21Errors 0 0Destination Unreachable 0 0Packet Too Big 0 0Time Exceeded 0 0Parameter Problems 0 0Echos 0 0Echo Replies 0 0MLD Queries 0 0MLD Reports 2 0MLD Dones 0 0Router Solicitations 0 9Router Advertisements 203 0Neighbor Solicitations 1 6Neighbor Advertisements 8 6Redirects 0 0Router Renumberings 0 0 TCP Statistics for IPv4Active Opens = 19796Passive Opens = 721Failed Connection Attempts = 14385Reset Connections = 863Current Connections = 37Segments Received = 9007968Segments Sent = 14458528Segments Retransmitted = 60816 TCP Statistics for IPv6Active Opens = 144Passive Opens = 19Failed Connection Attempts = 40Reset Connections = 0Current Connections = 0Segments Received = 2115Segments Sent = 1698Segments Retransmitted = 14 UDP Statistics for IPv4Datagrams Received = 287014No Ports = 6306Receive Errors = 6Datagrams Sent = 470359 UDP Statistics for IPv6Datagrams Received = 7511No Ports = 3121Receive Errors = 0Datagrams Sent = 5636 ";
            Assert.AreEqual(340, record.ICMPv4Statistics.Received.Messages);
            Assert.AreEqual(368, record.ICMPv4Statistics.Sent.Messages);
            Assert.AreEqual(340, record.ICMPv4Statistics.Received.DestinationUnreachable);
            Assert.AreEqual(368, record.ICMPv4Statistics.Sent.DestinationUnreachable);
            #endregion

            #region ICMPv6 Statistics
            //Rest of string from XML: "ICMPv6 StatisticsReceived SentMessages 214 21Errors 0 0Destination Unreachable 0 0Packet Too Big 0 0Time Exceeded 0 0Parameter Problems 0 0Echos 0 0Echo Replies 0 0MLD Queries 0 0MLD Reports 2 0MLD Dones 0 0Router Solicitations 0 9Router Advertisements 203 0Neighbor Solicitations 1 6Neighbor Advertisements 8 6Redirects 0 0Router Renumberings 0 0 TCP Statistics for IPv4Active Opens = 19796Passive Opens = 721Failed Connection Attempts = 14385Reset Connections = 863Current Connections = 37Segments Received = 9007968Segments Sent = 14458528Segments Retransmitted = 60816 TCP Statistics for IPv6Active Opens = 144Passive Opens = 19Failed Connection Attempts = 40Reset Connections = 0Current Connections = 0Segments Received = 2115Segments Sent = 1698Segments Retransmitted = 14 UDP Statistics for IPv4Datagrams Received = 287014No Ports = 6306Receive Errors = 6Datagrams Sent = 470359 UDP Statistics for IPv6Datagrams Received = 7511No Ports = 3121Receive Errors = 0Datagrams Sent = 5636 ";
            Assert.AreEqual(214, record.ICMPv6Statistics.Received.Messages);
            Assert.AreEqual(21, record.ICMPv6Statistics.Sent.Messages);
            Assert.AreEqual(2, record.ICMPv6Statistics.Received.MLDReports);
            Assert.AreEqual(0, record.ICMPv6Statistics.Sent.MLDReports);
            Assert.AreEqual(0, record.ICMPv6Statistics.Received.RouterSolicitations);
            Assert.AreEqual(9, record.ICMPv6Statistics.Sent.RouterSolicitations);
            Assert.AreEqual(203, record.ICMPv6Statistics.Received.RouterAdvertisements);
            Assert.AreEqual(0, record.ICMPv6Statistics.Sent.RouterAdvertisements);
            Assert.AreEqual(1, record.ICMPv6Statistics.Received.NeighborSolicitations);
            Assert.AreEqual(6, record.ICMPv6Statistics.Sent.NeighborSolicitations);
            Assert.AreEqual(8, record.ICMPv6Statistics.Received.NeighborAdvertisements);
            Assert.AreEqual(6, record.ICMPv6Statistics.Sent.NeighborAdvertisements);
            #endregion

            #region TCP Statistics for IPv4
            //Rest of string from XML: "TCP Statistics for IPv4Active Opens = 19796Passive Opens = 721Failed Connection Attempts = 14385Reset Connections = 863Current Connections = 37Segments Received = 9007968Segments Sent = 14458528Segments Retransmitted = 60816 TCP Statistics for IPv6Active Opens = 144Passive Opens = 19Failed Connection Attempts = 40Reset Connections = 0Current Connections = 0Segments Received = 2115Segments Sent = 1698Segments Retransmitted = 14 UDP Statistics for IPv4Datagrams Received = 287014No Ports = 6306Receive Errors = 6Datagrams Sent = 470359 UDP Statistics for IPv6Datagrams Received = 7511No Ports = 3121Receive Errors = 0Datagrams Sent = 5636 ";
            Assert.AreEqual(19796, record.TCPStatisticsIPv4.ActiveOpens);
            Assert.AreEqual(721, record.TCPStatisticsIPv4.PassiveOpens);
            Assert.AreEqual(14385, record.TCPStatisticsIPv4.FailedConnectionAttempts);
            Assert.AreEqual(863, record.TCPStatisticsIPv4.ResetConnections);
            Assert.AreEqual(37, record.TCPStatisticsIPv4.CurrentConnections);
            Assert.AreEqual(9007968, record.TCPStatisticsIPv4.SegmentsReceived);
            Assert.AreEqual(14458528, record.TCPStatisticsIPv4.SegmentsSent);
            Assert.AreEqual(60816, record.TCPStatisticsIPv4.SegmentsRetransmitted);
            Assert.AreEqual(144, record.TCPStatisticsIPv6.ActiveOpens);
            Assert.AreEqual(19, record.TCPStatisticsIPv6.PassiveOpens);
            Assert.AreEqual(40, record.TCPStatisticsIPv6.FailedConnectionAttempts);
            Assert.AreEqual(2115, record.TCPStatisticsIPv6.SegmentsReceived);
            Assert.AreEqual(1698, record.TCPStatisticsIPv6.SegmentsSent);
            Assert.AreEqual(14, record.TCPStatisticsIPv6.SegmentsRetransmitted);
            #endregion

            #region UDP Statistics for IPv4
            //Rest of string from XML: "UDP Statistics for IPv4Datagrams Received = 287014No Ports = 6306Receive Errors = 6Datagrams Sent = 470359 UDP Statistics for IPv6Datagrams Received = 7511No Ports = 3121Receive Errors = 0Datagrams Sent = 5636 ";
            Assert.AreEqual(287014, record.UDPStatisticsIPv4.DatagramsReceived);
            Assert.AreEqual(6306, record.UDPStatisticsIPv4.NoPorts);
            Assert.AreEqual(6, record.UDPStatisticsIPv4.ReceiveErrors);
            Assert.AreEqual(470359, record.UDPStatisticsIPv4.DatagramsSent);
            #endregion

            #region UDP Statistics for IPv6
            //Rest of string from XML: "UDP Statistics for IPv6Datagrams Received = 7511No Ports = 3121Receive Errors = 0Datagrams Sent = 5636 ";
            Assert.AreEqual(7511, record.UDPStatisticsIPv6.DatagramsReceived);
            Assert.AreEqual(3121, record.UDPStatisticsIPv6.NoPorts);
            Assert.AreEqual(5636, record.UDPStatisticsIPv6.DatagramsSent);
            #endregion
        }
    }
}