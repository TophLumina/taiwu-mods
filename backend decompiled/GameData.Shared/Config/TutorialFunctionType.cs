using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TutorialFunctionType : ConfigData<TutorialFunctionTypeItem, short>
{
	public static class DefKey
	{
		public const short BuildingAreaEnter = 0;

		public const short BuildingManageStopBuild = 1;

		public const short CharacterMenuEnter = 2;

		public const short CharacterMenuAttainment = 3;

		public const short CharacterMenuEquipCombatSkill = 4;

		public const short CharacterMenuNeili = 5;

		public const short CharacterMenuRelationship = 6;

		public const short CharacterMenuBreakout = 7;

		public const short CharacterMenuInventory = 8;

		public const short CharacterMenuLifeRecord = 9;

		public const short CharacterMenuInformation = 10;

		public const short ViewBottomReading = 11;

		public const short ViewBottomLooping = 12;

		public const short ViewBottomAdvanceMonth = 13;

		public const short ReadingRemoveCurrentBook = 14;

		public const short LoopingRemoveCurrentSkill = 15;

		public const short MapMove = 16;

		public const short MapCollectResource = 17;

		public const short MapTaiwuProfession = 18;

		public const short CombatInterruptSkill = 19;
	}

	public static class DefValue
	{
		public static TutorialFunctionTypeItem BuildingAreaEnter => Instance[(short)0];

		public static TutorialFunctionTypeItem BuildingManageStopBuild => Instance[(short)1];

		public static TutorialFunctionTypeItem CharacterMenuEnter => Instance[(short)2];

		public static TutorialFunctionTypeItem CharacterMenuAttainment => Instance[(short)3];

		public static TutorialFunctionTypeItem CharacterMenuEquipCombatSkill => Instance[(short)4];

		public static TutorialFunctionTypeItem CharacterMenuNeili => Instance[(short)5];

		public static TutorialFunctionTypeItem CharacterMenuRelationship => Instance[(short)6];

		public static TutorialFunctionTypeItem CharacterMenuBreakout => Instance[(short)7];

		public static TutorialFunctionTypeItem CharacterMenuInventory => Instance[(short)8];

		public static TutorialFunctionTypeItem CharacterMenuLifeRecord => Instance[(short)9];

		public static TutorialFunctionTypeItem CharacterMenuInformation => Instance[(short)10];

		public static TutorialFunctionTypeItem ViewBottomReading => Instance[(short)11];

		public static TutorialFunctionTypeItem ViewBottomLooping => Instance[(short)12];

		public static TutorialFunctionTypeItem ViewBottomAdvanceMonth => Instance[(short)13];

		public static TutorialFunctionTypeItem ReadingRemoveCurrentBook => Instance[(short)14];

		public static TutorialFunctionTypeItem LoopingRemoveCurrentSkill => Instance[(short)15];

		public static TutorialFunctionTypeItem MapMove => Instance[(short)16];

		public static TutorialFunctionTypeItem MapCollectResource => Instance[(short)17];

		public static TutorialFunctionTypeItem MapTaiwuProfession => Instance[(short)18];

		public static TutorialFunctionTypeItem CombatInterruptSkill => Instance[(short)19];
	}

	public static TutorialFunctionType Instance = new TutorialFunctionType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

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
		_dataArray.Add(new TutorialFunctionTypeItem(0));
		_dataArray.Add(new TutorialFunctionTypeItem(1));
		_dataArray.Add(new TutorialFunctionTypeItem(2));
		_dataArray.Add(new TutorialFunctionTypeItem(3));
		_dataArray.Add(new TutorialFunctionTypeItem(4));
		_dataArray.Add(new TutorialFunctionTypeItem(5));
		_dataArray.Add(new TutorialFunctionTypeItem(6));
		_dataArray.Add(new TutorialFunctionTypeItem(7));
		_dataArray.Add(new TutorialFunctionTypeItem(8));
		_dataArray.Add(new TutorialFunctionTypeItem(9));
		_dataArray.Add(new TutorialFunctionTypeItem(10));
		_dataArray.Add(new TutorialFunctionTypeItem(11));
		_dataArray.Add(new TutorialFunctionTypeItem(12));
		_dataArray.Add(new TutorialFunctionTypeItem(13));
		_dataArray.Add(new TutorialFunctionTypeItem(14));
		_dataArray.Add(new TutorialFunctionTypeItem(15));
		_dataArray.Add(new TutorialFunctionTypeItem(16));
		_dataArray.Add(new TutorialFunctionTypeItem(17));
		_dataArray.Add(new TutorialFunctionTypeItem(18));
		_dataArray.Add(new TutorialFunctionTypeItem(19));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TutorialFunctionTypeItem>(20);
		CreateItems0();
	}
}
