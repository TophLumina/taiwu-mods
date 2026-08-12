using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.World.MonthlyEvent;

/// <summary>
/// 过月事件的集合；后端添加，前端和即时通知一并显示并进行选择处理
/// </summary>
/// <summary>
/// 过月事件的集合 - 添加过月事件
/// </summary>
public class MonthlyEventCollection : WriteableRecordCollection
{
	/// <summary>
	/// 获取所有过月事件的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public void GetRenderInfos(List<MonthlyEventRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			MonthlyEventRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定位置上的记录类型（即过月事件模板ID）
	/// </summary>
	/// <param name="offset"></param>
	/// <returns></returns>
	public unsafe short GetRecordType(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return *(short*)(pRawData + offset + 1);
		}
	}

	/// <summary>
	/// 获取指定索引的过月事件的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public new unsafe MonthlyEventRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = *(short*)(pCurrData + 1);
			pCurrData += 3;
			MonthlyEventItem config = Config.MonthlyEvent.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			MonthlyEventRenderInfo info = new MonthlyEventRenderInfo(recordType, config.Desc, offset);
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
			info.EventGuid = config.Event;
			return info;
		}
	}

	/// <summary>
	/// 开始添加过月通知
	/// </summary>
	/// <param name="recordType">过月通知类型</param>
	/// <returns>当前过月通知的起始偏移</returns>
	private new unsafe int BeginAddingRecord(short recordType)
	{
		int offset = Size;
		int newSize = Size + 1 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(short*)(pRawData + offset + 1) = recordType;
		}
		return offset;
	}

	/// <summary>
	/// 在当前记录中读取字符串
	/// </summary>
	/// <param name="ppData"></param>
	/// <returns></returns>
	private unsafe static string ReadString(byte** ppData)
	{
		*ppData += SerializationHelper.Deserialize(*ppData, out var value);
		return value;
	}

	/// <summary>
	/// 在当前记录中添加字符串
	/// </summary>
	/// <param name="value"></param>
	private unsafe void AppendString(string value)
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
	/// 添加无参数过月事件
	/// </summary>
	/// <param name="templateId"></param>
	public void AddMonthlyEventWithNoArgument(short templateId)
	{
		Tester.Assert(Config.MonthlyEvent.Instance[templateId].Parameters.Count((string p) => !string.IsNullOrEmpty(p)) == 0);
		int beginOffset = BeginAddingRecord(templateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件-一个参数：人物
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="charId"></param>
	public void AddMonthlyEventWithOneCharacterArgument(short templateId, int charId)
	{
		MonthlyEventItem config = Config.MonthlyEvent.Instance[templateId];
		Tester.Assert(config.Parameters.Count((string p) => !string.IsNullOrEmpty(p)) == 1 && ParameterType.Parse(config.Parameters[0]) == 0);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 灵光一闪
	/// 在阅读{0}时突然灵光一闪。
	/// </summary>
	public void AddReadingEvent(ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(0);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 太吾死亡
	/// {0}在{1}死亡。
	/// </summary>
	public void AddTaiwuDeath(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(1);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 地区崩溃
	/// 遍地玄石撕裂了大地，{0}跌入玄石缝隙之中！
	/// </summary>
	public void AddAreaTotallyDestoryed(int charId)
	{
		int beginOffset = BeginAddingRecord(2);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 太吾入魔
	/// {0}在{1}入魔。
	/// </summary>
	public void AddTaiwuInfected(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(3);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 太吾入邪
	/// {0}在{1}入邪。
	/// </summary>
	public void AddTaiwuInfectedPartially(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(4);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 外道袭击
	/// 在{0}被由{1}带领的一帮外道所袭击！
	/// </summary>
	public void AddRandomEnemyAttack(Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(5);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 动物袭击
	/// 在{0}遭遇了{1}的袭击！
	/// </summary>
	public void AddRandomAnimalAttack(Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(6);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 义士袭击
	/// 在{0}被由{1}带领的一帮义士所袭击！
	/// </summary>
	public void AddRandomRighteousAttack(Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(7);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 失心人袭击
	/// 在{0}遭遇了堕入相枢魔道的{1}袭击！
	/// </summary>
	public void AddInfectedCharacterAttack(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(8);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 爪牙袭击
	/// 在{0}遭遇了已沦为相枢爪牙的{1}袭击！
	/// </summary>
	public void AddHumanSkeletonAttack(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(9);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 促织入梦
	/// {0}在{1}梦见一只奇异的促织！
	/// </summary>
	public void AddCricketInDream(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(10);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 生下促织
	/// {0}孕育的促织降生了！
	/// </summary>
	public void AddGiveBirthToCricketTaiwu(int charId)
	{
		int beginOffset = BeginAddingRecord(11);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 生下促织
	/// {0}孕育的促织降生了！
	/// </summary>
	public void AddGiveBirthToCricketWife(int charId)
	{
		int beginOffset = BeginAddingRecord(12);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 母亲胎教
	/// {0}腹中的胎儿似乎正在不安…
	/// </summary>
	public void AddPrenatalEducationTaiwu(int charId)
	{
		int beginOffset = BeginAddingRecord(13);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 痛失骨肉
	/// {0}因身体不适，在{1}触动了胎气，以致痛失了腹中的胎儿。
	/// </summary>
	public void AddAbortionTaiwu(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(14);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 痛失骨肉
	/// {0}因身体不适，在{1}触动了胎气，以致痛失了腹中的胎儿。
	/// </summary>
	public void AddLoseFetusWife(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(15);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产双亡
	/// {0}在{1}生育时发生意外，以致香消玉殒，并痛失了腹中的胎儿。
	/// </summary>
	public void AddMotherFetusBothDieTaiwu(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(16);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产双亡
	/// {0}在{1}生育时发生意外，以致香消玉殒，并痛失了腹中的胎儿。
	/// </summary>
	public void AddMotherFetusBothDieWife(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(17);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产失子
	/// {0}在{1}生育时发生意外，以致痛失了腹中的胎儿。
	/// </summary>
	public void AddDystociaLoseFetusTaiwu(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(18);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产失子
	/// {0}在{1}生育时发生意外，以致痛失了腹中的胎儿。
	/// </summary>
	public void AddDystociaLoseFetusWife(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(19);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 喜得贵子
	/// {0}在{1}诞下一子。
	/// </summary>
	public void AddHaveChildBoyTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(20);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 喜得千金
	/// {0}在{1}诞下一女。
	/// </summary>
	public void AddHaveChildGirlTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(21);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 喜得贵子
	/// {0}在{1}诞下一子。
	/// </summary>
	public void AddHaveChildBoyWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(22);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 喜得千金
	/// {0}在{1}诞下一女。
	/// </summary>
	public void AddHaveChildGirlWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(23);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产剩子
	/// {0}在{1}生育时发生意外，虽诞下一子，却终究香消玉殒。
	/// </summary>
	public void AddDystociaButHaveChildBoyTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(24);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产剩女
	/// {0}在{1}生育时发生意外，虽诞下一女，却终究香消玉殒。
	/// </summary>
	public void AddDystociaButHaveChildGirlTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(25);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产剩子
	/// {0}在{1}生育时发生意外，虽诞下一子，却终究香消玉殒。
	/// </summary>
	public void AddDystociaButHaveChildBoyWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(26);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产剩女
	/// {0}在{1}生育时发生意外，虽诞下一女，却终究香消玉殒。
	/// </summary>
	public void AddDystociaButHaveChildGirlWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(27);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产得子
	/// {0}在{1}生育时发生意外，最终顺利诞下一子。
	/// </summary>
	public void AddDystociaAndHaveChildBoyTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(28);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产得女
	/// {0}在{1}生育时发生意外，最终顺利诞下一女。
	/// </summary>
	public void AddDystociaAndHaveChildGirlTaiwu(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(29);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产得子
	/// {0}在{1}生育时发生意外，最终顺利诞下一子。
	/// </summary>
	public void AddDystociaAndHaveChildBoyWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(30);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难产得女
	/// {0}在{1}生育时发生意外，最终顺利诞下一女。
	/// </summary>
	public void AddDystociaAndHaveChildGirlWife(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(31);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 无名遗孤
	/// 一名婴儿被遗弃在了太吾村…
	/// </summary>
	public void AddAbandonedBabyInVilliage(int charId)
	{
		int beginOffset = BeginAddingRecord(32);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 孩子抓周
	/// {0}满周岁了！
	/// </summary>
	public void AddChildZhuazhou(int charId)
	{
		int beginOffset = BeginAddingRecord(33);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 教育子女
	/// {0}年岁渐长，正可开蒙教育…
	/// </summary>
	public void AddTeachChild(int charId)
	{
		int beginOffset = BeginAddingRecord(34);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 即将成年
	/// {0}即将成年！
	/// </summary>
	public void AddReachAdulthood(int charId)
	{
		int beginOffset = BeginAddingRecord(35);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 俘虏产子
	/// {0}关押中的{1}的孩子诞生了。
	/// </summary>
	public void AddCaptiveHaveChild(int charId, int charId1, int charId2, int charId3, int charId4, int charId5, int charId6)
	{
		int beginOffset = BeginAddingRecord(36);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		AppendCharacter(charId3);
		AppendCharacter(charId4);
		AppendCharacter(charId5);
		AppendCharacter(charId6);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 俘虏结仇
	/// {0}在{1}因被{2}监禁，对{2}心生怨恨…
	/// </summary>
	public void AddCaptiveBecomeEnemy(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(37);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 同道婚配
	/// {0}与{1}情投意合，想要互许终生，结为夫妻…
	/// </summary>
	public void AddGroupGetMarried(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(38);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 春日集市
	/// 冬去春来，辞旧迎新，各地的商贾们纷纷举办起热闹的集会，随处可见赶集的百姓们。
	/// </summary>
	public void AddSpringMarket()
	{
		int beginOffset = BeginAddingRecord(39);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 城镇比武
	/// 夏暑三伏，勤学苦练，热火朝天的城镇比武正在{0}举办。
	/// </summary>
	public void AddSummerTownCompetition(Location location)
	{
		int beginOffset = BeginAddingRecord(40);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 促织大赛
	/// 金秋伊始，秋虫活跃，一场促织大赛正在{0}轰轰烈烈地举办！
	/// </summary>
	public void AddAutumnCricketContest(Location location)
	{
		int beginOffset = BeginAddingRecord(41);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 较艺大会
	/// 数九寒冬，劳作不辍，一场关于{0}的较艺大会正在{1}轰轰烈烈地举办！
	/// </summary>
	public void AddWinterLifeCompetition(short lifeSkillTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(42);
		AppendLifeSkill(lifeSkillTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 结下仇怨
	/// {0}在{1}对{2}怀恨在心，结下了莫名的仇怨。
	/// </summary>
	public void AddMakeEnemy(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(43);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 化解仇怨
	/// {0}在{1}化解了对{2}的仇恨，不再视其为敌人了。
	/// </summary>
	public void AddSeverEnemy(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(44);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 心生爱慕
	/// {0}在{1}对{2}心生爱慕之情。
	/// </summary>
	public void AddAdore(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(45);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 表露心事
	/// {0}在{1}向{2}表明心中爱意…
	/// </summary>
	public void AddConfess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(46);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 恋人分手
	/// {0}在{1}向{2}提议断绝彼此的情爱，只叹：此情可待成追忆，只是当时已惘然……
	/// </summary>
	public void AddBreakup(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(47);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 共结连理
	/// {0}在{1}向{2}提议互许终生，结为夫妻…
	/// </summary>
	public void AddProposeMarriage(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(48);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 结为好友
	/// {0}在{1}与{2}相谈甚欢，提议结为知己好友…
	/// </summary>
	public void AddBecomeFriend(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(49);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 断绝友谊
	/// {0}在{1}与{2}产生隔阂，不复往日友谊…
	/// </summary>
	public void AddSeverFriendship(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(50);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 义结金兰
	/// {0}在{1}向{2}提议共结金兰之契，但求同生共死…
	/// </summary>
	public void AddBecomeSwornBrotherOrSister(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(51);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 割袍断义
	/// {0}在{1}向{2}提出割袍断义，所谓：不及黄泉，无相见也…
	/// </summary>
	public void AddSeverSwornBrotherhood(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(52);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 拜认义父
	/// {0}在{1}对{2}孺慕不已，请求拜认{2}为义父…
	/// </summary>
	public void AddGetAdoptedByFather(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(53);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 拜认义母
	/// {0}在{1}对{2}孺慕不已，请求拜认{2}为义母…
	/// </summary>
	public void AddGetAdoptedByMother(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(54);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 收养义子
	/// {0}在{1}对{2}关怀不已，提出收养{2}为义子…
	/// </summary>
	public void AddAdoptSon(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(55);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 收养义女
	/// {0}在{1}对{2}关怀不已，提出收养{2}为义女…
	/// </summary>
	public void AddAdoptDaughter(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(56);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 离开人世
	/// {0}在{1}离开了人世。
	/// </summary>
	public void AddDie(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(57);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 俘虏逃脱
	/// {0}在{1}摆脱了{2}的监禁逃走了……
	/// </summary>
	public void AddEscapeFromPrison(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(58);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 中止赴约
	/// {0}不再前往{1}赴约…
	/// </summary>
	public void AddAppointmentCancelled(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(59);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 寻仇袭击
	/// {0}在{1}遭遇了{2}的寻仇袭击…
	/// </summary>
	public void AddRevengeAttack(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(60);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 请求保护
	/// {0}在{1}遭遇了{2}的寻仇袭击，并请求{3}代其抵御{2}的袭击…
	/// </summary>
	public void AddAskProtectByRevengeAttack(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(61);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇下毒
	/// {0}在{1}遭受毒害，并发现了正欲逃走的{2}…
	/// </summary>
	public void AddCatchEnemyPoison(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(62);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇下毒
	/// {0}在{1}遭受毒害。
	/// </summary>
	public void AddEnemyPoisonAndEscape(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(63);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇损伤
	/// {0}在{1}被暗中损伤，并发现了正欲逃走的{2}…
	/// </summary>
	public void AddCatchEnemyPlotHarm(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(64);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇损伤
	/// {0}在{1}被暗中损伤。
	/// </summary>
	public void AddEnemyPlotHarmAndEscape(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(65);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 外伤请求
	/// {0}在{1}请求{2}赠予{3}，用以治疗外伤…
	/// </summary>
	public void AddRequestHealOuterInjuryByItem(int charId, Location location, int charId1, ulong itemKey, sbyte bodyPartType)
	{
		int beginOffset = BeginAddingRecord(66);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendBodyPartType(bodyPartType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 外伤请求
	/// {0}在{1}请求{2}赠予{3}药材，用以治疗外伤…
	/// </summary>
	public void AddRequestHealOuterInjuryByResource(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(67);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 内伤请求
	/// {0}在{1}请求{2}赠予{3}，用以治疗内伤…
	/// </summary>
	public void AddRequestHealInnerInjuryByItem(int charId, Location location, int charId1, ulong itemKey, sbyte bodyPartType)
	{
		int beginOffset = BeginAddingRecord(68);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendBodyPartType(bodyPartType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 内伤请求
	/// {0}在{1}请求{2}赠予{3}药材，用以治疗内伤…
	/// </summary>
	public void AddRequestHealInnerInjuryByResource(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(69);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 驱毒请求
	/// {0}在{1}请求{2}赠予{3}，用以驱除{4}…
	/// </summary>
	public void AddRequestHealPoisonByItem(int charId, Location location, int charId1, ulong itemKey, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(70);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 驱毒请求
	/// {0}在{1}请求{2}赠予{3}药材，用以驱除{4}…
	/// </summary>
	public void AddRequestHealPoisonByResource(int charId, Location location, int charId1, int value, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(71);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 续命请求
	/// {0}在{1}请求{2}赠予{3}，用以疗疾续命…
	/// </summary>
	public void AddRequestHealth(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(72);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 内息请求
	/// {0}在{1}请求{2}赠予{3}，用以调理内息…
	/// </summary>
	public void AddRequestHealDisorderOfQi(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(73);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 内力请求
	/// {0}在{1}请求{2}赠予{3}，用以恢复内力…
	/// </summary>
	public void AddRequestNeili(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(74);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 灭蛊请求
	/// {0}在{1}请求{2}赠予{3}，用以杀灭{4}…
	/// </summary>
	public void AddRequestKillWug(int charId, Location location, int charId1, ulong itemKey, ulong itemKey1)
	{
		int beginOffset = BeginAddingRecord(75);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 食物请求
	/// {0}在{1}请求{2}赠予{3}，用以果腹…
	/// </summary>
	public void AddRequestFood(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(76);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 茶酒请求
	/// {0}在{1}请求{2}赠予{3}，用以舒怀…
	/// </summary>
	public void AddRequestTeaWine(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(77);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 资源请求
	/// {0}在{1}请求{2}赠予{3}{4}…
	/// </summary>
	public void AddRequestResource(int charId, Location location, int charId1, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(78);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 物品请求
	/// {0}在{1}请求{2}赠予{3}…
	/// </summary>
	public void AddRequestItem(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(79);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 修理请求
	/// {0}在{1}请求{2}相助修理{3}…
	/// </summary>
	public void AddRequestRepairItem(int charId, Location location, int charId1, ulong itemKey, ulong itemKey1, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(80);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 淬毒请求
	/// {0}在{1}请求{2}相助为{3}淬毒…
	/// </summary>
	public void AddRequestAddPoisonToItem(int charId, Location location, int charId1, ulong itemKey, ulong itemKey1)
	{
		int beginOffset = BeginAddingRecord(81);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 技艺请求
	/// {0}在{1}请求{2}指点{3}的第{4}篇…
	/// </summary>
	public void AddRequestInstructionOnLifeSkill(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(82);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 武艺请求
	/// {0}在{1}请求{2}指点{3}的第{4}篇…
	/// </summary>
	public void AddRequestInstructionOnCombatSkill(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(83);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 研读技艺请求
	/// {0}在{1}请求{2}相助解读{3}的第{4}篇…
	/// </summary>
	public void AddRequestInstructionOnReadingLifeSkill(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(84);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 研读武学请求
	/// {0}在{1}请求{2}相助解读{3}的第{4}篇…
	/// </summary>
	public void AddRequestInstructionOnReadingCombatSkill(int charId, Location location, int charId1, ulong itemKey, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(85);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 突破请求
	/// {0}在{1}请求{2}相助突破{3}的玄关…
	/// </summary>
	public void AddRequestInstructionOnBreakout(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(86);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 切磋请求
	/// {0}在{1}向{2}提出切磋武艺…
	/// </summary>
	public void AddRequestPlayCombat(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(87);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 挑战请求
	/// {0}在{1}向{2}提出比试武艺…
	/// </summary>
	public void AddRequestNormalCombat(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(88);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 较艺请求
	/// {0}在{1}向{2}提出比试技艺…
	/// </summary>
	public void AddRequestLifeSkillBattle(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(89);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 促织决斗
	/// {0}在{1}向{2}提出促织决斗…
	/// </summary>
	public void AddRequestCricketBattle(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(90);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 窃取俘虏被抓
	/// {0}在{1}暗中解救了被{2}关押的{3}…
	/// </summary>
	public void AddRescueKidnappedCharacterSecretlyButBeCaught(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(91);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 窃取俘虏逃跑
	/// {0}关押的{2}在{1}被暗中解救了！
	/// </summary>
	public void AddRescueKidnappedCharacterSecretlyAndEscape(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(92);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇唬骗俘虏
	/// {0}在{1}意图用计解救被{2}关押的{3}…
	/// </summary>
	public void AddRescueKidnappedCharacterWithWit(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(93);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇抢夺俘虏
	/// {0}在{1}意图强行解救被{2}关押的{3}…
	/// </summary>
	public void AddRescueKidnappedCharacterWithForce(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(94);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 窃取资源被抓
	/// {0}在{1}窃取了{2}的部分{3}…
	/// </summary>
	public void AddStealResourceButBeCaught(int charId, Location location, int charId1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(95);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 窃取资源逃跑
	/// {2}的部分{3}在{1}失窃了…
	/// </summary>
	public void AddStealResourceAndEscape(int charId, Location location, int charId1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(96);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇唬骗资源
	/// {0}在{1}意图骗取{2}的{3}…
	/// </summary>
	public void AddScamResource(int charId, Location location, int charId1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(97);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇抢夺资源
	/// {0}在{1}意图夺取{2}的{3}…
	/// </summary>
	public void AddRobResource(int charId, Location location, int charId1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(98);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 窃取物品被抓
	/// {0}在{1}窃取了{2}的{3}…
	/// </summary>
	public void AddStealItemButBeCaught(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(99);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 窃取物品逃跑
	/// {2}的{3}在{1}失窃了…
	/// </summary>
	public void AddStealItemAndEscape(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(100);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇唬骗物品
	/// {0}在{1}意图骗取{2}的{3}…
	/// </summary>
	public void AddScamItem(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(101);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇抢夺物品
	/// {0}在{1}意图夺取{2}的{3}…
	/// </summary>
	public void AddRobItem(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(102);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 窃取技艺被抓
	/// {0}在{1}偷师了{2}的{3}第{4}篇，被{2}发现了…
	/// </summary>
	public void AddStealLifeSkillButBeCaught(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(103);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 窃取技艺逃跑
	/// {0}在{1}偷师了{2}的{3}第{4}篇后全身而退…
	/// </summary>
	public void AddStealLifeSkillAndEscape(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(104);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇唬骗技艺
	/// {0}在{1}意图骗取{2}的{3}第{4}篇秘诀…
	/// </summary>
	public void AddScamLifeSkill(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(105);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 窃取武学被抓
	/// {0}在{1}偷师了{2}的{3}第{4}篇，被{2}发现了…
	/// </summary>
	public void AddStealCombatSkillButBeCaught(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(106);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 窃取武学逃跑
	/// {0}在{1}偷师了{2}的{3}第{4}篇后全身而退…
	/// </summary>
	public void AddStealCombatSkillAndEscape(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(107);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇唬骗武学
	/// {0}在{1}意图骗取{2}的{3}第{4}篇秘诀…
	/// </summary>
	public void AddScamCombatSkill(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId, int value, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(108);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 推恩施义
	/// {0}在{1}向{2}提议将{2}的恩义施予百姓…
	/// </summary>
	public void AddAdviseExtendFavours(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(109);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 笼络人心
	/// {0}在{1}向{2}提议帮助{2}笼络当地人心…
	/// </summary>
	public void AddAdviseWinPeopleSupport(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(110);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 商会赞誉
	/// {0}在{1}向{2}提议增进{2}与商会的好感…
	/// </summary>
	public void AddAdviseMerchantFavor(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(111);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 茶酒相邀
	/// {0}在{1}以{3}邀约{2}…
	/// </summary>
	public void AddAdviseTeaWine(int charId, Location location, int charId1, ulong itemKey, ulong itemKey1)
	{
		int beginOffset = BeginAddingRecord(112);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 打折推销
	/// {0}在{1}向{2}推销{3}…
	/// </summary>
	public void AddAdviseSales(int charId, Location location, int charId1, ulong itemKey, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(113);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 施医赠药
	/// {0}在{1}向{2}提议助其疗愈伤势…
	/// </summary>
	public void AddAdviseHealInjury(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(114);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 施医赠药
	/// {0}在{1}向{2}提议助其驱除毒素…
	/// </summary>
	public void AddAdviseHealPoison(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(115);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 修补物品
	/// {0}在{1}向{2}提议为其修补{3}…
	/// </summary>
	public void AddAdviseRepairItem(int charId, Location location, int charId1, ulong itemKey, ulong itemKey1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(116);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendItemKey(itemKey1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 梳头修面
	/// {0}在{1}向{2}提议为其梳头修面…
	/// </summary>
	public void AddAdviseBarb(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(117);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 乞讨银钱
	/// {0}在{1}向{2}乞讨银钱…
	/// </summary>
	public void AddAskForMoney(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(118);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 盟会失败
	/// 因相枢之祸，天下武林盟会屡受袭扰，最终未能成功举办……
	/// </summary>
	public void AddWulinConferenceTaiwuAbsent()
	{
		int beginOffset = BeginAddingRecord(119);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 筹备盟会
	/// 为筹备天下武林盟会，一队{0}的弟子找到了{1}的所在……
	/// </summary>
	public void AddWulinConferenceAskForHelp(short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(120);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 太吾村毁灭
	/// 太吾村毁灭了！
	/// </summary>
	public void AddTaiwuVillageBeDestoryed()
	{
		int beginOffset = BeginAddingRecord(121);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 门派责罚！
	/// 奈何双飞燕，休负有情人，{0}因与太吾传人的情谊受到了门派责罚……
	/// </summary>
	public void AddForeverLoverBePunished(int charId)
	{
		int beginOffset = BeginAddingRecord(122);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇异木人
	/// 一具奇特的木人，忽然出现在太吾村的练功房中……
	/// </summary>
	public void AddVillageWoodenManByMonv()
	{
		int beginOffset = BeginAddingRecord(123);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇异木人
	/// 一具奇特的木人，忽然出现在太吾村的练功房中……
	/// </summary>
	public void AddVillageWoodenManByDayueYaochang()
	{
		int beginOffset = BeginAddingRecord(124);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇异木人
	/// 一具奇特的木人，忽然出现在太吾村的练功房中……
	/// </summary>
	public void AddVillageWoodenManByJiuhan()
	{
		int beginOffset = BeginAddingRecord(125);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇异木人
	/// 一具奇特的木人，忽然出现在太吾村的练功房中……
	/// </summary>
	public void AddVillageWoodenManByJinHuanger()
	{
		int beginOffset = BeginAddingRecord(126);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇异木人
	/// 一具奇特的木人，忽然出现在太吾村的练功房中……
	/// </summary>
	public void AddVillageWoodenManByYiYihou()
	{
		int beginOffset = BeginAddingRecord(127);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇异木人
	/// 一具奇特的木人，忽然出现在太吾村的练功房中……
	/// </summary>
	public void AddVillageWoodenManByWeiQi()
	{
		int beginOffset = BeginAddingRecord(128);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇异木人
	/// 一具奇特的木人，忽然出现在太吾村的练功房中……
	/// </summary>
	public void AddVillageWoodenManByYixiang()
	{
		int beginOffset = BeginAddingRecord(129);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇异木人
	/// 一具奇特的木人，忽然出现在太吾村的练功房中……
	/// </summary>
	public void AddVillageWoodenManByXuefeng()
	{
		int beginOffset = BeginAddingRecord(130);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇异木人
	/// 一具奇特的木人，忽然出现在太吾村的练功房中……
	/// </summary>
	public void AddVillageWoodenManByShuFang()
	{
		int beginOffset = BeginAddingRecord(131);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 背约负誓
	/// 衾寒枕冷梦不成，斜倚红烛坐天明，因{0}未如约前往与{1}完婚，{1}决意断绝与{0}的情爱…
	/// </summary>
	public void AddTaiwuNotAttendingWedding(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(132);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 背约负誓
	/// {1}听闻{0}心生两意，另结良缘，于是决意断绝与{0}的情爱…
	/// </summary>
	public void AddTaiwuAlreadyMarried(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(133);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇奇书挑战
	/// {0}在{1}向{2}发起挑战，誓要赢取手中的{3}……
	/// </summary>
	public void AddChallengeForLegendaryBook(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(134);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇求取奇书
	/// {0}在{1}向{2}发起请求，希望受传手中的{3}……
	/// </summary>
	public void AddRequestLegendaryBook(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(135);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇交换奇书
	/// {0}在{1}向{2}提出交易，希望换取手中的{3}……
	/// </summary>
	public void AddExchangeLegendaryBookByMoney(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(136);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇交换奇书
	/// {0}在{1}向{2}提出交易，希望换取手中的{3}……
	/// </summary>
	public void AddExchangeLegendaryBookByAuthority(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(137);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇交换奇书
	/// {0}在{1}向{2}提出交易，希望换取手中的{3}……
	/// </summary>
	public void AddExchangeLegendaryBookByExperience(int charId, Location location, int charId1, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(138);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇窃取奇书成功
	/// {0}在{1}窃取了{2}手中的{3}。
	/// </summary>
	public void AddStealLegendaryBookAndEscape(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(139);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇窃取奇书被抓
	/// {0}在{1}试图窃取{2}手中的{3}……
	/// </summary>
	public void AddStealLegendaryBookGotCaught(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(140);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇唬骗奇书
	/// {0}在{1}试图骗取{2}手中的{3}……
	/// </summary>
	public void AddScamLegendaryBook(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(141);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇夺取奇书
	/// {0}在{1}试图夺取{2}手中的{3}……
	/// </summary>
	public void AddRobLegendaryBook(int charId, Location location, int charId1, ulong itemKey, int value)
	{
		int beginOffset = BeginAddingRecord(142);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItemKey(itemKey);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 执迷相杀
	/// 奇书现世，引人执迷。{0}行至{1}，竟与执迷之人狭路相逢，遭受袭击……
	/// </summary>
	public void AddLegendaryBookShockedAttack(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(143);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 执迷相杀
	/// 奇书现世，引人执迷。{0}行至{1}，竟与执迷之人狭路相逢，遭受袭击……
	/// </summary>
	public void AddLegendaryBookInsaneAttack(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(144);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 执迷相杀
	/// 奇书现世，引人执迷。{0}行至{1}，竟与执迷之人狭路相逢，遭受袭击……
	/// </summary>
	public void AddLegendaryBookConsumedAttack(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(145);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 化身威显
	/// 奇书现世，引人成魔。因{0}宝典持有之人心性大变，心与魔通，剑冢似乎也与其发生了共鸣……
	/// </summary>
	public void AddSwordTombGetStronger(ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(146);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 化身锋敛
	/// 奇书影踪，宿昔流转。因{0}宝典易主，心魔蛰伏，剑冢似乎不再与其发生共鸣……
	/// </summary>
	public void AddSwordTombBackToNormal(ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(147);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇书出世
	/// {1}影踪初现，众多正邪高手逐渐聚集在{0}，只为争夺那流落世间的稀世宝典……
	/// </summary>
	public void AddFightForNewLegendaryBook(Location location, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(148);
		AppendLocation(location);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇书出世
	/// 因{0}放弃，{2}影踪重现，众多正邪高手逐渐聚集在{1}，只为争夺那已然无主的稀世宝典……
	/// </summary>
	public void AddFightForLegendaryBookAbandoned(int charId, Location location, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(149);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇书出世
	/// 因{0}离世，{2}影踪重现，众多正邪高手逐渐聚集在{1}，只为争夺那已然无主的稀世宝典……
	/// </summary>
	public void AddFightForLegendaryBookOwnerDie(int charId, Location location, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(150);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 奇书出世
	/// 因{0}堕魔，{2}影踪重现，众多正邪高手逐渐聚集在{1}，只为争夺那已然无主的稀世宝典……
	/// </summary>
	public void AddFightForLegendaryBookOwnerConsumed(int charId, Location location, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(151);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 魂牵梦萦
	/// 两心相印，如结丝萝，正是恩爱久长情浓时，{0}只欲与{1}共度闲暇……
	/// </summary>
	public void AddDateWithLoverEveryday(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(152);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 庆贺生辰
	/// {1}已至，此时正是{0}之生月……
	/// </summary>
	public void AddHappyBirthdayTaiwu(int charId, sbyte month)
	{
		int beginOffset = BeginAddingRecord(153);
		AppendCharacter(charId);
		AppendMonth(month);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 情深似海
	/// {0}与{1}相知相识已有悠悠数载……
	/// </summary>
	public void AddLoveAnniversary(int charId, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(154);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭受冷落
	/// 情人怨遥夜，竟夕起相思。怨怼之情，疾苦难知 ……
	/// </summary>
	public void AddNeglectedLover(int charId)
	{
		int beginOffset = BeginAddingRecord(155);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 醋海翻波
	/// 闻有两意，心生嫌隙，{1}似是有话要与{0}说……
	/// </summary>
	public void AddLoverBecomeJealous(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(156);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 风流危机
	/// 乱花迷眼，故而情之难专，如今{1}、{2}、{3}似是有话要与{0}说……
	/// </summary>
	public void AddLoversBecomeJealousAndViolent(int charId, int charId1, int charId2, int charId3)
	{
		int beginOffset = BeginAddingRecord(157);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		AppendCharacter(charId3);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 陪伴孕育
	/// {1}身怀六甲已有一段时日，{0}日日相伴在侧，琴瑟调和……
	/// </summary>
	public void AddPregnancyWithLover(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(158);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 万千兄弟
	/// 于江湖中四散寻访{0}下落的群丐似已返回……
	/// </summary>
	public void AddBeggerSkill2TargetUnavailable(int charId)
	{
		int beginOffset = BeginAddingRecord(159);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 万千兄弟
	/// 于江湖中四散寻访{0}下落的群丐似已返回……
	/// </summary>
	public void AddBeggarSkill2TargetBrought(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(160);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 万千兄弟
	/// 于江湖中四散寻访{0}下落的群丐似已返回……
	/// </summary>
	public void AddBeggarSkill2TargetDeadAndMissing(int charId)
	{
		int beginOffset = BeginAddingRecord(161);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 万千兄弟
	/// 于江湖中四散寻访{0}下落的群丐似已返回……
	/// </summary>
	public void AddBeggarSkill2TargetDead(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(162);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 万千兄弟
	/// 于江湖中四散寻访{0}下落的群丐似已返回……
	/// </summary>
	public void AddBeggarSkill2TargetNoneExistent(string text)
	{
		int beginOffset = BeginAddingRecord(163);
		AppendText(text);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 历灾渡劫
	/// 行满功成日，冲霄得道时。{0}将于{1}踏雷渡劫……
	/// </summary>
	public void AddTaiwuTribulation(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(164);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 轮回转生
	/// {0}依稀梦见佛光普照，霓虹满天，{1}降世于{2}……
	/// </summary>
	public void AddTaiwuComingSuccess(int charId, int charId1, Location location, int charId2)
	{
		int beginOffset = BeginAddingRecord(165);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 难入轮回
	/// {0}依稀梦见佛光黯然，霓虹残照，{1}前来与自己告别……
	/// </summary>
	public void AddTaiwuComingDefeated(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(166);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 化外逍遥
	/// {0}逍遥物外，游心太玄，早已勘破人寿，又何惧日月如流……
	/// </summary>
	public void AddTaiwuFreeAndunFettered(int charId)
	{
		int beginOffset = BeginAddingRecord(167);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 血犼妖异
	/// 传闻血犼教夜有妖异现身，如今教内人心惶惶……
	/// </summary>
	public void AddSectMainStoryXuehouGraveDigging()
	{
		int beginOffset = BeginAddingRecord(172);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 血犼妖异
	/// 传闻血犼教夜有妖异现身，如今教内人心惶惶……
	/// </summary>
	public void AddSectMainStoryXuehouGraveDiggingNormal()
	{
		int beginOffset = BeginAddingRecord(173);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 血犼异事
	/// 传闻血犼教夜有异事，如今教内人心惶惶……
	/// </summary>
	public void AddSectMainStoryXuehouStrangeDeath()
	{
		int beginOffset = BeginAddingRecord(174);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 鬼怪拦路
	/// 八表同昏，鬼怪当道，前有红衣之影，正拦路而来……
	/// </summary>
	public void AddSectMainStoryXuehouOldManAppears()
	{
		int beginOffset = BeginAddingRecord(175);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 鬼怪出坟
	/// 红衣老人的坟墓不知何故，一夜之间损毁消失了……
	/// </summary>
	public void AddSectMainStoryXuehouOldManReturns()
	{
		int beginOffset = BeginAddingRecord(176);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 血光之灾
	/// 馀血涂地，朝露微红，此处血光妖异，不知何故……
	/// </summary>
	public void AddSectMainStoryXuehouOnBloodBlock()
	{
		int beginOffset = BeginAddingRecord(177);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 僵尸突袭
	/// 死者之浊臭渐生，一道血红身影忽而袭来……
	/// </summary>
	public void AddSectMainStoryXuehouOldManAttacks()
	{
		int beginOffset = BeginAddingRecord(178);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 乡亲之睦
	/// 太吾村中，姬穸初来乍到，乡亲邻里关怀备至……
	/// </summary>
	public void AddSectMainStoryXuehouHarmoniousTaiwu()
	{
		int beginOffset = BeginAddingRecord(179);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 邻里之爱
	/// 太吾村中，姬穸不习水土，乡亲邻里关怀备至……
	/// </summary>
	public void AddSectMainStoryXuehouFeedJixi()
	{
		int beginOffset = BeginAddingRecord(180);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 村中怪事
	/// 太吾村中，近日怪事频发，常有夜半诡声……
	/// </summary>
	public void AddSectMainStoryXuehouMythInVillage()
	{
		int beginOffset = BeginAddingRecord(181);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 山野之王
	/// 太吾村中，姬穸百无聊赖，意欲前往山中散步……
	/// </summary>
	public void AddSectMainStoryXuehouProtectJixi()
	{
		int beginOffset = BeginAddingRecord(182);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 太吾佳肴
	/// 太吾村中，姬穸饮食不佳，似有几分苦恼……
	/// </summary>
	public void AddSectMainStoryXuehouJixiAskForFood()
	{
		int beginOffset = BeginAddingRecord(183);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 姬穸与鸡
	/// 太吾村中，姬穸百无聊赖，似对元鸡心生好奇……
	/// </summary>
	public void AddSectMainStoryXuehouJixiFeedChicken()
	{
		int beginOffset = BeginAddingRecord(184);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 疑心根种
	/// 太吾村中，姬穸时常行踪不定，似有秘密深藏……
	/// </summary>
	public void AddSectMainStoryXuehouJixiKills()
	{
		int beginOffset = BeginAddingRecord(185);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 少女心事
	/// 太吾村中，姬穸似有心事，伫立田边沉思……
	/// </summary>
	public void AddSectMainStoryXuehouVillageWork()
	{
		int beginOffset = BeginAddingRecord(186);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 疑梦相悲
	/// 心生疑窦，悲梦寥落，太吾村中，怪事频发，真相似已水落石出……
	/// </summary>
	public void AddSectMainStoryXuehouFinale()
	{
		int beginOffset = BeginAddingRecord(187);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 塔林崩塌
	/// 少林寺中，佛塔成林，如今却接连崩塌，不知何故……
	/// </summary>
	public void AddSectMainStoryShaolinTowerFalling()
	{
		int beginOffset = BeginAddingRecord(190);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 妙法佛梦
	/// 心生则佛生，心起则梦起，佛陀难见，禅机难求，缘法何其妙哉……
	/// </summary>
	public void AddSectMainStoryShaolinLearning()
	{
		int beginOffset = BeginAddingRecord(193);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 机缘未到
	/// 时运虽至，缘法未够，虽得佛陀一梦，却尚未修得正果……
	/// </summary>
	public void AddSectMainStoryShaolinNotEnough()
	{
		int beginOffset = BeginAddingRecord(194);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 达摩挑战
	/// 梦中习武已久，终有试炼之时，老僧入梦，今日或需一战……
	/// </summary>
	public void AddSectMainStoryShaolinChallenge()
	{
		int beginOffset = BeginAddingRecord(195);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 佛法将成
	/// 心若清净，无复魔业，如今佛梦之因缘，终得修成……
	/// </summary>
	public void AddSectMainStoryShaolinEndChallenge()
	{
		int beginOffset = BeginAddingRecord(196);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 佛法将成
	/// 心若清净，无复魔业，却知佛法万相，竟已是修成……
	/// </summary>
	public void AddSectMainStoryShaolinNeverLearnChallenge()
	{
		int beginOffset = BeginAddingRecord(197);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 深夜听琴
	/// 璇女弟子本擅音律，途径此处却忽闻琴声，呕哑嘲哳，不成曲调……
	/// </summary>
	public void AddSectMainStoryXuannvPrologue()
	{
		int beginOffset = BeginAddingRecord(200);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 失心人袭击
	/// 在{0}遭遇了堕入相枢魔道的{1}袭击！
	/// </summary>
	public void AddSectMainStoryYuanshanInfectedCharacterAttack(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(210);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 弟子入魔
	/// 临时文本大量元山弟子入魔
	/// </summary>
	public void AddSectMainStoryYuanshanDisciplesInfected()
	{
		int beginOffset = BeginAddingRecord(211);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 神入石牢
	/// 神思迷蒙，神入石牢。
	/// </summary>
	public void AddSectMainStoryYuanshanLastMonsterAppear()
	{
		int beginOffset = BeginAddingRecord(212);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 元山衰落
	/// 江湖言传，元山衰落。
	/// </summary>
	public void AddSectMainStoryYuanshanProsperous()
	{
		int beginOffset = BeginAddingRecord(213);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 狮相切磋
	/// {0}兴致所至，在{1}提出与{2}切磋狮相绝艺！
	/// </summary>
	public void AddSectMainStoryShixiangDuel(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(217);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 民怨载道
	/// {0}在{1}见到了受苦的百姓
	/// </summary>
	public void AddSectMainStoryJingangPeopleSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(219);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 金刚袭来
	/// 西域高僧行踪泄露，金刚宗弟子追击而来……
	/// </summary>
	public void AddSectMainStoryJingangAttack()
	{
		int beginOffset = BeginAddingRecord(220);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 僧人遭劫
	/// 密林深处，一桩血案扑朔迷离……
	/// </summary>
	public void AddSectMainStoryJingangMonkMurdered()
	{
		int beginOffset = BeginAddingRecord(221);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 驱邪除祟
	/// 行路匆匆之时，偶遇当地村民，愿出手为{0}煨桑驱邪……
	/// </summary>
	public void AddSectMainStoryJingangExorcism(int charId)
	{
		int beginOffset = BeginAddingRecord(222);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 高僧显灵
	/// 恍惚睡梦，又见高僧魂灵，不知轮回之事有何不测……
	/// </summary>
	public void AddSectMainStoryJingangGhostAppears()
	{
		int beginOffset = BeginAddingRecord(223);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 无名蛊毒
	/// {0}行路途中，忽感不适，竟身受莫名损伤……
	/// </summary>
	public void AddSectMainStoryWuxianPoisonousWug(int charId)
	{
		int beginOffset = BeginAddingRecord(227);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 五仙昌盛
	/// 江湖言传，五仙教弟子敬奉鬼神，尊爱自然，五仙之地民性质朴，和气如春……
	/// </summary>
	public void AddSectMainStoryWuxianProsperous()
	{
		int beginOffset = BeginAddingRecord(228);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 五仙衰落
	/// 江湖言传，五仙教弟子为修习苗疆秘术，以致身心悲苦，哀郁不绝……
	/// </summary>
	public void AddSectMainStoryWuxianFailing0()
	{
		int beginOffset = BeginAddingRecord(229);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 五仙衰落
	/// 江湖言传，五仙教弟子为修习苗疆秘术，以致身心悲苦，哀郁不绝……
	/// </summary>
	public void AddSectMainStoryWuxianFailing1()
	{
		int beginOffset = BeginAddingRecord(230);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 五仙异事
	/// 五仙教近日不知何故，竟是怪事频发，以致人心惶惶……
	/// </summary>
	public void AddSectMainStoryWuxianStrangeThings()
	{
		int beginOffset = BeginAddingRecord(231);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 心毒发作
	/// 中五圣心毒的人给玩家下毒
	/// </summary>
	public void AddSectMainStoryWuxianPoison()
	{
		int beginOffset = BeginAddingRecord(232);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 心毒发作
	/// 在{1}与心毒发作的{0}狭路相逢，遭遇袭击！
	/// </summary>
	public void AddSectMainStoryWuxianAssault(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(233);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 峨眉昌盛
	/// 江湖言传，峨眉派诛杀恶妖，拨乱反正，从此了悟祖师秘籍真谛，终得昌盛……
	/// </summary>
	public void AddSectMainStoryEmeiProsperous()
	{
		int beginOffset = BeginAddingRecord(234);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 峨眉衰落
	/// 江湖言传，峨眉派祖师秘籍尽皆信手涂鸦，门中弟子无人知其真意，修行受阻，终至落寞……
	/// </summary>
	public void AddSectMainStoryEmeiFailing()
	{
		int beginOffset = BeginAddingRecord(235);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 界青昌盛
	/// 玉蝉传信，界青门内乱已平，门中宿怨就此了断，无谓的内斗伤亡自此消弭，终至昌盛……
	/// </summary>
	public void AddSectMainStoryJieqingProsperous()
	{
		int beginOffset = BeginAddingRecord(236);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 界青衰落
	/// 江湖言传，界青门内乱不止，门人死伤惨重，界青自此一蹶不振，终至落寞……
	/// </summary>
	public void AddSectMainStoryJieqingFailing()
	{
		int beginOffset = BeginAddingRecord(237);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 血犼空墓
	/// 青冢应埋魂，幽宫坟已空，传言血犼教弟子寻得祖师之墓，墓中却已是空空如也……
	/// </summary>
	public void AddSectMainStoryXuehouEmptyGrave()
	{
		int beginOffset = BeginAddingRecord(238);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 血犼寻人
	/// 血犼教弟子似正在四方寻人，作恶不止，势要问得{0}踪迹……
	/// </summary>
	public void AddSectMainStoryXuehouLookingForTaiwu(int charId)
	{
		int beginOffset = BeginAddingRecord(239);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 不速之客
	/// 忽有不速之客自血犼教不请自来，气势汹汹，想必来者不善……
	/// </summary>
	public void AddSectMainStoryXuehouComing()
	{
		int beginOffset = BeginAddingRecord(240);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 华居来访
	/// {0}于{1}结识了一名然山派玉符宗弟子……
	/// </summary>
	public void AddSectMainStoryRanshanPaperCraneFromYufuFaction(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(241);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 玄质来访
	/// {0}于{1}结识了一名然山派神剑宗弟子……
	/// </summary>
	public void AddSectMainStoryRanshanPaperCraneFromShenjianFaction(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(242);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 迎娇来访
	/// {0}于{1}结识了一名然山派阴阳宗弟子……
	/// </summary>
	public void AddSectMainStoryRanshanPaperCraneFromYinyangFaction(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(243);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 然山昌盛
	/// 江湖言传，然山一派于上届三宗比武当中，得立派祖师鬼谷子真传，终得昌盛……
	/// </summary>
	public void AddSectMainStoryRanshanProsperous()
	{
		int beginOffset = BeginAddingRecord(244);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 然山衰落
	/// 江湖言传，然山一派于上届三宗比武当后，迷失仙途，日渐衰落……
	/// </summary>
	public void AddSectMainStoryRanshanFailing()
	{
		int beginOffset = BeginAddingRecord(245);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 老僧入梦
	/// 一梦既见佛陀，老僧恰入梦来……
	/// </summary>
	public void AddSectMainStoryShaolinDreamOfReadingSutra()
	{
		int beginOffset = BeginAddingRecord(246);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 老僧入梦
	/// 一梦既见佛陀，老僧恰入梦来……
	/// </summary>
	public void AddSectMainStoryShaolinDreamOfNewTaiwu()
	{
		int beginOffset = BeginAddingRecord(247);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 了悟禅武
	/// 灭除恶业，三业清净。诸法虚妄，此心终得禅武之道……
	/// </summary>
	public void AddSectMainStoryShaolinEnlightenment()
	{
		int beginOffset = BeginAddingRecord(248);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 机缘未到
	/// 时运虽至，缘法未够，虽得佛陀一梦，却尚未修得正果……
	/// </summary>
	public void AddSectMainStoryShaolinNotEnoughCommon()
	{
		int beginOffset = BeginAddingRecord(249);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 求知若渴
	/// 未知道义，寻人为师。{0}求知若渴，在{1}请求{3}赠予{2}……
	/// </summary>
	public void AddSectMainStoryShixiangRequestBook(int charId, Location location, ulong itemKey, int charId1)
	{
		int beginOffset = BeginAddingRecord(250);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 求知若渴
	/// 未知道义，寻人为师。{0}求知若渴，在{1}请求{3}相助解读{2}……
	/// </summary>
	public void AddSectMainStoryShixiangRequestLifeSkill(int charId, Location location, ulong itemKey, int charId1)
	{
		int beginOffset = BeginAddingRecord(251);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 捷报频传
	/// 眼望捷旌旗，耳听好消息。狮相门羽书捷至，血战功成，振奋人心！
	/// </summary>
	public void AddSectMainStoryShixiangGoodNews()
	{
		int beginOffset = BeginAddingRecord(252);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 老僧挑战
	/// 梦中习武已久，终有试炼之时，老僧入梦，今日或需一战……
	/// </summary>
	public void AddSectMainStoryShaolinChallengeCommon()
	{
		int beginOffset = BeginAddingRecord(254);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 佛法将成
	/// 心若清净，无复魔业，如今佛梦之因缘，终得修成……
	/// </summary>
	public void AddSectMainStoryShaolinEndChallengeCommon()
	{
		int beginOffset = BeginAddingRecord(255);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 佛法将成
	/// 心若清净，无复魔业，却知佛法万相，竟已是修成……
	/// </summary>
	public void AddSectMainStoryShaolinNeverLearnChallengeCommon()
	{
		int beginOffset = BeginAddingRecord(256);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 狮相来信
	/// 闻道烽烟动，红云映戎装。狮相门战事休罢，驰书托{0}……
	/// </summary>
	public void AddSectMainStoryShixiangLetterFrom2(int charId)
	{
		int beginOffset = BeginAddingRecord(257);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 捷报频传
	/// 眼望捷旌旗，耳听好消息。狮相门羽书捷至，血战功成，振奋人心！
	/// </summary>
	public void AddSectMainStoryShixiangGoodNews2()
	{
		int beginOffset = BeginAddingRecord(258);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 异族来敌
	/// 戎马鸣金鼙鼓震，万民牵衣顿足拦道哭，异族来敌进犯广东！
	/// </summary>
	public void AddSectMainStoryShixiangEnemyAttack2()
	{
		int beginOffset = BeginAddingRecord(259);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 狮相烽火
	/// 莲花山万籁俱寂，不闻人语犬吠，狮相门烽火将熄，旌旗欲倒……
	/// </summary>
	public void AddSectMainStoryShixiangStrange()
	{
		int beginOffset = BeginAddingRecord(260);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 邪祟来袭
	/// 神木之周，邪祟现世，正要前往啃食神木……
	/// </summary>
	public void AddSectMainStoryWudangProtectHeavenlyTree()
	{
		int beginOffset = BeginAddingRecord(262);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 神木凋萎
	/// 神木凋敝，死灰不燃。位于{0}的神木遭到相枢爪牙毁坏！
	/// </summary>
	public void AddSectMainStoryWudangHeavenlyTreeDestroyed(Location location)
	{
		int beginOffset = BeginAddingRecord(263);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 树下遇仙
	/// {0}于{1}依稀梦见，位于{3}的神木树下浮瑞霭，得道之真人乘风来，看来仙缘已至……
	/// </summary>
	public void AddSectMainStoryWudangMeetingImmortal(int charId, Location location, int charId1, Location location1)
	{
		int beginOffset = BeginAddingRecord(265);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遇到爪牙
	/// 千劫不尽，邪秽将至。{0}在位于{1}的神木树下与邪祟狭路相逢……
	/// </summary>
	public void AddSectMainStoryWudangGuardHeavenlyTree(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(266);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 神木灵化
	/// 神木至灵，则有山川之化。位于{0}的神木萎绝凋敝，其灵源养被{0}万物……
	/// </summary>
	public void AddSectMainStoryWudangHeavenlyTreeDestroyed2(Location location)
	{
		int beginOffset = BeginAddingRecord(276);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 魔念侵扰
	/// {0}在{1}受到相枢魔念侵扰…
	/// </summary>
	public void AddMirrorCreatedImpostureXiangshuInfected(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(277);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 邪祟来袭
	/// 神木之周，邪祟现世，正要前往啃食神木…
	/// </summary>
	public void AddSectMainStoryWudangProtectHeavenlyTree2()
	{
		int beginOffset = BeginAddingRecord(278);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 似曾相识
	/// 前尘已尽，因缘未了，在{1}忽遇{0}前来寻访…
	/// </summary>
	public void AddCrossArchiveReunionWithAcquaintance(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(279);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 指点武学
	/// {0}在{1}有意指点{2}一些{3}的习练法门…
	/// </summary>
	public void AddTeachCombatSkill(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(280);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 身怀六甲
	/// {0}在{1}感应到腹中胎气…
	/// </summary>
	public void AddPregnant(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(281);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 野性难驯
	/// {0}在{1}不受驯驭，忽然野性大发…
	/// </summary>
	public void AddTamingCarriers(short charTemplateId, Location location, ulong itemKey, Location location1)
	{
		int beginOffset = BeginAddingRecord(282);
		AppendCharacterTemplate(charTemplateId);
		AppendLocation(location);
		AppendItemKey(itemKey);
		AppendLocation(location1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 村中急信
	/// 事出反常，必有蹊跷。太吾村中传来急信，却不知所为何事……
	/// </summary>
	public void AddFiveLoongLetterFromTaiwuVillage()
	{
		int beginOffset = BeginAddingRecord(283);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 长蛟茁长
	/// 在{0}收到来自蛟池的消息：近日{1}虽有成长，然情态却异乎寻常……
	/// </summary>
	public void AddJiaoGrowold(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(284);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 囚牛笙歌
	/// {1}常伴{0}身侧，日日无忧无虑，自在快活，今日却颇有几分不寻常之处……
	/// </summary>
	public void AddDLCLoongRidingEffectQiuniu(int charId, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(285);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 睚眦必报
	/// {1}常伴{0}身侧，日日无忧无虑，自在快活，今日却颇有几分不寻常之处……
	/// </summary>
	public void AddDLCLoongRidingEffectYazi(int charId, int jiaoLoongId, int charId1)
	{
		int beginOffset = BeginAddingRecord(286);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 嘲风秘报
	/// {1}常伴{0}身侧，日日无忧无虑，自在快活，今日却颇有几分不寻常之处……
	/// </summary>
	public void AddDLCLoongRidingEffectChaofeng(int charId, int jiaoLoongId, int charId1)
	{
		int beginOffset = BeginAddingRecord(287);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 蒲牢巨声
	/// {1}常伴{0}身侧，日日无忧无虑，自在快活，今日却颇有几分不寻常之处……
	/// </summary>
	public void AddDLCLoongRidingEffectPulao(int charId, int jiaoLoongId, short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(288);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 狻猊嬉斗
	/// {1}常伴{0}身侧，日日无忧无虑，自在快活，今日却颇有几分不寻常之处……
	/// </summary>
	public void AddDLCLoongRidingEffectSuanni(int charId, int jiaoLoongId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(289);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 霸下觅宝
	/// {1}常伴{0}身侧，日日无忧无虑，自在快活，今日却颇有几分不寻常之处……
	/// </summary>
	public void AddDLCLoongRidingEffectBaxia(int charId, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(290);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 狴犴持衡
	/// {1}常伴{0}身侧，日日无忧无虑，自在快活，今日却颇有几分不寻常之处……
	/// </summary>
	public void AddDLCLoongRidingEffectBian(int charId, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(291);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 负屃舞文
	/// {1}常伴{0}身侧，日日无忧无虑，自在快活，今日却颇有几分不寻常之处……
	/// </summary>
	public void AddDLCLoongRidingEffectFuxi(int charId, int jiaoLoongId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(292);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 螭吻养内
	/// {1}常伴{0}身侧，日日无忧无虑，自在快活，今日却颇有几分不寻常之处……
	/// </summary>
	public void AddDLCLoongRidingEffectChiwen(int charId, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(293);
		AppendCharacter(charId);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 小龙袭击
	/// {0}在{1}遭遇了{2}的袭击！
	/// </summary>
	public void AddMinionLoongAttack(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(294);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 育蛟有成
	/// 在{0}收到来自蛟池的消息：近日{1}发荣滋长，已有化为龙子之质……
	/// </summary>
	public void AddDLCLoongJiaoGrowUp(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(295);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 五仙来信
	/// 于{1}收到一封古怪的信件，似乎乃是五仙来信……
	/// </summary>
	public void AddSectMainStoryWuxianGiftsReceived(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(296);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 僧人来访
	/// 一人传十，十人传百，有中原僧人听闻西域高僧美名，慕名前来……
	/// </summary>
	public void AddSectMainStoryJingangVisitorsArrive()
	{
		int beginOffset = BeginAddingRecord(297);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 金刚来信
	/// 迟迟未见西域高僧，金刚宗中竟传书催促，步步紧逼……
	/// </summary>
	public void AddSectMainStoryJingangLettersFromJingang(int charId)
	{
		int beginOffset = BeginAddingRecord(298);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 信受奉行
	/// 世人各有信念，自觉欢喜，信受奉行。焚香礼佛本为寻常，{0}却忽有奇闻……
	/// </summary>
	public void AddSectMainStoryJingangPiety(int charId)
	{
		int beginOffset = BeginAddingRecord(299);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 高僧托梦
	/// 万千法相，朦胧颠倒，不知何方僧人梦中说梦……
	/// </summary>
	public void AddSectMainStoryJingangRitualsInDream()
	{
		int beginOffset = BeginAddingRecord(301);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 再入轮回
	/// 因{0}相助，高僧魂灵终得再入轮回……
	/// </summary>
	public void AddSectMainStoryJingangReincarnation(int charId)
	{
		int beginOffset = BeginAddingRecord(304);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 魂灵消散
	/// 轮回台中，业已空空，魂灵缥缈，不知去处……
	/// </summary>
	public void AddSectMainStoryJingangGhostVanishes()
	{
		int beginOffset = BeginAddingRecord(305);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 偶遇妇人
	/// 于{0}遇到一名神情焦急的妇人，她似乎有话欲要告知太吾……
	/// </summary>
	public void AddSectMainStoryWuxianMiaoWoman(Location location)
	{
		int beginOffset = BeginAddingRecord(306);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 鲤跃龙门
	/// 黄河三尺鲤，本在孟津居，点额不成龙，归来伴凡鱼。
	/// </summary>
	public void AddSectMainStoryRanshanDragonGate()
	{
		int beginOffset = BeginAddingRecord(307);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 仙鹤传书
	/// {0}行路途中，收到一只古怪纸鹤……
	/// </summary>
	public void AddSectMainStoryRanshanMessage(int charId)
	{
		int beginOffset = BeginAddingRecord(308);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 恍若隔世
	/// 仙家诸事，扑朔迷离，{0}于{1}陷入沉思……
	/// </summary>
	public void AddSectMainStoryRanshanAfterQinglang(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(309);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 仙鹤回翔
	/// {0}行路途中，收到古怪纸鹤若干……
	/// </summary>
	public void AddSectMainStoryRanshanSanshiLeave(int charId)
	{
		int beginOffset = BeginAddingRecord(310);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 百花奇事
	/// 山水翠，草木芳，本是人间少有地，奈何有邪物打破了此地的宁静……
	/// </summary>
	public void AddSectMainStoryBaihuaEndenmic()
	{
		int beginOffset = BeginAddingRecord(311);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 再梦前尘
	/// 星月黯淡，万物沉寂，一段前尘，复现于{0}梦中……
	/// </summary>
	public void AddSectMainStoryBaihuaDreamAboutPastLast(int charId)
	{
		int beginOffset = BeginAddingRecord(313);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 杀人夺心
	/// 听闻近日有一白衣少女于{0}杀人夺心，以致当地人人自危……
	/// </summary>
	public void AddSectMainStoryBaihuaLeukoKills(Location location)
	{
		int beginOffset = BeginAddingRecord(317);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 商队拜访
	/// 太吾传人复归，商队特意前来拜访…
	/// </summary>
	public void AddMerchantVisit()
	{
		int beginOffset = BeginAddingRecord(318);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 弟子报恩
	/// 于{0}遇见一名门派弟子，此人似是来报答太吾传人的救命之恩……
	/// </summary>
	public void AddToRepayKindness(Location location)
	{
		int beginOffset = BeginAddingRecord(319);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 夺心之人
	/// 静夜沉沉，白影破空，“杀人夺心”的元凶终于显露踪迹……
	/// </summary>
	public void AddSectMainStoryBaihuaAmbushLeuko()
	{
		int beginOffset = BeginAddingRecord(320);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 毁人神智
	/// 听闻近日有一黑衣少年于{0}毁人神智，以致当地人人自危……
	/// </summary>
	public void AddSectMainStoryBaihuaMelanoKills(Location location)
	{
		int beginOffset = BeginAddingRecord(321);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 毁神之人
	/// 清光皎皎，黑影如团，“毁人神智”的元凶终于显露踪迹……
	/// </summary>
	public void AddSectMainStoryBaihuaAmbushMelano()
	{
		int beginOffset = BeginAddingRecord(322);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遭遇死气
	/// 异臭扑鼻，黑气障目，在{1}与身患神秘疯症的{0}狭路相逢！
	/// </summary>
	public void AddSectMainStoryBaihuaManicAttack(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(325);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 复生之人
	/// 死气氤氲，怪风膻腥之地，却见一道人影正矗立其中……
	/// </summary>
	public void AddSectMainStoryBaihuaAnonymReturns()
	{
		int beginOffset = BeginAddingRecord(326);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 玄鸮之乐
	/// 玄鸮与白鹿长居太吾村中，每日优哉游哉，步月寻溪……
	/// </summary>
	public void AddSectMainStoryBaihuaMelanoPlay()
	{
		int beginOffset = BeginAddingRecord(328);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 白鹿之乐
	/// 玄鸮与白鹿长居太吾村中，每日优哉游哉，步月寻溪……
	/// </summary>
	public void AddSectMainStoryBaihuaLeukoPlay()
	{
		int beginOffset = BeginAddingRecord(329);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 回首故村
	/// 玄鸮与白鹿长居太吾村中，每日优哉游哉，步月寻溪……
	/// </summary>
	public void AddSectMainStoryBaihuaLeukoMelanoPlay()
	{
		int beginOffset = BeginAddingRecord(330);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 天灾降临
	/// 赤明岛近日频发奇异天灾，伏龙坛上下皆道是天降祥瑞，为请真龙降世，已开始筹备祭龙盛典……
	/// </summary>
	public void AddSectMainStoryFulongDiasterAppear()
	{
		int beginOffset = BeginAddingRecord(331);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 琉璃传信
	/// 琉璃暂居伏龙坛中，似有话欲说，托付大王前来传信……
	/// </summary>
	public void AddSectMainStoryFulongLazuliLetter()
	{
		int beginOffset = BeginAddingRecord(333);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 追捕罪犯
	/// {0}被{1}拦住去路，道是奉命前来追捕要犯……
	/// </summary>
	public void AddHuntCriminal(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(336);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 刑期已满
	/// 关押在{1}的{0}的刑期已满，即将获释……
	/// </summary>
	public void AddSentenceCompleted(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(337);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 狂徒搜刮
	/// 在{0}遭遇伏龙狂徒拦路勒索，称若不交出供奉，便即刻命丧此地！
	/// </summary>
	public void AddSectMainStoryFulongRobTaiwu(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(338);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 狂徒搜刮
	/// {0}在{1}遭遇伏龙狂徒拦路勒索供奉，身陷困境……
	/// </summary>
	public void AddSectMainStoryFulongInterfereRobbery(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(339);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 请求庇护
	/// {0}在{1}遭遇伏龙狂徒拦路抢劫，请求{2}代其出手……
	/// </summary>
	public void AddSectMainStoryFulongProtect(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(340);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 齐心救火
	/// 赤明岛地区正有野火燎原，周遭百姓陷入绝境，幸得{0}舍身相救……
	/// </summary>
	public void AddSectMainStoryFulongFireFighting(int charId)
	{
		int beginOffset = BeginAddingRecord(341);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 施医赠药
	/// {0}在{1}向{2}提议助其调理内息…
	/// </summary>
	public void AddAdviseHealDisorderOfQi(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(343);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 施医赠药
	/// {0}在{1}向{2}提议助其治病复元…
	/// </summary>
	public void AddAdviseHealHealth(int charId, Location location, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(344);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 村民衣衫
	/// 玉尺剪裁工，衣衫巧样缝。太吾村民听闻村中新设{0}席位，于是制得{1}……
	/// </summary>
	public void AddTaiWuVillagerClothing(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(345);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 追捕罪犯
	/// 在{2}被{0}拦住去路，称奉命前来追捕{1}！
	/// </summary>
	public void AddHuntCriminalTaiwu(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(346);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 糊涂传人
	/// {0}行路途中，遇到两小童戏耍打闹……
	/// </summary>
	public void AddSectMainStoryZhujianHeir(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(347);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 铸剑衰落
	/// 江湖言传，铸剑山庄众人因执意效仿先祖，耗费资材过甚，终至落寞……
	/// </summary>
	public void AddSectMainStoryZhujianFailing()
	{
		int beginOffset = BeginAddingRecord(352);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 界青惩戒
	/// 因刻有{0}姓名的密令被投入无生渊，在{1}遭到界青杀手的袭击…
	/// </summary>
	public void AddJieQingPunishmentAssassin(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(353);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 追捕身死
	/// {0}在押送{1}返回门派途中死亡…
	/// </summary>
	public void AddTaiwuBeHuntedHunterDie(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(354);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 辟魔御邪
	/// 太吾村危机当前，{0}只得涉危履险，一力拒守……
	/// </summary>
	public void AddWardOffXiangshuProtection(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(355);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 上贡促织
	/// 秋气肃金，一名江湖人士受人所托，前来拜访{0}……
	/// </summary>
	public void AddProfessionDukeReceiveCricket(int charId)
	{
		int beginOffset = BeginAddingRecord(356);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 促织入梦
	/// {0}在{1}梦见一只奇异的促织！
	/// </summary>
	public void AddCricketInDreamTaiwuPartnerPregnant(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(357);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 诛魔试炼
	/// {0}行路途中，忽得少林派传来书信一封……
	/// </summary>
	public void AddSectMainStoryShaolinDharmaCave(int charId)
	{
		int beginOffset = BeginAddingRecord(358);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 重申信誓
	/// 重申太吾村{2}石碑信誓，{1}遣弟子与{0}相见…
	/// </summary>
	public void AddTaiwuVillageStoneClaimed(int charId, short settlementId, short settlementId1, int value)
	{
		int beginOffset = BeginAddingRecord(359);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendSettlement(settlementId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 收养弃婴
	/// 太吾村民在太吾村外偶遇一弃婴，意欲将其收养至村中……
	/// </summary>
	public void AddTaiwuVillagerAdoptOrphan(int charId, int charId1, int value)
	{
		int beginOffset = BeginAddingRecord(360);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 神木凋萎
	/// 神木凋敝，死灰不燃。位于{0}的神木遭到相枢爪牙毁坏！
	/// </summary>
	public void AddNormalHeavenlyTreeDestroyed(Location location)
	{
		int beginOffset = BeginAddingRecord(363);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 遇到爪牙
	/// 千劫不尽，邪秽将至。{0}在位于{1}的神木树下与邪祟狭路相逢……
	/// </summary>
	public void AddNormalGuardHeavenlyTree(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(364);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 天外世界
	/// {0}入一明珏游历三千幻境，遍探山海，饱览奇观，如今终于自镜中归来……
	/// </summary>
	public void AddBackFromOuterWorlds(int charId)
	{
		int beginOffset = BeginAddingRecord(374);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 千里姻缘
	/// {0}欲成姻缘喜事，却因心存迷惘，特意寄来一封书信……
	/// </summary>
	public void AddAiLongDistanceMarriageAskAdvice(int charId)
	{
		int beginOffset = BeginAddingRecord(378);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 跃马听香
	/// 良辰吉日，同乐共欢，有一“宛渠之民”喜气洋洋而来……
	/// </summary>
	public void AddDLCYearOfHorseCloth()
	{
		int beginOffset = BeginAddingRecord(393);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 继承遗赠
	/// {0}于{1}获得来自{2}的遗赠……
	/// </summary>
	public void AddBequest(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(394);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 金丝化烬
	/// 这一日，不知何故，{0}怀中锦囊忽生异动……
	/// </summary>
	public void AddMainStoryTianmuPeopleRemoveItem(int charId)
	{
		int beginOffset = BeginAddingRecord(395);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 仙公寻仙
	/// 月落星沉，夜阑风静，{0}诸事萦怀，不觉沉沉睡去，长梦之中，依稀望见徐仙公身影……
	/// </summary>
	public void AddMainStoryImmortalXuSeekSacrifice(int charId)
	{
		int beginOffset = BeginAddingRecord(396);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 神火黑焰
	/// 月落星沉，夜阑风静，{0}诸事萦怀，不觉沉沉睡去，长梦之中，依稀望见两道相仿的身影……
	/// </summary>
	public void AddMainStoryHeavenlyDarkFire(int charId)
	{
		int beginOffset = BeginAddingRecord(397);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 无绡遗魄
	/// 月落星沉，夜阑风静，{0}诸事萦怀，不觉沉沉睡去，长梦之中，依稀望见紫无绡身影……
	/// </summary>
	public void AddMainStoryWuxiaoSpiritSection0(int charId)
	{
		int beginOffset = BeginAddingRecord(398);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 无绡遗魄
	/// 月落星沉，夜阑风静，{0}诸事萦怀，不觉沉沉睡去，长梦之中，依稀望见紫无绡身影……
	/// </summary>
	public void AddMainStoryWuxiaoSpiritSection1(int charId)
	{
		int beginOffset = BeginAddingRecord(399);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 无绡遗魄
	/// 月落星沉，夜阑风静，{0}诸事萦怀，不觉沉沉睡去，长梦之中，依稀望见紫无绡身影……
	/// </summary>
	public void AddMainStoryWuxiaoSpiritSection2(int charId)
	{
		int beginOffset = BeginAddingRecord(400);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 三途邪魔
	/// 月残星隐，天地无光，忽闻马蹄声急，一骑如星流而至！
	/// </summary>
	public void AddMainStoryThreeWorldDevilAppear()
	{
		int beginOffset = BeginAddingRecord(401);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 火途邪魔
	/// 永堕三途，万劫不复。在{0}与火途邪魔狭路相逢，遭遇袭击！
	/// </summary>
	public void AddMainStoryThreeWorldDevilFire(Location location)
	{
		int beginOffset = BeginAddingRecord(402);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 血途邪魔
	/// 永堕三途，万劫不复。在{0}与血途邪魔狭路相逢，遭遇袭击！
	/// </summary>
	public void AddMainStoryThreeWorldDevilBlood(Location location)
	{
		int beginOffset = BeginAddingRecord(403);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 刀途邪魔
	/// 永堕三途，万劫不复。在{0}与刀途邪魔狭路相逢，遭遇袭击！
	/// </summary>
	public void AddMainStoryThreeWorldDevilMelee(Location location)
	{
		int beginOffset = BeginAddingRecord(404);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 仙公遗骸
	/// 是夜，{0}辗转难眠之际，忽见一道灰影悄然近前……
	/// </summary>
	public void AddMainStoryImmortalXuStolen(int charId)
	{
		int beginOffset = BeginAddingRecord(405);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 促织幻形
	/// 太吾村蛰室常有灵光明灭不定，夜半隐现人形，村中传言是有{0}幻化为人……
	/// </summary>
	public void AddDLCTransmogrifyingCricketToHumanbeing(short colorId, short partId, int nameId, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(406);
		AppendCricket(colorId, partId, nameId);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 人变促织
	/// {0}促织NPC已然性命垂危，化作{1}促织名重新回到{2}主角名称行囊
	/// </summary>
	public void AddDLCTransmogrifyingHumanbeingToCricket(int charId, short colorId, short partId, int nameId, int charId1)
	{
		int beginOffset = BeginAddingRecord(407);
		AppendCharacter(charId);
		AppendCricket(colorId, partId, nameId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 七星血光
	/// 破军孤悬，七星血光未息，不知此夜星象，又是何等光景……
	/// </summary>
	public void AddSectMainStoryJieqingBloodBeiDou()
	{
		int beginOffset = BeginAddingRecord(408);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 无名秘信
	/// 这一日，不知何人留下一封无名秘信……
	/// </summary>
	public void AddSectMainStoryJieqingMessage()
	{
		int beginOffset = BeginAddingRecord(409);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 摔珠之期
	/// 昔日与万恶约定的摔珠之期已至，是否依约碎珠，终须有所决断……
	/// </summary>
	public void AddSectMainStoryJieqingSmashPearl()
	{
		int beginOffset = BeginAddingRecord(410);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 界青故人
	/// 自界青崖下一别，已是数日，不知玉蝉的伤势如今可有好转……
	/// </summary>
	public void AddSectMainStoryJieqingRecovery()
	{
		int beginOffset = BeginAddingRecord(411);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 界青杀机
	/// 身负死令，界青杀手果然循踪而来……
	/// </summary>
	public void AddSectMainStoryJieqingAssassination()
	{
		int beginOffset = BeginAddingRecord(412);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 宛渠赠礼
	/// 晨雾未散，有一“宛渠之民”满怀歉意而来……
	/// </summary>
	public void AddDLCGiftFromConchShip1()
	{
		int beginOffset = BeginAddingRecord(413);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 宛渠赠礼
	/// 云散雾消，明月入怀，有一“宛渠之民”面带憧憬而来……
	/// </summary>
	public void AddDLCGiftFromConchShip2()
	{
		int beginOffset = BeginAddingRecord(414);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 新衣贺春
	/// 良辰吉日，同乐共欢，有一“宛渠之民”喜气洋洋而来……
	/// </summary>
	public void AddDLCHappyNewYear2024()
	{
		int beginOffset = BeginAddingRecord(415);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 碧霄蛇影
	/// 良辰吉日，同乐共欢，有一“宛渠之民”喜气洋洋而来……
	/// </summary>
	public void AddDLCYearOfSnakeCloth()
	{
		int beginOffset = BeginAddingRecord(416);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 老僧探访
	/// 此日，只见室述辅忧心忡忡，忽尔来访……
	/// </summary>
	public void AddMainStoryLineIronPlateMonkInvestigate()
	{
		int beginOffset = BeginAddingRecord(417);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 初见铁盘
	/// 此日行路途中，忽见一名太吾村人，匆匆赶来……
	/// </summary>
	public void AddMainStoryLineIronPlateItemReceived()
	{
		int beginOffset = BeginAddingRecord(418);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 初遇魔血
	/// {0}睡梦之中，似见血迹蜿蜒，流经玄石………
	/// </summary>
	public void AddMainStoryLineEvilDemonBlood(int charId)
	{
		int beginOffset = BeginAddingRecord(419);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 欲念侵心
	/// {0}独坐空帷，不觉绮念丛生，拂之难去，欲断还连………
	/// </summary>
	public void AddMainStoryLineEvilMohaMind(int charId)
	{
		int beginOffset = BeginAddingRecord(420);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 魔血异动
	/// 血光明灭，低语幽然，伏虞剑柄似有异动！
	/// </summary>
	public void AddMainStoryLineEvilBloodAdv()
	{
		int beginOffset = BeginAddingRecord(421);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 剑斗之邀
	/// 大岳瑶常寻来，欲要比斗一番……
	/// </summary>
	public void AddMainStoryLineDivineflameFuxietie()
	{
		int beginOffset = BeginAddingRecord(422);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 龙吟神髓
	/// 卫起若有所思，身中龙魂不断显现……
	/// </summary>
	public void AddMainStoryLineDivineflameJielongpo()
	{
		int beginOffset = BeginAddingRecord(423);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 雪落空寂
	/// 入冬以来，九寒始终独自雕琢雪像，对其余事情充耳不闻……
	/// </summary>
	public void AddMainStoryLineDivineflameDaxuanning()
	{
		int beginOffset = BeginAddingRecord(424);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 金戈铁军
	/// 血枫自称重组铁军，邀太吾传人前去一观……
	/// </summary>
	public void AddMainStoryLineDivineflameQiumomu()
	{
		int beginOffset = BeginAddingRecord(425);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 繁花蜃景
	/// 异火飘摇，桃花纷落，似有白狐在林中游窜……
	/// </summary>
	public void AddMainStoryLineDivineflameFenshenlian()
	{
		int beginOffset = BeginAddingRecord(426);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 痴念建木	
	/// 以向木然呆坐，凝然不动，不知在痴想什么……
	/// </summary>
	public void AddMainStoryLineDivineflameRongchenyin()
	{
		int beginOffset = BeginAddingRecord(427);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 春酒醉人
	/// 金凰儿手捧美酒，轻舞欢歌，欲邀人共饮……
	/// </summary>
	public void AddMainStoryLineDivineflameFenghuangjian()
	{
		int beginOffset = BeginAddingRecord(428);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 雨后绮梦
	/// 暴雨倾落，昏然欲睡，似有绮梦邀人入眠……
	/// </summary>
	public void AddMainStoryLineDivineflameGuishenxia()
	{
		int beginOffset = BeginAddingRecord(429);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 灵鸟宿缘
	/// 灵鸟啼鸣，如泣如诉，似有宿缘未了，只待重逢……
	/// </summary>
	public void AddMainStoryLineDivineflameMonvyi()
	{
		int beginOffset = BeginAddingRecord(430);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 仙猿传闻
	/// 峨眉山间，似有奇闻异事悄然流传……
	/// </summary>
	public void AddSectMainStoryEmeiUpgradeRumors()
	{
		int beginOffset = BeginAddingRecord(431);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 修行之果
	/// 小白猿修行尚未有成，峨眉山间，却忽生异事……
	/// </summary>
	public void AddSectMainStoryEmeiUpgradeStudy()
	{
		int beginOffset = BeginAddingRecord(432);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 修得人身
	/// 得{0}一番点拨，小白猿修行日久，终有所成……
	/// </summary>
	public void AddSectMainStoryEmeiUpgradeAchieve(int charId)
	{
		int beginOffset = BeginAddingRecord(433);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 春宵一刻
	/// 春宵一刻值千金，花有清香月有阴……
	/// </summary>
	public void AddMakeLoveWithTaiwu(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(434);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 莫女寸心
	/// {0}心结已解，其剑柄隐隐泛光，剑柄中功法已然精深……
	/// </summary>
	public void AddSwordFragmentUnlockSkillMonvGood(int charId)
	{
		int beginOffset = BeginAddingRecord(435);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 莫女入潭
	/// {0}劫数难消，其剑柄微微震颤，剑柄中功法已然凝炼……
	/// </summary>
	public void AddSwordFragmentUnlockSkillMonvBad(int charId)
	{
		int beginOffset = BeginAddingRecord(436);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 伏邪斩恶
	/// {0}心结已解，其剑柄隐隐泛光，剑柄中功法已然精深……
	/// </summary>
	public void AddSwordFragmentUnlockSkillDayueYaochangGood(int charId)
	{
		int beginOffset = BeginAddingRecord(437);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 伏邪舍断
	/// {0}劫数难消，其剑柄微微震颤，剑柄中功法已然凝炼……
	/// </summary>
	public void AddSwordFragmentUnlockSkillDayueYaochangBad(int charId)
	{
		int beginOffset = BeginAddingRecord(438);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 大玄凝洪
	/// {0}心结已解，其剑柄隐隐泛光，剑柄中功法已然精深……
	/// </summary>
	public void AddSwordFragmentUnlockSkillJiuhanGood(int charId)
	{
		int beginOffset = BeginAddingRecord(439);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 大玄诉亡
	/// {0}劫数难消，其剑柄微微震颤，剑柄中功法已然凝炼……
	/// </summary>
	public void AddSwordFragmentUnlockSkillJiuhanBad(int charId)
	{
		int beginOffset = BeginAddingRecord(440);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 凤凰贺世
	/// {0}心结已解，其剑柄隐隐泛光，剑柄中功法已然精深……
	/// </summary>
	public void AddSwordFragmentUnlockSkillJinHuangerGood(int charId)
	{
		int beginOffset = BeginAddingRecord(441);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 凤凰破空
	/// {0}劫数难消，其剑柄微微震颤，剑柄中功法已然凝炼……
	/// </summary>
	public void AddSwordFragmentUnlockSkillJinHuangerBad(int charId)
	{
		int beginOffset = BeginAddingRecord(442);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 焚神归狐
	/// {0}心结已解，其剑柄隐隐泛光，剑柄中功法已然精深……
	/// </summary>
	public void AddSwordFragmentUnlockSkillYiYihouGood(int charId)
	{
		int beginOffset = BeginAddingRecord(443);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 焚神残恸
	/// {0}劫数难消，其剑柄微微震颤，剑柄中功法已然凝炼……
	/// </summary>
	public void AddSwordFragmentUnlockSkillYiYihouBad(int charId)
	{
		int beginOffset = BeginAddingRecord(444);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 解龙舍命
	/// {0}心结已解，其剑柄隐隐泛光，剑柄中功法已然精深……
	/// </summary>
	public void AddSwordFragmentUnlockSkillWeiQiGood(int charId)
	{
		int beginOffset = BeginAddingRecord(445);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 解龙舍身
	/// {0}劫数难消，其剑柄微微震颤，剑柄中功法已然凝炼……
	/// </summary>
	public void AddSwordFragmentUnlockSkillWeiQiBad(int charId)
	{
		int beginOffset = BeginAddingRecord(446);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 溶尘无剑
	/// {0}心结已解，其剑柄隐隐泛光，剑柄中功法已然精深……
	/// </summary>
	public void AddSwordFragmentUnlockSkillYixiangGood(int charId)
	{
		int beginOffset = BeginAddingRecord(447);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 溶尘无心
	/// {0}劫数难消，其剑柄微微震颤，剑柄中功法已然凝炼……
	/// </summary>
	public void AddSwordFragmentUnlockSkillYixiangBad(int charId)
	{
		int beginOffset = BeginAddingRecord(448);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 六合囚魔
	/// {0}心结已解，其剑柄隐隐泛光，剑柄中功法已然精深……
	/// </summary>
	public void AddSwordFragmentUnlockSkillXuefengGood(int charId)
	{
		int beginOffset = BeginAddingRecord(449);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 囚魔无赦
	/// {0}劫数难消，其剑柄微微震颤，剑柄中功法已然凝炼……
	/// </summary>
	public void AddSwordFragmentUnlockSkillXuefengBad(int charId)
	{
		int beginOffset = BeginAddingRecord(450);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 昆仑神霞
	/// {0}心结已解，其剑柄隐隐泛光，剑柄中功法已然精深……
	/// </summary>
	public void AddSwordFragmentUnlockSkillShuFangGood(int charId)
	{
		int beginOffset = BeginAddingRecord(451);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 魔瞳神霞
	/// {0}劫数难消，其剑柄微微震颤，剑柄中功法已然凝炼……
	/// </summary>
	public void AddSwordFragmentUnlockSkillShuFangBad(int charId)
	{
		int beginOffset = BeginAddingRecord(452);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 化身传讯
	/// 这一日，神剑剑柄震动，似是一位紫竹化身遥遥传讯而至……
	/// </summary>
	public void AddMainStoryMessagefromtheAvatar(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(453);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 剑光捷报
	/// 这一日，忽见天边一道剑光破空而来……
	/// </summary>
	public void AddMainStoryTidingsonSwiftBlades(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(454);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 故人传讯
	/// 这一日，忽见一位江湖隐士飞身而来……
	/// </summary>
	public void AddMainStoryMessagefromanOldFriend(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(455);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 故人捷报
	/// 这一日，七元铁盘隐隐发烫，似有故人遥遥传讯而至……
	/// </summary>
	public void AddMainStoryTidingsfromanOldFriend(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(456);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 无念传讯
	/// 这一日，一位无念众暗中传讯而至……
	/// </summary>
	public void AddMainStoryMessagefromWunian(int charId)
	{
		int beginOffset = BeginAddingRecord(457);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 心念捷报
	/// 这一日，忽见一位心念化身迎上前来……
	/// </summary>
	public void AddMainStoryTidingsoftheMind(int charId)
	{
		int beginOffset = BeginAddingRecord(458);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 剑柄异动
	/// 降服邪仙之事渐有眉目，这一日，伏虞剑柄又一阵躁动……
	/// </summary>
	public void AddMainStoryStirringoftheSwordHilt()
	{
		int beginOffset = BeginAddingRecord(459);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 月濯紫尘
	/// 邪仙尚未尽除，如此深夜时分，徐仙公急急相寻，所为何事？
	/// </summary>
	public void AddMainStoryMoonlitPurpleDust()
	{
		int beginOffset = BeginAddingRecord(460);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 子夜生变
	/// 夜半子时，天地昏蒙，一阵嘈杂之声却骤然响起……
	/// </summary>
	public void AddMainStoryMidnightUpheaval()
	{
		int beginOffset = BeginAddingRecord(461);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 异火焚天
	/// 万籁俱寂，阴云蔽月，忽而一道异火冲天而起，撕开沉沉夜幕……
	/// </summary>
	public void AddMainStoryStrangeFireScorchestheSky()
	{
		int beginOffset = BeginAddingRecord(462);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 青焰异动
	/// 繁星盈野，月隐于穹。忽闻道旁窸窣之声，似有故人披星而来……
	/// </summary>
	public void AddSectMainStoryJieQingUpgradeYuchan()
	{
		int beginOffset = BeginAddingRecord(463);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 星运入世
	/// 暮色四合，星子渐明。数日不见，玉蝉已似与往日不同……
	/// </summary>
	public void AddSectMainStoryJieQingUpgradeXingYun()
	{
		int beginOffset = BeginAddingRecord(464);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 剑冢异动
	/// 剑冢{0}所在之处异变丛生，似有可怖之物已破冢而出！
	/// </summary>
	public void AddXiangshuAvatarAttack(sbyte xiangshuAvatarId)
	{
		int beginOffset = BeginAddingRecord(465);
		AppendSwordTomb(xiangshuAvatarId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 风波乍起
	/// 行路途中，一名峨眉弟子行迹匆匆，径直迎面而来……
	/// </summary>
	public void AddSectMainStoryEmeiBeginning()
	{
		int beginOffset = BeginAddingRecord(466);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 峨眉山月
	/// 峨峨峻岭，峰衔新月，此夜峨眉山中，却有几分不同寻常……
	/// </summary>
	public void AddSectMainStoryEmeiMidnight()
	{
		int beginOffset = BeginAddingRecord(467);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 掌门密信
	/// 峨眉派中，忽而传来一封密信……
	/// </summary>
	public void AddSectMainStoryEmeiSecretLetter()
	{
		int beginOffset = BeginAddingRecord(468);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 峨眉急信
	/// 峨眉派中，忽而传来一封急信……
	/// </summary>
	public void AddSectMainStoryEmeiUrgentLetter()
	{
		int beginOffset = BeginAddingRecord(469);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 白猿送果
	/// 白猿幽居山林，心中仍然挂念{0}……
	/// </summary>
	public void AddSectMainStoryEmeiFruitsGift(int charId)
	{
		int beginOffset = BeginAddingRecord(470);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 峨眉之谢
	/// 此日，忽有一名峨眉弟子寻来，欲要称谢……
	/// </summary>
	public void AddSectMainStoryEmeiAppreciateofEmei()
	{
		int beginOffset = BeginAddingRecord(471);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 江湖行客
	/// 峨眉事了，风波既平，各路前来相助的江湖侠客纷纷前来辞别……
	/// </summary>
	public void AddSectMainStoryEmeiFarewell()
	{
		int beginOffset = BeginAddingRecord(472);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 怨恨横生
	/// {1}在{2}受邪仙赤鸿子蛊惑，竟无端对{0}心生怨恨……
	/// </summary>
	public void AddMainStoryImmortalChiHongZi(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(473);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 护法袭击
	/// 受邪仙破烬上人驱使，化作魔天护法的{1}忽向途径近旁的{0}暴起发难……
	/// </summary>
	public void AddMainStoryImmortalPoJinShangRen(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(474);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 无明杀机
	/// 妄动无明，杀心顿生。因邪仙八九剑隐作祟，{1}心中唯余杀念，向途经近旁的{0}袭来！
	/// </summary>
	public void AddMainStoryImmortalBaJiuJianYin(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(475);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 痴念横生
	/// {1}在{2}受邪仙真丹圣女的蛊惑，竟无端对{0}心生爱慕痴缠之念……
	/// </summary>
	public void AddMainStoryImmortalZhenDanShengNv(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(476);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 青山依旧
	/// 雨霁云开，青山依旧，有一“宛渠之民”满怀感激而来……
	/// </summary>
	public void AddDLCGreenHillsRemain()
	{
		int beginOffset = BeginAddingRecord(477);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 八载同舟
	/// 八载同舟，劫波共渡，有一“宛渠之民”满怀感激而来……
	/// </summary>
	public void AddDLCEightYearsOneJourney()
	{
		int beginOffset = BeginAddingRecord(478);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月事件 - 尸魔袭击
	/// 因邪仙活骨师作祟，坟冢中钻出的的尸魔向途径近旁的{0}袭来！
	/// </summary>
	public void AddMainStoryImmortalHuoGuShi(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(479);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加自动触发得过月事件.
	/// 该类过月事件不允许添加参数.
	/// </summary>
	/// <param name="argBox"></param>
	/// <param name="monthlyEventCfg"></param>
	public void AddAutoMonthlyEvent(IVariantCollection<string> argBox, MonthlyEventItem monthlyEventCfg)
	{
		int i = 0;
		for (int count = monthlyEventCfg.Parameters.Length; i < count; i++)
		{
			string parameter = monthlyEventCfg.Parameters[i];
			if (!string.IsNullOrEmpty(parameter) && !monthlyEventCfg.AutoTriggerArguments.CheckIndex(i))
			{
				AdaptableLog.Warning($"Invalid auto monthly event with args: {monthlyEventCfg.Name} arg{i}={parameter}", appendWarningMessage: true);
				return;
			}
		}
		int beginOffset = BeginAddingRecord(monthlyEventCfg.TemplateId);
		int j = 0;
		for (int count2 = monthlyEventCfg.Parameters.Length; j < count2; j++)
		{
			string parameter2 = monthlyEventCfg.Parameters[j];
			if (!string.IsNullOrEmpty(parameter2))
			{
				sbyte paramType = ParameterType.Parse(parameter2);
				string argKey = monthlyEventCfg.AutoTriggerArguments[j];
				switch (paramType)
				{
				case 0:
				{
					int charId = GetCharIdFromArgBox(argBox, argKey);
					AppendCharacter(charId);
					break;
				}
				case 1:
				{
					Location location = GetLocationFromArgBox(argBox, argKey);
					AppendLocation(location);
					break;
				}
				case 5:
				{
					int settlement = -1;
					argBox.Get(argKey, ref settlement);
					AppendSettlement((short)settlement);
					break;
				}
				case 10:
				{
					int adventureId = -1;
					argBox.Get(argKey, ref adventureId);
					AppendAdventure((short)adventureId);
					break;
				}
				case 22:
				{
					int value = 0;
					argBox.Get(argKey, ref value);
					AppendInteger(value);
					break;
				}
				case 25:
				{
					argBox.Get(argKey, out ItemKey itemKey);
					AppendItemKey((ulong)itemKey);
					break;
				}
				default:
					AdaptableLog.Warning("Invalid auto monthly event with args: " + monthlyEventCfg.Name, appendWarningMessage: true);
					break;
				}
			}
		}
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加任务系统关联的过月事件
	/// </summary>
	/// <param name="argBox"></param>
	/// <param name="monthlyEvent"></param>
	public void AddAutoMonthlyEvent(IVariantCollection<string> argBox, AutoTriggerMonthlyEvent monthlyEvent)
	{
		int beginOffset = BeginAddingRecord(monthlyEvent.MonthlyEventId);
		MonthlyEventItem monthlyEventCfg = Config.MonthlyEvent.Instance[monthlyEvent.MonthlyEventId];
		int i = 0;
		for (int count = monthlyEventCfg.Parameters.Length; i < count; i++)
		{
			string parameter = monthlyEventCfg.Parameters[i];
			if (string.IsNullOrEmpty(parameter))
			{
				break;
			}
			string argKey = monthlyEvent.Args[i];
			switch (ParameterType.Parse(parameter))
			{
			case 0:
			{
				int charId = GetCharIdFromArgBox(argBox, argKey);
				AppendCharacter(charId);
				break;
			}
			case 1:
			{
				Location location = GetLocationFromArgBox(argBox, argKey);
				AppendLocation(location);
				break;
			}
			case 5:
			{
				int settlement = -1;
				argBox.Get(argKey, ref settlement);
				AppendSettlement((short)settlement);
				break;
			}
			case 10:
			{
				int adventureId = -1;
				argBox.Get(argKey, ref adventureId);
				AppendAdventure((short)adventureId);
				break;
			}
			case 22:
			{
				int value = 0;
				argBox.Get(argKey, ref value);
				AppendInteger(value);
				break;
			}
			case 25:
			{
				argBox.Get(argKey, out ItemKey itemKey);
				AppendItemKey((ulong)itemKey);
				break;
			}
			}
		}
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加世界状态关联的过月事件
	/// </summary>
	/// <param name="worldState"></param>
	/// <param name="monthlyEvent"></param>
	public void AddWorldStateMonthlyEvent(WorldStateItem worldState, MonthlyEventItem monthlyEvent)
	{
		int beginOffset = BeginAddingRecord(monthlyEvent.TemplateId);
		EndAddingRecord(beginOffset);
	}

	private int GetCharIdFromArgBox(IVariantCollection<string> argBox, string argKey)
	{
		if (argKey == "RoleTaiwu")
		{
			return ExternalDataBridge.Context.TaiwuCharId;
		}
		int charId = -1;
		if (!argBox.Get(argKey, ref charId))
		{
			return -1;
		}
		return charId;
	}

	private Location GetLocationFromArgBox(IVariantCollection<string> argBox, string argKey)
	{
		if (argKey == "TaiwuLocation")
		{
			return ExternalDataBridge.Context.TaiwuLocation;
		}
		if (!argBox.Get(argKey, out Location location))
		{
			return Location.Invalid;
		}
		return location;
	}

	/// <inheritdoc />
	public unsafe override void FillEventArgBox(int offset, IVariantCollection<string> eventArgBox)
	{
		string keyPrefix = "MonthlyEvent_arg";
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = *(short*)(pCurrData + 1);
			pCurrData += 3;
			string[] parameters = Config.MonthlyEvent.Instance[recordType].Parameters;
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				ReadArgumentToEventArgBox(keyPrefix, i, paramType, &pCurrData, eventArgBox);
			}
		}
	}
}
