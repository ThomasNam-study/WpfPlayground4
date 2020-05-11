using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WpfPlayground4.Packet
{
	/************************************************************************/
	/* Key&Value Packet
	/************************************************************************/
	class KeyValuePacketImp : CommonPacketImp, KeyValuePacket
	{
		// DataTable 를 저장한다.
		Dictionary<string, string> dataTable = new Dictionary<string, string> ();

		public KeyValuePacketImp ()
		{

		}

		public KeyValuePacketImp (PacketHeader packetHeader, MemoryStream ms)
			: base (packetHeader, ms)
		{
			var buf = new byte[4];

			ms.Read (buf, 0, buf.Length);
			var dataSize = IPAddress.NetworkToHostOrder (BitConverter.ToInt32 (buf, 0));

			// 데이터를 읽어들인다.
			var keyValueBuf = new byte[dataSize];
			ms.Read (keyValueBuf, 0, keyValueBuf.Length);

			var keyValue = Encoding.UTF8.GetString (keyValueBuf);

			string key, value;
			int start = 0, pos = 0;

			while (pos != -1)
			{
				pos = keyValue.IndexOf ("=", start);

				if (pos == -1)
					continue;

				key = keyValue.Substring (start, pos - start);
				start = pos + 1;

				pos = keyValue.IndexOf ("&", start);

				value = pos == -1 ? keyValue.Substring (start, keyValue.Length - start) : keyValue.Substring (start, pos - start);
				value = value.Trim ();

				start = pos + 1;

				if (key.Length <= 0) continue;

				dataTable.Add (key, decodeValue (value));
				key = "";
			}
		}

		protected override PacketDataType getDataType ()
		{
			return PacketDataType.KeyValue;
		}

		public Dictionary<string, string> GetTable ()
		{
			return dataTable;
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
			var headerPacket = packetHeader.serialize ();

			/************************************************************************/
			/* 해더 패킷 + 데이터 패킷
			 * 
			 * 데이터 패킷 처리
			/************************************************************************/

			// 데이터테이블을 시리얼라이징 한다.
			var sb = new StringBuilder ();

			var enumKey = dataTable.GetEnumerator ();

			while (enumKey.MoveNext ())
			{
				if (sb.Length > 0)
					sb.Append ("&");

				sb.Append (enumKey.Current.Key);
				sb.Append ("=");
				sb.Append (encodeValue (enumKey.Current.Value));
			}

			// 직렬화된 스트링을 byte 배열로 바꾼다.
			var keyValueBuf = Encoding.UTF8.GetBytes (sb.ToString ());

			// 전체 패킷
			var totalPacket = new byte[headerPacket.Length + 4 + keyValueBuf.Length];

			var ms = new MemoryStream (totalPacket);

			// 해더 패킷을 쓴다.
			ms.Write (headerPacket, 0, headerPacket.Length);

			// 오더 체인지
			var noDataSize = IPAddress.HostToNetworkOrder (keyValueBuf.Length);

			var buf = BitConverter.GetBytes (noDataSize);
			ms.Write (buf, 0, buf.Length);

			// 키데이터를 메모리에 쓴다.
			ms.Write (keyValueBuf, 0, keyValueBuf.Length);

			return totalPacket;
		}

		private string encodeValue (string data)
		{
			if (data == null)
				return "";

			data = data.Replace ("&", ";;GWAMP;;");
			data = data.Replace ("=", ";;GWEQ;;");

			return data;
		}

		private string decodeValue (string data)
		{
			data = data.Replace (";;GWAMP;;", "&");
			data = data.Replace (";;GWEQ;;", "=");

			return data;
		}
	}
}
