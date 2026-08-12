using System;
using System.Text.RegularExpressions;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 玩家AI选项
/// </summary>
/// <summary>
/// 玩家AI选项
/// </summary>
public class AiOptions : ISerializableGameData, ICommonObjectSerializationAware
{
	/// <summary>
	/// 自动攻击
	/// </summary>
	[SerializableGameDataField]
	public bool AutoAttack;

	/// <summary>
	/// 自动切换兵器
	/// </summary>
	[SerializableGameDataField]
	public bool AutoChangeWeapon;

	/// <summary>
	/// 自动切换兵器内外比例
	/// </summary>
	[Obsolete]
	[SerializableGameDataField]
	public bool AutoChangeWeaponInnerRatio;

	/// <summary>
	/// 自动变招
	/// </summary>
	[SerializableGameDataField]
	public bool AutoChangeTrick;

	/// <summary>
	/// 自动解封
	/// </summary>
	[SerializableGameDataField]
	public bool AutoUnlock;

	/// <summary>
	/// 跳过生铸
	/// </summary>
	[SerializableGameDataField]
	public bool SkipRawCreate;

	/// <summary>
	/// 自动移动
	/// </summary>
	[SerializableGameDataField]
	public bool AutoMove;

	/// <summary>
	/// 尝试躲避
	/// </summary>
	[SerializableGameDataField]
	public bool TryDodge;

	/// <summary>
	/// 保存移动目标距离
	/// </summary>
	[SerializableGameDataField]
	public bool SaveMoveTarget;

	/// <summary>
	/// 自动施展增幅
	/// </summary>
	[SerializableGameDataField]
	public bool AutoCostNeiliAllocation;

	/// <summary>
	/// 中断施展
	/// </summary>
	[SerializableGameDataField]
	public bool AutoInterrupt;

	/// <summary>
	/// 中断身法
	/// </summary>
	[SerializableGameDataField]
	public bool AutoClearAgile;

	/// <summary>
	/// 中断护体
	/// </summary>
	[SerializableGameDataField]
	public bool AutoClearDefense;

	/// <summary>
	/// 自动消耗蓄式
	/// </summary>
	[SerializableGameDataField]
	public bool AutoCostTrick;

	/// <summary>
	/// 自动施展功法（0-摧破、1-轻灵、2-护体）
	/// </summary>
	[SerializableGameDataField]
	public bool[] AutoCastSkill = new bool[3];

	/// <summary>
	/// 自动动作（0-疗伤、1-驱毒、2-逃跑）
	/// </summary>
	[SerializableGameDataField]
	public bool[] AutoUseOtherAction = new bool[3];

	/// <summary>
	/// 自动使用同道指令
	/// </summary>
	[SerializableGameDataField]
	public bool[] AutoUseTeammateCommand = new bool[25];

