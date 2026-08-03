using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Taiwu.Profession;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 地格人物列表的人物TIP所需数据
/// </summary>
/// <summary>
/// 对于引用类型字段, 构造函数中可以不创建对象, 保留默认的 null 值.
/// 在进行反序列化时, 允许所有引用类型字段都为 null.
/// 但是在序列化时, 要求所有是定长集合的引用字段都已经被创建, 且长度与定义一致. 集合中的引用类型元素若也为定长, 则也必须被创建; 变长的则可以为 null.
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class CharacterDisplayDataForMapBlock : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public byte CreatingType;

	[SerializableGameDataField]
	public NameRelatedData NameRelatedData;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public short Age;

	[SerializableGameDataField]
	public short Charm;

	[SerializableGameDataField]
	public sbyte Gender;

	/// <summary>
	/// 隐居
	/// </summary>
	[SerializableGameDataField]
	public bool IsReclusiveChar;

	[SerializableGameDataField]
	public sbyte HappinessType;

	[SerializableGameDataField]
	public sbyte BehaviorType;

	[SerializableGameDataField]
	public sbyte FameType;

	[SerializableGameDataField]
	public OrganizationInfo OrganizationInfo;

	/// <summary>
	/// 势力值
	/// </summary>
	[SerializableGameDataField]
	public int InfluencePower;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public short LeftMaxHealth;

	/// <summary>
	/// 称号ID列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> TitleIdList;

	/// <summary>
	/// 轮回
	/// </summary>
	[SerializableGameDataField]
	public short PreexistenceCharCount;

	/// <summary>
	/// 内息紊乱
	/// </summary>
	[SerializableGameDataField]
	public short DisorderOfQi;

	/// <summary>
	/// 内力五行
	/// </summary>
	[SerializableGameDataField]
	public NeiliProportionOfFiveElements NeiliProportionOfFiveElements;

	/// <summary>
	/// 精纯
	/// </summary>
	[SerializableGameDataField]
	public sbyte ConsummateLevel;

	/// <summary>
	/// 出生月份
	/// </summary>
	[SerializableGameDataField]
	public sbyte BirthMonth;

	/// <summary>
	/// 进攻
	/// </summary>
	[SerializableGameDataField]
	public int AttackMedal;

	/// <summary>
	/// 守御
	/// </summary>
	[SerializableGameDataField]
	public int DefenceMedal;

	/// <summary>
	/// 机略
	/// </summary>
	[SerializableGameDataField]
	public int WisdomMedal;

	/// <summary>
	/// 伤势
	/// </summary>
	[SerializableGameDataField]
	public Injuries Injuries;

	/// <summary>
	/// 毒素
	/// </summary>
	[SerializableGameDataField]
	public PoisonInts Poisons;

	/// <summary>
	/// 同道指令
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> TeammateCommands;

	/// <summary>
	/// 对太吾的关系的列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> RelationshipToTaiwuList;

	/// <summary>
	/// 喜恶数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterLoveAndHateItemInfo LoveAndHateItemInfo;

	/// <summary>
	/// 关联人物数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<ushort, NameAndAvatarArray> RelationshipDict;

	/// <summary>
	/// 关联人物数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<ushort, int> RelationshipCountDict;

	/// <summary>
	/// 可见互动的可用情况字典
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, bool> VisibleCharacterInteractionEventOptionDict;

	/// <summary>
	/// 临时特性剩余时间
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, int> TemporaryFeatureLeftTimes;

	/// <summary>
	/// VisibleCharacterInteractionEventOptionDict中没有正常互动的原因
	/// 0: 无效；1: 没有关系；2：敌对等状态，比如点击了只有打架的交互
	/// </summary>
	[SerializableGameDataField]
	public int NoInteractionReason;

	/// <summary>
	/// 对太吾的好感
	/// </summary>
	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	/// <summary>
	/// 对太吾的戒心
	/// </summary>
	[SerializableGameDataField]
	public int Alertness;

	/// <summary>
	/// 七元
	/// </summary>
	[SerializableGameDataField]
	public Personalities Personalities;

	/// <summary>
	/// 每个品级的已学功法的数量
	/// </summary>
	[SerializableGameDataField]
	public short[] LearnedCombatSkillCountArray;

	/// <summary>
	/// 已学的前四个最高品级内功功法
	/// </summary>
	[SerializableGameDataField]
	public short[] LearnedHighestGradeNeigongCombatSkillArray;

	/// <summary>
	/// 已学的前四个最高品级摧破功法
	/// </summary>
	[SerializableGameDataField]
	public short[] LearnedHighestGradeAttackCombatSkillArray;

	/// <summary>
	/// 已学的前四个最高品级身法功法
	/// </summary>
	[SerializableGameDataField]
	public short[] LearnedHighestGradeAgileCombatSkillArray;

	/// <summary>
	/// 已学的前四个最高品级护体功法
	/// </summary>
	[SerializableGameDataField]
	public short[] LearnedHighestGradeDefenseCombatSkillArray;

	/// <summary>
	/// 已学的前四个最高品级奇窍功法
	/// </summary>
	[SerializableGameDataField]
	public short[] LearnedHighestGradeAssistCombatSkillArray;

	/// <summary>
	/// 主属性
	/// </summary>
	[SerializableGameDataField]
	public MainAttributes MainAttributes;

	/// <summary>
	/// 当前主属性
	/// </summary>
	[SerializableGameDataField]
	public MainAttributes CurrMainAttributes;

	/// <summary>
	/// 武学资质
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	/// <summary>
	/// 武学造诣
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	/// <summary>
	/// 神力
	/// </summary>
	[SerializableGameDataField]
	public int DivinePower;

	/// <summary>
	/// 鬼术
	/// </summary>
	[SerializableGameDataField]
	public int GhostTechnique;

	/// <summary>
	/// 武学资质成长类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte CombatSkillGrowthType;

	/// <summary>
	/// 技艺资质
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	/// <summary>
	/// 技艺造诣
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	/// <summary>
	/// 技艺资质成长类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte LifeSkillGrowthType;

	/// <summary>
	/// 特性ID列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> FeatureIds;

	/// <summary>
	/// 装备
	/// </summary>
	[SerializableGameDataField]
	public ItemKey[] EquipmentArray;

	/// <summary>
	/// 物品（排除装备和书籍）
	/// </summary>
	[SerializableGameDataField]
	public ItemKey[] HighestGradeItemArray;

	/// <summary>
	/// 武学书籍
	/// </summary>
	[SerializableGameDataField]
	public ItemKey[] HighestGradeCombatSkillBookArray;

	/// <summary>
	/// 技艺书籍
	/// </summary>
	[SerializableGameDataField]
	public ItemKey[] HighestGradeLifeSkillBookArray;

	/// <summary>
	/// 每个品级可交互藏书的数量
	/// </summary>
	[SerializableGameDataField]
	public short[] SkillBookCountArray;

	/// <summary>
	/// 奇书
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> LegendaryBookTypeList;

	/// <summary>
	/// 玄灰保护状态
	/// </summary>
	[SerializableGameDataField]
	public uint DarkAshProtector;

	/// <summary>
	/// 当前志向
	/// </summary>
	[SerializableGameDataField]
	public ProfessionData CurrentProfession;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 326;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize = ((TitleIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TitleIdList.Count)));
		totalSize = ((TeammateCommands == null) ? (totalSize + 2) : (totalSize + (2 + TeammateCommands.Count)));
		totalSize = ((RelationshipToTaiwuList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * RelationshipToTaiwuList.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(RelationshipDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(RelationshipCountDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(VisibleCharacterInteractionEventOptionDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(TemporaryFeatureLeftTimes);
		totalSize = ((LearnedCombatSkillCountArray == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedCombatSkillCountArray.Length)));
		totalSize = ((LearnedHighestGradeNeigongCombatSkillArray == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedHighestGradeNeigongCombatSkillArray.Length)));
		totalSize = ((LearnedHighestGradeAttackCombatSkillArray == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedHighestGradeAttackCombatSkillArray.Length)));
		totalSize = ((LearnedHighestGradeAgileCombatSkillArray == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedHighestGradeAgileCombatSkillArray.Length)));
		totalSize = ((LearnedHighestGradeDefenseCombatSkillArray == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedHighestGradeDefenseCombatSkillArray.Length)));
		totalSize = ((LearnedHighestGradeAssistCombatSkillArray == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedHighestGradeAssistCombatSkillArray.Length)));
		totalSize = ((FeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * FeatureIds.Count)));
		totalSize = ((EquipmentArray == null) ? (totalSize + 2) : (totalSize + (2 + 8 * EquipmentArray.Length)));
		totalSize = ((HighestGradeItemArray == null) ? (totalSize + 2) : (totalSize + (2 + 8 * HighestGradeItemArray.Length)));
		totalSize = ((HighestGradeCombatSkillBookArray == null) ? (totalSize + 2) : (totalSize + (2 + 8 * HighestGradeCombatSkillBookArray.Length)));
		totalSize = ((HighestGradeLifeSkillBookArray == null) ? (totalSize + 2) : (totalSize + (2 + 8 * HighestGradeLifeSkillBookArray.Length)));
		totalSize = ((SkillBookCountArray == null) ? (totalSize + 2) : (totalSize + (2 + 2 * SkillBookCountArray.Length)));
		totalSize = ((LegendaryBookTypeList == null) ? (totalSize + 2) : (totalSize + (2 + LegendaryBookTypeList.Count)));
		totalSize = ((CurrentProfession == null) ? (totalSize + 2) : (totalSize + (2 + CurrentProfession.GetSerializedSize())));
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
		pCurrData += NameRelatedData.Serialize(pCurrData);
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
		*(short*)pCurrData = Age;
		pCurrData += 2;
		*(short*)pCurrData = Charm;
		pCurrData += 2;
		*pCurrData = (byte)Gender;
		pCurrData++;
		*pCurrData = (IsReclusiveChar ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)HappinessType;
		pCurrData++;
		*pCurrData = (byte)BehaviorType;
		pCurrData++;
		*pCurrData = (byte)FameType;
		pCurrData++;
		pCurrData += OrganizationInfo.Serialize(pCurrData);
		*(int*)pCurrData = InfluencePower;
		pCurrData += 4;
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = LeftMaxHealth;
		pCurrData += 2;
		if (TitleIdList != null)
		{
			int elementsCount = TitleIdList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = TitleIdList[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = PreexistenceCharCount;
		pCurrData += 2;
		*(short*)pCurrData = DisorderOfQi;
		pCurrData += 2;
		pCurrData += NeiliProportionOfFiveElements.Serialize(pCurrData);
		*pCurrData = (byte)ConsummateLevel;
		pCurrData++;
		*pCurrData = (byte)BirthMonth;
		pCurrData++;
		*(int*)pCurrData = AttackMedal;
		pCurrData += 4;
		*(int*)pCurrData = DefenceMedal;
		pCurrData += 4;
		*(int*)pCurrData = WisdomMedal;
		pCurrData += 4;
		pCurrData += Injuries.Serialize(pCurrData);
		pCurrData += Poisons.Serialize(pCurrData);
		if (TeammateCommands != null)
		{
			int elementsCount2 = TeammateCommands.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = (byte)TeammateCommands[j];
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RelationshipToTaiwuList != null)
		{
			int elementsCount3 = RelationshipToTaiwuList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = RelationshipToTaiwuList[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += LoveAndHateItemInfo.Serialize(pCurrData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref RelationshipDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref RelationshipCountDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref VisibleCharacterInteractionEventOptionDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref TemporaryFeatureLeftTimes);
		*(int*)pCurrData = NoInteractionReason;
		pCurrData += 4;
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		*(int*)pCurrData = Alertness;
		pCurrData += 4;
		pCurrData += Personalities.Serialize(pCurrData);
		if (LearnedCombatSkillCountArray != null)
		{
			int elementsCount4 = LearnedCombatSkillCountArray.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				((short*)pCurrData)[l] = LearnedCombatSkillCountArray[l];
			}
			pCurrData += 2 * elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LearnedHighestGradeNeigongCombatSkillArray != null)
		{
			int elementsCount5 = LearnedHighestGradeNeigongCombatSkillArray.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				((short*)pCurrData)[m] = LearnedHighestGradeNeigongCombatSkillArray[m];
			}
			pCurrData += 2 * elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LearnedHighestGradeAttackCombatSkillArray != null)
		{
			int elementsCount6 = LearnedHighestGradeAttackCombatSkillArray.Length;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				((short*)pCurrData)[n] = LearnedHighestGradeAttackCombatSkillArray[n];
			}
			pCurrData += 2 * elementsCount6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LearnedHighestGradeAgileCombatSkillArray != null)
		{
			int elementsCount7 = LearnedHighestGradeAgileCombatSkillArray.Length;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				((short*)pCurrData)[num] = LearnedHighestGradeAgileCombatSkillArray[num];
			}
			pCurrData += 2 * elementsCount7;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LearnedHighestGradeDefenseCombatSkillArray != null)
		{
			int elementsCount8 = LearnedHighestGradeDefenseCombatSkillArray.Length;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				((short*)pCurrData)[num2] = LearnedHighestGradeDefenseCombatSkillArray[num2];
			}
			pCurrData += 2 * elementsCount8;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LearnedHighestGradeAssistCombatSkillArray != null)
		{
			int elementsCount9 = LearnedHighestGradeAssistCombatSkillArray.Length;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				((short*)pCurrData)[num3] = LearnedHighestGradeAssistCombatSkillArray[num3];
			}
			pCurrData += 2 * elementsCount9;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += MainAttributes.Serialize(pCurrData);
		pCurrData += CurrMainAttributes.Serialize(pCurrData);
		pCurrData += CombatSkillQualifications.Serialize(pCurrData);
		pCurrData += CombatSkillAttainments.Serialize(pCurrData);
		*(int*)pCurrData = DivinePower;
		pCurrData += 4;
		*(int*)pCurrData = GhostTechnique;
		pCurrData += 4;
		*pCurrData = (byte)CombatSkillGrowthType;
		pCurrData++;
		pCurrData += LifeSkillQualifications.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		*pCurrData = (byte)LifeSkillGrowthType;
		pCurrData++;
		if (FeatureIds != null)
		{
			int elementsCount10 = FeatureIds.Count;
			Tester.Assert(elementsCount10 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount10;
			pCurrData += 2;
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				((short*)pCurrData)[num4] = FeatureIds[num4];
			}
			pCurrData += 2 * elementsCount10;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (EquipmentArray != null)
		{
			int elementsCount11 = EquipmentArray.Length;
			Tester.Assert(elementsCount11 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount11;
			pCurrData += 2;
			for (int num5 = 0; num5 < elementsCount11; num5++)
			{
				pCurrData += EquipmentArray[num5].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (HighestGradeItemArray != null)
		{
			int elementsCount12 = HighestGradeItemArray.Length;
			Tester.Assert(elementsCount12 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount12;
			pCurrData += 2;
			for (int num6 = 0; num6 < elementsCount12; num6++)
			{
				pCurrData += HighestGradeItemArray[num6].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (HighestGradeCombatSkillBookArray != null)
		{
			int elementsCount13 = HighestGradeCombatSkillBookArray.Length;
			Tester.Assert(elementsCount13 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount13;
			pCurrData += 2;
			for (int num7 = 0; num7 < elementsCount13; num7++)
			{
				pCurrData += HighestGradeCombatSkillBookArray[num7].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (HighestGradeLifeSkillBookArray != null)
		{
			int elementsCount14 = HighestGradeLifeSkillBookArray.Length;
			Tester.Assert(elementsCount14 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount14;
			pCurrData += 2;
			for (int num8 = 0; num8 < elementsCount14; num8++)
			{
				pCurrData += HighestGradeLifeSkillBookArray[num8].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SkillBookCountArray != null)
		{
			int elementsCount15 = SkillBookCountArray.Length;
			Tester.Assert(elementsCount15 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount15;
			pCurrData += 2;
			for (int num9 = 0; num9 < elementsCount15; num9++)
			{
				((short*)pCurrData)[num9] = SkillBookCountArray[num9];
			}
			pCurrData += 2 * elementsCount15;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LegendaryBookTypeList != null)
		{
			int elementsCount16 = LegendaryBookTypeList.Count;
			Tester.Assert(elementsCount16 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount16;
			pCurrData += 2;
			for (int num10 = 0; num10 < elementsCount16; num10++)
			{
				pCurrData[num10] = (byte)LegendaryBookTypeList[num10];
			}
			pCurrData += elementsCount16;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(uint*)pCurrData = DarkAshProtector;
		pCurrData += 4;
		if (CurrentProfession != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = CurrentProfession.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CreatingType = *pCurrData;
		pCurrData++;
		pCurrData += NameRelatedData.Deserialize(pCurrData);
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
		Age = *(short*)pCurrData;
		pCurrData += 2;
		Charm = *(short*)pCurrData;
		pCurrData += 2;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		IsReclusiveChar = *pCurrData != 0;
		pCurrData++;
		HappinessType = (sbyte)(*pCurrData);
		pCurrData++;
		BehaviorType = (sbyte)(*pCurrData);
		pCurrData++;
		FameType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += OrganizationInfo.Deserialize(pCurrData);
		InfluencePower = *(int*)pCurrData;
		pCurrData += 4;
		Health = *(short*)pCurrData;
		pCurrData += 2;
		LeftMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (TitleIdList == null)
			{
				TitleIdList = new List<short>(elementsCount);
			}
			else
			{
				TitleIdList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				TitleIdList.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			TitleIdList?.Clear();
		}
		PreexistenceCharCount = *(short*)pCurrData;
		pCurrData += 2;
		DisorderOfQi = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += NeiliProportionOfFiveElements.Deserialize(pCurrData);
		ConsummateLevel = (sbyte)(*pCurrData);
		pCurrData++;
		BirthMonth = (sbyte)(*pCurrData);
		pCurrData++;
		AttackMedal = *(int*)pCurrData;
		pCurrData += 4;
		DefenceMedal = *(int*)pCurrData;
		pCurrData += 4;
		WisdomMedal = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Injuries.Deserialize(pCurrData);
		pCurrData += Poisons.Deserialize(pCurrData);
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (TeammateCommands == null)
			{
				TeammateCommands = new List<sbyte>(elementsCount2);
			}
			else
			{
				TeammateCommands.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				TeammateCommands.Add((sbyte)pCurrData[j]);
			}
			pCurrData += (int)elementsCount2;
		}
		else
		{
			TeammateCommands?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (RelationshipToTaiwuList == null)
			{
				RelationshipToTaiwuList = new List<short>(elementsCount3);
			}
			else
			{
				RelationshipToTaiwuList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				RelationshipToTaiwuList.Add(((short*)pCurrData)[k]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			RelationshipToTaiwuList?.Clear();
		}
		if (LoveAndHateItemInfo == null)
		{
			LoveAndHateItemInfo = new CharacterLoveAndHateItemInfo();
		}
		pCurrData += LoveAndHateItemInfo.Deserialize(pCurrData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref RelationshipDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref RelationshipCountDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref VisibleCharacterInteractionEventOptionDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref TemporaryFeatureLeftTimes);
		NoInteractionReason = *(int*)pCurrData;
		pCurrData += 4;
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		Alertness = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Personalities.Deserialize(pCurrData);
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (LearnedCombatSkillCountArray == null || LearnedCombatSkillCountArray.Length != elementsCount4)
			{
				LearnedCombatSkillCountArray = new short[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				LearnedCombatSkillCountArray[l] = ((short*)pCurrData)[l];
			}
			pCurrData += 2 * elementsCount4;
		}
		else
		{
			LearnedCombatSkillCountArray = null;
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (LearnedHighestGradeNeigongCombatSkillArray == null || LearnedHighestGradeNeigongCombatSkillArray.Length != elementsCount5)
			{
				LearnedHighestGradeNeigongCombatSkillArray = new short[elementsCount5];
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				LearnedHighestGradeNeigongCombatSkillArray[m] = ((short*)pCurrData)[m];
			}
			pCurrData += 2 * elementsCount5;
		}
		else
		{
			LearnedHighestGradeNeigongCombatSkillArray = null;
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (LearnedHighestGradeAttackCombatSkillArray == null || LearnedHighestGradeAttackCombatSkillArray.Length != elementsCount6)
			{
				LearnedHighestGradeAttackCombatSkillArray = new short[elementsCount6];
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				LearnedHighestGradeAttackCombatSkillArray[n] = ((short*)pCurrData)[n];
			}
			pCurrData += 2 * elementsCount6;
		}
		else
		{
			LearnedHighestGradeAttackCombatSkillArray = null;
		}
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (LearnedHighestGradeAgileCombatSkillArray == null || LearnedHighestGradeAgileCombatSkillArray.Length != elementsCount7)
			{
				LearnedHighestGradeAgileCombatSkillArray = new short[elementsCount7];
			}
			for (int num2 = 0; num2 < elementsCount7; num2++)
			{
				LearnedHighestGradeAgileCombatSkillArray[num2] = ((short*)pCurrData)[num2];
			}
			pCurrData += 2 * elementsCount7;
		}
		else
		{
			LearnedHighestGradeAgileCombatSkillArray = null;
		}
		ushort elementsCount8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount8 > 0)
		{
			if (LearnedHighestGradeDefenseCombatSkillArray == null || LearnedHighestGradeDefenseCombatSkillArray.Length != elementsCount8)
			{
				LearnedHighestGradeDefenseCombatSkillArray = new short[elementsCount8];
			}
			for (int num3 = 0; num3 < elementsCount8; num3++)
			{
				LearnedHighestGradeDefenseCombatSkillArray[num3] = ((short*)pCurrData)[num3];
			}
			pCurrData += 2 * elementsCount8;
		}
		else
		{
			LearnedHighestGradeDefenseCombatSkillArray = null;
		}
		ushort elementsCount9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount9 > 0)
		{
			if (LearnedHighestGradeAssistCombatSkillArray == null || LearnedHighestGradeAssistCombatSkillArray.Length != elementsCount9)
			{
				LearnedHighestGradeAssistCombatSkillArray = new short[elementsCount9];
			}
			for (int num4 = 0; num4 < elementsCount9; num4++)
			{
				LearnedHighestGradeAssistCombatSkillArray[num4] = ((short*)pCurrData)[num4];
			}
			pCurrData += 2 * elementsCount9;
		}
		else
		{
			LearnedHighestGradeAssistCombatSkillArray = null;
		}
		pCurrData += MainAttributes.Deserialize(pCurrData);
		pCurrData += CurrMainAttributes.Deserialize(pCurrData);
		pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		pCurrData += CombatSkillAttainments.Deserialize(pCurrData);
		DivinePower = *(int*)pCurrData;
		pCurrData += 4;
		GhostTechnique = *(int*)pCurrData;
		pCurrData += 4;
		CombatSkillGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		LifeSkillGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount10 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount10 > 0)
		{
			if (FeatureIds == null)
			{
				FeatureIds = new List<short>(elementsCount10);
			}
			else
			{
				FeatureIds.Clear();
			}
			for (int num5 = 0; num5 < elementsCount10; num5++)
			{
				FeatureIds.Add(((short*)pCurrData)[num5]);
			}
			pCurrData += 2 * elementsCount10;
		}
		else
		{
			FeatureIds?.Clear();
		}
		ushort elementsCount11 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount11 > 0)
		{
			if (EquipmentArray == null || EquipmentArray.Length != elementsCount11)
			{
				EquipmentArray = new ItemKey[elementsCount11];
			}
			for (int num6 = 0; num6 < elementsCount11; num6++)
			{
				ItemKey element = default(ItemKey);
				pCurrData += element.Deserialize(pCurrData);
				EquipmentArray[num6] = element;
			}
		}
		else
		{
			EquipmentArray = null;
		}
		ushort elementsCount12 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount12 > 0)
		{
			if (HighestGradeItemArray == null || HighestGradeItemArray.Length != elementsCount12)
			{
				HighestGradeItemArray = new ItemKey[elementsCount12];
			}
			for (int num7 = 0; num7 < elementsCount12; num7++)
			{
				ItemKey element2 = default(ItemKey);
				pCurrData += element2.Deserialize(pCurrData);
				HighestGradeItemArray[num7] = element2;
			}
		}
		else
		{
			HighestGradeItemArray = null;
		}
		ushort elementsCount13 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount13 > 0)
		{
			if (HighestGradeCombatSkillBookArray == null || HighestGradeCombatSkillBookArray.Length != elementsCount13)
			{
				HighestGradeCombatSkillBookArray = new ItemKey[elementsCount13];
			}
			for (int num8 = 0; num8 < elementsCount13; num8++)
			{
				ItemKey element3 = default(ItemKey);
				pCurrData += element3.Deserialize(pCurrData);
				HighestGradeCombatSkillBookArray[num8] = element3;
			}
		}
		else
		{
			HighestGradeCombatSkillBookArray = null;
		}
		ushort elementsCount14 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount14 > 0)
		{
			if (HighestGradeLifeSkillBookArray == null || HighestGradeLifeSkillBookArray.Length != elementsCount14)
			{
				HighestGradeLifeSkillBookArray = new ItemKey[elementsCount14];
			}
			for (int num9 = 0; num9 < elementsCount14; num9++)
			{
				ItemKey element4 = default(ItemKey);
				pCurrData += element4.Deserialize(pCurrData);
				HighestGradeLifeSkillBookArray[num9] = element4;
			}
		}
		else
		{
			HighestGradeLifeSkillBookArray = null;
		}
		ushort elementsCount15 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount15 > 0)
		{
			if (SkillBookCountArray == null || SkillBookCountArray.Length != elementsCount15)
			{
				SkillBookCountArray = new short[elementsCount15];
			}
			for (int num10 = 0; num10 < elementsCount15; num10++)
			{
				SkillBookCountArray[num10] = ((short*)pCurrData)[num10];
			}
			pCurrData += 2 * elementsCount15;
		}
		else
		{
			SkillBookCountArray = null;
		}
		ushort elementsCount16 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount16 > 0)
		{
			if (LegendaryBookTypeList == null)
			{
				LegendaryBookTypeList = new List<sbyte>(elementsCount16);
			}
			else
			{
				LegendaryBookTypeList.Clear();
			}
			for (int num11 = 0; num11 < elementsCount16; num11++)
			{
				LegendaryBookTypeList.Add((sbyte)pCurrData[num11]);
			}
			pCurrData += (int)elementsCount16;
		}
		else
		{
			LegendaryBookTypeList?.Clear();
		}
		DarkAshProtector = *(uint*)pCurrData;
		pCurrData += 4;
		ushort num12 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num12 > 0)
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
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
