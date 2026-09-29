using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Taiwu.Profession;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
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

	[SerializableGameDataField]
	public int InfluencePower;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public short LeftMaxHealth;

	[SerializableGameDataField]
	public List<short> TitleIdList;

	[SerializableGameDataField]
	public short PreexistenceCharCount;

	[SerializableGameDataField]
	public short DisorderOfQi;

	[SerializableGameDataField]
	public NeiliProportionOfFiveElements NeiliProportionOfFiveElements;

	[SerializableGameDataField]
	public sbyte ConsummateLevel;

	[SerializableGameDataField]
	public sbyte BirthMonth;

	[SerializableGameDataField]
	public int AttackMedal;

	[SerializableGameDataField]
	public int DefenceMedal;

	[SerializableGameDataField]
	public int WisdomMedal;

	[SerializableGameDataField]
	public Injuries Injuries;

	[SerializableGameDataField]
	public PoisonInts Poisons;

	[SerializableGameDataField]
	public List<sbyte> TeammateCommands;

	[SerializableGameDataField]
	public List<short> RelationshipToTaiwuList;

	[SerializableGameDataField]
	public CharacterLoveAndHateItemInfo LoveAndHateItemInfo;

	[SerializableGameDataField]
	public Dictionary<ushort, NameAndAvatarArray> RelationshipDict;

	[SerializableGameDataField]
	public Dictionary<ushort, int> RelationshipCountDict;

	[SerializableGameDataField]
	public Dictionary<short, bool> VisibleCharacterInteractionEventOptionDict;

	[SerializableGameDataField]
	public Dictionary<short, int> TemporaryFeatureLeftTimes;

	[SerializableGameDataField]
	public int NoInteractionReason;

	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	[SerializableGameDataField]
	public int Alertness;

	[SerializableGameDataField]
	public Personalities Personalities;

	[SerializableGameDataField]
	public short[] LearnedCombatSkillCountArray;

	[SerializableGameDataField]
	public short[] LearnedHighestGradeNeigongCombatSkillArray;

	[SerializableGameDataField]
	public short[] LearnedHighestGradeAttackCombatSkillArray;

	[SerializableGameDataField]
	public short[] LearnedHighestGradeAgileCombatSkillArray;

	[SerializableGameDataField]
	public short[] LearnedHighestGradeDefenseCombatSkillArray;

	[SerializableGameDataField]
	public short[] LearnedHighestGradeAssistCombatSkillArray;

	[SerializableGameDataField]
	public MainAttributes MainAttributes;

	[SerializableGameDataField]
	public MainAttributes CurrMainAttributes;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	[SerializableGameDataField]
	public int DivinePower;

	[SerializableGameDataField]
	public int GhostTechnique;

	[SerializableGameDataField]
	public sbyte CombatSkillGrowthType;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public sbyte LifeSkillGrowthType;

	[SerializableGameDataField]
	public List<short> FeatureIds;

	[SerializableGameDataField]
	public ItemKey[] EquipmentArray;

	[SerializableGameDataField]
	public ItemKey[] HighestGradeItemArray;

	[SerializableGameDataField]
	public ItemKey[] HighestGradeCombatSkillBookArray;

	[SerializableGameDataField]
	public ItemKey[] HighestGradeLifeSkillBookArray;

	[SerializableGameDataField]
	public short[] SkillBookCountArray;

	[SerializableGameDataField]
	public List<sbyte> LegendaryBookTypeList;

	[SerializableGameDataField]
	public uint DarkAshProtector;

	[SerializableGameDataField]
	public ProfessionData CurrentProfession;

	[SerializableGameDataField]
	public bool IsXiangshuInfectedDemon;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 327;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize = ((TitleIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TitleIdList.Count)));
		totalSize = ((TeammateCommands == null) ? (totalSize + 2) : (totalSize + (2 + TeammateCommands.Count)));
		totalSize = ((RelationshipToTaiwuList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * RelationshipToTaiwuList.Count)));
		totalSize += 4;
		if (RelationshipDict != null)
		{
			foreach (KeyValuePair<ushort, NameAndAvatarArray> pair in RelationshipDict)
			{
				totalSize += 2;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (RelationshipCountDict != null)
		{
			foreach (KeyValuePair<ushort, int> item in RelationshipCountDict)
			{
				_ = item;
				totalSize += 2;
				totalSize += 4;
			}
		}
		totalSize += 4;
		if (VisibleCharacterInteractionEventOptionDict != null)
		{
			foreach (KeyValuePair<short, bool> item2 in VisibleCharacterInteractionEventOptionDict)
			{
				_ = item2;
				totalSize += 2;
				totalSize++;
			}
		}
		totalSize += 4;
		if (TemporaryFeatureLeftTimes != null)
		{
			foreach (KeyValuePair<short, int> temporaryFeatureLeftTime in TemporaryFeatureLeftTimes)
			{
				_ = temporaryFeatureLeftTime;
				totalSize += 2;
				totalSize += 4;
			}
		}
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
				*(short*)pCurrData = TitleIdList[i];
				pCurrData += 2;
			}
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
				*pCurrData = (byte)TeammateCommands[j];
				pCurrData++;
			}
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
				*(short*)pCurrData = RelationshipToTaiwuList[k];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += LoveAndHateItemInfo.Serialize(pCurrData);
		if (RelationshipDict != null)
		{
			*(int*)pCurrData = RelationshipDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<ushort, NameAndAvatarArray> pair in RelationshipDict)
			{
				*(ushort*)pCurrData = pair.Key;
				pCurrData += 2;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (RelationshipCountDict != null)
		{
			*(int*)pCurrData = RelationshipCountDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<ushort, int> pair2 in RelationshipCountDict)
			{
				*(ushort*)pCurrData = pair2.Key;
				pCurrData += 2;
				*(int*)pCurrData = pair2.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (VisibleCharacterInteractionEventOptionDict != null)
		{
			*(int*)pCurrData = VisibleCharacterInteractionEventOptionDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, bool> pair3 in VisibleCharacterInteractionEventOptionDict)
			{
				*(short*)pCurrData = pair3.Key;
				pCurrData += 2;
				*pCurrData = (pair3.Value ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (TemporaryFeatureLeftTimes != null)
		{
			*(int*)pCurrData = TemporaryFeatureLeftTimes.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, int> pair4 in TemporaryFeatureLeftTimes)
			{
				*(short*)pCurrData = pair4.Key;
				pCurrData += 2;
				*(int*)pCurrData = pair4.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
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
				*(short*)pCurrData = LearnedCombatSkillCountArray[l];
				pCurrData += 2;
			}
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
				*(short*)pCurrData = LearnedHighestGradeNeigongCombatSkillArray[m];
				pCurrData += 2;
			}
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
				*(short*)pCurrData = LearnedHighestGradeAttackCombatSkillArray[n];
				pCurrData += 2;
			}
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
				*(short*)pCurrData = LearnedHighestGradeAgileCombatSkillArray[num];
				pCurrData += 2;
			}
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
				*(short*)pCurrData = LearnedHighestGradeDefenseCombatSkillArray[num2];
				pCurrData += 2;
			}
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
				*(short*)pCurrData = LearnedHighestGradeAssistCombatSkillArray[num3];
				pCurrData += 2;
			}
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
				*(short*)pCurrData = FeatureIds[num4];
				pCurrData += 2;
			}
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
				*(short*)pCurrData = SkillBookCountArray[num9];
				pCurrData += 2;
			}
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
				*pCurrData = (byte)LegendaryBookTypeList[num10];
				pCurrData++;
			}
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
		*pCurrData = (IsXiangshuInfectedDemon ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
			AvatarRelatedData = new AvatarRelatedData();
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
				TitleIdList = new List<short>();
			}
			else
			{
				TitleIdList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				TitleIdList.Add(element);
			}
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
				TeammateCommands = new List<sbyte>();
			}
			else
			{
				TeammateCommands.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				sbyte element2 = (sbyte)(*pCurrData);
				pCurrData++;
				TeammateCommands.Add(element2);
			}
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
				RelationshipToTaiwuList = new List<short>();
			}
			else
			{
				RelationshipToTaiwuList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				short element3 = *(short*)pCurrData;
				pCurrData += 2;
				RelationshipToTaiwuList.Add(element3);
			}
		}
		else
		{
			RelationshipToTaiwuList?.Clear();
		}
		LoveAndHateItemInfo = new CharacterLoveAndHateItemInfo();
		pCurrData += LoveAndHateItemInfo.Deserialize(pCurrData);
		int RelationshipDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (RelationshipDictElementsCount > 0)
		{
			if (RelationshipDict == null)
			{
				RelationshipDict = new Dictionary<ushort, NameAndAvatarArray>();
			}
			else
			{
				RelationshipDict.Clear();
			}
			for (int l = 0; l < RelationshipDictElementsCount; l++)
			{
				ushort key = *(ushort*)pCurrData;
				pCurrData += 2;
				NameAndAvatarArray value = default(NameAndAvatarArray);
				pCurrData += value.Deserialize(pCurrData);
				RelationshipDict.Add(key, value);
			}
		}
		else
		{
			RelationshipDict?.Clear();
		}
		int RelationshipCountDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (RelationshipCountDictElementsCount > 0)
		{
			if (RelationshipCountDict == null)
			{
				RelationshipCountDict = new Dictionary<ushort, int>();
			}
			else
			{
				RelationshipCountDict.Clear();
			}
			for (int m = 0; m < RelationshipCountDictElementsCount; m++)
			{
				ushort key2 = *(ushort*)pCurrData;
				pCurrData += 2;
				int value2 = *(int*)pCurrData;
				pCurrData += 4;
				RelationshipCountDict.Add(key2, value2);
			}
		}
		else
		{
			RelationshipCountDict?.Clear();
		}
		int VisibleCharacterInteractionEventOptionDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (VisibleCharacterInteractionEventOptionDictElementsCount > 0)
		{
			if (VisibleCharacterInteractionEventOptionDict == null)
			{
				VisibleCharacterInteractionEventOptionDict = new Dictionary<short, bool>();
			}
			else
			{
				VisibleCharacterInteractionEventOptionDict.Clear();
			}
			for (int n = 0; n < VisibleCharacterInteractionEventOptionDictElementsCount; n++)
			{
				short key3 = *(short*)pCurrData;
				pCurrData += 2;
				bool value3 = *pCurrData != 0;
				pCurrData++;
				VisibleCharacterInteractionEventOptionDict.Add(key3, value3);
			}
		}
		else
		{
			VisibleCharacterInteractionEventOptionDict?.Clear();
		}
		int TemporaryFeatureLeftTimesElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (TemporaryFeatureLeftTimesElementsCount > 0)
		{
			if (TemporaryFeatureLeftTimes == null)
			{
				TemporaryFeatureLeftTimes = new Dictionary<short, int>();
			}
			else
			{
				TemporaryFeatureLeftTimes.Clear();
			}
			for (int num2 = 0; num2 < TemporaryFeatureLeftTimesElementsCount; num2++)
			{
				short key4 = *(short*)pCurrData;
				pCurrData += 2;
				int value4 = *(int*)pCurrData;
				pCurrData += 4;
				TemporaryFeatureLeftTimes.Add(key4, value4);
			}
		}
		else
		{
			TemporaryFeatureLeftTimes?.Clear();
		}
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
			for (int num3 = 0; num3 < elementsCount4; num3++)
			{
				LearnedCombatSkillCountArray[num3] = *(short*)pCurrData;
				pCurrData += 2;
			}
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
			for (int num4 = 0; num4 < elementsCount5; num4++)
			{
				LearnedHighestGradeNeigongCombatSkillArray[num4] = *(short*)pCurrData;
				pCurrData += 2;
			}
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
			for (int num5 = 0; num5 < elementsCount6; num5++)
			{
				LearnedHighestGradeAttackCombatSkillArray[num5] = *(short*)pCurrData;
				pCurrData += 2;
			}
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
			for (int num6 = 0; num6 < elementsCount7; num6++)
			{
				LearnedHighestGradeAgileCombatSkillArray[num6] = *(short*)pCurrData;
				pCurrData += 2;
			}
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
			for (int num7 = 0; num7 < elementsCount8; num7++)
			{
				LearnedHighestGradeDefenseCombatSkillArray[num7] = *(short*)pCurrData;
				pCurrData += 2;
			}
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
			for (int num8 = 0; num8 < elementsCount9; num8++)
			{
				LearnedHighestGradeAssistCombatSkillArray[num8] = *(short*)pCurrData;
				pCurrData += 2;
			}
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
				FeatureIds = new List<short>();
			}
			else
			{
				FeatureIds.Clear();
			}
			for (int num9 = 0; num9 < elementsCount10; num9++)
			{
				short element4 = *(short*)pCurrData;
				pCurrData += 2;
				FeatureIds.Add(element4);
			}
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
			for (int num10 = 0; num10 < elementsCount11; num10++)
			{
				EquipmentArray[num10] = default(ItemKey);
				pCurrData += EquipmentArray[num10].Deserialize(pCurrData);
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
			for (int num11 = 0; num11 < elementsCount12; num11++)
			{
				HighestGradeItemArray[num11] = default(ItemKey);
				pCurrData += HighestGradeItemArray[num11].Deserialize(pCurrData);
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
			for (int num12 = 0; num12 < elementsCount13; num12++)
			{
				HighestGradeCombatSkillBookArray[num12] = default(ItemKey);
				pCurrData += HighestGradeCombatSkillBookArray[num12].Deserialize(pCurrData);
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
			for (int num13 = 0; num13 < elementsCount14; num13++)
			{
				HighestGradeLifeSkillBookArray[num13] = default(ItemKey);
				pCurrData += HighestGradeLifeSkillBookArray[num13].Deserialize(pCurrData);
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
			for (int num14 = 0; num14 < elementsCount15; num14++)
			{
				SkillBookCountArray[num14] = *(short*)pCurrData;
				pCurrData += 2;
			}
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
				LegendaryBookTypeList = new List<sbyte>();
			}
			else
			{
				LegendaryBookTypeList.Clear();
			}
			for (int num15 = 0; num15 < elementsCount16; num15++)
			{
				sbyte element5 = (sbyte)(*pCurrData);
				pCurrData++;
				LegendaryBookTypeList.Add(element5);
			}
		}
		else
		{
			LegendaryBookTypeList?.Clear();
		}
		DarkAshProtector = *(uint*)pCurrData;
		pCurrData += 4;
		ushort num16 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num16 > 0)
		{
			CurrentProfession = new ProfessionData();
			pCurrData += CurrentProfession.Deserialize(pCurrData);
		}
		else
		{
			CurrentProfession = null;
		}
		IsXiangshuInfectedDemon = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
