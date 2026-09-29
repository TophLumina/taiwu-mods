using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockMatcher : ConfigData<MapBlockMatcherItem, short>
{
	public static class DefKey
	{
		public const short NonDeveloped = 0;

		public const short NonDevelopedNatural = 1;

		public const short NonDevelopedNaturalNoEffectAndAdventure = 2;

		public const short NoEffectNoAdventureNoCharacter = 3;

		public const short NoAdventureNoMajorEvent = 6;
	}

	public static class DefValue
	{
		public static MapBlockMatcherItem NonDeveloped => Instance[(short)0];

		public static MapBlockMatcherItem NonDevelopedNatural => Instance[(short)1];

		public static MapBlockMatcherItem NonDevelopedNaturalNoEffectAndAdventure => Instance[(short)2];

		public static MapBlockMatcherItem NoEffectNoAdventureNoCharacter => Instance[(short)3];

		public static MapBlockMatcherItem NoAdventureNoMajorEvent => Instance[(short)6];
	}

	public static MapBlockMatcher Instance = new MapBlockMatcher();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "IncludeTypes", "IncludeSubTypes", "ExcludeTypes", "ExcludeSubTypes", "TemplateId" };

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
		_dataArray.Add(new MapBlockMatcherItem(0, new EMapBlockType[4]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild,
			EMapBlockType.Bad,
			EMapBlockType.scenery
		}, null, null, null, excludeBlocksWithIntelligentCharacters: false, excludeBlocksWithAdventure: false, excludeBlocksWithEffect: false));
		_dataArray.Add(new MapBlockMatcherItem(1, new EMapBlockType[4]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild,
			EMapBlockType.Bad,
			EMapBlockType.scenery
		}, null, null, new EMapBlockSubType[4]
		{
			EMapBlockSubType.SwordTomb,
			EMapBlockSubType.DLCLoong,
			EMapBlockSubType.Ruin,
			EMapBlockSubType.DarkPool
		}, excludeBlocksWithIntelligentCharacters: false, excludeBlocksWithAdventure: false, excludeBlocksWithEffect: false));
		_dataArray.Add(new MapBlockMatcherItem(2, new EMapBlockType[4]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild,
			EMapBlockType.Bad,
			EMapBlockType.scenery
		}, null, null, new EMapBlockSubType[4]
		{
			EMapBlockSubType.SwordTomb,
			EMapBlockSubType.DLCLoong,
			EMapBlockSubType.Ruin,
			EMapBlockSubType.DarkPool
		}, excludeBlocksWithIntelligentCharacters: false, excludeBlocksWithAdventure: true, excludeBlocksWithEffect: true));
		_dataArray.Add(new MapBlockMatcherItem(3, null, null, null, null, excludeBlocksWithIntelligentCharacters: true, excludeBlocksWithAdventure: true, excludeBlocksWithEffect: true));
		_dataArray.Add(new MapBlockMatcherItem(4, new EMapBlockType[2]
		{
			EMapBlockType.Town,
			EMapBlockType.City
		}, null, null, null, excludeBlocksWithIntelligentCharacters: false, excludeBlocksWithAdventure: false, excludeBlocksWithEffect: false));
		_dataArray.Add(new MapBlockMatcherItem(5, new EMapBlockType[1], null, null, null, excludeBlocksWithIntelligentCharacters: false, excludeBlocksWithAdventure: false, excludeBlocksWithEffect: false));
		_dataArray.Add(new MapBlockMatcherItem(6, null, null, null, null, excludeBlocksWithIntelligentCharacters: false, excludeBlocksWithAdventure: true, excludeBlocksWithEffect: true));
		_dataArray.Add(new MapBlockMatcherItem(7, new EMapBlockType[1] { EMapBlockType.Bad }, null, null, new EMapBlockSubType[4]
		{
			EMapBlockSubType.SwordTomb,
			EMapBlockSubType.DLCLoong,
			EMapBlockSubType.Ruin,
			EMapBlockSubType.DarkPool
		}, excludeBlocksWithIntelligentCharacters: false, excludeBlocksWithAdventure: false, excludeBlocksWithEffect: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MapBlockMatcherItem>(8);
		CreateItems0();
	}
}
