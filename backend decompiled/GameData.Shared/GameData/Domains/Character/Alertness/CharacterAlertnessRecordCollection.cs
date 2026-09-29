using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Character.Alertness;

public class CharacterAlertnessRecordCollection : WriteableRecordCollection
{
	public void GetRenderInfos(List<CharacterAlertnessRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			CharacterAlertnessRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	public unsafe short GetRecordType(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return ((short*)(pRawData + offset + 1))[2];
		}
	}

	private unsafe int GetDate(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return *(int*)(pRawData + offset + 1);
		}
	}

	public new unsafe CharacterAlertnessRecordRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			CharacterAlertnessRecordItem config = CharacterAlertnessRecord.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			CharacterAlertnessRecordRenderInfo info = new CharacterAlertnessRecordRenderInfo(recordType, config.Desc, date);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadonlyRecordCollection.ReadArgumentAndGetIndex(paramType, &pCurrData, argumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			return info;
		}
	}

	private unsafe int BeginAddingRecord(int date, short recordType)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = date;
			((short*)(num + 1))[2] = recordType;
		}
		return offset;
	}

	public int AddCharBehaviorType(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 0);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCharGrade(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddOrganizationApprove(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 2);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTaiwuFame(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 3);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddChallengeFame(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 56);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddChallengeBehavior(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 57);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSendGif(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 4);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGiveTeammateResource(int date, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 5);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGiveTeammateItem(int date, sbyte itemType, short itemTemplateId, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 6);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTalkByNormalInformation(int date, short infoTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 7);
		AppendInformation(infoTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPraiseSevenElement(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 8);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPraiseCharm(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 9);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPraiseFame(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 10);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPraiseFeature(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 11);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPraiseMoney(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 12);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSneerSevenElement(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 13);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSneerCharm(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 14);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSneerFame(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 15);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSneerFeature(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 16);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSneerMoney(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 17);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddMakeLineAndBridge(int date, int charId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 18);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionWineTasterSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 19);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionWineTasterSkill3(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 20);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionLiteratiSkill3(int date, short infoTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 21);
		AppendInformation(infoTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionTaoistMonkSkill1(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 22);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionAristocratSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 23);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionAristocratSkill1(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 24);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionBeggarSkill3(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 25);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionCivilianSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 26);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionCivilianSkill1(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 27);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionDoctorSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 28);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionDoctorSkill1(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 29);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionDoctorSkill3(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 30);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionTeaTasterSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 31);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionTeaTasterSkill3(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 32);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionDukeSkill1Add(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 33);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionMartialArtistSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 34);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionCivilianSkill2(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 35);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddProfessionDukeSkill1Remove(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 36);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTakeTeammateResource(int date, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 37);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTakeTeammateItem(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 38);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStealLifeSkill(int date, short lifeSkillTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 39);
		AppendLifeSkill(lifeSkillTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStealCombatSkill(int date, short lifeSkillTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 40);
		AppendLifeSkill(lifeSkillTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamLifeSkill(int date, short lifeSkillTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 41);
		AppendLifeSkill(lifeSkillTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamCombatSkill(int date, short lifeSkillTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 42);
		AppendLifeSkill(lifeSkillTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamItem(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 43);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamResource(int date, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 44);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamNormalInformation(int date, short infoTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 45);
		AppendInformation(infoTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddScamSecretInformation(int date, short secretInfoTemplateId, int secretInfoId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 46);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStealItem(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 47);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStealResource(int date, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 48);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRobItem(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 49);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRobResource(int date, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 50);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPoison(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 51);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddDamage(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 52);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAttack(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 53);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddAttackKidnappedCharacter(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 54);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRemoveKidnappedCharacter(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 55);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBase(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 58);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
