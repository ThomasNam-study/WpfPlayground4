namespace WpfPlayground4.Packet
{
	/************************************************************************/
	/* Command 성공 타입
	/************************************************************************/
	public enum PacketCommandType
	{
		/// <summary>
		/// 핑
		/// </summary>
		Ping = 0x01,

		/// <summary>
		/// 로그인
		/// </summary>
		Login = 0x10,

		/// <summary>
		/// 부서 정보 - 로그인시
		/// </summary>
		GetPostInfoForLogin = 0x11,

		/// <summary>
		/// 사용자 정보 - 로그인시
		/// </summary>
		GetUserInfoForLogin = 0x12,

		/// <summary>
		/// 준비 완료
		/// </summary>
		AllsReady = 0x13,

		/// <summary>
		/// 로그아웃
		/// </summary>
		Logout = 0x14,

		/// <summary>
		/// 사용자 상태가 바뀌었음
		/// </summary>
		NotifyUserState = 0x15,

		/// <summary>
		/// 사용자 상태 변경 요청
		/// </summary>
		ChangeUserState = 0x16,

		/// <summary>
		/// 대화명이 수정되었다.
		/// </summary>
		NotifyChatMent = 0x17,

		/// <summary>
		/// 대화명 수정을 요청한다.
		/// </summary>
		ChangeChatMent = 0x18,

		/// <summary>
		/// 푸쉬를 받음
		/// </summary>
		NotifyWebPush = 0x1B,

		/// <summary>
		/// 추가 데이터를 요청한다.
		/// </summary>
		RequestEtcDataCnt = 0x1C,
	
		/// <summary>
		/// 추가 데이터를 응답한다.
		/// </summary>
		NotifyEtcDataCnt = 0x1D,

		/// <summary>
		/// 사용자 이미지가 변경을 알린다.
		/// </summary>
		ChangeUserImage = 0x60,

		/// <summary>
		/// 사용자 이미지가 변경되었다.
		/// </summary>
		NotifyUserImage = 0x61,

		/// <summary>
		/// 채팅 메시지를 수신 받았다.
		/// </summary>
		RecvChatMessage = 0x21,

		/// <summary>
		/// 채팅 메시지를 발송한다.
		/// </summary>
		SendChatMessage = 0x22,

		/// <summary>
		/// 채팅 메시지 입력중 을 수신 받음
		/// </summary>
		RecvInputingChatMessage = 0x23,

		/// <summary>
		/// 채팅 메시지 입력중 을 전송
		/// </summary>
		SendInputingChatMessage = 0x24,

		/// <summary>
		/// 파일 전송을 요청 받았다.
		/// </summary>
		ResponseFileTrans = 0x30,

		/// <summary>
		/// 파일 전송을 요청한다.
		/// </summary>
		RequestFileTrans = 0x31,

		/// <summary>
		/// 파일 전송 수락을 요청 받았다.
		/// </summary>
		ResponseAcceptFileTrans = 0x32,

		/// <summary>
		/// 파일 전송 수락을 요청한다.
		/// </summary>
		RequestAcceptFileTrans = 0x33,

		/// <summary>
		/// 파일 전송 거부 응답
		/// </summary>
		ResponseRejectFileTrans = 0x34,

		/// <summary>
		/// 파일 전송 거부 요청
		/// </summary>
		RequestRejectFileTrans = 0x35,

		/// <summary>
		/// 파일 발송 취소 응답
		/// </summary>
		ResponseSendCancel = 0x36,

		/// <summary>
		/// 파일 발송 취소 요청
		/// </summary>
		RequestSendCancel = 0x37,

		/// <summary>
		/// 파일 수신 취소 응답
		/// </summary>
		ResponseCancelFileRecv = 0x38,

		/// <summary>
		/// 파일 수신 취소 요청
		/// </summary>
		RequestCancelFileRecv = 0x39,

		/// <summary>
		/// MFT 연결을 요청한다.
		/// </summary>
		RequestMFTConnect = 0x3A,

		/// <summary>
		/// FMT 연결을 요청 받았다.
		/// </summary>
		ResponseMFTConnect = 0x3B,

		/// <summary>
		/// MFT 서버에 연결한다.
		/// </summary>
		JoinMFTServer = 0x40,

		/// <summary>
		/// MFT 서버 연결되었고 준비 완료
		/// </summary>
		ReadyMFTServerJoin = 0x41,

		/// <summary>
		/// 파일 전송을 시작한다.
		/// </summary>
		FileSendStart = 0x200,

		/// <summary>
		/// 파일 전송중
		/// </summary>
		FileSending = 0x201,

		/// <summary>
		/// 파일 전송 완료
		/// </summary>
		FileSendEnd = 0x202,

		/// <summary>
		/// 파일 전송 취소
		/// </summary>
		FileSendCancel = 0x203,

		/// <summary>
		/// 사용자 그룹 추가를 요청한다.
		/// </summary>
		RequestAddUserGroup = 0x50,
	
		/// <summary>
		/// 사용자 그룹 추가를 응답받았다.
		/// </summary>
		NotifyAddUserGroup = 0x51,
	
		/// <summary>
		/// 사용자 그룹 수정를 요청한다.
		/// </summary>
		RequestModifyUserGroup = 0x52,
	
		/// <summary>
		/// 사용자 그룹 수정완료를 응답받았다.
		/// </summary>
		NotifyModifyUserGroup = 0x53,
	
		/// <summary>
		/// 사용자 그룹 삭제를 요청한다.
		/// </summary>
		RequestDeleteUserGroup = 0x54,
	
		/// <summary>
		/// 사용자 그룹 삭제완료를 응답받았다.
		/// </summary>
		NotifyDeleteUserGroup = 0x55,

		/// <summary>
		/// 사용자 그룹 XML 을 요청한다.
		/// </summary>
		RequestUserGroupXml = 0x56,
	
		/// <summary>
		/// 사용자 그룹 XML 을 응답받았다.
		/// </summary>
		NotifytUserGroupXml = 0x57,

		/// <summary>
		/// 사용자 그룹 구성원을 수정요청한다.
		/// </summary>
		RequestModifyUserGroupMember = 0x58,

		/// <summary>
		/// 사용자 그룹 구성원 수정 응답
		/// </summary>
		NotifyModifyUserGroupMember = 0x59,

		/// <summary>
		/// 채팅 메시지를 수신한다.
		/// </summary>
		ReceivedChatMessageV2 = 0x71,

		/// <summary>
		/// 채팅 메시지를 발송한다.
		/// </summary>
		SendChatMessageV2 = 0x72,

		/// <summary>
		/// 채팅 메시지 입력중 을 수신 받음
		/// </summary>
		ReceivedInputtingChatV2Message = 0x73,

		/// <summary>
		/// 채팅 메시지 입력중 을 전송
		/// </summary>
		SendInputtingChatV2Message = 0x74,

		/**
 * 채팅 메시지를 수신한다.
 */
		UpdateChatThread = 0x75,

		UpdateTargetChatView = 0x76,

		/// <summary>
		/// 출퇴근부 처리
		/// </summary>
		ProcessTimeCard = 0x80,

		/// <summary>
		/// 출퇴근 정보가 수정되었다.
		/// </summary>
		UpdateTimeCard = 0x81,

		/// <summary>
		/// 사용자 정보가 추가되었다.
		/// </summary>
		NotifyAddUserInfo = 0x91,

		/// <summary>
		/// 사용자 정보가 삭제되었다.
		/// </summary>
		NotifyDelUserInfo = 0x93,

		/// <summary>
		/// 회의실 생성을 요청한다.
		/// </summary>
		CreateMeetingRoom = 0x100,

		/// <summary>
		/// 회의실이 생성되었다.
		/// </summary>
		NotifyCreateMeetingRoom = 0x101,

		/// <summary>
		/// 회의실 퇴장을 요청한다.
		/// </summary>
		OutMeetingRoom = 0x102,
	
		/// <summary>
		/// 회의실을 퇴장했다.
		/// </summary>
		NotifyOutMeetingRoom = 0x103,

		/// <summary>
		/// 회의실 채팅 메시지를 수신했음
		/// </summary>
		MRRecvChatMessage = 0x104,
	
		/// <summary>
		/// 회의실 채팅 메시지를 보냈다.
		/// </summary>
		MRSendChatMessage = 0x105,
	
		/// <summary>
		/// 회의실 채팅 메시지 입력중을 수신받음
		/// </summary>
		MRRecvInputtingChatMessage = 0x106,
	
		/// <summary>
		/// 회의실 채팅 메시지 입력중을 보낸다.
		/// </summary>
		MRSendInputtingChatMessage = 0x107,

		/// <summary>
		/// 회의실에 초대한다.
		/// </summary>
		InviteMeetingRoom = 0x108,

		/// <summary>
		/// 회의실에 사용자가 참여했다.
		/// </summary>
		JoinMeetingRoom = 0x109,

		/// <summary>
		/// 회의실 퇴장 요청
		/// </summary>
		MRForceOut = 0x10A,
	
		/// <summary>
		/// 회의실 강제 퇴장 요청 받음
		/// </summary>
		MRRecvForceOut = 0x10B,
	}
}