using System;
using System.IO;
using System.Net;

namespace WpfPlayground4.Packet
{
	/************************************************************************/
	/* Key&Value Packet
	/************************************************************************/
	class BinaryPacketImp : CommonPacketImp, BinaryPacket
	{
		private byte[] datas = null;

		private int bufferSize = 0;
		
		public BinaryPacketImp ()
			: base ()
		{
			bufferSize = 0;
		}

		public BinaryPacketImp (PacketHeader packetHeader, MemoryStream ms)
			: base (packetHeader, ms)
		{
			byte[] buf = new byte[4];

			ms.Read (buf, 0, buf.Length);
			int dataSize = IPAddress.NetworkToHostOrder (BitConverter.ToInt32 (buf, 0));

			// 데이터를 읽어들인다.
			datas = new byte[dataSize];
			bufferSize = datas.Length;

			ms.Read (datas, 0, datas.Length);
		}

		protected override PacketDataType getDataType ()
		{
			return PacketDataType.Binary;
		}

		public byte[] GetDatas ()
		{
			return datas;
		}

		public void SetDatas (byte[] datas)
		{
			this.datas = datas;
			this.bufferSize = datas.Length;
		}

		public void SetDatas (byte[] datas, int bufferSize)
		{
			this.datas = datas;
			this.bufferSize = bufferSize;
		}

		public PacketHeader getPacketHeader ()
		{
			return packetHeader;
		}

		public int GetBufferSize ()
		{
			return bufferSize;
		}

		/************************************************************************/
		/* Packet 을 직렬화 한다.
		/************************************************************************/
		public byte[] serializePacket ()
		{
			byte[] headerPacket = packetHeader.serialize ();

			/************************************************************************/
			/* 해더 패킷 + 데이터 패킷
			 * 
			 * 데이터 패킷 처리
			/************************************************************************/

			// 데이터가 null 인 경우 0 배열을 넣어준다.
			if (datas == null)
				datas = new byte[0];

			// 전체 패킷
			byte[] totalPacket = new byte[headerPacket.Length + 4 + bufferSize];

			MemoryStream ms = new MemoryStream (totalPacket);

			// 해더 패킷을 쓴다.
			ms.Write (headerPacket, 0, headerPacket.Length);

			// 오더 체인지
			int noDataSize = IPAddress.HostToNetworkOrder (bufferSize);

			byte[] buf = BitConverter.GetBytes (noDataSize);
			ms.Write (buf, 0, buf.Length);

			// 키데이터를 메모리에 쓴다.
			ms.Write (datas, 0, bufferSize);

			return totalPacket;
		}
	}
}
