using System.Xml;

namespace WpfPlayground4.Packet
{
	internal interface XmlPacket : BasePacket
	{
		XmlDocument getXmlDocument ();

		void setXmlDocument (XmlDocument xmlDocument);
	}
}
