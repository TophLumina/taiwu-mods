using System;
using System.Collections.Generic;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Mod;

/// <summary>
/// 模组相关的信息
/// </summary>
public class ModInfo : ISerializableGameData, IEquatable<ModInfo>
{
	/// <summary>
	/// Mod 文件夹全路径
	/// </summary>
	[SerializableGameDataField]
	public string DirectoryName;

	/// <summary>
	/// Mod 标题
	/// </summary>
	[SerializableGameDataField]
	public string Title;

	/// <summary>
	/// Mod 发布时的文件Id
	/// </summary>
	[SerializableGameDataField]
	public ModId ModId;

	/// <summary>
	/// 后端的插件
	/// </summary>
	[SerializableGameDataField]
	public List<string> BackendPlugins;

	/// <summary>
	/// 未选定为测试的前端的插件
	/// </summary>
	[SerializableGameDataField]
	public List<string> BackendPluginsLegacy;

	/// <summary>
	/// 后端的补丁包（启动时读取，会修改内存中的程序集）
	/// </summary>
	[SerializableGameDataField]
	public List<string> BackendPatches;

	/// <summary>
	/// 事件包
	/// </summary>
	[SerializableGameDataField]
	public List<string> EventPackages;

	/// <summary>
	/// Mod 设置相关数据
	/// </summary>
	[SerializableGameDataField]
	public SerializableModData ModSettings;

	public ModInfo()
	{
		BackendPlugins = new List<string>();
		BackendPluginsLegacy = new List<string>();
		BackendPatches = new List<string>();
		EventPackages = new List<string>();
		ModSettings = new SerializableModData();
	}

	public void Upload()
	{
	}

	public bool Equals(ModInfo other)
	{
		return ModId.Equals(other?.ModId);
	}

	public override int GetHashCode()
	{
		return ModId.GetHashCode();
	}

	public string GetVersionString()
	{
		ulong subUlong = BitOperation.GetSubUlong(ModId.Version, 0, 16);
		ulong minor = BitOperation.GetSubUlong(ModId.Version, 16, 16);
		ulong build = BitOperation.GetSubUlong(ModId.Version, 32, 16);
		ulong revision = BitOperation.GetSubUlong(ModId.Version, 48, 16);
		return new Version((ushort)subUlong, (ushort)minor, (ushort)build, (ushort)revision).ToString();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 20;
		totalSize = ((DirectoryName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * DirectoryName.Length)));
		totalSize = ((Title == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Title.Length)));
		if (BackendPlugins != null)
		{
			totalSize += 2;
			int elementsCount = BackendPlugins.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = BackendPlugins[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element.Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (BackendPatches != null)
		{
			totalSize += 2;
			int elementsCount2 = BackendPatches.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				string element2 = BackendPatches[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element2.Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (EventPackages != null)
		{
			totalSize += 2;
			int elementsCount3 = EventPackages.Count;
			for (int k = 0; k < elementsCount3; k++)
			{
				string element3 = EventPackages[k];
				totalSize = ((element3 == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element3.Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((ModSettings == null) ? (totalSize + 2) : (totalSize + (2 + ModSettings.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (DirectoryName != null)
		{
			int elementsCount = DirectoryName.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = DirectoryName)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Title != null)
		{
			int elementsCount2 = Title.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar2 = Title)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar2[j];
				}
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += ModId.Serialize(pCurrData);
		if (BackendPlugins != null)
		{
			int elementsCount3 = BackendPlugins.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				string element = BackendPlugins[k];
				if (element != null)
				{
					int subElementsCount = element.Length;
					Tester.Assert(subElementsCount <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount;
					pCurrData += 2;
					fixed (char* pChar3 = element)
					{
						for (int l = 0; l < subElementsCount; l++)
						{
							((short*)pCurrData)[l] = (short)pChar3[l];
						}
					}
					pCurrData += 2 * subElementsCount;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BackendPatches != null)
		{
			int elementsCount4 = BackendPatches.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int m = 0; m < elementsCount4; m++)
			{
				string element2 = BackendPatches[m];
				if (element2 != null)
				{
					int subElementsCount2 = element2.Length;
					Tester.Assert(subElementsCount2 <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount2;
					pCurrData += 2;
					fixed (char* pChar4 = element2)
					{
						for (int n = 0; n < subElementsCount2; n++)
						{
							((short*)pCurrData)[n] = (short)pChar4[n];
						}
					}
					pCurrData += 2 * subElementsCount2;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (EventPackages != null)
		{
			int elementsCount5 = EventPackages.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int num = 0; num < elementsCount5; num++)
			{
				string element3 = EventPackages[num];
				if (element3 != null)
				{
					int subElementsCount3 = element3.Length;
					Tester.Assert(subElementsCount3 <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount3;
					pCurrData += 2;
					fixed (char* pChar5 = element3)
					{
						for (int num2 = 0; num2 < subElementsCount3; num2++)
						{
							((short*)pCurrData)[num2] = (short)pChar5[num2];
						}
					}
					pCurrData += 2 * subElementsCount3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ModSettings != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ModSettings.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			DirectoryName = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			DirectoryName = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			int fieldSize2 = 2 * elementsCount2;
			Title = Encoding.Unicode.GetString(pCurrData, fieldSize2);
			pCurrData += fieldSize2;
		}
		else
		{
			Title = null;
		}
		pCurrData += ModId.Deserialize(pCurrData);
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (BackendPlugins == null)
			{
				BackendPlugins = new List<string>(elementsCount3);
			}
			else
			{
				BackendPlugins.Clear();
			}
			for (int i = 0; i < elementsCount3; i++)
			{
				ushort subDataCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount > 0)
				{
					int subDataSize = 2 * subDataCount;
					BackendPlugins.Add(Encoding.Unicode.GetString(pCurrData, subDataSize));
					pCurrData += subDataSize;
				}
				else
				{
					BackendPlugins.Add(null);
				}
			}
		}
		else
		{
			BackendPlugins?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (BackendPatches == null)
			{
				BackendPatches = new List<string>(elementsCount4);
			}
			else
			{
				BackendPatches.Clear();
			}
			for (int j = 0; j < elementsCount4; j++)
			{
				ushort subDataCount2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount2 > 0)
				{
					int subDataSize2 = 2 * subDataCount2;
					BackendPatches.Add(Encoding.Unicode.GetString(pCurrData, subDataSize2));
					pCurrData += subDataSize2;
				}
				else
				{
					BackendPatches.Add(null);
				}
			}
		}
		else
		{
			BackendPatches?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (EventPackages == null)
			{
				EventPackages = new List<string>(elementsCount5);
			}
			else
			{
				EventPackages.Clear();
			}
			for (int k = 0; k < elementsCount5; k++)
			{
				ushort subDataCount3 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount3 > 0)
				{
					int subDataSize3 = 2 * subDataCount3;
					EventPackages.Add(Encoding.Unicode.GetString(pCurrData, subDataSize3));
					pCurrData += subDataSize3;
				}
				else
				{
					EventPackages.Add(null);
				}
			}
		}
		else
		{
			EventPackages?.Clear();
		}
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (ModSettings == null)
			{
				ModSettings = new SerializableModData();
			}
			pCurrData += ModSettings.Deserialize(pCurrData);
		}
		else
		{
			ModSettings = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
