using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class RelationDisplayType : ConfigData<RelationDisplayTypeItem, short>
{
	public static class DefKey
	{
		public const short Parent = 0;

		public const short Sworn = 1;

		public const short HusbandOrWife = 2;

		public const short Child = 3;

		public const short Faction = 4;

		public const short Enemy = 5;

		public const short Friend = 6;

		public const short Adored = 7;

		public const short Mentor = 8;

		public const short Sibling = 9;

		public const short BloodParent = 10;

		public const short BloodChild = 11;

		public const short BloodBrotherOrSister = 12;

		public const short StepParent = 13;

		public const short StepChild = 14;

		public const short StepBrotherOrSister = 15;

		public const short AdoptiveParent = 16;

		public const short AdoptiveChild = 17;

		public const short AdoptiveBrotherOrSister = 18;
	}

	public static class DefValue
	{
		public static RelationDisplayTypeItem Parent => Instance[(short)0];

		public static RelationDisplayTypeItem Sworn => Instance[(short)1];

		public static RelationDisplayTypeItem HusbandOrWife => Instance[(short)2];

		public static RelationDisplayTypeItem Child => Instance[(short)3];

		public static RelationDisplayTypeItem Faction => Instance[(short)4];

		public static RelationDisplayTypeItem Enemy => Instance[(short)5];

		public static RelationDisplayTypeItem Friend => Instance[(short)6];

		public static RelationDisplayTypeItem Adored => Instance[(short)7];

		public static RelationDisplayTypeItem Mentor => Instance[(short)8];

		public static RelationDisplayTypeItem Sibling => Instance[(short)9];

		public static RelationDisplayTypeItem BloodParent => Instance[(short)10];

		public static RelationDisplayTypeItem BloodChild => Instance[(short)11];

		public static RelationDisplayTypeItem BloodBrotherOrSister => Instance[(short)12];

		public static RelationDisplayTypeItem StepParent => Instance[(short)13];

		public static RelationDisplayTypeItem StepChild => Instance[(short)14];

		public static RelationDisplayTypeItem StepBrotherOrSister => Instance[(short)15];

		public static RelationDisplayTypeItem AdoptiveParent => Instance[(short)16];

		public static RelationDisplayTypeItem AdoptiveChild => Instance[(short)17];

		public static RelationDisplayTypeItem AdoptiveBrotherOrSister => Instance[(short)18];
	}

	public static RelationDisplayType Instance = new RelationDisplayType();

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
		_dataArray.Add(new RelationDisplayTypeItem(0, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_0"), new sbyte[3] { 1, 4, 7 }, 1, 6));
		_dataArray.Add(new RelationDisplayTypeItem(1, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_1"), new sbyte[1] { 10 }, 9, 4));
		_dataArray.Add(new RelationDisplayTypeItem(2, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_2"), new sbyte[1] { 11 }, 2, 3));
		_dataArray.Add(new RelationDisplayTypeItem(3, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_3"), new sbyte[3] { 2, 5, 8 }, 3, 7));
		_dataArray.Add(new RelationDisplayTypeItem(4, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_4"), new sbyte[0], 10, 10));
		_dataArray.Add(new RelationDisplayTypeItem(5, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_5"), new sbyte[1] { 16 }, 6, 1));
		_dataArray.Add(new RelationDisplayTypeItem(6, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_6"), new sbyte[1] { 14 }, 8, 5));
		_dataArray.Add(new RelationDisplayTypeItem(7, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_7"), new sbyte[1] { 15 }, 7, 2));
		_dataArray.Add(new RelationDisplayTypeItem(8, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_8"), new sbyte[1] { 12 }, 5, 9));
		_dataArray.Add(new RelationDisplayTypeItem(9, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_9"), new sbyte[3] { 3, 6, 9 }, 4, 8));
		_dataArray.Add(new RelationDisplayTypeItem(10, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_10"), new sbyte[1] { 1 }, 0, 0));
		_dataArray.Add(new RelationDisplayTypeItem(11, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_11"), new sbyte[1] { 2 }, 0, 0));
		_dataArray.Add(new RelationDisplayTypeItem(12, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_12"), new sbyte[1] { 3 }, 0, 0));
		_dataArray.Add(new RelationDisplayTypeItem(13, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_13"), new sbyte[1] { 4 }, 0, 0));
		_dataArray.Add(new RelationDisplayTypeItem(14, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_14"), new sbyte[1] { 5 }, 0, 0));
		_dataArray.Add(new RelationDisplayTypeItem(15, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_15"), new sbyte[1] { 6 }, 0, 0));
		_dataArray.Add(new RelationDisplayTypeItem(16, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_16"), new sbyte[1] { 7 }, 0, 0));
		_dataArray.Add(new RelationDisplayTypeItem(17, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_17"), new sbyte[1] { 8 }, 0, 0));
		_dataArray.Add(new RelationDisplayTypeItem(18, LocalStringManager.GetConfig("RelationDisplayType_language", "Name_18"), new sbyte[1] { 9 }, 0, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<RelationDisplayTypeItem>(19);
		CreateItems0();
	}
}
