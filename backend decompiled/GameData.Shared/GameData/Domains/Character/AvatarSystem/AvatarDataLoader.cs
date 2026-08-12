using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GameData.Utilities;
using MoonSharp.Interpreter;

namespace GameData.Domains.Character.AvatarSystem;

/// <summary>
/// 从 StreamingAssets 加载 AvatarData 的工具.
/// 数据格式为 lua: 文件以 `return { ... }` 形式存在, 顶层 key 对应 AvatarData 字段名.
/// 加载结果会按相对路径缓存.
/// </summary>
public static class AvatarDataLoader
{
	/// <summary>
	/// StreamingAssets 根目录名
	/// </summary>
	private const string StreamingAssetsFolder = "StreamingAssets";

	/// <summary>
	/// AvatarData 资源在 StreamingAssets 下的固定根目录.
	/// AvatarDataPath 字段填写的是相对于此目录的路径.
	/// </summary>
	private const string AvatarDataRootFolder = "CharacterAvatarData";

	/// <summary>
	/// 已加载的 AvatarData 缓存, key 为相对路径
	/// </summary>
	private static readonly ConcurrentDictionary<string, AvatarData> Cache = new ConcurrentDictionary<string, AvatarData>();

	/// <summary>
	/// 用于解析 lua 的 Script 实例(数据文件只含纯数据, 没有副作用代码)
	/// </summary>
	private static readonly Script LuaScript = new Script(CoreModules.Preset_HardSandbox);

	/// <summary>
	/// 反射缓存: AvatarData 所有可序列化字段(包含 private)
	/// </summary>
	private static readonly FieldInfo[] AvatarFields = BuildAvatarFieldInfos();

	private static FieldInfo[] BuildAvatarFieldInfos()
	{
		List<FieldInfo> list = new List<FieldInfo>();
		FieldInfo[] fields = typeof(AvatarData).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo f in fields)
		{
			if (f.GetCustomAttribute<NonSerializedAttribute>() == null)
			{
				Type ft = f.FieldType;
				if (!(ft != typeof(bool)) || !(ft != typeof(byte)) || !(ft != typeof(sbyte)) || !(ft != typeof(short)) || !(ft != typeof(ushort)))
				{
					list.Add(f);
				}
			}
		}
		return list.ToArray();
	}

	/// <summary>
	/// 按 AvatarDataPath 加载 AvatarData.
	/// AvatarDataPath 是相对于 StreamingAssets/CharacterAvatarData 目录的路径(带扩展名).
	/// 同一路径只读取并解析一次.
	/// </summary>
	/// <param name="relativePath">相对于 StreamingAssets/CharacterAvatarData 目录的路径.</param>
	/// <returns>加载成功返回 AvatarData 实例; 加载失败返回 null.</returns>
	public static AvatarData Load(string relativePath)
	{
		if (string.IsNullOrEmpty(relativePath))
		{
			return null;
		}
		if (Cache.TryGetValue(relativePath, out var cached))
		{
			return cached;
		}
		string filePath = Path.Combine(ExternalDataBridge.Context.DataPath, "StreamingAssets", "CharacterAvatarData", relativePath);
		if (!File.Exists(filePath))
		{
			AdaptableLog.Warning("[AvatarDataLoader] AvatarData file not found: " + filePath);
			Cache[relativePath] = null;
			return null;
		}
		AvatarData avatar = Parse(File.ReadAllText(filePath));
		if (avatar == null)
		{
			AdaptableLog.Warning("[AvatarDataLoader] Failed to parse AvatarData from: " + filePath);
		}
		Cache[relativePath] = avatar;
		return avatar;
	}

	/// <summary>
	/// 解析一段 lua 文本为 AvatarData.
	/// 期望的格式为 `return { FieldName = value, ... }`.
	/// </summary>
	private static AvatarData Parse(string luaContent)
	{
		DynValue root;
		try
		{
			root = LuaScript.DoString(luaContent);
		}
		catch (Exception ex)
		{
			AdaptableLog.Warning("[AvatarDataLoader] Lua parse exception: " + ex.Message);
			return null;
		}
		if (root == null || root.Type != DataType.Table)
		{
			return null;
		}
		Table luaTable = root.Table;
		AvatarData avatar = new AvatarData();
		FieldInfo[] avatarFields = AvatarFields;
		checked
		{
			foreach (FieldInfo field in avatarFields)
			{
				DynValue value = luaTable.RawGet(field.Name);
				if (value == null || value.Type == DataType.Nil)
				{
					continue;
				}
				try
				{
					if (field.FieldType == typeof(bool))
					{
						field.SetValue(avatar, value.Type == DataType.Boolean && value.Boolean);
					}
					else if (field.FieldType == typeof(byte))
					{
						field.SetValue(avatar, (byte)value.Number);
					}
					else if (field.FieldType == typeof(sbyte))
					{
						field.SetValue(avatar, (sbyte)value.Number);
					}
					else if (field.FieldType == typeof(short))
					{
						field.SetValue(avatar, (short)value.Number);
					}
					else if (field.FieldType == typeof(ushort))
					{
						field.SetValue(avatar, (ushort)value.Number);
					}
				}
				catch (Exception ex2)
				{
					AdaptableLog.Warning("[AvatarDataLoader] Failed to set field " + field.Name + " on AvatarData: " + ex2.Message);
				}
			}
			return avatar;
		}
	}

	/// <summary>
	/// 清空缓存(主要用于编辑器/测试场景)
	/// </summary>
	public static void ClearCache()
	{
		Cache.Clear();
	}
}
