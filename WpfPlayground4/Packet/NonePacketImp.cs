using System;
using System.IO;
using System.Net;

namespace WpfPlayground4.Packet
{
	/************************************************************************/
	/* None Packet 구현
	/************************************************************************/
	class NonePacketImp : CommonPacketImp, NonePacket
	{
		public NonePacketImp () : base ()
		{
		}

		public NonePacketImp (PacketHeader packetHeader, MemoryStream ms)
			: base (packetHeader, ms)
		{
			byte [] buf = new byte[4];

			ms.Read (buf, 0, buf.Length);

			// dataSize 가 없기 때문에 변수에 담아놓지 않는다.
			// int dataSize = IPAddress.NetworkToHostOrder (BitConverter.ToInt32 (buf, 0));
			IPAddress.NetworkToHostOrder (BitConverter.ToInt32 (buf, 0));
		}

		protected override PacketDataType getDataType ()
		{
			return PacketDataType.None;
		}

		public PacketHeader getPacketHeader ()
		{
			return packetHeader;
		}

		/************************************************************************/
		/* Packet 을 직렬화 한다.
		/************************************************************************/
		public byte[] serializePacket ()
		{
			byte [] headerPacket = packetHeader.serialize ();

			/************************************************************************/
			/* 해더 패킷 + 데이터 패킷
			 * 
			 * 데이터 패킷이 없기 때문에 따로 처리하지 않는다.
			/************************************************************************/
			byte[] totalPacket = new byte[headerPacket.Length + 4];

			MemoryStream ms = new MemoryStream (totalPacket);

			// 해더 패킷을 쓴다.
			ms.Write (headerPacket, 0, headerPacket.Length);

			// 오더 체인지
			int noDataSize = IPAddress.HostToNetworkOrder(0);

			byte [] buf = BitConverter.GetBytes (noDataSize);
			ms.Write (buf, 0, buf.Length);

			return totalPacket;
		}
	}
}
