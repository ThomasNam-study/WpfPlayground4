using System.IO;

namespace WpfPlayground4.Packet
{
	abstract class CommonPacketImp
	{
		protected PacketHeader packetHeader;

		protected CommonPacketImp ()
		{
			packetHeader = new PacketHeader (getDataType ());
		}

		protected CommonPacketImp (PacketHeader packetHeader, MemoryStream packetStream)
		{
			this.packetHeader = packetHeader;
		}

		protected abstract PacketDataType getDataType ();
	}
}
