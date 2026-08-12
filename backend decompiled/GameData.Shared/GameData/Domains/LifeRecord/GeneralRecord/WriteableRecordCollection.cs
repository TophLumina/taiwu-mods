using System;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.LifeRecord.GeneralRecord;

/// <summary>
/// 可写的通用记录的集合
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public class WriteableRecordCollection : ReadonlyRecordCollection
{
	private const int DefaultInitialCapacity = 1024;

	/// <summary>
	/// 可写的通用记录的集合
	/// </summary>
	public WriteableRecordCollection()
		: this(1024)
	{
	}

	/// <summary>
	/// 可写的通用记录的集合
	/// </summary>
	/// <param name="initialCapacity">原始数据容器的初始容量</param>
	public WriteableRecordCollection(int initialCapacity)
		: base(initialCapacity)
	{
	}

	/// <summary>
	/// 开始添加记录.
	/// 各个派生类需要各自实现自己的此方法, 参数也会各不相同.
	/// </summary>
	/// <param name="recordType">记录类型 (即记录配置表中的模板 ID)</param>
	/// <returns>当前记录的起始偏移</returns>
	protected int BeginAddingRecord(short recordType)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// 结束添加记录
	/// </summary>
	/// <param name="beginOffset">当前记录的起始偏移</param>
	protected unsafe void EndAddingRecord(int beginOffset)
	{
		int size = Size - beginOffset;
		if (size > 255)
		{
			throw new Exception("Record exceeded the max size");
		}
		fixed (byte* pRawData = RawData)
		{
			pRawData[beginOffset] = (byte)size;
		}
		int count = base.Count + 1;
		base.Count = count;
	}

	/// <summary>
	/// 在当前记录中添加角色
	/// </summary>
	/// <param name="charId"></param>
	protected unsafe void AppendCharacter(int charId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = charId;
		}
	}

	/// <summary>
	/// 在当前记录中添加地点
	/// </summary>
	/// <param name="location"></param>
	protected unsafe void AppendLocation(Location location)
	{
		int offset = Size;
		int newSize = Size + 2 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(short*)num = location.AreaId;
			((short*)num)[1] = location.BlockId;
		}
	}

	/// <summary>
	/// 在当前记录中添加物品
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplateId"></param>
	protected unsafe void AppendItem(sbyte itemType, short itemTemplateId)
	{
		int offset = Size;
		int newSize = Size + 1 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*num = (byte)itemType;
			*(short*)(num + 1) = itemTemplateId;
		}
	}

	/// <summary>
	/// 在当前记录中添加功法
	/// </summary>
	/// <param name="combatSkillTemplateId"></param>
	protected unsafe void AppendCombatSkill(short combatSkillTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = combatSkillTemplateId;
		}
	}

	/// <summary>
	/// 在当前记录中添加资源
	/// </summary>
	/// <param name="resourceType"><see cref="T:GameData.Domains.Character.ResourceType" /></param>
	protected unsafe void AppendResource(sbyte resourceType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)resourceType;
		}
	}

	/// <summary>
	/// 在当前记录中添加定居点
	/// </summary>
	/// <param name="settlementId"></param>
	protected unsafe void AppendSettlement(short settlementId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = settlementId;
		}
	}

	/// <summary>
	/// 在当前记录中添加团体级别
	/// </summary>
	/// <param name="orgTemplateId"></param>
	/// <param name="orgGrade"></param>
	/// <param name="orgPrincipal"></param>
	/// <param name="gender"></param>
	protected unsafe void AppendOrgGrade(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int offset = Size;
		int newSize = Size + 1 + 1 + 1 + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*num = (byte)orgTemplateId;
			num[1] = (byte)orgGrade;
			(num + 1)[1] = (orgPrincipal ? ((byte)1) : ((byte)0));
			(num + 1 + 1)[1] = (byte)gender;
		}
	}

	/// <summary>
	/// 在当前记录中添加产业建筑
	/// </summary>
	/// <param name="buildingTemplateId"></param>
	protected unsafe void AppendBuilding(short buildingTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = buildingTemplateId;
		}
	}

	/// <summary>
	/// 在当前记录中添加剑冢
	/// </summary>
	/// <param name="xiangshuAvatarId"></param>
	protected unsafe void AppendSwordTomb(sbyte xiangshuAvatarId)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)xiangshuAvatarId;
		}
	}

	/// <summary>
	/// 在当前记录中添加紫竹化身
	/// </summary>
	/// <param name="xiangshuAvatarId"></param>
	protected unsafe void AppendJuniorXiangshu(sbyte xiangshuAvatarId)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)xiangshuAvatarId;
		}
	}

	/// <summary>
	/// 在当前记录中添加奇遇
	/// </summary>
	/// <param name="adventureCoreId"></param>
	protected unsafe void AppendAdventure(int adventureCoreId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = adventureCoreId;
		}
	}

	/// <summary>
	/// 在当前记录中添加角色立场
	/// </summary>
	/// <param name="behaviorType"></param>
	protected unsafe void AppendBehaviorType(sbyte behaviorType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)behaviorType;
		}
	}

	/// <summary>
	/// 在当前记录中添加好感类型
	/// </summary>
	/// <param name="favorabilityType"></param>
	protected unsafe void AppendFavorabilityType(sbyte favorabilityType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)favorabilityType;
		}
	}

	/// <summary>
	/// 在当前记录中添加促织
	/// </summary>
	/// <param name="colorId"></param>
	/// <param name="partId"></param>
	/// <param name="nameId"></param>
	protected unsafe void AppendCricket(short colorId, short partId, int nameId)
	{
		int offset = Size;
		int newSize = Size + 2 + 2 + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(short*)num = colorId;
			((short*)num)[1] = partId;
			*(int*)(num + 2 + 2) = nameId;
		}
	}

	/// <summary>
	/// 在当前记录中添加物品子类
	/// </summary>
	/// <param name="itemSubType"></param>
	protected unsafe void AppendItemSubType(short itemSubType)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = itemSubType;
		}
	}

	/// <summary>
	/// 在当前记录中添加鸡
	/// </summary>
	/// <param name="chickenId"></param>
	protected unsafe void AppendChicken(short chickenId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = chickenId;
		}
	}

	/// <summary>
	/// 在当前记录中添加角色属性引用类型
	/// </summary>
	/// <param name="characterPropertyReferencedType"></param>
	protected unsafe void AppendCharacterPropertyReferencedType(short characterPropertyReferencedType)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = characterPropertyReferencedType;
		}
	}

	/// <summary>
	/// 在当前记录中添加身体部位类型
	/// </summary>
	/// <param name="bodyPartType"></param>
	protected unsafe void AppendBodyPartType(sbyte bodyPartType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)bodyPartType;
		}
	}

	/// <summary>
	/// 在当前记录中添加伤势类型
	/// </summary>
	/// <param name="injuryType"></param>
	protected unsafe void AppendInjuryType(sbyte injuryType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)injuryType;
		}
	}

	/// <summary>
	/// 在当前记录中添加毒素类型
	/// </summary>
	/// <param name="poisonType"></param>
	protected unsafe void AppendPoisonType(sbyte poisonType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)poisonType;
		}
	}

	/// <summary>
	/// 在当前记录中添加角色模板
	/// </summary>
	/// <param name="templateId"></param>
	protected unsafe void AppendCharacterTemplate(short templateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = templateId;
		}
	}

	/// <summary>
	/// 在当前记录中添加角色特性模板
	/// </summary>
	/// <param name="featureId"></param>
	protected unsafe void AppendFeature(short featureId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = featureId;
		}
	}

	/// <summary>
	/// 在当前记录中添加整型数值
	/// </summary>
	/// <param name="value"></param>
	protected unsafe void AppendInteger(int value)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = value;
		}
	}

	/// <summary>
	/// 在当前记录中添加技艺模板Id
	/// </summary>
	/// <param name="lifeSkillTemplateId"></param>
	protected unsafe void AppendLifeSkill(short lifeSkillTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = lifeSkillTemplateId;
		}
	}

	/// <summary>
	/// 在当前记录中添加商会类型
	/// </summary>
	/// <param name="merchantType"></param>
	protected unsafe void AppendMerchantType(sbyte merchantType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)merchantType;
		}
	}

	/// <summary>
	/// 在当前记录中添加物品实例的Key
	/// </summary>
	/// <param name="itemKey"></param>
	protected unsafe void AppendItemKey(ulong itemKey)
	{
		int offset = Size;
		int newSize = Size + 8;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(ulong*)(pRawData + offset) = itemKey;
		}
	}

	/// <summary>
	/// 在当前记录中添加战斗类型
	/// </summary>
	/// <param name="combatType"></param>
	protected unsafe void AppendCombatType(sbyte combatType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)combatType;
		}
	}

	/// <summary>
	/// 在当前记录中添加技艺类型
	/// </summary>
	/// <param name="lifeSkillType"></param>
	protected unsafe void AppendLifeSkillType(sbyte lifeSkillType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)lifeSkillType;
		}
	}

	/// <summary>
	/// 在当前记录中添加功法类型
	/// </summary>
	/// <param name="combatSkillType"></param>
	protected unsafe void AppendCombatSkillType(sbyte combatSkillType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)combatSkillType;
		}
	}

	/// <summary>
	/// 在当前记录中添加见闻
	/// </summary>
	/// <param name="infoTemplateId"></param>
	protected unsafe void AppendInformation(short infoTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = infoTemplateId;
		}
	}

	/// <summary>
	/// 在当前记录中添加秘闻
	/// </summary>
	/// <param name="secretInfoTemplateId"></param>
	protected unsafe void AppendSecretInformationTemplate(short secretInfoTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = secretInfoTemplateId;
		}
	}

	/// <summary>
	/// 在当前记录中添加惩罚类型
	/// </summary>
	/// <param name="punishmentType"></param>
	protected unsafe void AppendPunishmentType(short punishmentType)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = punishmentType;
		}
	}

	/// <summary>
	/// 在当前记录中添加角色称号
	/// </summary>
	/// <param name="titleTemplateId"></param>
	protected unsafe void AppendCharacterTitle(short titleTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = titleTemplateId;
		}
	}

	/// <summary>
	/// 在当前记录中添加浮点数
	/// </summary>
	/// <param name="floatValue"></param>
	protected unsafe void AppendFloat(float floatValue)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(float*)(pRawData + offset) = floatValue;
		}
	}

	/// <summary>
	/// 在当前记录中添加角色真名
	/// </summary>
	/// <param name="charId"></param>
	protected void AppendCharacterRealName(int charId)
	{
		AppendCharacter(charId);
	}

	/// <summary>
	/// 在当前记录中添加月份
	/// </summary>
	/// <param name="month"></param>
	protected unsafe void AppendMonth(sbyte month)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)month;
		}
	}

	/// <summary>
	/// 在当前记录中添加志向
	/// </summary>
	/// <param name="professionTemplateId"></param>
	protected unsafe void AppendProfession(int professionTemplateId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = professionTemplateId;
		}
	}

	/// <summary>
	/// 在当前记录中添加志向技能
	/// </summary>
	/// <param name="skillTemplateId"></param>
	protected unsafe void AppendProfessionSkill(int skillTemplateId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = skillTemplateId;
		}
	}

	/// <summary>
	/// 在当前记录中添加物品品阶
	/// </summary>
	/// <param name="grade"></param>
	protected unsafe void AppendItemGrade(sbyte grade)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)grade;
		}
	}

	/// <summary>
	/// 在当前记录中添加文本
	/// </summary>
	/// <param name="value"></param>
	protected unsafe void AppendText(string value)
	{
		int offset = Size;
		int newSize = Size + 2 + value.Length * 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			SerializationHelper.Serialize(pRawData + offset, value);
		}
	}

	/// <summary>
	/// 在当前位置记录音乐模板ID
	/// </summary>
	/// <param name="musicTemplateId"></param>
	protected unsafe void AppendMusic(short musicTemplateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = musicTemplateId;
		}
	}

	/// <summary>
	/// 在当前位置记录音乐模板ID
	/// </summary>
	/// <param name="stateTemplateId"></param>
	protected unsafe void AppendMapState(sbyte stateTemplateId)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)stateTemplateId;
		}
	}

	/// <summary>
	/// 在当前位置记录蛟龙 ID
	/// </summary>
	/// <param name="jiaoLoongId"></param>
	protected unsafe void AppendJiaoLoong(int jiaoLoongId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = jiaoLoongId;
		}
	}

	/// <summary>
	/// 在当前位置记录蛟龙 ID
	/// </summary>
	/// <param name="jiaoPropertyId"></param>
	protected unsafe void AppendJiaoProperty(short jiaoPropertyId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = jiaoPropertyId;
		}
	}

	/// <summary>
	/// 在当前位置记录轮回类型
	/// </summary>
	/// <param name="destinyType"></param>
	protected unsafe void AppendDestinyType(sbyte destinyType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)destinyType;
		}
	}

	/// <summary>
	/// 在当前位置记录秘闻实例
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="id"></param>
	protected unsafe void AppendSecretInformation(short templateId, int id)
	{
		int offset = Size;
		int newSize = Size + 2 + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(short*)num = templateId;
			*(int*)(num + 2) = id;
		}
	}

	/// <summary>
	/// 在当前位置记录商店
	/// </summary>
	/// <param name="templateId"></param>
	protected unsafe void AppendMerchant(sbyte templateId)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)templateId;
		}
	}

	/// <summary>
	/// 在当前位置记录遗惠
	/// </summary>
	/// <param name="templateId"></param>
	protected unsafe void AppendLegacy(short templateId)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = templateId;
		}
	}

	/// <summary>
	/// 在当前位置记录人物品级
	/// </summary>
	/// <param name="grade"></param>
	protected unsafe void AppendCharGrade(sbyte grade)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)grade;
		}
	}

	/// <summary>
	/// 在当前位置记录宴会
	/// </summary>
	/// <param name="feast"></param>
	protected unsafe void AppendFeast(short feast)
	{
		int offset = Size;
		int newSize = Size + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset) = feast;
		}
	}

	/// <summary>
	/// 在当前位置记录奇遇元素
	/// </summary>
	/// <param name="elementCoreId"></param>
	protected unsafe void AppendAdventureElement(int elementCoreId)
	{
		int offset = Size;
		int newSize = Size + 4;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(int*)(pRawData + offset) = elementCoreId;
		}
	}

	/// <summary>
	/// 在当前位置记录七元
	/// </summary>
	/// <param name="personalityType"></param>
	protected unsafe void AppendPersonalityType(sbyte personalityType)
	{
		int offset = Size;
		int newSize = Size + 1;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)personalityType;
		}
	}
}
