using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using WpfPlayground4.Packet;

namespace PureMessengerEngine.Packet
{
	class XmlPacketImp : CommonPacketImp, XmlPacket
	{
		XmlDocument xmlDocument;

		public XmlPacketImp () : base ()
		{
		}

		public XmlPacketImp (PacketHeader packetHeader, MemoryStream ms) 
			: base (packetHeader, ms)
		{
			byte[] buf = new byte[4];

			ms.Read (buf, 0, buf.Length);
			int dataSize = IPAddress.NetworkToHostOrder (BitConverter.ToInt32 (buf, 0));

			// 데이터를 읽어들인다.
			byte[] xmlBuf = new byte[dataSize];
			ms.Read (xmlBuf, 0, dataSize);

			String xmlValue = Encoding.UTF8.GetString (xmlBuf);

			xmlDocument = new XmlDocument ();

			try
			{
				xmlDocument.LoadXml (xmlValue);
			}
			catch (Exception ex)
			{
				Console.WriteLine (ex);
			}
			
		}

		protected override PacketDataType getDataType ()
		{
			return PacketDataType.Xml;
		}

		public XmlDocument getXmlDocument ()
		{
			return xmlDocument;
		}

		public void setXmlDocument (XmlDocument xmlDocument)
		{
			this.xmlDocument = xmlDocument;
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
			StringWriter xmlStr = new StringWriter ();

			xmlDocument.Save (xmlStr);

			byte[] headerPacket = packetHeader.serialize ();

			/************************************************************************/
			/* 해더 패킷 + 데이터 패킷
			 * 
			 * 데이터 패킷 처리
			/************************************************************************/

			// 직렬화된 스트링을 byte 배열로 바꾼다.
			byte[] xmlBuf = Encoding.UTF8.GetBytes (xmlStr.ToString ());

			// 전체 패킷
			byte[] totalPacket = new byte[headerPacket.Length + 4 + xmlBuf.Length];

			MemoryStream ms = new MemoryStream (totalPacket);

			// 해더 패킷을 쓴다.
			ms.Write (headerPacket, 0, headerPacket.Length);

			// 오더 체인지
			int noDataSize = IPAddress.HostToNetworkOrder (xmlBuf.Length);

			byte[] buf = BitConverter.GetBytes (noDataSize);
			ms.Write (buf, 0, buf.Length);

			// 키데이터를 메모리에 쓴다.
			ms.Write (xmlBuf, 0, xmlBuf.Length);

			return totalPacket;
		}
	}
}
