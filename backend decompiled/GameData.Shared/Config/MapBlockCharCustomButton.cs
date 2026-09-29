using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockCharCustomButton : ConfigData<MapBlockCharCustomButtonItem, short>
{
	public static class DefKey
	{
		public const short TalkBySecretInformation = 0;

		public const short SendGift = 1;

		public const short CriketCombat = 2;

		public const short LifeSkillCombat = 3;

		public const short ConsultCombatSkill = 4;

		public const short ConsultLifeSkill = 5;

		public const short ExchangeSkillBook = 6;

		public const short AskForSupport = 7;

		public const short RecentOption = 8;

		public const short NpcAgency = 9;
	}

	public static class DefValue
	{
		public static MapBlockCharCustomButtonItem TalkBySecretInformation => Instance[(short)0];

		public static MapBlockCharCustomButtonItem SendGift => Instance[(short)1];

		public static MapBlockCharCustomButtonItem CriketCombat => Instance[(short)2];

		public static MapBlockCharCustomButtonItem LifeSkillCombat => Instance[(short)3];

		public static MapBlockCharCustomButtonItem ConsultCombatSkill => Instance[(short)4];

		public static MapBlockCharCustomButtonItem ConsultLifeSkill => Instance[(short)5];

		public static MapBlockCharCustomButtonItem ExchangeSkillBook => Instance[(short)6];

		public static MapBlockCharCustomButtonItem AskForSupport => Instance[(short)7];

		public static MapBlockCharCustomButtonItem RecentOption => Instance[(short)8];

		public static MapBlockCharCustomButtonItem NpcAgency => Instance[(short)9];
	}

	public static MapBlockCharCustomButton Instance = new MapBlockCharCustomButton();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "InteractionEventOption", "TemplateId" };

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
		_dataArray.Add(new MapBlockCharCustomButtonItem(0, LocalStringManager.GetConfig("MapBlockCharCustomButton_language", "Name_0"), EMapBlockCharCustomButtonLogicType.Interact, EMapBlockCharCustomButtonDisplayGroup.Interact, new List<short> { 1 }));
		_dataArray.Add(new MapBlockCharCustomButtonItem(1, LocalStringManager.GetConfig("MapBlockCharCustomButton_language", "Name_1"), EMapBlockCharCustomButtonLogicType.Interact, EMapBlockCharCustomButtonDisplayGroup.Interact, new List<short> { 6 }));
		_dataArray.Add(new MapBlockCharCustomButtonItem(2, LocalStringManager.GetConfig("MapBlockCharCustomButton_language", "Name_2"), EMapBlockCharCustomButtonLogicType.Interact, EMapBlockCharCustomButtonDisplayGroup.Interact, new List<short> { 7 }));
		_dataArray.Add(new MapBlockCharCustomButtonItem(3, LocalStringManager.GetConfig("MapBlockCharCustomButton_language", "Name_3"), EMapBlockCharCustomButtonLogicType.Interact, EMapBlockCharCustomButtonDisplayGroup.Interact, new List<short> { 8 }));
		_dataArray.Add(new MapBlockCharCustomButtonItem(4, LocalStringManager.GetConfig("MapBlockCharCustomButton_language", "Name_4"), EMapBlockCharCustomButtonLogicType.Interact, EMapBlockCharCustomButtonDisplayGroup.Interact, new List<short> { 14, 15, 16 }));
		_dataArray.Add(new MapBlockCharCustomButtonItem(5, LocalStringManager.GetConfig("MapBlockCharCustomButton_language", "Name_5"), EMapBlockCharCustomButtonLogicType.Interact, EMapBlockCharCustomButtonDisplayGroup.Interact, new List<short> { 11, 12, 13 }));
		_dataArray.Add(new MapBlockCharCustomButtonItem(6, LocalStringManager.GetConfig("MapBlockCharCustomButton_language", "Name_6"), EMapBlockCharCustomButtonLogicType.Interact, EMapBlockCharCustomButtonDisplayGroup.Interact, new List<short> { 21 }));
		_dataArray.Add(new MapBlockCharCustomButtonItem(7, LocalStringManager.GetConfig("MapBlockCharCustomButton_language", "Name_7"), EMapBlockCharCustomButtonLogicType.Interact, EMapBlockCharCustomButtonDisplayGroup.Interact, new List<short> { 25 }));
		_dataArray.Add(new MapBlockCharCustomButtonItem(8, LocalStringManager.GetConfig("MapBlockCharCustomButton_language", "Name_8"), EMapBlockCharCustomButtonLogicType.Special, EMapBlockCharCustomButtonDisplayGroup.TopLevel, new List<short>()));
		_dataArray.Add(new MapBlockCharCustomButtonItem(9, LocalStringManager.GetConfig("MapBlockCharCustomButton_language", "Name_9"), EMapBlockCharCustomButtonLogicType.Special, EMapBlockCharCustomButtonDisplayGroup.TopLevel, new List<short>()));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MapBlockCharCustomButtonItem>(10);
		CreateItems0();
	}
}
