using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WorldFavorability : ConfigData<WorldFavorabilityItem, short>
{
	public static class DefKey
	{
		public const short FirstSightFavorability = 0;

		public const short GiftItem = 1;

		public const short ShareInformation = 2;

		public const short RepeatedEvent = 3;

		public const short StoryEvent = 4;

		public const short MonthlyEvolution = 5;

		public const short StoryCharacterFavorability = 6;
	}

	public static class DefValue
	{
		public static WorldFavorabilityItem FirstSightFavorability => Instance[(short)0];

		public static WorldFavorabilityItem GiftItem => Instance[(short)1];

		public static WorldFavorabilityItem ShareInformation => Instance[(short)2];

		public static WorldFavorabilityItem RepeatedEvent => Instance[(short)3];

		public static WorldFavorabilityItem StoryEvent => Instance[(short)4];

		public static WorldFavorabilityItem MonthlyEvolution => Instance[(short)5];

		public static WorldFavorabilityItem StoryCharacterFavorability => Instance[(short)6];
	}

	public static WorldFavorability Instance = new WorldFavorability();

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
		_dataArray.Add(new WorldFavorabilityItem(0, new short[4] { 200, 100, 75, 50 }, negativeUsingReciprocal: true));
		_dataArray.Add(new WorldFavorabilityItem(1, new short[4] { 100, 75, 50, 25 }, negativeUsingReciprocal: true));
		_dataArray.Add(new WorldFavorabilityItem(2, new short[4] { 100, 75, 50, 25 }, negativeUsingReciprocal: true));
		_dataArray.Add(new WorldFavorabilityItem(3, new short[4] { 100, 75, 50, 25 }, negativeUsingReciprocal: true));
		_dataArray.Add(new WorldFavorabilityItem(4, new short[4] { 100, 100, 100, 100 }, negativeUsingReciprocal: false));
		_dataArray.Add(new WorldFavorabilityItem(5, new short[4] { 100, 75, 50, 25 }, negativeUsingReciprocal: true));
		_dataArray.Add(new WorldFavorabilityItem(6, new short[4] { 100, 100, 100, 100 }, negativeUsingReciprocal: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<WorldFavorabilityItem>(7);
		CreateItems0();
	}
}
