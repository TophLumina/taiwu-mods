using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarElementPosition : ConfigData<AvatarElementPositionItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte MaleSmall = 0;

		public const sbyte FemaleSmall = 1;

		public const sbyte MaleNormal = 2;

		public const sbyte FemaleNormal = 3;

		public const sbyte MaleBig = 4;

		public const sbyte FemaleBig = 5;

		public const sbyte ChildMaleSmall = 6;

		public const sbyte ChildFemaleSmall = 7;

		public const sbyte ChildMaleBig = 8;

		public const sbyte ChildFemaleBig = 9;
	}

	public static class DefValue
	{
		public static AvatarElementPositionItem MaleSmall => Instance[(sbyte)0];

		public static AvatarElementPositionItem FemaleSmall => Instance[(sbyte)1];

		public static AvatarElementPositionItem MaleNormal => Instance[(sbyte)2];

		public static AvatarElementPositionItem FemaleNormal => Instance[(sbyte)3];

		public static AvatarElementPositionItem MaleBig => Instance[(sbyte)4];

		public static AvatarElementPositionItem FemaleBig => Instance[(sbyte)5];

		public static AvatarElementPositionItem ChildMaleSmall => Instance[(sbyte)6];

		public static AvatarElementPositionItem ChildFemaleSmall => Instance[(sbyte)7];

		public static AvatarElementPositionItem ChildMaleBig => Instance[(sbyte)8];

		public static AvatarElementPositionItem ChildFemaleBig => Instance[(sbyte)9];
	}

	public static AvatarElementPosition Instance = new AvatarElementPosition();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AvatarElementPositionItem(0, new float[2] { -13.45f, -4.3f }, new float[2] { 14.95f, -4.3f }, new float[2] { -16f, 5.5f }, new float[2] { 16f, 5.5f }, new float[2] { 0f, -11.9f }, new float[2] { 0.3f, -30.27f }, new float[2] { 0f, -34.3f }, new float[2] { 0f, -56f }, new float[2] { 0f, -16f }, new float[2] { 0f, -16f }, new float[2], new float[2], new float[2] { 0f, 60f }, new float[4] { -1.5f, -0.7f, 0.7f, 1.5f }, new float[4] { -1f, -0.5f, 0.5f, 1f }, new float[4] { 0.9f, 0.95f, 1.05f, 1.1f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { 0.9f, 0.95f, 1.1f, 1.2f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -1f, -0.3f, 0.3f, 1f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }, new float[4] { -1.5f, -0.5f, 0.5f, 1.5f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }));
		_dataArray.Add(new AvatarElementPositionItem(1, new float[2] { -14.45f, -5.6f }, new float[2] { 14.45f, -5.6f }, new float[2] { -16f, 4f }, new float[2] { 16f, 4f }, new float[2] { 0f, -13.5f }, new float[2] { 0f, -31f }, new float[2], new float[2], new float[2] { 0f, -16f }, new float[2] { 0f, -16f }, new float[2], new float[2], new float[2] { 0f, 44f }, new float[4] { -1.5f, -0.7f, 0.7f, 1.5f }, new float[4] { -1f, -0.5f, 0.5f, 1f }, new float[4] { 0.9f, 0.95f, 1.05f, 1.1f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { 0.9f, 0.95f, 1.1f, 1.2f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -1f, -0.3f, 0.3f, 1f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }, new float[4] { -1.5f, -0.5f, 0.5f, 1.5f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }));
		_dataArray.Add(new AvatarElementPositionItem(2, new float[2] { -14.8f, -4.4f }, new float[2] { 14.8f, -4.4f }, new float[2] { -15f, 5.4f }, new float[2] { 15f, 5.4f }, new float[2] { 0f, -13.75f }, new float[2] { 0f, -35f }, new float[2] { 0f, -39f }, new float[2] { 0f, -58f }, new float[2] { 0f, -16f }, new float[2] { 0f, -16f }, new float[2], new float[2], new float[2] { 0f, 82f }, new float[4] { -1.6f, -0.7f, 0.7f, 1.6f }, new float[4] { -1f, -0.5f, 0.5f, 1f }, new float[4] { 0.9f, 0.95f, 1.05f, 1.1f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { 0.9f, 0.95f, 1.1f, 1.2f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -1f, -0.3f, 0.3f, 1f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }, new float[4] { -1.5f, -0.5f, 0.5f, 1.5f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }));
		_dataArray.Add(new AvatarElementPositionItem(3, new float[2] { -13.63f, -6.42f }, new float[2] { 13.63f, -6.42f }, new float[2] { -16f, 4f }, new float[2] { 16f, 4f }, new float[2] { 0f, -13.8f }, new float[2] { 0f, -32f }, new float[2], new float[2], new float[2] { 0f, -16f }, new float[2] { 0f, -16f }, new float[2], new float[2], new float[2] { 0f, 66f }, new float[4] { -1.6f, -0.7f, 0.7f, 1.6f }, new float[4] { -1f, -0.5f, 0.5f, 1f }, new float[4] { 0.9f, 0.95f, 1.05f, 1.1f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { 0.9f, 0.95f, 1.1f, 1.2f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -1f, -0.3f, 0.3f, 1f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }, new float[4] { -1.5f, -0.5f, 0.5f, 1.5f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }));
		_dataArray.Add(new AvatarElementPositionItem(4, new float[2] { -16f, -5.4f }, new float[2] { 16f, -5.4f }, new float[2] { -16f, 6f }, new float[2] { 16f, 6f }, new float[2] { 0f, -14.7f }, new float[2] { 0f, -36.4f }, new float[2] { 0f, -38f }, new float[2] { 0f, -66f }, new float[2] { 0f, -16f }, new float[2] { 0f, -16f }, new float[2], new float[2], new float[2] { 0f, 94f }, new float[4] { -1.7f, -0.7f, 0.7f, 1.7f }, new float[4] { -1f, -0.5f, 0.5f, 1f }, new float[4] { 0.9f, 0.95f, 1.05f, 1.1f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { 0.9f, 0.95f, 1.1f, 1.2f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -1f, -0.3f, 0.3f, 1f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }, new float[4] { -1.5f, -0.5f, 0.5f, 1.5f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }));
		_dataArray.Add(new AvatarElementPositionItem(5, new float[2] { -16.9f, -6.75f }, new float[2] { 16.9f, -6.75f }, new float[2] { -16f, 4f }, new float[2] { 16f, 4f }, new float[2] { 0f, -15.67f }, new float[2] { 0f, -36.5f }, new float[2], new float[2], new float[2] { 0f, -16f }, new float[2] { 0f, -16f }, new float[2], new float[2], new float[2] { 0f, 82f }, new float[4] { -1.7f, -0.7f, 0.7f, 1.7f }, new float[4] { -1f, -0.5f, 0.5f, 1f }, new float[4] { 0.9f, 0.95f, 1.05f, 1.1f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { -2f, -1f, 1f, 2f }, new float[4] { 0.9f, 0.95f, 1.1f, 1.2f }, new float[4] { -6f, -2f, 2f, 6f }, new float[4] { -1f, -0.3f, 0.3f, 1f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }, new float[4] { -1.5f, -0.5f, 0.5f, 1.5f }, new float[4] { 0.95f, 0.98f, 1.02f, 1.05f }));
		_dataArray.Add(new AvatarElementPositionItem(6, new float[2] { -16f, -10f }, new float[2] { 16f, -10f }, new float[2] { -16f, 2f }, new float[2] { 16f, 2f }, new float[2] { 0f, -20f }, new float[2] { 0f, -36f }, new float[2], new float[2], new float[2], new float[2], new float[2], new float[2], new float[2] { 0f, 48f }, new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4]));
		_dataArray.Add(new AvatarElementPositionItem(7, new float[2] { -16f, -10f }, new float[2] { 16f, -10f }, new float[2] { -16f, 0f }, new float[2] { 16f, 0f }, new float[2] { 0f, -19f }, new float[2] { 0f, -36f }, new float[2], new float[2], new float[2], new float[2], new float[2], new float[2], new float[2] { 0f, 48f }, new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4]));
		_dataArray.Add(new AvatarElementPositionItem(8, new float[2] { -20f, -12f }, new float[2] { 20f, -12f }, new float[2] { -20f, 0f }, new float[2] { 20f, 0f }, new float[2] { 0f, -17.5f }, new float[2] { 0f, -37f }, new float[2], new float[2], new float[2] { 0f, 2f }, new float[2] { 0f, 2f }, new float[2], new float[2], new float[2] { 0f, 52f }, new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4]));
		_dataArray.Add(new AvatarElementPositionItem(9, new float[2] { -18f, -14f }, new float[2] { 18f, -14f }, new float[2] { -18f, -4f }, new float[2] { 18f, -4f }, new float[2] { 0f, -23.5f }, new float[2] { 0f, -41.5f }, new float[2], new float[2], new float[2] { 0f, -2f }, new float[2] { 0f, -2f }, new float[2], new float[2], new float[2] { 0f, 54f }, new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4], new float[4]));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AvatarElementPositionItem>(10);
		CreateItems0();
	}
}
