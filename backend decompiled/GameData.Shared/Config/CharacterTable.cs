using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterTable : ConfigData<CharacterTableItem, short>
{
	public static class DefKey
	{
		public const short GeneralProperty = 0;

		public const short MainAndAttackProperty = 1;

		public const short HitProperty = 2;

		public const short LifeSkill = 3;

		public const short CombatSkill = 4;

		public const short Personality = 5;

		public const short ItemAndResource = 6;

		public const short Command = 7;

		public const short LegendBookCompetitors = 8;

		public const short LegendBookFallen = 9;

		public const short Villager = 10;

		public const short VillagerNeed = 11;
	}

	public static class DefValue
	{
		public static CharacterTableItem GeneralProperty => Instance[(short)0];

		public static CharacterTableItem MainAndAttackProperty => Instance[(short)1];

		public static CharacterTableItem HitProperty => Instance[(short)2];

		public static CharacterTableItem LifeSkill => Instance[(short)3];

		public static CharacterTableItem CombatSkill => Instance[(short)4];

		public static CharacterTableItem Personality => Instance[(short)5];

		public static CharacterTableItem ItemAndResource => Instance[(short)6];

		public static CharacterTableItem Command => Instance[(short)7];

		public static CharacterTableItem LegendBookCompetitors => Instance[(short)8];

		public static CharacterTableItem LegendBookFallen => Instance[(short)9];

		public static CharacterTableItem Villager => Instance[(short)10];

		public static CharacterTableItem VillagerNeed => Instance[(short)11];
	}

	public static CharacterTable Instance = new CharacterTable();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Title", "Elements", "TemplateId", "Width" };

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
		_dataArray.Add(new CharacterTableItem(0, LocalStringManager.GetConfig("CharacterTable_language", "Title_0"), ECharacterTableType.GeneralProperty, new List<short>
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10
		}, new List<int>
		{
			347, 34, 214, 214, 214, 214, 214, 214, 214, 214,
			219
		}));
		_dataArray.Add(new CharacterTableItem(1, LocalStringManager.GetConfig("CharacterTable_language", "Title_1"), ECharacterTableType.MainAndAttackProperty, new List<short>
		{
			0, 1, 11, 12, 13, 14, 15, 16, 17, 18,
			19, 20
		}, new List<int>
		{
			347, 34, 193, 193, 193, 193, 193, 193, 193, 193,
			193, 196
		}));
		_dataArray.Add(new CharacterTableItem(2, LocalStringManager.GetConfig("CharacterTable_language", "Title_2"), ECharacterTableType.HitProperty, new List<short>
		{
			0, 1, 21, 22, 23, 24, 25, 26, 27, 28,
			17
		}, new List<int>
		{
			347, 34, 214, 214, 214, 214, 214, 214, 214, 214,
			219
		}));
		_dataArray.Add(new CharacterTableItem(3, LocalStringManager.GetConfig("CharacterTable_language", "Title_3"), ECharacterTableType.LifeSkill, new List<short>
		{
			0, 1, 30, 31, 32, 33, 34, 35, 36, 37,
			38, 39, 40, 41, 42, 43, 44, 45, 46
		}, new List<int>
		{
			347, 34, 107, 107, 107, 107, 107, 107, 107, 107,
			107, 107, 107, 107, 107, 107, 107, 107, 235
		}));
		_dataArray.Add(new CharacterTableItem(4, LocalStringManager.GetConfig("CharacterTable_language", "Title_4"), ECharacterTableType.CombatSkill, new List<short>
		{
			0, 1, 47, 48, 49, 50, 51, 52, 53, 54,
			55, 56, 57, 58, 59, 60, 61
		}, new List<int>
		{
			347, 34, 122, 122, 122, 122, 122, 122, 122, 122,
			122, 122, 122, 122, 122, 122, 235
		}));
		_dataArray.Add(new CharacterTableItem(5, LocalStringManager.GetConfig("CharacterTable_language", "Title_5"), ECharacterTableType.Personality, new List<short> { 0, 1, 62, 63, 64, 65, 66, 67, 68 }, new List<int> { 347, 34, 274, 274, 274, 274, 274, 274, 283 }));
		_dataArray.Add(new CharacterTableItem(6, LocalStringManager.GetConfig("CharacterTable_language", "Title_6"), ECharacterTableType.ItemAndResource, new List<short>
		{
			0, 1, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 80
		}, new List<int>
		{
			347, 34, 193, 193, 193, 193, 193, 193, 193, 193,
			193, 196
		}));
		_dataArray.Add(new CharacterTableItem(7, LocalStringManager.GetConfig("CharacterTable_language", "Title_7"), ECharacterTableType.Command, new List<short> { 0, 1, 81, 82, 83, 84, 85, 86 }, new List<int> { 347, 34, 320, 320, 320, 320, 320, 325 }));
		_dataArray.Add(new CharacterTableItem(8, LocalStringManager.GetConfig("CharacterTable_language", "Title_8"), ECharacterTableType.LegendBookCompetitors, new List<short> { 0, 1, 87, 88, 91, 92, 93, 94 }, new List<int> { 347, 34, 193, 193, 384, 384, 384, 387 }));
		_dataArray.Add(new CharacterTableItem(9, LocalStringManager.GetConfig("CharacterTable_language", "Title_9"), ECharacterTableType.LegendBookFallen, new List<short> { 0, 1, 89, 90, 91, 92, 93, 94, 95 }, new List<int> { 347, 34, 193, 193, 193, 193, 193, 384, 578 }));
		_dataArray.Add(new CharacterTableItem(10, LocalStringManager.GetConfig("CharacterTable_language", "Title_10"), ECharacterTableType.Villager, new List<short>
		{
			0, 1, 2, 92, 99, 100, 101, 103, 102, 7,
			4
		}, new List<int>
		{
			347, 34, 214, 214, 214, 214, 214, 214, 214, 214,
			219
		}));
		_dataArray.Add(new CharacterTableItem(11, LocalStringManager.GetConfig("CharacterTable_language", "Title_11"), ECharacterTableType.VillagerNeed, new List<short> { 0, 1, 92, 107, 108, 109 }, new List<int> { 347, 34, 478, 478, 478, 487 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterTableItem>(12);
		CreateItems0();
	}
}
