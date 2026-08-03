using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarFaceElementScore : ConfigData<AvatarFaceElementScoreItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 眼睛
		/// </summary>
		public const short Eye = 0;

		/// <summary>
		/// 眉毛
		/// </summary>
		public const short Eyebrow = 1;

		/// <summary>
		/// 鼻子
		/// </summary>
		public const short Nose = 2;

		/// <summary>
		/// 嘴巴
		/// </summary>
		public const short Mouth = 3;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 眼睛
		/// </summary>
		public static AvatarFaceElementScoreItem Eye => Instance[(short)0];

		/// <summary>
		/// 眉毛
		/// </summary>
		public static AvatarFaceElementScoreItem Eyebrow => Instance[(short)1];

		/// <summary>
		/// 鼻子
		/// </summary>
		public static AvatarFaceElementScoreItem Nose => Instance[(short)2];

		/// <summary>
		/// 嘴巴
		/// </summary>
		public static AvatarFaceElementScoreItem Mouth => Instance[(short)3];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AvatarFaceElementScore Instance = new AvatarFaceElementScore();

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
		_dataArray.Add(new AvatarFaceElementScoreItem(0, 60, 100, 100, 30, 15));
		_dataArray.Add(new AvatarFaceElementScoreItem(1, 100, 60, 40, 10, 10));
		_dataArray.Add(new AvatarFaceElementScoreItem(2, 0, 100, 60, 15, 0));
		_dataArray.Add(new AvatarFaceElementScoreItem(3, 0, 100, 80, 20, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AvatarFaceElementScoreItem>(4);
		CreateItems0();
	}
}
