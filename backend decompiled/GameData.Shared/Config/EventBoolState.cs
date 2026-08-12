using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventBoolState : ConfigData<EventBoolStateItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 打乱选项顺序
		/// </summary>
		public const short ShuffleOption = 0;

		/// <summary>
		/// 左侧角色使用代称
		/// </summary>
		public const short MainRoleUseAlternativeName = 1;

		/// <summary>
		/// 右侧角色使用代称
		/// </summary>
		public const short TargetRoleUseAlternativeName = 2;

		/// <summary>
		/// 不显示左侧角色的立绘
		/// </summary>
		public const short NotShowMainRole = 3;

		/// <summary>
		/// 不显示右侧角色的立绘
		/// </summary>
		public const short NotShowTargetRole = 4;

		/// <summary>
		/// 禁止查看左侧人物
		/// </summary>
		public const short ForbidViewSelf = 5;

		/// <summary>
		/// 禁止查看右侧人物
		/// </summary>
		public const short ForbidViewCharacter = 6;

		/// <summary>
		/// 隐藏左侧人物好感度
		/// </summary>
		public const short HideLeftFavorability = 7;

		/// <summary>
		/// 隐藏右侧人物好感度
		/// </summary>
		public const short HideFavorability = 8;

		/// <summary>
		/// 左侧角色是否显示脸红表现
		/// </summary>
		public const short MainRoleShowBlush = 9;

		/// <summary>
		/// 右侧角色是否显示脸红表现
		/// </summary>
		public const short TargetRoleShowBlush = 10;

		/// <summary>
		/// 左侧角色显示伤病tips按钮
		/// </summary>
		public const short LeftRoleShowInjuryInfo = 11;

		/// <summary>
		/// 右侧角色显示伤病tips按钮
		/// </summary>
		public const short RightRoleShowInjuryInfo = 12;

		/// <summary>
		/// 右侧人物设置为剪影
		/// </summary>
		public const short RightCharacterShadow = 13;

		/// <summary>
		/// 禁止显示右侧精纯
		/// </summary>
		public const short RightForbiddenConsummateLevel = 14;

		/// <summary>
		/// 左侧显示好感变化特效
		/// </summary>
		public const short LeftForbidShowFavorChangeEffect = 15;

		/// <summary>
		/// 右侧显示好感变化特效
		/// </summary>
		public const short RightForbidShowFavorChangeEffect = 16;

		/// <summary>
		/// 左侧演员显示婚服1
		/// </summary>
		public const short LeftActorShowMarriageLook1 = 17;

		/// <summary>
		/// 左侧演员显示婚服2
		/// </summary>
		public const short LeftActorShowMarriageLook2 = 18;

		/// <summary>
		/// 右侧演员显示婚服1
		/// </summary>
		public const short RightActorShowMarriageLook1 = 19;

		/// <summary>
		/// 右侧演员显示婚服2
		/// </summary>
		public const short RightActorShowMarriageLook2 = 20;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 打乱选项顺序
		/// </summary>
		public static EventBoolStateItem ShuffleOption => Instance[(short)0];

		/// <summary>
		/// 左侧角色使用代称
		/// </summary>
		public static EventBoolStateItem MainRoleUseAlternativeName => Instance[(short)1];

		/// <summary>
		/// 右侧角色使用代称
		/// </summary>
		public static EventBoolStateItem TargetRoleUseAlternativeName => Instance[(short)2];

		/// <summary>
		/// 不显示左侧角色的立绘
		/// </summary>
		public static EventBoolStateItem NotShowMainRole => Instance[(short)3];

		/// <summary>
		/// 不显示右侧角色的立绘
		/// </summary>
		public static EventBoolStateItem NotShowTargetRole => Instance[(short)4];

		/// <summary>
		/// 禁止查看左侧人物
		/// </summary>
		public static EventBoolStateItem ForbidViewSelf => Instance[(short)5];

		/// <summary>
		/// 禁止查看右侧人物
		/// </summary>
		public static EventBoolStateItem ForbidViewCharacter => Instance[(short)6];

		/// <summary>
		/// 隐藏左侧人物好感度
		/// </summary>
		public static EventBoolStateItem HideLeftFavorability => Instance[(short)7];

		/// <summary>
		/// 隐藏右侧人物好感度
		/// </summary>
		public static EventBoolStateItem HideFavorability => Instance[(short)8];

		/// <summary>
		/// 左侧角色是否显示脸红表现
		/// </summary>
		public static EventBoolStateItem MainRoleShowBlush => Instance[(short)9];

		/// <summary>
		/// 右侧角色是否显示脸红表现
		/// </summary>
		public static EventBoolStateItem TargetRoleShowBlush => Instance[(short)10];

		/// <summary>
		/// 左侧角色显示伤病tips按钮
		/// </summary>
		public static EventBoolStateItem LeftRoleShowInjuryInfo => Instance[(short)11];

		/// <summary>
		/// 右侧角色显示伤病tips按钮
		/// </summary>
		public static EventBoolStateItem RightRoleShowInjuryInfo => Instance[(short)12];

		/// <summary>
		/// 右侧人物设置为剪影
		/// </summary>
		public static EventBoolStateItem RightCharacterShadow => Instance[(short)13];

		/// <summary>
		/// 禁止显示右侧精纯
		/// </summary>
		public static EventBoolStateItem RightForbiddenConsummateLevel => Instance[(short)14];

		/// <summary>
		/// 左侧显示好感变化特效
		/// </summary>
		public static EventBoolStateItem LeftForbidShowFavorChangeEffect => Instance[(short)15];

		/// <summary>
		/// 右侧显示好感变化特效
		/// </summary>
		public static EventBoolStateItem RightForbidShowFavorChangeEffect => Instance[(short)16];

		/// <summary>
		/// 左侧演员显示婚服1
		/// </summary>
		public static EventBoolStateItem LeftActorShowMarriageLook1 => Instance[(short)17];

		/// <summary>
		/// 左侧演员显示婚服2
		/// </summary>
		public static EventBoolStateItem LeftActorShowMarriageLook2 => Instance[(short)18];

		/// <summary>
		/// 右侧演员显示婚服1
		/// </summary>
		public static EventBoolStateItem RightActorShowMarriageLook1 => Instance[(short)19];

		/// <summary>
		/// 右侧演员显示婚服2
		/// </summary>
		public static EventBoolStateItem RightActorShowMarriageLook2 => Instance[(short)20];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EventBoolState Instance = new EventBoolState();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId" };

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
		_dataArray.Add(new EventBoolStateItem(0, LocalStringManager.GetConfig("EventBoolState_language", "Name_0"), removeBeforeNextEvent: true));
		_dataArray.Add(new EventBoolStateItem(1, LocalStringManager.GetConfig("EventBoolState_language", "Name_1"), removeBeforeNextEvent: true));
		_dataArray.Add(new EventBoolStateItem(2, LocalStringManager.GetConfig("EventBoolState_language", "Name_2"), removeBeforeNextEvent: true));
		_dataArray.Add(new EventBoolStateItem(3, LocalStringManager.GetConfig("EventBoolState_language", "Name_3"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(4, LocalStringManager.GetConfig("EventBoolState_language", "Name_4"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(5, LocalStringManager.GetConfig("EventBoolState_language", "Name_5"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(6, LocalStringManager.GetConfig("EventBoolState_language", "Name_6"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(7, LocalStringManager.GetConfig("EventBoolState_language", "Name_7"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(8, LocalStringManager.GetConfig("EventBoolState_language", "Name_8"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(9, LocalStringManager.GetConfig("EventBoolState_language", "Name_9"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(10, LocalStringManager.GetConfig("EventBoolState_language", "Name_10"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(11, LocalStringManager.GetConfig("EventBoolState_language", "Name_11"), removeBeforeNextEvent: true));
		_dataArray.Add(new EventBoolStateItem(12, LocalStringManager.GetConfig("EventBoolState_language", "Name_12"), removeBeforeNextEvent: true));
		_dataArray.Add(new EventBoolStateItem(13, LocalStringManager.GetConfig("EventBoolState_language", "Name_13"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(14, LocalStringManager.GetConfig("EventBoolState_language", "Name_14"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(15, LocalStringManager.GetConfig("EventBoolState_language", "Name_15"), removeBeforeNextEvent: true));
		_dataArray.Add(new EventBoolStateItem(16, LocalStringManager.GetConfig("EventBoolState_language", "Name_16"), removeBeforeNextEvent: true));
		_dataArray.Add(new EventBoolStateItem(17, LocalStringManager.GetConfig("EventBoolState_language", "Name_17"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(18, LocalStringManager.GetConfig("EventBoolState_language", "Name_18"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(19, LocalStringManager.GetConfig("EventBoolState_language", "Name_19"), removeBeforeNextEvent: false));
		_dataArray.Add(new EventBoolStateItem(20, LocalStringManager.GetConfig("EventBoolState_language", "Name_20"), removeBeforeNextEvent: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventBoolStateItem>(21);
		CreateItems0();
	}
}
