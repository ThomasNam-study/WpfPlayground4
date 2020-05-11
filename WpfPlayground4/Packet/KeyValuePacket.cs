using System.Collections.Generic;

namespace WpfPlayground4.Packet
{
	public interface KeyValuePacket : BasePacket
	{
		Dictionary<string, string> GetTable ();
	}
}
