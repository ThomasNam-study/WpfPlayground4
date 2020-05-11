using System;
using System.IO;
using System.Net;
using System.Text;

namespace WpfPlayground4.Packet
{
	/************************************************************************/
	/* 패킷의 해더를 구성한다.
	/************************************************************************/
	public class PacketHeader
	{
		// 기본 해더 사이즈 26 Byte
		private const int headerSize = 26;

		// 기본 해더
		private byte baseHeader;

		// 암호화 여부
		private byte encryt;

		// 요청 아이디
		public string RequestID { get; set; }

		// 명령 커멘트
		private PacketCommandType command;
		public PacketCommandType Command
		{
			get {return command;}
			set {command = value;}
		}

		// 데이터 타입
		private readonly PacketDataType dataType;
		public PacketDataType DataType
		{
			get {return dataType;}
		}

		// 성공 여부
		public PacketSuccessType Success { get; set; }

		private PacketHeader ()
		{
			baseHeader = 0x10;

			// 일단 암호화는 구축하지 않는다.
			encryt = 0x00;
		}

		public PacketHeader (PacketDataType dataType) 
			: this ()
		{
			this.dataType = dataType;
			Success = PacketSuccessType.None;
		}

		/************************************************************************/
		/* 데이터를 파싱한다.
		/************************************************************************/
		public PacketHeader (MemoryStream ms)
			: this ()
		{
			// 기본 해더
			baseHeader = (byte) ms.ReadByte ();

			// 인크립스
			encryt = (byte) ms.ReadByte ();

			// RequestID
			var requestIDBytes = new byte[20];
			ms.Read (requestIDBytes, 0, requestIDBytes.Length);

			RequestID = Encoding.UTF8.GetString (requestIDBytes);

			var commandBuf = new byte[2];

			ms.Read (commandBuf, 0, commandBuf.Length);

			var ohCommand = BitConverter.ToInt16 (commandBuf, 0);

			ohCommand = IPAddress.NetworkToHostOrder (ohCommand);

			// 커멘드 처리
			command = (PacketCommandType) ohCommand;

			// 데이터 타입 처리
			
			dataType = (PacketDataType) ms.ReadByte ();

			// 성공 여부 처리
			Success = (PacketSuccessType) ms.ReadByte ();
		}

		/************************************************************************/
		/* 직렬화 한다.
		/************************************************************************/
		public byte[] serialize ()
		{
			// 기본 해더 버퍼를 생성한다.
			byte [] headerBuf = new byte [headerSize];

			MemoryStream ms = new MemoryStream (headerBuf);

			ms.WriteByte (baseHeader);
			ms.WriteByte (encryt);

			byte[] buf = Encoding.UTF8.GetBytes (RequestID);

			ms.Write (buf, 0, buf.Length);

			for (int i = buf.Length; i < 20; i++)
				ms.WriteByte (0x00);

			short commandVal = (short) command;
			commandVal = IPAddress.HostToNetworkOrder (commandVal);

			buf = BitConverter.GetBytes (commandVal);

			ms.Write (buf, 0, buf.Length);
			ms.WriteByte ((byte) dataType);

			ms.WriteByte ((byte) Success);

			return headerBuf;
		}

		// 기본 요청 아이디를 생성한다.
		public void makeDefaultRequestID ()
		{
			DateTime dt = DateTime.Now;

			// yyyyMMddHHmmssfff 17
			RequestID = "REQ" + dt.ToString ("yyyyMMddHHmmssfff");
		}
	}
}
