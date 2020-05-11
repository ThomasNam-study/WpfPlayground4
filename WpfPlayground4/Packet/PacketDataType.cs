namespace WpfPlayground4.Packet
{
	/************************************************************************/
	/* Packet 데이터 타입
	/************************************************************************/
	public enum PacketDataType
	{
		// None Packet
		None = 0x00,

		// Key & Value
		KeyValue = 0x01,

		// XML
		Xml = 0x02,

		// Binary
		Binary = 0x03
	}
}