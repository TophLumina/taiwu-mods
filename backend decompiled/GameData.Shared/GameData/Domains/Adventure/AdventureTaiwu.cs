using System.Collections.Generic;
using GameData.Adventure;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

/// <summary>
/// 太吾处于奇遇时的运行时数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class AdventureTaiwu : ISerializableGameData, IAdventureParticipant, IAdventureParameterProvider
{
	private static class FieldIds
	{
		public const ushort AdventureId = 0;

		public const ushort InternalIndex = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "AdventureId", "InternalIndex" };
	}

	/// <summary>
	/// 当前所处的奇遇 ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public int AdventureId;

	/// <summary>
	/// 当前索引 X
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	private AdventureBlockIndex _internalIndex;

	/// <summary>
	/// 当前是否进入了任意奇遇，奇遇运行时 ID 限制从 1 开始，因此默认值 0 也被视为未处于奇遇
	/// </summary>
	public bool InAdventure => AdventureId >= 1;

	/// <summary>
	/// 当前是否未进入任意奇遇
	/// </summary>
	public bool NotInAdventure => !InAdventure;

	/// <summary>
	/// 奇遇数据
	/// </summary>
	public AdventureRuntime Adventure => ExternalDataBridge.Context.GetAdventure(AdventureId);

	/// <summary>
	/// 当前所处小格
	/// </summary>
	public AdventureBlockIndex Index => _internalIndex;

	IReadOnlyList<AdventureParameterData> IAdventureParameterProvider.Parameters => Adventure.Core.Parameters;

	/// <summary>
	/// 基于某个奇遇创建运行时数据
	/// </summary>
	public AdventureTaiwu(int adventureId, AdventureBlockIndex index)
	{
		AdventureId = adventureId;
		_internalIndex = index;
	}

	/// <summary>
	/// 重置所处奇遇 ID
	/// </summary>
	public void ResetAdventureId()
	{
		AdventureId = 0;
		SetCurrentIndex(default(AdventureBlockIndex));
	}

	/// <summary>
	/// 设置当前所处小格
	/// </summary>
	public void SetCurrentIndex(AdventureBlockIndex index)
	{
		_internalIndex = index;
	}

	AdventureParameterValue? IAdventureParameterProvider.GetParameterOrNull(AdventureParameterKey key)
	{
		return Adventure.GetParameterOrNull(key);
	}

	void IAdventureParameterProvider.SetParameter(AdventureParameterKey key, AdventureParameterValue value)
	{
		Adventure.SetParameter(key, value);
	}

	void IAdventureParameterProvider.RemoveParameter(AdventureParameterKey key)
	{
		Adventure.RemoveParameter(key);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public AdventureTaiwu()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public AdventureTaiwu(AdventureTaiwu other)
	{
		AdventureId = other.AdventureId;
		_internalIndex = other._internalIndex;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(AdventureTaiwu other)
	{
		AdventureId = other.AdventureId;
		_internalIndex = other._internalIndex;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize += ((AdventureBlockIndexForSerialize)_internalIndex).GetSerializedSize();
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
		*(short*)pCurrData = 2;
		pCurrData += 2;
		*(int*)pCurrData = AdventureId;
		pCurrData += 4;
		int fieldSize = ((AdventureBlockIndexForSerialize)_internalIndex).Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			AdventureId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			AdventureBlockIndexForSerialize field = _internalIndex;
			pCurrData += field.Deserialize(pCurrData);
			_internalIndex = field;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
