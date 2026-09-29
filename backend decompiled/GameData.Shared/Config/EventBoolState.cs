using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventBoolState : ConfigData<EventBoolStateItem, short>
{
	public static class DefKey
	{
		public const short ShuffleOption = 0;

		public const short MainRoleUseAlternativeName = 1;

		public const short TargetRoleUseAlternativeName = 2;

		public const short NotShowMainRole = 3;

		public const short NotShowTargetRole = 4;

		public const short ForbidViewSelf = 5;

		public const short ForbidViewCharacter = 6;

		public const short HideLeftFavorability = 7;

		public const short HideFavorability = 8;

		public const short MainRoleShowBlush = 9;

		public const short TargetRoleShowBlush = 10;

		public const short LeftRoleShowInjuryInfo = 11;

		public const short RightRoleShowInjuryInfo = 12;

		public const short RightCharacterShadow = 13;

		public const short RightForbiddenConsummateLevel = 14;

		public const short LeftForbidShowFavorChangeEffect = 15;

		public const short RightForbidShowFavorChangeEffect = 16;

		public const short LeftActorShowMarriageLook1 = 17;

		public const short LeftActorShowMarriageLook2 = 18;

		public const short RightActorShowMarriageLook1 = 19;

		public const short RightActorShowMarriageLook2 = 20;
	}

	public static class DefValue
	{
		public static EventBoolStateItem ShuffleOption => Instance[(short)0];

		public static EventBoolStateItem MainRoleUseAlternativeName => Instance[(short)1];

		public static EventBoolStateItem TargetRoleUseAlternativeName => Instance[(short)2];

		public static EventBoolStateItem NotShowMainRole => Instance[(short)3];

		public static EventBoolStateItem NotShowTargetRole => Instance[(short)4];

		public static EventBoolStateItem ForbidViewSelf => Instance[(short)5];

		public static EventBoolStateItem ForbidViewCharacter => Instance[(short)6];

		public static EventBoolStateItem HideLeftFavorability => Instance[(short)7];

		public static EventBoolStateItem HideFavorability => Instance[(short)8];

		public static EventBoolStateItem MainRoleShowBlush => Instance[(short)9];

		public static EventBoolStateItem TargetRoleShowBlush => Instance[(short)10];

		public static EventBoolStateItem LeftRoleShowInjuryInfo => Instance[(short)11];

		public static EventBoolStateItem RightRoleShowInjuryInfo => Instance[(short)12];

		public static EventBoolStateItem RightCharacterShadow => Instance[(short)13];

		public static EventBoolStateItem RightForbiddenConsummateLevel => Instance[(short)14];

		public static EventBoolStateItem LeftForbidShowFavorChangeEffect => Instance[(short)15];

		public static EventBoolStateItem RightForbidShowFavorChangeEffect => Instance[(short)16];

		public static EventBoolStateItem LeftActorShowMarriageLook1 => Instance[(short)17];

		public static EventBoolStateItem LeftActorShowMarriageLook2 => Instance[(short)18];

		public static EventBoolStateItem RightActorShowMarriageLook1 => Instance[(short)19];

		public static EventBoolStateItem RightActorShowMarriageLook2 => Instance[(short)20];
	}

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
