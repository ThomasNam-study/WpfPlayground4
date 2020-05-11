using PureMessengerEngine.Packet;

namespace WpfPlayground4.Packet
{
	public interface BasePacket
	{
		PacketHeader getPacketHeader ();

		byte[] serializePacket ();
	}
}
