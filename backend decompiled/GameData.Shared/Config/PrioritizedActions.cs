using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class PrioritizedActions : ConfigData<PrioritizedActionsItem, short>
{
	public static class DefKey
	{
		public const short JoinSect = 0;

		public const short Appointment = 1;

		public const short ProtectFriendOrFamily = 2;

		public const short RescueFriendOrFamily = 3;

		public const short Mourn = 4;

		public const short VisitFriendOrFamily = 5;

		public const short FindTreasure = 6;

		public const short FindSpecialMaterial = 7;

		public const short TakeRevenge = 8;

		public const short ContestForLegendaryBook = 9;

		public const short AdoptInfant = 10;

		public const short SectStoryYuanshanToFightDemon = 11;

		public const short SectStoryShixiangToFightEnemy = 12;

		public const short SectStoryEmeiToFightComrade = 13;

		public const short DejaVu = 14;

		public const short GuardTreasury = 15;

		public const short SectStoryBaihuaToCureManic = 16;

		public const short HuntFugitive = 17;

		public const short EscapeFromPrison = 18;

		public const short SeekAsylum = 19;

		public const short EscortPrisoner = 20;

		public const short VillagerRoleArrangement = 21;

		public const short HuntTaiwu = 22;
	}

	public static class DefValue
	{
		public static PrioritizedActionsItem JoinSect => Instance[(short)0];

		public static PrioritizedActionsItem Appointment => Instance[(short)1];

		public static PrioritizedActionsItem ProtectFriendOrFamily => Instance[(short)2];

		public static PrioritizedActionsItem RescueFriendOrFamily => Instance[(short)3];

		public static PrioritizedActionsItem Mourn => Instance[(short)4];

		public static PrioritizedActionsItem VisitFriendOrFamily => Instance[(short)5];

		public static PrioritizedActionsItem FindTreasure => Instance[(short)6];

		public static PrioritizedActionsItem FindSpecialMaterial => Instance[(short)7];

		public static PrioritizedActionsItem TakeRevenge => Instance[(short)8];

		public static PrioritizedActionsItem ContestForLegendaryBook => Instance[(short)9];

		public static PrioritizedActionsItem AdoptInfant => Instance[(short)10];

		public static PrioritizedActionsItem SectStoryYuanshanToFightDemon => Instance[(short)11];

		public static PrioritizedActionsItem SectStoryShixiangToFightEnemy => Instance[(short)12];

		public static PrioritizedActionsItem SectStoryEmeiToFightComrade => Instance[(short)13];

		public static PrioritizedActionsItem DejaVu => Instance[(short)14];

		public static PrioritizedActionsItem GuardTreasury => Instance[(short)15];

		public static PrioritizedActionsItem SectStoryBaihuaToCureManic => Instance[(short)16];

		public static PrioritizedActionsItem HuntFugitive => Instance[(short)17];

		public static PrioritizedActionsItem EscapeFromPrison => Instance[(short)18];

		public static PrioritizedActionsItem SeekAsylum => Instance[(short)19];

		public static PrioritizedActionsItem EscortPrisoner => Instance[(short)20];

		public static PrioritizedActionsItem VillagerRoleArrangement => Instance[(short)21];

		public static PrioritizedActionsItem HuntTaiwu => Instance[(short)22];
	}

	public static PrioritizedActions Instance = new PrioritizedActions();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "OrgTemplateId", "RefuseAppointment", "TemplateId", "ActType", "FailToCreateActionCoolDown", "ActionCoolDown", "BasePriority" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new PrioritizedActionsItem(0, EPrioritizedActionsActType.Normal, 6, 6, 12, 0, new short[5] { 90, 90, 90, 90, 90 }, isPrevActionInterrupted: false, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, 0, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_0")));
		_dataArray.Add(new PrioritizedActionsItem(1, EPrioritizedActionsActType.Normal, 0, 0, 0, 0, new short[5] { 80, 50, 80, 20, 60 }, isPrevActionInterrupted: true, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_1")));
		_dataArray.Add(new PrioritizedActionsItem(2, EPrioritizedActionsActType.Normal, 3, 3, 4, 0, new short[5] { 60, 60, 40, 60, 10 }, isPrevActionInterrupted: false, isAdultOnly: true, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, 25, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5] { 60, 70, 40, 50, 80 }, LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_2")));
		_dataArray.Add(new PrioritizedActionsItem(3, EPrioritizedActionsActType.Normal, 3, 3, 4, 0, new short[5] { 70, 70, 50, 70, 20 }, isPrevActionInterrupted: false, isAdultOnly: true, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, 25, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5] { 60, 70, 40, 50, 80 }, LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_3")));
		_dataArray.Add(new PrioritizedActionsItem(4, EPrioritizedActionsActType.Normal, 12, 12, 3, 0, new short[5] { 30, 40, 10, 0, 30 }, isPrevActionInterrupted: true, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, 50, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5] { 60, 80, 40, 50, 70 }, LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_4")));
		_dataArray.Add(new PrioritizedActionsItem(5, EPrioritizedActionsActType.Normal, 6, 6, 3, 0, new short[5] { 20, 30, 30, 10, 0 }, isPrevActionInterrupted: true, isAdultOnly: false, isNonLeader: true, isNonTaiwuTeammate: true, isNonMonk: false, 0, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5] { 50, 80, 40, 30, 60 }, LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_5")));
		_dataArray.Add(new PrioritizedActionsItem(6, EPrioritizedActionsActType.Normal, 3, 3, 6, 0, new short[5] { 0, 10, 60, 30, 70 }, isPrevActionInterrupted: true, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, 0, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5] { 30, 60, 70, 50, 80 }, LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_6")));
		_dataArray.Add(new PrioritizedActionsItem(7, EPrioritizedActionsActType.Normal, 0, 0, 6, 0, new short[5] { 10, 20, 70, 40, 80 }, isPrevActionInterrupted: true, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5] { 30, 60, 70, 50, 80 }, LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_7")));
		_dataArray.Add(new PrioritizedActionsItem(8, EPrioritizedActionsActType.Normal, 6, 6, 6, 0, new short[5] { 40, 0, 0, 80, 50 }, isPrevActionInterrupted: false, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, 50, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5] { 30, 60, 50, 70, 80 }, LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_8")));
		_dataArray.Add(new PrioritizedActionsItem(9, EPrioritizedActionsActType.Normal, 36, 36, 24, 0, new short[5] { 100, 100, 100, 100, 100 }, isPrevActionInterrupted: false, isAdultOnly: true, isNonLeader: true, isNonTaiwuTeammate: true, isNonMonk: false, -1, new sbyte[15]
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5] { 50, 60, 40, 70, 80 }, LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_9")));
		_dataArray.Add(new PrioritizedActionsItem(10, EPrioritizedActionsActType.Normal, 0, 0, 3, 0, new short[5] { 50, 80, 20, 50, 40 }, isPrevActionInterrupted: false, isAdultOnly: true, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: true, 50, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_10")));
		_dataArray.Add(new PrioritizedActionsItem(11, EPrioritizedActionsActType.SectStory, 0, 0, -1, 90, new short[5] { 100, 100, 100, 100, 100 }, isPrevActionInterrupted: false, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, new sbyte[1] { 5 }, new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_11")));
		_dataArray.Add(new PrioritizedActionsItem(12, EPrioritizedActionsActType.SectStory, 0, 0, -1, 90, new short[5] { 100, 100, 100, 100, 100 }, isPrevActionInterrupted: false, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, new sbyte[1] { 6 }, new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_12")));
		_dataArray.Add(new PrioritizedActionsItem(13, EPrioritizedActionsActType.SectStory, 0, 0, -1, 90, new short[5] { 100, 100, 100, 100, 100 }, isPrevActionInterrupted: false, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, new sbyte[1] { 2 }, new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_13")));
		_dataArray.Add(new PrioritizedActionsItem(14, EPrioritizedActionsActType.DreamBack, 0, 0, -1, 99, new short[5] { 100, 100, 100, 100, 100 }, isPrevActionInterrupted: false, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_14")));
		_dataArray.Add(new PrioritizedActionsItem(15, EPrioritizedActionsActType.Normal, 0, 0, -1, 100, new short[5] { 100, 80, 60, 30, 40 }, isPrevActionInterrupted: true, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_15")));
		_dataArray.Add(new PrioritizedActionsItem(16, EPrioritizedActionsActType.Normal, 3, 3, 6, 0, new short[5] { 80, 90, 70, 60, 50 }, isPrevActionInterrupted: false, isAdultOnly: false, isNonLeader: true, isNonTaiwuTeammate: true, isNonMonk: false, 0, new sbyte[1] { 3 }, new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_16")));
		_dataArray.Add(new PrioritizedActionsItem(17, EPrioritizedActionsActType.Normal, 0, 0, -1, 0, new short[5] { 80, 50, 30, 60, 20 }, isPrevActionInterrupted: false, isAdultOnly: true, isNonLeader: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_17")));
		_dataArray.Add(new PrioritizedActionsItem(18, EPrioritizedActionsActType.Normal, 0, 0, -1, 100, new short[5] { 100, 100, 100, 100, 100 }, isPrevActionInterrupted: true, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5] { 30, 50, 40, 70, 80 }, LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_18")));
		_dataArray.Add(new PrioritizedActionsItem(19, EPrioritizedActionsActType.Normal, 0, 0, -1, 101, new short[5] { 100, 100, 100, 100, 100 }, isPrevActionInterrupted: true, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5] { 30, 50, 40, 70, 80 }, LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_19")));
		_dataArray.Add(new PrioritizedActionsItem(20, EPrioritizedActionsActType.Normal, 0, 0, -1, 100, new short[5] { 100, 100, 100, 100, 100 }, isPrevActionInterrupted: true, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_20")));
		_dataArray.Add(new PrioritizedActionsItem(21, EPrioritizedActionsActType.Normal, 0, 0, -1, 100, new short[5] { 100, 100, 100, 100, 100 }, isPrevActionInterrupted: true, isAdultOnly: false, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, new sbyte[0], new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_21")));
		_dataArray.Add(new PrioritizedActionsItem(22, EPrioritizedActionsActType.Normal, 0, 3, -1, 0, new short[5] { 80, 50, 30, 60, 20 }, isPrevActionInterrupted: false, isAdultOnly: true, isNonLeader: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, new sbyte[1] { 13 }, new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new sbyte[5], LocalStringManager.GetConfig("PrioritizedActions_language", "RefuseAppointment_22")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PrioritizedActionsItem>(23);
		CreateItems0();
	}
}
