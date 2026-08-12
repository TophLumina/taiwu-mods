using Config;
using GameData.Serializer;

namespace GameData.DLC.CricketPolymorph;

/// <summary>
/// 促织化形数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class CricketPolymorphData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CricketItemId = 0;

		public const ushort MaleCharacterId = 1;

		public const ushort FemaleCharacterId = 2;

		public const ushort State = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "CricketItemId", "MaleCharacterId", "FemaleCharacterId", "State" };
	}

	/// <summary>
	/// 促织道具 ID，-1 表示尚未化形
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public int CricketItemId = -1;

	/// <summary>
	/// 男角色 ID，-1 表示从未化形为此性别（首次化形后即使重新变回道具，角色 ID 也不会清除）
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int MaleCharacterId = -1;

	/// <summary>
	/// 女角色 ID，-1 表示从未化形为此性别（首次化形后即使重新变回道具，角色 ID 也不会清除）
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public int FemaleCharacterId = -1;

	/// <summary>
	/// 促织化形状态
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	private ECricketPolymorphState _state;

	/// <summary>
	/// 已化形
	/// </summary>
	public bool Alive => (_state & ECricketPolymorphState.Alive) != 0;

	/// <summary>
	/// 当前角色 ID，未化形时返回 -1
	/// </summary>
	public int CurrentCharacterId
	{
		get
		{
			if (Alive)
			{
				if (!ContainsState(ECricketPolymorphState.Male))
				{
					return FemaleCharacterId;
				}
				return MaleCharacterId;
			}
			return -1;
		}
	}

	/// <summary>
	/// 包含目标角色
	/// </summary>
	public bool ContainsCharacter(int characterId)
	{
		if (characterId != MaleCharacterId)
		{
			return characterId == FemaleCharacterId;
		}
		return true;
	}

	/// <summary>
	/// 匹配目标角色
	/// </summary>
	public bool MatchCharacter(int characterId)
	{
		if (characterId != MaleCharacterId || !ContainsState(ECricketPolymorphState.Male))
		{
			if (characterId == FemaleCharacterId)
			{
				return ContainsState(ECricketPolymorphState.Female);
			}
			return false;
		}
		return true;
	}

	/// <summary>
	/// 包含指定状态
	/// </summary>
	public bool ContainsState(ECricketPolymorphState state)
	{
		if (state == ECricketPolymorphState.None)
		{
			if (_state == ECricketPolymorphState.None)
			{
				if (MaleCharacterId >= 0)
				{
					return FemaleCharacterId < 0;
				}
				return true;
			}
			return false;
		}
		return (_state & state) == state;
	}

	/// <summary>
	/// 改变为指定状态，失败时抛出异常
	/// </summary>
	public void ChangeState(ECricketPolymorphState newState)
	{
		if (!ChangeStateWithoutAssert(newState))
		{
			PredefinedLog.DefValue.PolymorphStateChangeFailed.Log(_state, newState);
		}
	}

	/// <summary>
	/// 改变为指定状态，需要调用方检查是否成功
	/// </summary>
	private bool ChangeStateWithoutAssert(ECricketPolymorphState newState)
	{
		if (newState == _state)
		{
			return false;
		}
		if (_state == ECricketPolymorphState.None)
		{
			_state = newState;
		}
		else if ((newState == ECricketPolymorphState.Returned || newState == ECricketPolymorphState.Dead) ? true : false)
		{
			_state = newState;
		}
		else
		{
			bool flag = (uint)(newState - 1) <= 1u;
			bool flag2 = flag;
			if (flag2)
			{
				ECricketPolymorphState state = _state;
				bool flag3 = ((state == ECricketPolymorphState.Returned || state == ECricketPolymorphState.Dead) ? true : false);
				flag2 = flag3;
			}
			if (flag2)
			{
				_state = newState;
			}
			else
			{
				if (newState != ECricketPolymorphState.WaitForReturn || !Alive)
				{
					return false;
				}
				_state |= newState;
			}
		}
		return true;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CricketPolymorphData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CricketPolymorphData(CricketPolymorphData other)
	{
		CricketItemId = other.CricketItemId;
		MaleCharacterId = other.MaleCharacterId;
		FemaleCharacterId = other.FemaleCharacterId;
		_state = other._state;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CricketPolymorphData other)
	{
		CricketItemId = other.CricketItemId;
		MaleCharacterId = other.MaleCharacterId;
		FemaleCharacterId = other.FemaleCharacterId;
		_state = other._state;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 15;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		*(int*)num = CricketItemId;
		byte* num2 = num + 4;
		*(int*)num2 = MaleCharacterId;
		byte* num3 = num2 + 4;
		*(int*)num3 = FemaleCharacterId;
		byte* num4 = num3 + 4;
		*num4 = (byte)_state;
		int totalSize = (int)(num4 + 1 - pData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			CricketItemId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			MaleCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			FemaleCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			_state = (ECricketPolymorphState)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
