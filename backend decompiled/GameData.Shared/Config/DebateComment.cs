using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DebateComment : ConfigData<DebateCommentItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 直言不讳
		/// </summary>
		public const short PositiveComment0 = 0;

		/// <summary>
		/// 黔驴技穷
		/// </summary>
		public const short NegativeComment0 = 1;

		/// <summary>
		/// 审时度势
		/// </summary>
		public const short PositiveComment1 = 2;

		/// <summary>
		/// 花言巧语
		/// </summary>
		public const short NegativeComment1 = 3;

		/// <summary>
		/// 好言相劝
		/// </summary>
		public const short PositiveComment2 = 4;

		/// <summary>
		/// 不胜其烦
		/// </summary>
		public const short NegativeComment2 = 5;

		/// <summary>
		/// 穷追猛打
		/// </summary>
		public const short PositiveComment3 = 6;

		/// <summary>
		/// 恶语相向
		/// </summary>
		public const short NegativeComment3 = 7;

		/// <summary>
		/// 妙语连珠
		/// </summary>
		public const short PositiveComment4 = 8;

		/// <summary>
		/// 物极必反
		/// </summary>
		public const short NegativeComment4 = 9;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 直言不讳
		/// </summary>
		public static DebateCommentItem PositiveComment0 => Instance[(short)0];

		/// <summary>
		/// 黔驴技穷
		/// </summary>
		public static DebateCommentItem NegativeComment0 => Instance[(short)1];

		/// <summary>
		/// 审时度势
		/// </summary>
		public static DebateCommentItem PositiveComment1 => Instance[(short)2];

		/// <summary>
		/// 花言巧语
		/// </summary>
		public static DebateCommentItem NegativeComment1 => Instance[(short)3];

		/// <summary>
		/// 好言相劝
		/// </summary>
		public static DebateCommentItem PositiveComment2 => Instance[(short)4];

		/// <summary>
		/// 不胜其烦
		/// </summary>
		public static DebateCommentItem NegativeComment2 => Instance[(short)5];

		/// <summary>
		/// 穷追猛打
		/// </summary>
		public static DebateCommentItem PositiveComment3 => Instance[(short)6];

		/// <summary>
		/// 恶语相向
		/// </summary>
		public static DebateCommentItem NegativeComment3 => Instance[(short)7];

		/// <summary>
		/// 妙语连珠
		/// </summary>
		public static DebateCommentItem PositiveComment4 => Instance[(short)8];

		/// <summary>
		/// 物极必反
		/// </summary>
		public static DebateCommentItem NegativeComment4 => Instance[(short)9];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static DebateComment Instance = new DebateComment();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "ResultTip", "BubbleContent", "BehaviorType", "Negation", "TemplateId", "Favor", "IsPositive", "CheckValue" };

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
		_dataArray.Add(new DebateCommentItem(0, LocalStringManager.GetConfig("DebateComment_language", "Name_0"), LocalStringManager.GetConfig("DebateComment_language", "Desc_0"), LocalStringManager.GetConfig("DebateComment_language", "ResultTip_0"), LocalStringManager.GetConfig("DebateComment_language", "BubbleContent_0"), 0, new short[5] { 3, 1, 1, 0, 1 }, 600, isPositive: true, 1, 0));
		_dataArray.Add(new DebateCommentItem(1, LocalStringManager.GetConfig("DebateComment_language", "Name_1"), LocalStringManager.GetConfig("DebateComment_language", "Desc_1"), LocalStringManager.GetConfig("DebateComment_language", "ResultTip_1"), LocalStringManager.GetConfig("DebateComment_language", "BubbleContent_1"), 3, new short[5] { 0, -1, -1, -3, -1 }, -300, isPositive: false, 0, 0));
		_dataArray.Add(new DebateCommentItem(2, LocalStringManager.GetConfig("DebateComment_language", "Name_2"), LocalStringManager.GetConfig("DebateComment_language", "Desc_2"), LocalStringManager.GetConfig("DebateComment_language", "ResultTip_2"), LocalStringManager.GetConfig("DebateComment_language", "BubbleContent_2"), 2, new short[5] { 0, 1, 3, 1, 1 }, 600, isPositive: true, 3, 2));
		_dataArray.Add(new DebateCommentItem(3, LocalStringManager.GetConfig("DebateComment_language", "Name_3"), LocalStringManager.GetConfig("DebateComment_language", "Desc_3"), LocalStringManager.GetConfig("DebateComment_language", "ResultTip_3"), LocalStringManager.GetConfig("DebateComment_language", "BubbleContent_3"), 0, new short[5] { -3, -1, 0, -1, -1 }, -300, isPositive: false, 2, 2));
		_dataArray.Add(new DebateCommentItem(4, LocalStringManager.GetConfig("DebateComment_language", "Name_4"), LocalStringManager.GetConfig("DebateComment_language", "Desc_4"), LocalStringManager.GetConfig("DebateComment_language", "ResultTip_4"), LocalStringManager.GetConfig("DebateComment_language", "BubbleContent_4"), 1, new short[5] { 1, 3, 1, 1, 0 }, 600, isPositive: true, 5, 5));
		_dataArray.Add(new DebateCommentItem(5, LocalStringManager.GetConfig("DebateComment_language", "Name_5"), LocalStringManager.GetConfig("DebateComment_language", "Desc_5"), LocalStringManager.GetConfig("DebateComment_language", "ResultTip_5"), LocalStringManager.GetConfig("DebateComment_language", "BubbleContent_5"), 4, new short[5] { -1, 0, -1, -1, -3 }, -300, isPositive: false, 4, 5));
		_dataArray.Add(new DebateCommentItem(6, LocalStringManager.GetConfig("DebateComment_language", "Name_6"), LocalStringManager.GetConfig("DebateComment_language", "Desc_6"), LocalStringManager.GetConfig("DebateComment_language", "ResultTip_6"), LocalStringManager.GetConfig("DebateComment_language", "BubbleContent_6"), 4, new short[5] { 1, 0, 1, 1, 3 }, 600, isPositive: true, 7, 2));
		_dataArray.Add(new DebateCommentItem(7, LocalStringManager.GetConfig("DebateComment_language", "Name_7"), LocalStringManager.GetConfig("DebateComment_language", "Desc_7"), LocalStringManager.GetConfig("DebateComment_language", "ResultTip_7"), LocalStringManager.GetConfig("DebateComment_language", "BubbleContent_7"), 1, new short[5] { -1, -3, -1, -1, 0 }, -300, isPositive: false, 6, 2));
		_dataArray.Add(new DebateCommentItem(8, LocalStringManager.GetConfig("DebateComment_language", "Name_8"), LocalStringManager.GetConfig("DebateComment_language", "Desc_8"), LocalStringManager.GetConfig("DebateComment_language", "ResultTip_8"), LocalStringManager.GetConfig("DebateComment_language", "BubbleContent_8"), 3, new short[5] { 1, 1, 0, 3, 1 }, 600, isPositive: true, 9, 0));
		_dataArray.Add(new DebateCommentItem(9, LocalStringManager.GetConfig("DebateComment_language", "Name_9"), LocalStringManager.GetConfig("DebateComment_language", "Desc_9"), LocalStringManager.GetConfig("DebateComment_language", "ResultTip_9"), LocalStringManager.GetConfig("DebateComment_language", "BubbleContent_9"), 2, new short[5] { -1, -1, -3, 0, -1 }, -300, isPositive: false, 8, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DebateCommentItem>(10);
		CreateItems0();
	}
}
