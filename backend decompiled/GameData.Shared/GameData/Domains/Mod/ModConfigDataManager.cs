using System;
using System.Collections.Generic;
using System.IO;
using Config;
using GameData.Serializer;
using GameData.Utilities;
using GameData.Utilities.Mod;
using TaiwuModdingLib.Core.Utils;

namespace GameData.Domains.Mod;

public class ModConfigDataManager
{
	public void LoadModConfig(ModInfo modInfo)
	{
		string cfgDirPath = Path.Combine(modInfo.DirectoryName, "Config");
		string modIdentifier = modInfo.Title + "(" + modInfo.ModId.ToString();
		if (!Directory.Exists(cfgDirPath))
		{
			return;
		}
		string[] files = Directory.GetFiles(cfgDirPath, "*.lua", SearchOption.AllDirectories);
		foreach (string cfgPath in files)
		{
			ModConfigItem.ModIdentifier = modIdentifier + "-" + cfgPath;
			CommonObjectSerializer.Deserialize<ModConfigItem>(File.ReadAllText(cfgPath), out var modConfigItem, CommonObjectSerializer.MarshalFormat.LuaWithReturnPrefix);
			if (!modConfigItem.IsValid || !ConfigCollection.NameMap.TryGetValue(modConfigItem.ConfigName, out var configData))
			{
				continue;
			}
			if (modConfigItem.SrcConfigRefName != null)
			{
				string srcConfigRefName = modConfigItem.SrcConfigRefName;
				object srcConfigItem = configData.GetConfigItem(srcConfigRefName);
				object destConfigItem;
				if (srcConfigRefName == modConfigItem.DestConfigRefName)
				{
					AdaptableLog.Info(modIdentifier + " is replacing " + modConfigItem.ConfigName + " - " + srcConfigRefName);
					destConfigItem = srcConfigItem;
				}
				else
				{
					AdaptableLog.Info(modIdentifier + " is appending " + modConfigItem.ConfigName + " - " + modConfigItem.DestConfigRefName);
					destConfigItem = srcConfigItem.CreateDeepCopy();
					int destTemplateId = modConfigItem.TemplateId;
					destConfigItem.ModifyFieldWithTypeConvert("TemplateId", destTemplateId);
					configData.AddExtraItem(modIdentifier, modConfigItem.DestConfigRefName, destConfigItem);
				}
				ModConfigItemData data = modConfigItem.Data;
				if (data == null || data.Fields == null)
				{
					continue;
				}
				foreach (var (key, value) in modConfigItem.Data.Fields)
				{
					destConfigItem.ModifyFieldWithTypeConvert(key, value);
				}
				continue;
			}
			throw new NotImplementedException();
		}
	}
}
