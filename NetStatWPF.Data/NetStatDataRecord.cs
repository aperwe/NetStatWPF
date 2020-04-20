using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStatWPF.Data
{
    public class NetStatDataRecord
    {
        public NetStatDataRecord()
        {
            IPv4Statistics = new IPv4StatisticsClass();
            IPv6Statistics = new IPv6StatisticsClass();
            ICMPv4Statistics = new ICMPv4StatisticsClass();
            ICMPv6Statistics = new ICMPv6StatisticsClass();
            TCPStatisticsIPv4 = new TCPStatisticsIPv4Class();
            TCPStatisticsIPv6 = new TCPStatisticsIPv6Class();
            UDPStatisticsIPv4 = new UDPStatisticsClass();
            UDPStatisticsIPv6 = new UDPStatisticsClass();
        }
        public class IPv4StatisticsClass
        {
            public Int64 PacketsReceived { get; set; }
            public Int64 ReceivedHeaderErrors { get; set; }
            public Int64 ReceivedAddressErrors { get; set; }
            public Int64 DatagramsForwarded { get; set; }
            public Int64 UnknownProtocolsReceived { get; set; }
            public Int64 ReceivedPacketsDiscarded { get; set; }
            public Int64 ReceivedPacketsDelivered { get; set; }
            public Int64 OutputRequests { get; set; }
            public Int64 RoutingDiscards { get; set; }
            public Int64 DiscardedOutputPackets { get; set; }
            public Int64 OutputPacketNoRoute { get; set; }
            public Int64 ReassemblyRequired { get; set; }
            public Int64 ReassemblySuccessful { get; set; }
            public Int64 ReassemblyFailures { get; set; }
            public Int64 DatagramsSuccessfullyFragmented { get; set; }
            public Int64 DatagramsFailingFragmentation { get; set; }
            public Int64 FragmentsCreated { get; set; }
        }

        public class IPv6StatisticsClass
        {
            public Int64 PacketsReceived { get; set; }
            public Int64 ReceivedHeaderErrors { get; set; }
            public Int64 ReceivedAddressErrors { get; set; }
            public Int64 DatagramsForwarded { get; set; }
            public Int64 UnknownProtocolsReceived { get; set; }
            public Int64 ReceivedPacketsDiscarded { get; set; }
            public Int64 ReceivedPacketsDelivered { get; set; }
            public Int64 OutputRequests { get; set; }
            public Int64 RoutingDiscards { get; set; }
            public Int64 DiscardedOutputPackets { get; set; }
            public Int64 OutputPacketNoRoute { get; set; }
            public Int64 ReassemblyRequired { get; set; }
            public Int64 ReassemblySuccessful { get; set; }
            public Int64 ReassemblyFailures { get; set; }
            public Int64 DatagramsSuccessfullyFragmented { get; set; }
            public Int64 DatagramsFailingFragmentation { get; set; }
            public Int64 FragmentsCreated { get; set; }
        }
        public class ICMPv4StatisticsClass
        {
            internal ICMPv4StatisticsClass()
            {
                Received = new ICMPv4StatisticsRecSent();
                Sent = new ICMPv4StatisticsRecSent();
            }
            public ICMPv4StatisticsRecSent Received { get; internal set; }
            public ICMPv4StatisticsRecSent Sent { get; internal set; }

            public class ICMPv4StatisticsRecSent
            {
                public Int64 Messages { get; set; }
                public Int64 Errors { get; set; }
                public Int64 DestinationUnreachable { get; set; }
                public Int64 TimeExceeded { get; set; }
                public Int64 ParameterProblems { get; set; }
                public Int64 SourceQuenches { get; set; }
                public Int64 Redirects { get; set; }
                public Int64 EchoReplies { get; set; }
                public Int64 Echos { get; set; }
                public Int64 Timestamps { get; set; }
                public Int64 TimestampReplies { get; set; }
                public Int64 AddressMasks { get; set; }
                public Int64 AddressMaskReplies { get; set; }
                public Int64 RouterSolicitations { get; set; }
                public Int64 RouterAdvertisements { get; set; }
            }
        }
        public class ICMPv6StatisticsClass
        {
            internal ICMPv6StatisticsClass()
            {
                Received = new ICMPv6StatisticsRecSent();
                Sent = new ICMPv6StatisticsRecSent();
            }
            public ICMPv6StatisticsRecSent Received { get; internal set; }
            public ICMPv6StatisticsRecSent Sent { get; internal set; }
            public class ICMPv6StatisticsRecSent : ICMPv4StatisticsClass.ICMPv4StatisticsRecSent
            {
                public Int64 PacketTooBig { get;  set; }
                public Int64 MLDQueries { get;  set; }
                public Int64 MLDReports { get;  set; }
                public Int64 MLDDones { get;  set; }
                public Int64 NeighborSolicitations { get;  set; }
                public Int64 NeighborAdvertisements { get;  set; }
                public Int64 RouterRenumberings { get;  set; }
            }
        }
        public class TCPStatisticsIPv4Class
        {
            public TCPStatisticsIPv4Class()
            {
            }

            public Int64 ActiveOpens { get;  set; }
            public Int64 PassiveOpens { get;  set; }
            public Int64 FailedConnectionAttempts { get;  set; }
            public Int64 ResetConnections { get;  set; }
            public Int64 CurrentConnections { get;  set; }
            public Int64 SegmentsReceived { get;  set; }
            public Int64 SegmentsSent { get;  set; }
            public Int64 SegmentsRetransmitted { get;  set; }
        }
        public class TCPStatisticsIPv6Class : TCPStatisticsIPv4Class
        {
            public TCPStatisticsIPv6Class()
            {
            }

        }
        public class UDPStatisticsClass
        {
            public Int64 DatagramsReceived { get;  set; }
            public Int64 NoPorts { get;  set; }
            public Int64 ReceiveErrors { get;  set; }
            public Int64 DatagramsSent { get;  set; }
        }

        public IPv4StatisticsClass IPv4Statistics { get; set; }
        public IPv6StatisticsClass IPv6Statistics { get; set; }
        public ICMPv4StatisticsClass ICMPv4Statistics { get; set; }
        public ICMPv6StatisticsClass ICMPv6Statistics { get; set; }
        public TCPStatisticsIPv4Class TCPStatisticsIPv4 { get; set; }
        public TCPStatisticsIPv6Class TCPStatisticsIPv6 { get; set; }
        public UDPStatisticsClass UDPStatisticsIPv4 { get; set; }
        public UDPStatisticsClass UDPStatisticsIPv6 { get; set; }
    }
}
