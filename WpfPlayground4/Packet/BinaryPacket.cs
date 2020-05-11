namespace WpfPlayground4.Packet
{
	internal interface BinaryPacket : BasePacket
	{
		byte[] GetDatas ();

		void SetDatas (byte[] datas);

		/// <summary>
		/// 데이터를 설정한다.
		/// </summary>
		/// <param name="datas"></param>
		/// <param name="bufferSize"></param>
		void SetDatas (byte[] datas, int bufferSize);

		/// <summary>
		/// 버퍼 사이즈를 리턴한다.
		/// </summary>
		/// <returns></returns>
		int GetBufferSize ();
	}
}
