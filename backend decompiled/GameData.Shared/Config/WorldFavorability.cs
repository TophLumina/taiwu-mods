using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WorldFavorability : ConfigData<WorldFavorabilityItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 初见好感度
		/// </summary>
		public const short FirstSightFavorability = 0;

		/// <summary>
		/// 赠予物品
		/// </summary>
		public const short GiftItem = 1;

		/// <summary>
		/// 见闻闲谈
		/// </summary>
		public const short ShareInformation = 2;

		/// <summary>
		/// 重复互动事件
		/// </summary>
		public const short RepeatedEvent = 3;

		/// <summary>
		/// 剧情事件
		/// </summary>
		public const short StoryEvent = 4;

		/// <summary>
		/// NPC演化
		/// </summary>
		public const short MonthlyEvolution = 5;

		/// <summary>
		/// 剧情角色好感度
		/// </summary>
		public const short StoryCharacterFavorability = 6;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 初见好感度
		/// </summary>
		public static WorldFavorabilityItem FirstSightFavorability => Instance[(short)0];

		/// <summary>
		/// 赠予物品
		/// </summary>
		public static WorldFavorabilityItem GiftItem => Instance[(short)1];

		/// <summary>
		/// 见闻闲谈
		/// </summary>
		public static WorldFavorabilityItem ShareInformation => Instance[(short)2];

		/// <summary>
		/// 重复互动事件
		/// </summary>
		public static WorldFavorabilityItem RepeatedEvent => Instance[(short)3];

		/// <summary>
		/// 剧情事件
		/// </summary>
		public static WorldFavorabilityItem StoryEvent => Instance[(short)4];

		/// <summary>
		/// NPC演化
		/// </summary>
		public static WorldFavorabilityItem MonthlyEvolution => Instance[(short)5];

		/// <summary>
		/// 剧情角色好感度
		/// </summary>
		public static WorldFavorabilityItem StoryCharacterFavorability => Instance[(short)6];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
