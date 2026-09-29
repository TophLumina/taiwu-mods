using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarFaceElementScore : ConfigData<AvatarFaceElementScoreItem, short>
{
	public static class DefKey
	{
		public const short Eye = 0;

		public const short Eyebrow = 1;

		public const short Nose = 2;

		public const short Mouth = 3;
	}

	public static class DefValue
	{
		public static AvatarFaceElementScoreItem Eye => Instance[(short)0];

		public static AvatarFaceElementScoreItem Eyebrow => Instance[(short)1];

		public static AvatarFaceElementScoreItem Nose => Instance[(short)2];

		public static AvatarFaceElementScoreItem Mouth => Instance[(short)3];
	}

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
