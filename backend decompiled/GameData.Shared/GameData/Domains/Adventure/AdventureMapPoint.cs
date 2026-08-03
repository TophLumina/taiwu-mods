using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Adventure;

[Serializable]
public class AdventureMapPoint : ISerializableGameData
{
	/// <summary>
	/// 地形
	/// </summary>
	[SerializableGameDataField]
	public int TerrainId;

	/// <summary>
	/// 结点类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte NodeType;

	/// <summary>
	/// x坐标
	/// </summary>
	[SerializableGameDataField]
	public short PosX;

	/// <summary>
	/// y坐标
	/// </summary>
	[SerializableGameDataField]
	public short PosY;

	/// <summary>
	///  七元类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte SevenElementType;

	/// <summary>
	///  七元消耗
	/// </summary>
	[SerializableGameDataField]
	public sbyte SevenElementCost;

	/// <summary>
	/// 奇遇内容分类
	/// </summary>
	[SerializableGameDataField]
	public sbyte NodeContentType;

	/// <summary>
	///
	/// </summary>
	[SerializableGameDataField]
	public int NodeContentIndex;

	/// <summary>
	/// 节点判定是否成功
	/// </summary>
	public bool JudgeSuccess;

	/// <summary>
	/// 所属分支序号，仅对分支内部节点有效
	/// </summary>
	[SerializableGameDataField]
	public sbyte AffiliatedBranchIdx;

	/// <summary>
	/// 判定技能ID
	/// </summary>
	[SerializableGameDataField]
	public short JudgeSkill = -1;

	/// <summary>
	/// 技能判定值
	/// </summary>
	[SerializableGameDataField]
	public short JudgeValue;

	/// <summary>
	/// 该点在顶点组（起点，转点，终点的集合）中的序号，仅对顶点节点有效
	/// </summary>
	[SerializableGameDataField]
	public short Index;

	public bool IsEvent
	{
		get
		{
			if (NodeContentType != 0)
			{
				return NodeContentType == 10;
			}
			return true;
		}
	}

	public bool NeedAttainment
	{
		get
		{
			if (JudgeSkill >= 0 && JudgeValue > 0 && NodeContentType >= 0)
			{
				return !IsEvent;
			}
			return false;
		}
	}

	public void Assign(AdventureMapPoint other)
	{
		TerrainId = other.TerrainId;
		NodeType = other.NodeType;
		PosX = other.PosX;
		PosY = other.PosY;
		SevenElementType = other.SevenElementType;
		SevenElementCost = other.SevenElementCost;
		NodeContentType = other.NodeContentType;
		NodeContentIndex = other.NodeContentIndex;
		AffiliatedBranchIdx = other.AffiliatedBranchIdx;
		JudgeSkill = other.JudgeSkill;
		JudgeValue = other.JudgeValue;
		Index = other.Index;
	}

	public override string ToString()
	{
		return $"{PosX}:{PosY}";
	}

	public string GetDetailedInfo()
	{
		return $"{{Position:({PosX},{PosY}),NodeType:{NodeType},SevenElementType:{SevenElementType},NodeContentType{NodeContentType},NodeContentIndex{NodeContentIndex},AffiliatedBranchIndex:{AffiliatedBranchIdx}}}";
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 23;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = TerrainId;
		byte* num = pData + 4;
		*num = (byte)NodeType;
		byte* num2 = num + 1;
		*(short*)num2 = PosX;
		byte* num3 = num2 + 2;
		*(short*)num3 = PosY;
		byte* num4 = num3 + 2;
		*num4 = (byte)SevenElementType;
		byte* num5 = num4 + 1;
		*num5 = (byte)SevenElementCost;
		byte* num6 = num5 + 1;
		*num6 = (byte)NodeContentType;
		byte* num7 = num6 + 1;
		*(int*)num7 = NodeContentIndex;
		byte* num8 = num7 + 4;
		*num8 = (byte)AffiliatedBranchIdx;
		byte* num9 = num8 + 1;
		*(short*)num9 = JudgeSkill;
		byte* num10 = num9 + 2;
		*(short*)num10 = JudgeValue;
		byte* num11 = num10 + 2;
		*(short*)num11 = Index;
		int totalSize = (int)(num11 + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		TerrainId = *(int*)pCurrData;
		pCurrData += 4;
		NodeType = (sbyte)(*pCurrData);
		pCurrData++;
		PosX = *(short*)pCurrData;
		pCurrData += 2;
		PosY = *(short*)pCurrData;
		pCurrData += 2;
		SevenElementType = (sbyte)(*pCurrData);
		pCurrData++;
		SevenElementCost = (sbyte)(*pCurrData);
		pCurrData++;
		NodeContentType = (sbyte)(*pCurrData);
		pCurrData++;
		NodeContentIndex = *(int*)pCurrData;
		pCurrData += 4;
		AffiliatedBranchIdx = (sbyte)(*pCurrData);
		pCurrData++;
		JudgeSkill = *(short*)pCurrData;
		pCurrData += 2;
		JudgeValue = *(short*)pCurrData;
		pCurrData += 2;
		Index = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public bool GetAttainmentEnough(List<short> lifeSkillAttainments)
	{
		if (NeedAttainment)
		{
			return lifeSkillAttainments[JudgeSkill] >= JudgeValue;
		}
		return false;
	}
}
