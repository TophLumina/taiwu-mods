using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Merchant;

/// <summary>
/// 商会信息的商人内容
/// </summary>
[SerializableGameData(NoCopyConstructors = true)]
public class MerchantInfoMerchantData : ISerializableGameData
{
	/// <summary>
	/// 商人角色ID
	/// </summary>
	[SerializableGameDataField]
	public int CharId;

	/// <summary>
	/// 姓名数据
	/// </summary>
	[SerializableGameDataField]
	public NameRelatedData NameRelatedData;

	/// <summary>
	/// 立场
	/// </summary>
	[SerializableGameDataField]
	public sbyte BehaviorType;

	/// <summary>
	/// 对太吾的好感
	/// </summary>
	[SerializableGameDataField]
	public short Favorability;

	/// <summary>
	/// 商店的模板ID
	/// </summary>
	[SerializableGameDataField]
	public short MerchantTemplateId;

	/// <summary>
	/// 当前地区的模板ID
	/// </summary>
	[SerializableGameDataField]
	public short CurrentAreaTemplateId;

	/// <summary>
	/// 所属势力的模板ID
	/// </summary>
	[SerializableGameDataField]
	public short OrgTemplateId;

	/// <summary>
	/// 所属势力的地格名称数据
	/// </summary>
	[SerializableGameDataField]
	public FullBlockName FullBlockName;

	/// <summary>
	/// 头像数据
	/// </summary>
	[SerializableGameDataField]
	public AvatarRelatedData AvatarData;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 45;
		totalSize += FullBlockName.GetSerializedSize();
		totalSize = ((AvatarData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarData.GetSerializedSize())));
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
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		pCurrData += NameRelatedData.Serialize(pCurrData);
		*pCurrData = (byte)BehaviorType;
		pCurrData++;
		*(short*)pCurrData = Favorability;
		pCurrData += 2;
		*(short*)pCurrData = MerchantTemplateId;
		pCurrData += 2;
		*(short*)pCurrData = CurrentAreaTemplateId;
		pCurrData += 2;
		*(short*)pCurrData = OrgTemplateId;
		pCurrData += 2;
		int fieldSize = FullBlockName.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (AvatarData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize2 = AvatarData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize2;
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += NameRelatedData.Deserialize(pCurrData);
		BehaviorType = (sbyte)(*pCurrData);
		pCurrData++;
		Favorability = *(short*)pCurrData;
		pCurrData += 2;
		MerchantTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CurrentAreaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		OrgTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += FullBlockName.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (AvatarData == null)
			{
				AvatarData = new AvatarRelatedData();
			}
			pCurrData += AvatarData.Deserialize(pCurrData);
		}
		else
		{
			AvatarData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
