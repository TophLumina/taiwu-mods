using GameData.Serializer;

namespace GameData.Domains.Merchant;

/// <summary>
/// 打开交易界面的事件参数
/// </summary>
public class OpenShopEventArguments : ISerializableGameData
{
	/// <summary>
	/// 商店来源类型的枚举
	/// </summary>
	public enum EMerchantSourceType
	{
		None = -1,
		/// <summary>
		/// 普通商人，有智能角色
		/// </summary>
		NormalCharacter,
		/// <summary>
		/// 商会总部
		/// </summary>
		MerchantHeadBuilding,
		/// <summary>
		/// 商会分部
		/// </summary>
		MerchantBranchBuilding,
		/// <summary>
		/// 定居点库房，只复用了商店界面，实际跟商会体系无关
		/// </summary>
		SettlementTreasury,
		/// <summary>
		/// 特殊建筑
		/// </summary>
		SpecialBuilding,
		/// <summary>
		/// 地图普通商队
		/// </summary>
		NormalCaravan,
		/// <summary>
		/// 旧奇遇的临时商队，共用1个特殊ID，不能重复创建 <see cref="!:GameData.Domains.Merchant.MerchantDomain.TempCaravanId" />
		/// 新奇遇商队使用<see cref="F:GameData.Domains.Merchant.OpenShopEventArguments.EMerchantSourceType.SpecifiedOnBuildingMerchantType" />
		/// </summary>
		SingleAdventureCaravan,
		/// <summary>
		/// 富商技能召唤的临时商队，共用1个特殊ID，不能重复创建 <see cref="!:GameData.Domains.Merchant.MerchantDomain.TempCaravanId" />
		/// </summary>
		ProfessionSkillCaravan,
		/// <summary>
		/// 在 <see cref="F:GameData.Domains.Merchant.OpenShopEventArguments.BuildingMerchantType" /> 字段指定了来源商会类型，<see cref="F:GameData.Domains.Merchant.OpenShopEventArguments.Id" /> 字段用来指定人物 Id
		/// 新奇遇要求商队可以重复，所以是用新加的模板创建临时角色
		/// </summary>
		SpecifiedOnBuildingMerchantType
	}

	/// <summary>
	/// 商队或商人的ID
	/// </summary>
	[SerializableGameDataField]
	public int Id = -1;

	/// <summary>
	/// 建筑商会总部或分部的类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte BuildingMerchantType = -1;

	/// <summary>
	/// 需要刷新，奇遇用
	/// </summary>
	[SerializableGameDataField]
	public bool Refresh;

	/// <summary>
	/// 无视世界进度，奇遇用
	/// </summary>
	[SerializableGameDataField]
	public bool IgnoreWorldProgress;

	/// <summary>
	/// 无视商会好感，奇遇用
	/// 峨眉恩义互动复用了这个字段，对峨眉恩义互动，这个字段的意思是判断支持度是否达到半价标准
	/// </summary>
	[SerializableGameDataField]
	public bool IgnoreFavorability;

	/// <summary>
	/// 库房的定居点ID
	/// </summary>
	[SerializableGameDataField]
	public short SettlementId = -1;

	/// <summary>
	/// 商店来源类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte MerchantSourceType = -1;

	/// <summary>
	/// 定居点库房页签，-1表示强闯库房时关闭已显示库房界面
	/// </summary>
	[SerializableGameDataField]
	public sbyte CurrPage;

	public EMerchantSourceType MerchantSourceTypeEnum => (EMerchantSourceType)MerchantSourceType;

	public bool IsSettlementTreasury => MerchantSourceTypeEnum == EMerchantSourceType.SettlementTreasury;

	public bool IsFromBuilding
	{
		get
		{
			EMerchantSourceType merchantSourceTypeEnum = MerchantSourceTypeEnum;
			if ((uint)(merchantSourceTypeEnum - 1) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsHeadBuildingMerchant => MerchantSourceTypeEnum == EMerchantSourceType.MerchantHeadBuilding;

	public bool IsCaravan
	{
		get
		{
			EMerchantSourceType merchantSourceTypeEnum = MerchantSourceTypeEnum;
			if ((uint)(merchantSourceTypeEnum - 5) <= 2u)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsSpecialBuilding => MerchantSourceTypeEnum == EMerchantSourceType.SpecialBuilding;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public OpenShopEventArguments()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public OpenShopEventArguments(OpenShopEventArguments other)
	{
		Id = other.Id;
		BuildingMerchantType = other.BuildingMerchantType;
		Refresh = other.Refresh;
		IgnoreWorldProgress = other.IgnoreWorldProgress;
		IgnoreFavorability = other.IgnoreFavorability;
		SettlementId = other.SettlementId;
		MerchantSourceType = other.MerchantSourceType;
		CurrPage = other.CurrPage;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(OpenShopEventArguments other)
	{
		Id = other.Id;
		BuildingMerchantType = other.BuildingMerchantType;
		Refresh = other.Refresh;
		IgnoreWorldProgress = other.IgnoreWorldProgress;
		IgnoreFavorability = other.IgnoreFavorability;
		SettlementId = other.SettlementId;
		MerchantSourceType = other.MerchantSourceType;
		CurrPage = other.CurrPage;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = Id;
		byte* num = pData + 4;
		*num = (byte)BuildingMerchantType;
		byte* num2 = num + 1;
		*num2 = (Refresh ? ((byte)1) : ((byte)0));
		byte* num3 = num2 + 1;
		*num3 = (IgnoreWorldProgress ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*num4 = (IgnoreFavorability ? ((byte)1) : ((byte)0));
		byte* num5 = num4 + 1;
		*(short*)num5 = SettlementId;
		byte* num6 = num5 + 2;
		*num6 = (byte)MerchantSourceType;
		byte* num7 = num6 + 1;
		*num7 = (byte)CurrPage;
		int totalSize = (int)(num7 + 1 - pData);
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		BuildingMerchantType = (sbyte)(*pCurrData);
		pCurrData++;
		Refresh = *pCurrData != 0;
		pCurrData++;
		IgnoreWorldProgress = *pCurrData != 0;
		pCurrData++;
		IgnoreFavorability = *pCurrData != 0;
		pCurrData++;
		SettlementId = *(short*)pCurrData;
		pCurrData += 2;
		MerchantSourceType = (sbyte)(*pCurrData);
		pCurrData++;
		CurrPage = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
