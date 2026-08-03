using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AiGroup : ConfigData<AiGroupItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 通用
		/// </summary>
		public const int General = 0;

		/// <summary>
		/// 战斗
		/// </summary>
		public const int Combat = 1;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 通用
		/// </summary>
		public static AiGroupItem General => Instance[0];

		/// <summary>
		/// 战斗
		/// </summary>
		public static AiGroupItem Combat => Instance[1];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AiGroup Instance = new AiGroup();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "GroupIds", "TemplateId" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AiGroupItem(0, new List<int> { 0, 1 }));
		_dataArray.Add(new AiGroupItem(1, new List<int> { 1 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AiGroupItem>(2);
		CreateItems0();
	}
}
