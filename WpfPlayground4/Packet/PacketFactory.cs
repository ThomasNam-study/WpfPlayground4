using System.IO;
using PureMessengerEngine.Packet;

namespace WpfPlayground4.Packet
{
	internal class PacketFactory
	{
		internal static BasePacket makePacket (MemoryStream ms)
		{
			PacketHeader packetHeader = new PacketHeader (ms);

			BasePacket basePacket = null;

			switch (packetHeader.DataType)
			{
				case PacketDataType.None :
					basePacket = new NonePacketImp (packetHeader, ms);
					break;

				case PacketDataType.KeyValue:
					basePacket = new KeyValuePacketImp (packetHeader, ms);
					break;

				case PacketDataType.Binary:
					basePacket = new BinaryPacketImp (packetHeader, ms);
					break;

				case PacketDataType.Xml:
					basePacket = new XmlPacketImp (packetHeader, ms);
					break;
			}

			return basePacket;
		}

		/************************************************************************/
		/* 비어있는 패킷을 생성한다.
		/************************************************************************/
		public static BasePacket createPacket (PacketDataType dataType)
		{
			BasePacket basePacket = null;

			switch (dataType)
			{
				case PacketDataType.None :
					basePacket = new NonePacketImp ();
					break;

				case PacketDataType.KeyValue:
					basePacket = new KeyValuePacketImp ();
					break;

				case PacketDataType.Binary:
					basePacket = new BinaryPacketImp ();
					break;

				case PacketDataType.Xml:
					basePacket = new XmlPacketImp ();
					break;
			}

			return basePacket;
		}
	}
}
