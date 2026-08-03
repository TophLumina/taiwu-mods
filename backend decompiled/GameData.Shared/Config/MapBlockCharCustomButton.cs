using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockCharCustomButton : ConfigData<MapBlockCharCustomButtonItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 交谈-使用秘闻
		/// </summary>
		public const short TalkBySecretInformation = 0;

		/// <summary>
		/// 交谈-赠送礼物
		/// </summary>
		public const short SendGift = 1;

		/// <summary>
		/// 比试-促织决斗
		/// </summary>
		public const short CriketCombat = 2;

		/// <summary>
		/// 比试-较艺比试
		/// </summary>
		public const short LifeSkillCombat = 3;

		/// <summary>
		/// 修习-请教功法
		/// </summary>
		public const short ConsultCombatSkill = 4;

		/// <summary>
		/// 修习-请教技艺
		/// </summary>
		public const short ConsultLifeSkill = 5;

		/// <summary>
		/// 修习-交换藏书
		/// </summary>
		public const short ExchangeSkillBook = 6;

		/// <summary>
		/// 亲近-获取支持
		/// </summary>
		public const short AskForSupport = 7;

		/// <summary>
		/// 自动高频选项
		/// </summary>
		public const short RecentOption = 8;

		/// <summary>
		/// NPC代办
		/// </summary>
		public const short NpcAgency = 9;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 交谈-使用秘闻
		/// </summary>
		public static MapBlockCharCustomButtonItem TalkBySecretInformation => Instance[(short)0];

		/// <summary>
		/// 交谈-赠送礼物
		/// </summary>
		public static MapBlockCharCustomButtonItem SendGift => Instance[(short)1];

		/// <summary>
		/// 比试-促织决斗
		/// </summary>
		public static MapBlockCharCustomButtonItem CriketCombat => Instance[(short)2];

		/// <summary>
		/// 比试-较艺比试
		/// </summary>
		public static MapBlockCharCustomButtonItem LifeSkillCombat => Instance[(short)3];

		/// <summary>
		/// 修习-请教功法
		/// </summary>
		public static MapBlockCharCustomButtonItem ConsultCombatSkill => Instance[(short)4];

		/// <summary>
		/// 修习-请教技艺
		/// </summary>
		public static MapBlockCharCustomButtonItem ConsultLifeSkill => Instance[(short)5];

		/// <summary>
		/// 修习-交换藏书
		/// </summary>
		public static MapBlockCharCustomButtonItem ExchangeSkillBook => Instance[(short)6];

		/// <summary>
		/// 亲近-获取支持
		/// </summary>
		public static MapBlockCharCustomButtonItem AskForSupport => Instance[(short)7];

		/// <summary>
		/// 自动高频选项
		/// </summary>
		public static MapBlockCharCustomButtonItem RecentOption => Instance[(short)8];

		/// <summary>
		/// NPC代办
		/// </summary>
		public static MapBlockCharCustomButtonItem NpcAgency => Instance[(short)9];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
