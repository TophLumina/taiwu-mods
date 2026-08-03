using System;
using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Domains.Merchant;
using GameData.Domains.Taiwu.Profession;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 人物显示数据。用于向前端返回显示所需数据，使前端不必监听人物数据
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class CharacterDisplayData : ISerializableGameData
{
	/// <summary>
	/// 角色 ID
	/// </summary>
	[SerializableGameDataField]
	public int CharacterId;

	/// <summary>
	/// 角色模板 ID
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 角色创建类型
	/// </summary>
	[SerializableGameDataField]
	public byte CreatingType;

	/// <summary>
	/// 性别
	/// </summary>
	[SerializableGameDataField]
	public sbyte Gender;

	/// <summary>
	/// 姓名数据
	/// </summary>
	[SerializableGameDataField]
	public FullName FullName;

	/// <summary>
	/// 出家类型
	/// </summary>
	[SerializableGameDataField]
	public byte MonkType;

	/// <summary>
	/// 法号
	/// </summary>
	[SerializableGameDataField]
	public MonasticTitle MonasticTitle;

	/// <summary>
	/// 形象数据
	/// </summary>
	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	/// <summary>
	/// 生理年龄
	/// </summary>
	[SerializableGameDataField]
	public short PhysiologicalAge;

	/// <summary>
	/// 当前年龄
	/// </summary>
	[Obsolete("Unless necessary, use PhysiologicalAge instead.")]
	[SerializableGameDataField]
	public short CurrAge;

	/// <summary>
	/// 真实年龄
	/// </summary>
	[SerializableGameDataField]
	public short ActualAge;

	/// <summary>
	/// 团体数据
	/// </summary>
	[SerializableGameDataField]
	public OrganizationInfo OrgInfo;

	/// <summary>
	/// 立场
	/// </summary>
	[SerializableGameDataField]
	public sbyte BehaviorType;

	/// <summary>
	/// 名誉
	/// </summary>
	[SerializableGameDataField]
	public sbyte FameType;

	/// <summary>
	/// 对太吾的好感度
	/// </summary>
	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	/// <summary>
	/// 是否已经支持太吾
	/// </summary>
	[SerializableGameDataField]
	public bool IsApproveTaiwu;

	/// <summary>
	/// 对太吾的支持度
	/// </summary>
	[SerializableGameDataField]
	public short ApproveTaiwu;

	/// <summary>
	/// 团队影响力
	/// </summary>
	[SerializableGameDataField]
	public short InfluencePower;

	/// <summary>
	/// 团队贡献度
	/// 对死人数据，重用此字段以保存坟墓耐久
	/// </summary>
	[SerializableGameDataField]
	public int Contribution;

	/// <summary>
	/// 每月团队贡献度
	/// 对死人数据，重用此字段以保存死亡日期
	/// </summary>
	[SerializableGameDataField]
	public int ContributionPerMonth;

	/// <summary>
	/// 角色的称号列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> TitleIds;

	/// <summary>
	/// 是否已入魔
	/// </summary>
	[SerializableGameDataField]
	public bool CompletelyInfected;

	/// <summary>
	/// 可用的关押
	/// </summary>
	[SerializableGameDataField]
	public byte ValidKidnapSlotCount;

	/// <summary>
	/// 存活状态：0：活着，1：死亡，2：死亡并消除数据
	/// </summary>
	[SerializableGameDataField]
	public sbyte AliveState;

	/// <summary>
	/// 当前位置
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 出生日期
	/// </summary>
	[SerializableGameDataField]
	public int BirthDate;

	/// <summary>
	/// 外部关联状态位
	/// </summary>
	[SerializableGameDataField]
	public ulong ExternalRelationState;

	/// <summary>
	/// 奇书状态
	/// </summary>
	[SerializableGameDataField]
	public sbyte LegendaryBookOwnerState;

	/// <summary>
	/// 拥有的奇书，可能为null
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> LegendaryBooks;

	/// <summary>
	/// 自定义显示名
	/// </summary>
	[SerializableGameDataField]
	public int CustomDisplayNameId;

	/// <summary>
	/// 获取库房守卫信息
	/// </summary>
	[SerializableGameDataField]
	public byte SettlementTreasuryGuardInfo;

	/// <summary>
	/// 悬赏的犯罪程度
	/// </summary>
	[SerializableGameDataField]
	public sbyte BountyPunishmentSeverity;

	/// <summary>
	/// 发出悬赏的门派
	/// </summary>
	[SerializableGameDataField]
	public sbyte BountyOrgTemplate;

	/// <summary>
	/// 是否不能说话
	/// </summary>
	[SerializableGameDataField]
	public bool CanNotSpeak;

	/// <summary>
	/// 太吾是否关注了此人
	/// </summary>
	[SerializableGameDataField]
	public bool IsFollowedByTaiwu;

	/// <summary>
	/// 昵称。现在关注者才配有。
	/// </summary>
	[SerializableGameDataField]
	public int NickNameId;

	/// <summary>
	/// ExtraNameText对应的模板id
	/// </summary>
	[SerializableGameDataField]
	public int ExtraNameTextTemplateId;

	/// <summary>
	/// 理想门派
	/// </summary>
	[SerializableGameDataField]
	public sbyte IdealSect;

	/// <summary>
	/// 当前位置所属团体
	/// </summary>
	[SerializableGameDataField]
	public sbyte CurrOrgTemplate;

	/// <summary>
	/// 玄灰保护状态
	/// </summary>
	[SerializableGameDataField]
	public uint DarkAshProtector;

	/// <summary>
	/// 玄灰倒计时
	/// </summary>
	[SerializableGameDataField]
	public DarkAshCounter DarkAshCounter;

	/// <summary>
	/// 继承人的显示信息
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData OrganizationMemberPotentialSuccessor;

	/// <summary>
	/// 与太吾的关系
	/// </summary>
	[SerializableGameDataField]
	public ushort RelationToTaiwu;

	/// <summary>
	/// 太吾与之的关系
	/// </summary>
	[SerializableGameDataField]
	public ushort RelationFromTaiwu;

	/// <summary>
	/// 魅力
	/// </summary>
	[SerializableGameDataField]
	public short Charm;

	/// <summary>
	/// 健康
	/// </summary>
	[SerializableGameDataField]
	public short Health;

	/// <summary>
	/// 剩余最大健康
	/// </summary>
	[SerializableGameDataField]
	public short LeftMaxHealth;

	/// <summary>
	/// 健康状态标志位：bit0=外伤，bit1=内伤，bit2=毒，bit3=内息紊乱
	/// </summary>
	[SerializableGameDataField]
	public sbyte HealthStateFlags;

	/// <summary>
	/// 心情
	/// </summary>
	[SerializableGameDataField]
	public sbyte Happiness;

	/// <summary>
	/// 商人类别
	/// </summary>
	[SerializableGameDataField]
	public sbyte MerchantTemplateId;

	/// <summary>
	/// 是否与太吾同一派系
	/// </summary>
	[SerializableGameDataField]
	public bool IsSameFactionWithTaiwu;

	/// <summary>
	/// 地区主线 - 界青 - 星运点数
	/// </summary>
	[SerializableGameDataField]
	public int FortuneExtraLegacyPointWorth;

	/// <summary>
	/// 七元，活人才有意义
	/// </summary>
	[SerializableGameDataField]
	public Personalities Personalities;

	/// <summary>
	/// 特性勋章 (攻防智星级) 汇总值
	/// </summary>
	[SerializableGameDataField]
	public int AttackMedal;

	[SerializableGameDataField]
	public int DefenceMedal;

	[SerializableGameDataField]
	public int WisdomMedal;

	/// <summary>
	/// 轮回次数
	/// </summary>
	[SerializableGameDataField]
	public short SamsaraCount;

	/// <summary>
	/// 角色的特性列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> FeatureIds;

	/// <summary>
	/// 年龄影响因素
	/// </summary>
	[SerializableGameDataField]
	public byte AgeAffector;

	/// <summary>
	/// 精纯
	/// </summary>
	[SerializableGameDataField]
	public sbyte ConsummateLevel;

	/// <summary>
	/// 戒心数据
	/// </summary>
	[SerializableGameDataField]
	public int Alertness;

	/// <summary>
	/// 商人从属商会类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte MerchantType;

	/// <summary>
	/// 商人经验数据
	/// </summary>
	[SerializableGameDataField]
	public MerchantExpData MerchantExpData;

	/// <summary>
	/// 当前志向
	/// </summary>
	[SerializableGameDataField]
	public ProfessionData CurrentProfession;

	/// <summary>
	/// 是否为搜索到的Npc
	/// </summary>
	[SerializableGameDataField]
	public bool IsSearchedCharacter;

	/// <summary>
	/// 可见互动的可用情况字典，通常为空，按需赋值
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, bool> VisibleCharacterInteractionEventOptionDict;

	/// <summary>
	/// 相枢化身类型
	/// 0：Normal，1：XiangshuAvatar，2：XiangshuCore，3：PurpleBambooAvatar，4：WoodenXiangshuAvatar
	/// </summary>
	[SerializableGameDataField]
	public sbyte XiangshuType;

	/// <summary>
	/// 无交互数据原因
	/// -1: 未计算
	/// 计算方法：(data.VisibleCharacterInteractionEventOptionDict, data.NoInteractionReason) = DomainManager.TaiwuEvent.GetVisibleCharacterInteractionEventOptions(data.CharacterId)
	/// 由于这个字段不是必须的，一切请求这个字段的界面必须额外进行一次赋值调用
	/// </summary>
	[SerializableGameDataField]
	public int NoInteractionReason = -1;

	/// <summary>
	/// 坟墓耐久，直接重用Contribution
	/// </summary>
	public int GraveDuration
	{
		get
		{
			return Contribution;
		}
		set
		{
			Contribution = value;
		}
	}

	/// <summary>
	/// 死亡日期，直接重用ContributionPerMonth
	/// </summary>
	public int DeathDate
	{
		get
		{
			return ContributionPerMonth;
		}
		set
		{
			ContributionPerMonth = value;
		}
	}

	/// <summary>
	/// 是否是库房守卫
	/// </summary>
	public bool IsSettlementTreasuryGuard => SettlementTreasuryGuardLevel != 0;

	/// <summary>
	/// 获取库房守卫等级
	/// </summary>
	public byte SettlementTreasuryGuardLevel => (byte)(SettlementTreasuryGuardInfo & 3);

	/// <summary>
	/// 获取库房守卫是否工作
	/// </summary>
	public bool SettlementTreasuryGuardWorking => (SettlementTreasuryGuardInfo & 4) != 0;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 162;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize = ((TitleIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TitleIds.Count)));
		totalSize = ((LegendaryBooks == null) ? (totalSize + 2) : (totalSize + (2 + LegendaryBooks.Count)));
		totalSize = ((OrganizationMemberPotentialSuccessor == null) ? (totalSize + 2) : (totalSize + (2 + OrganizationMemberPotentialSuccessor.GetSerializedSize())));
		totalSize = ((FeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * FeatureIds.Count)));
		totalSize = ((MerchantExpData == null) ? (totalSize + 2) : (totalSize + (2 + MerchantExpData.GetSerializedSize())));
		totalSize = ((CurrentProfession == null) ? (totalSize + 2) : (totalSize + (2 + CurrentProfession.GetSerializedSize())));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(VisibleCharacterInteractionEventOptionDict);
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
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*pCurrData = CreatingType;
		pCurrData++;
		*pCurrData = (byte)Gender;
		pCurrData++;
		pCurrData += FullName.Serialize(pCurrData);
		*pCurrData = MonkType;
		pCurrData++;
		pCurrData += MonasticTitle.Serialize(pCurrData);
		if (AvatarRelatedData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = AvatarRelatedData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = PhysiologicalAge;
		pCurrData += 2;
		*(short*)pCurrData = CurrAge;
		pCurrData += 2;
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		pCurrData += OrgInfo.Serialize(pCurrData);
		*pCurrData = (byte)BehaviorType;
		pCurrData++;
		*pCurrData = (byte)FameType;
		pCurrData++;
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		*pCurrData = (IsApproveTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = ApproveTaiwu;
		pCurrData += 2;
		*(short*)pCurrData = InfluencePower;
		pCurrData += 2;
		*(int*)pCurrData = Contribution;
		pCurrData += 4;
		*(int*)pCurrData = ContributionPerMonth;
		pCurrData += 4;
		if (TitleIds != null)
		{
			int elementsCount = TitleIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = TitleIds[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (CompletelyInfected ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = ValidKidnapSlotCount;
		pCurrData++;
		*pCurrData = (byte)AliveState;
		pCurrData++;
		pCurrData += Location.Serialize(pCurrData);
		*(int*)pCurrData = BirthDate;
		pCurrData += 4;
		*(ulong*)pCurrData = ExternalRelationState;
		pCurrData += 8;
		*pCurrData = (byte)LegendaryBookOwnerState;
		pCurrData++;
		if (LegendaryBooks != null)
		{
			int elementsCount2 = LegendaryBooks.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = (byte)LegendaryBooks[j];
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CustomDisplayNameId;
		pCurrData += 4;
		*pCurrData = SettlementTreasuryGuardInfo;
		pCurrData++;
		*pCurrData = (byte)BountyPunishmentSeverity;
		pCurrData++;
		*pCurrData = (byte)BountyOrgTemplate;
		pCurrData++;
		*pCurrData = (CanNotSpeak ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsFollowedByTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = NickNameId;
		pCurrData += 4;
		*(int*)pCurrData = ExtraNameTextTemplateId;
		pCurrData += 4;
		*pCurrData = (byte)IdealSect;
		pCurrData++;
		*pCurrData = (byte)CurrOrgTemplate;
		pCurrData++;
		*(uint*)pCurrData = DarkAshProtector;
		pCurrData += 4;
		pCurrData += DarkAshCounter.Serialize(pCurrData);
		if (OrganizationMemberPotentialSuccessor != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = OrganizationMemberPotentialSuccessor.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(ushort*)pCurrData = RelationToTaiwu;
		pCurrData += 2;
		*(ushort*)pCurrData = RelationFromTaiwu;
		pCurrData += 2;
		*(short*)pCurrData = Charm;
		pCurrData += 2;
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = LeftMaxHealth;
		pCurrData += 2;
		*pCurrData = (byte)HealthStateFlags;
		pCurrData++;
		*pCurrData = (byte)Happiness;
		pCurrData++;
		*pCurrData = (byte)MerchantTemplateId;
		pCurrData++;
		*pCurrData = (IsSameFactionWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = FortuneExtraLegacyPointWorth;
		pCurrData += 4;
		pCurrData += Personalities.Serialize(pCurrData);
		*(int*)pCurrData = AttackMedal;
		pCurrData += 4;
		*(int*)pCurrData = DefenceMedal;
		pCurrData += 4;
		*(int*)pCurrData = WisdomMedal;
		pCurrData += 4;
		*(short*)pCurrData = SamsaraCount;
		pCurrData += 2;
		if (FeatureIds != null)
		{
			int elementsCount3 = FeatureIds.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = FeatureIds[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = AgeAffector;
		pCurrData++;
		*pCurrData = (byte)ConsummateLevel;
		pCurrData++;
		*(int*)pCurrData = Alertness;
		pCurrData += 4;
		*pCurrData = (byte)MerchantType;
		pCurrData++;
		if (MerchantExpData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = MerchantExpData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CurrentProfession != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = CurrentProfession.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr4 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsSearchedCharacter ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref VisibleCharacterInteractionEventOptionDict);
		*pCurrData = (byte)XiangshuType;
		pCurrData++;
		*(int*)pCurrData = NoInteractionReason;
		pCurrData += 4;
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CreatingType = *pCurrData;
		pCurrData++;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += FullName.Deserialize(pCurrData);
		MonkType = *pCurrData;
		pCurrData++;
		pCurrData += MonasticTitle.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (AvatarRelatedData == null)
			{
				AvatarRelatedData = new AvatarRelatedData();
			}
			pCurrData += AvatarRelatedData.Deserialize(pCurrData);
		}
		else
		{
			AvatarRelatedData = null;
		}
		PhysiologicalAge = *(short*)pCurrData;
		pCurrData += 2;
		CurrAge = *(short*)pCurrData;
		pCurrData += 2;
		ActualAge = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += OrgInfo.Deserialize(pCurrData);
		BehaviorType = (sbyte)(*pCurrData);
		pCurrData++;
		FameType = (sbyte)(*pCurrData);
		pCurrData++;
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		IsApproveTaiwu = *pCurrData != 0;
		pCurrData++;
		ApproveTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		InfluencePower = *(short*)pCurrData;
		pCurrData += 2;
		Contribution = *(int*)pCurrData;
		pCurrData += 4;
		ContributionPerMonth = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (TitleIds == null)
			{
				TitleIds = new List<short>(elementsCount);
			}
			else
			{
				TitleIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				TitleIds.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			TitleIds?.Clear();
		}
		CompletelyInfected = *pCurrData != 0;
		pCurrData++;
		ValidKidnapSlotCount = *pCurrData;
		pCurrData++;
		AliveState = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Location.Deserialize(pCurrData);
		BirthDate = *(int*)pCurrData;
		pCurrData += 4;
		ExternalRelationState = *(ulong*)pCurrData;
		pCurrData += 8;
		LegendaryBookOwnerState = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (LegendaryBooks == null)
			{
				LegendaryBooks = new List<sbyte>(elementsCount2);
			}
			else
			{
				LegendaryBooks.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				LegendaryBooks.Add((sbyte)pCurrData[j]);
			}
			pCurrData += (int)elementsCount2;
		}
		else
		{
			LegendaryBooks?.Clear();
		}
		CustomDisplayNameId = *(int*)pCurrData;
		pCurrData += 4;
		SettlementTreasuryGuardInfo = *pCurrData;
		pCurrData++;
		BountyPunishmentSeverity = (sbyte)(*pCurrData);
		pCurrData++;
		BountyOrgTemplate = (sbyte)(*pCurrData);
		pCurrData++;
		CanNotSpeak = *pCurrData != 0;
		pCurrData++;
		IsFollowedByTaiwu = *pCurrData != 0;
		pCurrData++;
		NickNameId = *(int*)pCurrData;
		pCurrData += 4;
		ExtraNameTextTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		IdealSect = (sbyte)(*pCurrData);
		pCurrData++;
		CurrOrgTemplate = (sbyte)(*pCurrData);
		pCurrData++;
		DarkAshProtector = *(uint*)pCurrData;
		pCurrData += 4;
		pCurrData += DarkAshCounter.Deserialize(pCurrData);
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (OrganizationMemberPotentialSuccessor == null)
			{
				OrganizationMemberPotentialSuccessor = new CharacterDisplayData();
			}
			pCurrData += OrganizationMemberPotentialSuccessor.Deserialize(pCurrData);
		}
		else
		{
			OrganizationMemberPotentialSuccessor = null;
		}
		RelationToTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		RelationFromTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		Charm = *(short*)pCurrData;
		pCurrData += 2;
		Health = *(short*)pCurrData;
		pCurrData += 2;
		LeftMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		HealthStateFlags = (sbyte)(*pCurrData);
		pCurrData++;
		Happiness = (sbyte)(*pCurrData);
		pCurrData++;
		MerchantTemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		IsSameFactionWithTaiwu = *pCurrData != 0;
		pCurrData++;
		FortuneExtraLegacyPointWorth = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Personalities.Deserialize(pCurrData);
		AttackMedal = *(int*)pCurrData;
		pCurrData += 4;
		DefenceMedal = *(int*)pCurrData;
		pCurrData += 4;
		WisdomMedal = *(int*)pCurrData;
		pCurrData += 4;
		SamsaraCount = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (FeatureIds == null)
			{
				FeatureIds = new List<short>(elementsCount3);
			}
			else
			{
				FeatureIds.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				FeatureIds.Add(((short*)pCurrData)[k]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			FeatureIds?.Clear();
		}
		AgeAffector = *pCurrData;
		pCurrData++;
		ConsummateLevel = (sbyte)(*pCurrData);
		pCurrData++;
		Alertness = *(int*)pCurrData;
		pCurrData += 4;
		MerchantType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			if (MerchantExpData == null)
			{
				MerchantExpData = new MerchantExpData();
			}
			pCurrData += MerchantExpData.Deserialize(pCurrData);
		}
		else
		{
			MerchantExpData = null;
		}
		ushort num4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num4 > 0)
		{
			if (CurrentProfession == null)
			{
				CurrentProfession = new ProfessionData();
			}
			pCurrData += CurrentProfession.Deserialize(pCurrData);
		}
		else
		{
			CurrentProfession = null;
		}
		IsSearchedCharacter = *pCurrData != 0;
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref VisibleCharacterInteractionEventOptionDict);
		XiangshuType = (sbyte)(*pCurrData);
		pCurrData++;
		NoInteractionReason = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