	public void Reset()
	{
		AutoAttack = true;
		AutoChangeWeapon = true;
		AutoChangeWeaponInnerRatio = true;
		AutoChangeTrick = true;
		AutoUnlock = false;
		SkipRawCreate = false;
		AutoMove = true;
		TryDodge = true;
		SaveMoveTarget = false;
		AutoCostNeiliAllocation = false;
		AutoInterrupt = false;
		AutoClearAgile = false;
		AutoClearDefense = false;
		for (int i = 0; i < AutoCastSkill.Length; i++)
		{
			AutoCastSkill[i] = true;
		}
		for (int j = 0; j < AutoUseOtherAction.Length; j++)
		{
			AutoUseOtherAction[j] = true;
		}
		for (int k = 0; k < AutoUseTeammateCommand.Length; k++)
		{
			AutoUseTeammateCommand[k] = true;
		}
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public AiOptions()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public AiOptions(AiOptions other)
	{
		AutoAttack = other.AutoAttack;
		AutoChangeWeapon = other.AutoChangeWeapon;
		AutoChangeWeaponInnerRatio = other.AutoChangeWeaponInnerRatio;
		AutoChangeTrick = other.AutoChangeTrick;
		AutoUnlock = other.AutoUnlock;
		SkipRawCreate = other.SkipRawCreate;
		AutoMove = other.AutoMove;
		TryDodge = other.TryDodge;
		SaveMoveTarget = other.SaveMoveTarget;
		AutoCostNeiliAllocation = other.AutoCostNeiliAllocation;
		AutoInterrupt = other.AutoInterrupt;
		AutoClearAgile = other.AutoClearAgile;
		AutoClearDefense = other.AutoClearDefense;
		AutoCostTrick = other.AutoCostTrick;
		bool[] item = other.AutoCastSkill;
		int elementsCount = item.Length;
		AutoCastSkill = new bool[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			AutoCastSkill[i] = item[i];
		}
		bool[] item2 = other.AutoUseOtherAction;
		int elementsCount2 = item2.Length;
		AutoUseOtherAction = new bool[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			AutoUseOtherAction[j] = item2[j];
		}
		bool[] item3 = other.AutoUseTeammateCommand;
		int elementsCount3 = item3.Length;
		AutoUseTeammateCommand = new bool[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			AutoUseTeammateCommand[k] = item3[k];
		}
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(AiOptions other)
	{
		AutoAttack = other.AutoAttack;
		AutoChangeWeapon = other.AutoChangeWeapon;
		AutoChangeWeaponInnerRatio = other.AutoChangeWeaponInnerRatio;
		AutoChangeTrick = other.AutoChangeTrick;
		AutoUnlock = other.AutoUnlock;
		SkipRawCreate = other.SkipRawCreate;
		AutoMove = other.AutoMove;
		TryDodge = other.TryDodge;
		SaveMoveTarget = other.SaveMoveTarget;
		AutoCostNeiliAllocation = other.AutoCostNeiliAllocation;
		AutoInterrupt = other.AutoInterrupt;
		AutoClearAgile = other.AutoClearAgile;
		AutoClearDefense = other.AutoClearDefense;
		AutoCostTrick = other.AutoCostTrick;
		bool[] item = other.AutoCastSkill;
		int elementsCount = item.Length;
		AutoCastSkill = new bool[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			AutoCastSkill[i] = item[i];
		}
		bool[] item2 = other.AutoUseOtherAction;
		int elementsCount2 = item2.Length;
		AutoUseOtherAction = new bool[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			AutoUseOtherAction[j] = item2[j];
		}
		bool[] item3 = other.AutoUseTeammateCommand;
		int elementsCount3 = item3.Length;
		AutoUseTeammateCommand = new bool[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			AutoUseTeammateCommand[k] = item3[k];
		}
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 14;
		totalSize = ((AutoCastSkill == null) ? (totalSize + 2) : (totalSize + (2 + AutoCastSkill.Length)));
		totalSize = ((AutoUseOtherAction == null) ? (totalSize + 2) : (totalSize + (2 + AutoUseOtherAction.Length)));
		totalSize = ((AutoUseTeammateCommand == null) ? (totalSize + 2) : (totalSize + (2 + AutoUseTeammateCommand.Length)));
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
		*pCurrData = (AutoAttack ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoChangeWeapon ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoChangeWeaponInnerRatio ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoChangeTrick ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoUnlock ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (SkipRawCreate ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoMove ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (TryDodge ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (SaveMoveTarget ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoCostNeiliAllocation ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoInterrupt ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoClearAgile ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoClearDefense ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoCostTrick ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (AutoCastSkill != null)
		{
			int elementsCount = AutoCastSkill.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (AutoCastSkill[i] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AutoUseOtherAction != null)
		{
			int elementsCount2 = AutoUseOtherAction.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = (AutoUseOtherAction[j] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AutoUseTeammateCommand != null)
		{
			int elementsCount3 = AutoUseTeammateCommand.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData[k] = (AutoUseTeammateCommand[k] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount3;
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
		AutoAttack = *pCurrData != 0;
		pCurrData++;
		AutoChangeWeapon = *pCurrData != 0;
		pCurrData++;
		AutoChangeWeaponInnerRatio = *pCurrData != 0;
		pCurrData++;
		AutoChangeTrick = *pCurrData != 0;
		pCurrData++;
		AutoUnlock = *pCurrData != 0;
		pCurrData++;
		SkipRawCreate = *pCurrData != 0;
		pCurrData++;
		AutoMove = *pCurrData != 0;
		pCurrData++;
		TryDodge = *pCurrData != 0;
		pCurrData++;
		SaveMoveTarget = *pCurrData != 0;
		pCurrData++;
		AutoCostNeiliAllocation = *pCurrData != 0;
		pCurrData++;
		AutoInterrupt = *pCurrData != 0;
		pCurrData++;
		AutoClearAgile = *pCurrData != 0;
		pCurrData++;
		AutoClearDefense = *pCurrData != 0;
		pCurrData++;
		AutoCostTrick = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (AutoCastSkill == null || AutoCastSkill.Length != elementsCount)
			{
				AutoCastSkill = new bool[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				AutoCastSkill[i] = pCurrData[i] != 0;
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			AutoCastSkill = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (AutoUseOtherAction == null || AutoUseOtherAction.Length != elementsCount2)
			{
				AutoUseOtherAction = new bool[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				AutoUseOtherAction[j] = pCurrData[j] != 0;
			}
			pCurrData += (int)elementsCount2;
		}
		else
		{
			AutoUseOtherAction = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (AutoUseTeammateCommand == null || AutoUseTeammateCommand.Length != elementsCount3)
			{
				AutoUseTeammateCommand = new bool[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				AutoUseTeammateCommand[k] = pCurrData[k] != 0;
			}
			pCurrData += (int)elementsCount3;
		}
		else
		{
			AutoUseTeammateCommand = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public bool DeserializingUnknownField(string name, out CommonObjectSerializationMember proc)
	{
		Match m;
		Match match = (m = Regex.Match(name, "^AutoCastSkill(\\d+)$"));
		if (match != null && match.Success)
		{
			int idx = int.Parse(m.Groups[1].Value);
			proc = CommonObjectSerializationMember.Make(name, () => AutoCastSkill[idx], delegate(bool v)
			{
				AutoCastSkill[idx] = v;
			});
			return true;
		}
		match = (m = Regex.Match(name, "^AutoUseOtherAction(\\d+)$"));
		if (match != null && match.Success)
		{
			int idx2 = int.Parse(m.Groups[1].Value);
			proc = CommonObjectSerializationMember.Make(name, () => AutoUseOtherAction[idx2], delegate(bool v)
			{
				AutoUseOtherAction[idx2] = v;
			});
			return true;
		}
		match = (m = Regex.Match(name, "^AutoUseTeammateCommand(\\d+)$"));
		if (match != null && match.Success)
		{
			int idx3 = int.Parse(m.Groups[1].Value);
			proc = CommonObjectSerializationMember.Make(name, () => AutoUseTeammateCommand[idx3], delegate(bool v)
			{
				AutoUseTeammateCommand[idx3] = v;
			});
			return true;
		}
		proc = default(CommonObjectSerializationMember);
		return false;
	}

	public void InitializeOnDeserializing()
	{
		Reset();
	}
}
