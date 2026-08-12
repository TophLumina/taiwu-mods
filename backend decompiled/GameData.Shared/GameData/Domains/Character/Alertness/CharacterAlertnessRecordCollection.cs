using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Character.Alertness;

/// <summary>
/// 戒心记录集合
/// </summary>
/// <summary>
/// 人物戒心的集合
/// </summary>
public class CharacterAlertnessRecordCollection : WriteableRecordCollection
{
	/// <summary>
	/// 获取所有戒心记录的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
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

	/// <summary>
	/// 获取指定位置上的记录类型（即戒心记录模板ID）
	/// </summary>
	/// <param name="offset"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取指定索引的戒心记录的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
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

	/// <summary>
	/// 开始添加戒心记录
	/// </summary>
	/// <param name="date">经历发生的日期</param>
	/// <param name="recordType">过月通知类型</param>
	/// <returns>当前过月通知的起始偏移</returns>
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

	/// <summary>
	/// 添加人物戒心记录 - 人物立场
	/// 双方立场{0}
	/// </summary>
	public int AddCharBehaviorType(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 0);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 人物身份
	/// 人物身份{0}
	/// </summary>
	public int AddCharGrade(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 门派支持度
	/// 门派支持度{0}
	/// </summary>
	public int AddOrganizationApprove(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 2);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 太吾名誉
	/// 太吾名誉{0}
	/// </summary>
	public int AddTaiwuFame(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 3);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 名誉不同
	/// 因名誉不同，受人以群分词条影响，戒心{0}
	/// </summary>
	public int AddChallengeFame(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 56);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 立场不同
	/// 因立场不同，受人以群分词条影响，戒心{0}
	/// </summary>
	public int AddChallengeBehavior(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 57);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 送礼
	/// 赠送礼物{0}{1}
	/// </summary>
	public int AddSendGif(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 4);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 转赠同道资源
	/// 赠送资源{0}{1}{2}
	/// </summary>
	public int AddGiveTeammateResource(int date, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 5);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 转赠同道物品
	/// 赠送礼物{0}{1}{2}
	/// </summary>
	public int AddGiveTeammateItem(int date, sbyte itemType, short itemTemplateId, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 6);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 见闻闲谈
	/// 见闻闲谈{0}{1}
	/// </summary>
	public int AddTalkByNormalInformation(int date, short infoTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 7);
		AppendInformation(infoTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 赞颂夸奖
	/// 赞颂夸奖赋性{0}
	/// </summary>
	public int AddPraiseSevenElement(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 8);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 赞颂夸奖
	/// 赞颂夸奖魅力{0}
	/// </summary>
	public int AddPraiseCharm(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 9);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 赞颂夸奖
	/// 赞颂夸奖名誉{0}
	/// </summary>
	public int AddPraiseFame(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 10);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 赞颂夸奖
	/// 赞颂夸奖特性{0}
	/// </summary>
	public int AddPraiseFeature(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 11);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 赞颂夸奖
	/// 赞颂夸奖财富{0}
	/// </summary>
	public int AddPraiseMoney(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 12);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 羞辱指责
	/// 羞辱指责赋性{0}
	/// </summary>
	public int AddSneerSevenElement(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 13);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 羞辱指责
	/// 羞辱指责魅力{0}
	/// </summary>
	public int AddSneerCharm(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 14);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 羞辱指责
	/// 羞辱指责名誉{0}
	/// </summary>
	public int AddSneerFame(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 15);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 羞辱指责
	/// 羞辱指责特性{0}
	/// </summary>
	public int AddSneerFeature(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 16);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 羞辱指责
	/// 羞辱指责财富{0}
	/// </summary>
	public int AddSneerMoney(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 17);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 牵线搭桥
	/// 牵线搭桥{0}{1}
	/// </summary>
	public int AddMakeLineAndBridge(int date, int charId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 18);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 拼豪斗酒
	/// 拼豪斗酒{0}
	/// </summary>
	public int AddProfessionWineTasterSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 19);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 豪侠研武
	/// 豪侠研武{0}
	/// </summary>
	public int AddProfessionWineTasterSkill3(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 20);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 谈天说地
	/// 谈天说地{0}{1}
	/// </summary>
	public int AddProfessionLiteratiSkill3(int date, short infoTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 21);
		AppendInformation(infoTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 驱邪法事
	/// 驱邪法事{0}
	/// </summary>
	public int AddProfessionTaoistMonkSkill1(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 22);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 扶助保荐
	/// 扶助保荐{0}
	/// </summary>
	public int AddProfessionAristocratSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 23);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 采擢荐进
	/// 采擢荐进{0}
	/// </summary>
	public int AddProfessionAristocratSkill1(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 24);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 天地为食
	/// 天地为食{0}{1}
	/// </summary>
	public int AddProfessionBeggarSkill3(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 25);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 乡亲父老
	/// 乡亲父老{0}
	/// </summary>
	public int AddProfessionCivilianSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 26);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 安居乐业
	/// 安居乐业{0}
	/// </summary>
	public int AddProfessionCivilianSkill1(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 27);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 看诊施药
	/// 看诊施药{0}
	/// </summary>
	public int AddProfessionDoctorSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 28);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 游医义诊
	/// 游医义诊{0}
	/// </summary>
	public int AddProfessionDoctorSkill1(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 29);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 金针渡命
	/// 金针渡命{0}
	/// </summary>
	public int AddProfessionDoctorSkill3(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 30);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 评水品茗
	/// 评水品茗{0}
	/// </summary>
	public int AddProfessionTeaTasterSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 31);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 仙人泼墨
	/// 仙人泼墨{0}
	/// </summary>
	public int AddProfessionTeaTasterSkill3(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 32);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 封侯拜相添加
	/// 封侯拜相{0}
	/// </summary>
	public int AddProfessionDukeSkill1Add(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 33);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 江湖中人
	/// 江湖中人{0}
	/// </summary>
	public int AddProfessionMartialArtistSkill0(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 34);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 退隐江湖
	/// 退隐江湖{0}
	/// </summary>
	public int AddProfessionCivilianSkill2(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 35);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 封侯拜相移除
	/// 封侯拜相{0}
	/// </summary>
	public int AddProfessionDukeSkill1Remove(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 36);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 拿取同道资源
	/// 拿取资源{0}{1}{2}
	/// </summary>
	public int AddTakeTeammateResource(int date, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 37);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 拿取同道道具
	/// 拿取物品{0}{1}
	/// </summary>
	public int AddTakeTeammateItem(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 38);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 偷师技艺
	/// 偷师失败{0}{1}
	/// </summary>
	public int AddStealLifeSkill(int date, short lifeSkillTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 39);
		AppendLifeSkill(lifeSkillTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 偷师功法
	/// 偷师失败{0}{1}
	/// </summary>
	public int AddStealCombatSkill(int date, short lifeSkillTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 40);
		AppendLifeSkill(lifeSkillTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 唬骗技艺
	/// 唬骗失败{0}{1}
	/// </summary>
	public int AddScamLifeSkill(int date, short lifeSkillTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 41);
		AppendLifeSkill(lifeSkillTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 唬骗功法
	/// 唬骗失败{0}{1}
	/// </summary>
	public int AddScamCombatSkill(int date, short lifeSkillTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 42);
		AppendLifeSkill(lifeSkillTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 唬骗物品
	/// 唬骗失败{0}{1}
	/// </summary>
	public int AddScamItem(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 43);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 唬骗资源
	/// 唬骗失败{0}{1}{2}
	/// </summary>
	public int AddScamResource(int date, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 44);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 唬骗见闻
	/// 唬骗失败{0}{1}
	/// </summary>
	public int AddScamNormalInformation(int date, short infoTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 45);
		AppendInformation(infoTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 唬骗秘闻
	/// 唬骗失败{0}{1}
	/// </summary>
	public int AddScamSecretInformation(int date, short secretInfoTemplateId, int secretInfoId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 46);
		AppendSecretInformation(secretInfoTemplateId, secretInfoId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 窃取物品
	/// 窃取失败{0}{1}
	/// </summary>
	public int AddStealItem(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 47);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 窃取资源
	/// 窃取失败{0}{1}{2}
	/// </summary>
	public int AddStealResource(int date, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 48);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 夺取物品
	/// 夺取{0}{1}
	/// </summary>
	public int AddRobItem(int date, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 49);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 夺取资源
	/// 夺取{0}{1}{2}
	/// </summary>
	public int AddRobResource(int date, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, 50);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 施以毒害
	/// 施以毒害{0}
	/// </summary>
	public int AddPoison(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 51);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 暗中损伤
	/// 暗中损伤{0}
	/// </summary>
	public int AddDamage(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 52);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 出手袭击
	/// 出手袭击{0}
	/// </summary>
	public int AddAttack(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 53);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 处罚俘虏
	/// 处罚俘虏{0}
	/// </summary>
	public int AddAttackKidnappedCharacter(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 54);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 俘虏抢夺
	/// 俘虏抢夺{0}
	/// </summary>
	public int AddRemoveKidnappedCharacter(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 55);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物戒心记录 - 基础
	/// 基础{0}
	/// </summary>
	public int AddBase(int date, int value)
	{
		int beginOffset = BeginAddingRecord(date, 58);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
