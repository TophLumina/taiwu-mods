using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GameData.Utilities;
using MoonSharp.Interpreter;

namespace GameData.Domains.Character.AvatarSystem;

public static class AvatarDataLoader
{
	private const string StreamingAssetsFolder = "StreamingAssets";

	private const string AvatarDataRootFolder = "CharacterAvatarData";

	private static readonly ConcurrentDictionary<string, AvatarData> Cache = new ConcurrentDictionary<string, AvatarData>();

	private static readonly Script LuaScript = new Script(CoreModules.Preset_HardSandbox);

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

	public static void ClearCache()
	{
		Cache.Clear();
	}
}
