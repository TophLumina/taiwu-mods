using System.Collections.Generic;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 事件系统选择技艺的数据(单选)
/// </summary>
public class EventSelectLifeSkillData : ISerializableGameData
{
	/// <summary>
	/// 保存的选择的功法数据的key
	/// </summary>
	[SerializableGameDataField]
	public string ResultSaveKey;

	/// <summary>
	/// 当前事件如果选择这个OptionKey对应的选项，则需要进行技艺数据选择
	/// </summary>
	[SerializableGameDataField]
	public string OptionKey;

	/// <summary>
	/// 正在选择的功法所属的角色id
	/// </summary>
	[SerializableGameDataField]
	public int CharId;

	/// <summary>
	/// 所有可选功法id列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> CanSelectLifeSkillIdList;

	/// <summary>
	/// 选择结果的数据索引，不需要序列化，通过SetLifeSkillResult方法设置到参数盒子
	/// 前端获取到此结果时自动把该值设置到-1表示还没进行过选择
	/// 选择完毕后把该值改为有效值并自动再次选择该选项
	/// </summary>
	public int SelectResultIndex;

	public EventSelectLifeSkillData()
	{
	}

	public EventSelectLifeSkillData(EventSelectLifeSkillData other)
	{
		ResultSaveKey = other.ResultSaveKey;
		OptionKey = other.OptionKey;
		CharId = other.CharId;
		CanSelectLifeSkillIdList = new List<short>(other.CanSelectLifeSkillIdList);
	}

	public void Assign(EventSelectLifeSkillData other)
	{
		ResultSaveKey = other.ResultSaveKey;
		OptionKey = other.OptionKey;
		CharId = other.CharId;
		CanSelectLifeSkillIdList = new List<short>(other.CanSelectLifeSkillIdList);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="!:ISerializableGameData.GetSerializeSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((ResultSaveKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ResultSaveKey.Length)));
		totalSize = ((OptionKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * OptionKey.Length)));
		totalSize = ((CanSelectLifeSkillIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CanSelectLifeSkillIdList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (ResultSaveKey != null)
		{
			int elementsCount = ResultSaveKey.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = ResultSaveKey)
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
		if (OptionKey != null)
		{
			int elementsCount2 = OptionKey.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar2 = OptionKey)
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
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		if (CanSelectLifeSkillIdList != null)
		{
			int elementsCount3 = CanSelectLifeSkillIdList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = CanSelectLifeSkillIdList[k];
			}
			pCurrData += 2 * elementsCount3;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			ResultSaveKey = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			ResultSaveKey = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			int fieldSize2 = 2 * elementsCount2;
			OptionKey = Encoding.Unicode.GetString(pCurrData, fieldSize2);
			pCurrData += fieldSize2;
		}
		else
		{
			OptionKey = null;
		}
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (CanSelectLifeSkillIdList == null)
			{
				CanSelectLifeSkillIdList = new List<short>(elementsCount3);
			}
			else
			{
				CanSelectLifeSkillIdList.Clear();
			}
			for (int i = 0; i < elementsCount3; i++)
			{
				CanSelectLifeSkillIdList.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			CanSelectLifeSkillIdList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
