using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.World.Notification;

/// <summary>
/// 过月通知的集合.
/// 单条过月通知数据格式: size (uint8_t), record_type (int16_t), optional arguments.
/// </summary>
/// <summary>
/// 过月通知的集合 - 添加过月通知
/// </summary>
public class MonthlyNotificationCollection : WriteableRecordCollection
{
	/// <summary>
	/// 过月通知的集合
	/// </summary>
	public MonthlyNotificationCollection()
	{
	}

	/// <summary>
	/// 过月通知的集合
	/// </summary>
	/// <param name="initialCapacity">原始数据容器的初始容量</param>
	public MonthlyNotificationCollection(int initialCapacity)
		: base(initialCapacity)
	{
	}

	/// <summary>
	/// 获取所有过月通知的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public new void GetRenderInfos(List<RenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			RenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定类型的过月通知的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	/// <param name="sectionType">指定板块类型</param>
	public void GetRenderInfos(List<RenderInfo> renderInfos, ArgumentCollection argumentCollection, EMonthlyNotificationSectionType sectionType)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			RenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null && MonthlyNotification.Instance[renderInfo.RecordType].SectionType == sectionType)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定索引的过月通知的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public new unsafe RenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = *(short*)(pCurrData + 1);
			pCurrData += 3;
			MonthlyNotificationItem config = MonthlyNotification.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			RenderInfo info = new RenderInfo(recordType, config.Desc);
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

	public unsafe byte* PrepareCopy(int size)
	{
		int offset = Size;
		int newSize = Size + size;
		EnsureCapacity(newSize);
		Size = newSize;
		int count = base.Count + 1;
		base.Count = count;
		fixed (byte* pRawData = RawData)
		{
			pRawData[offset] = (byte)size;
			return pRawData + offset;
		}
	}

	/// <summary>
	/// 添加无参数过月通知
	/// </summary>
	/// <param name="templateId"></param>
	public void AddMonthlyNotificationWithNoArgument(short templateId)
	{
		Tester.Assert(MonthlyNotification.Instance[templateId].Parameters.Count((string p) => !string.IsNullOrEmpty(p)) == 0);
		int beginOffset = BeginAddingRecord(templateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 寅月
	/// 建正之月，斗柄回寅。\n部分地点的「金铁」、「玉石」资源有一定程度的恢复。\n所有人恢复胸背外伤、内伤各一层…
	/// </summary>
	public void AddSolarTerm0()
	{
		int beginOffset = BeginAddingRecord(0);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 卯月
	/// 建卯之月，阳和布气。\n部分地点的「食材」、「木材」、「药材」资源有一定程度的恢复。\n所有人恢复腰腹外伤、内伤各一层…
	/// </summary>
	public void AddSolarTerm1()
	{
		int beginOffset = BeginAddingRecord(1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 辰月
	/// 建辰之月，斗柄东指。\n部分地点的「食材」、「木材」、「药材」资源有一定程度的恢复。\n所有人恢复左臂、右臂的外伤、内伤各一层…
	/// </summary>
	public void AddSolarTerm2()
	{
		int beginOffset = BeginAddingRecord(2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 巳月
	/// 建巳之月，草木舒荣。\n部分地点的「食材」、「木材」、「药材」资源有一定程度的恢复。\n所有人恢复左腿、右腿的外伤、内伤各一层…
	/// </summary>
	public void AddSolarTerm3()
	{
		int beginOffset = BeginAddingRecord(3);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 午月
	/// 建午之月，秧稻初齐。\n部分地点的「木材」、「织物」资源有一定程度的恢复。\n伤势无法自然恢复…
	/// </summary>
	public void AddSolarTerm4()
	{
		int beginOffset = BeginAddingRecord(4);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 未月
	/// 建未之月，斗柄南指。\n部分地点的「木材」、「织物」资源有一定程度的恢复。\n所有人恢复头颈的外伤、内伤各一层…
	/// </summary>
	public void AddSolarTerm5()
	{
		int beginOffset = BeginAddingRecord(5);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 申月
	/// 建申之月，蝉鸣嘒嘒。\n部分地点的「木材」、「织物」资源有一定程度的恢复。\n所有人恢复胸背的外伤、内伤各一层…
	/// </summary>
	public void AddSolarTerm6()
	{
		int beginOffset = BeginAddingRecord(6);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 酉月
	/// 建酉之月，商星西流。\n部分地点的「食材」、「织物」、「药材」资源有一定程度的恢复。\n所有人恢复腰腹的外伤、内伤各一层…
	/// </summary>
	public void AddSolarTerm7()
	{
		int beginOffset = BeginAddingRecord(7);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 戌月
	/// 建戌之月，斗柄西指。\n部分地点的「食材」、「织物」、「药材」资源有一定程度的恢复。\n所有人恢复左臂、右臂的外伤、内伤各一层…
	/// </summary>
	public void AddSolarTerm8()
	{
		int beginOffset = BeginAddingRecord(8);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 亥月
	/// 建亥之月，柳衰谷秀。\n部分地点的「食材」、「织物」、「药材」资源有一定程度的恢复。\n所有人恢复左腿、右腿的外伤、内伤各一层…
	/// </summary>
	public void AddSolarTerm9()
	{
		int beginOffset = BeginAddingRecord(9);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 子月
	/// 建子之月，万物收藏。\n部分地点的「金铁」、「玉石」资源有一定程度的恢复。\n伤势无法自然恢复…
	/// </summary>
	public void AddSolarTerm10()
	{
		int beginOffset = BeginAddingRecord(10);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 丑月
	/// 建丑之月，斗柄北指。\n部分地点的「金铁」、「玉石」资源有一定程度的恢复。\n所有人恢复头颈的外伤、内伤各一层…
	/// </summary>
	public void AddSolarTerm11()
	{
		int beginOffset = BeginAddingRecord(11);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 坟冢消亡
	/// {0}的坟墓因为长时间未被打理，彻底损毁消失了。
	/// </summary>
	public void AddGraveDestroyed(int charId)
	{
		int beginOffset = BeginAddingRecord(12);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 外道供奉
	/// {0}在{1}代{2}收取了{3}的供奉…
	/// </summary>
	public void AddIncomeFromNest(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(13);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 仓库超负
	/// 由于存放了过多的物品，导致仓库中的{0}不慎遗失…
	/// </summary>
	public void AddLoseItemCausedByWarehouseFull(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(14);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遭到暗杀
	/// {0}在{1}因遭到界青门的暗杀而死…
	/// </summary>
	public void AddAssassinated(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(15);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 无影夺命
	/// {0}在{1}因手持无影令遭到界青门的暗杀而死…
	/// </summary>
	public void AddAssassinatedDueToKillerToken(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(16);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天人永别
	/// {0}在{1}离开了人世。
	/// </summary>
	public void AddDie(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(17);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 相枢入邪
	/// {0}在{1}被相枢的邪念干扰，不能自己。
	/// </summary>
	public void AddInfectXiangshuPartially(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(18);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 相枢魔通
	/// {0}在{1}屈服于相枢的邪念，终于堕入魔道，化身为相枢座下恶鬼。
	/// </summary>
	public void AddInfectXiangshuCompletely(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(19);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 监禁仇怨
	/// {0}在{1}因被{2}监禁，对{2}心生怨恨…
	/// </summary>
	public void AddCreateHatredByPrison(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(20);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 逃脱关押
	/// {0}在{1}摆脱了{2}的监禁逃走了…
	/// </summary>
	public void AddEscapeFromPrison(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(21);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 促织寿终
	/// 一只{0}寿终正寝了…
	/// </summary>
	public void AddCricketEndLife(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(22);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 资源超负
	/// 由于携带了过多的资源，导致{0}行囊中的部分{1}不慎遗失…
	/// </summary>
	public void AddLoseResourceCausedByInventoryFull(int charId, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(23);
		AppendCharacter(charId);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 行囊超负
	/// 由于携带了过多的物品，导致{0}行囊中的{1}不慎遗失…
	/// </summary>
	public void AddLoseItemCausedByInventoryFull(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(24);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 与人结怨
	/// {0}在{1}对{2}怀恨在心，结下了莫名的仇怨。
	/// </summary>
	public void AddCreateHatred(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(25);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 化解仇恨
	/// {0}在{1}化解了对{2}的仇恨，不再视其为敌人了。
	/// </summary>
	public void AddDecreaseHatred(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(26);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 诉说爱慕
	/// {0}在{1}对{2}倾情相待，终于打动对方，两人互生爱慕之情。
	/// </summary>
	public void AddConfessLoveAndSucceed(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(27);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 雨恨云愁
	/// {0}在{1}与{2}断绝了彼此的情爱。只叹：此情可待成追忆，只是当时已惘然…
	/// </summary>
	public void AddSeverLove(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(28);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 共结连理
	/// {0}在{1}与{2}互许终生，结为夫妻。
	/// </summary>
	public void AddMarriage(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(29);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 意气相投
	/// {0}在{1}与{2}相谈甚欢，均觉莫逆于心，于是结为知己好友。
	/// </summary>
	public void AddBecomeFriend(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(30);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 关系疏远
	/// {0}在{1}与{2}产生隔阂。二人不复往日友谊，最终难免行同陌路。
	/// </summary>
	public void AddDecreaseFriendship(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(31);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 义结金兰
	/// {0}在{1}与{2}八拜结义，不求同年同月同日生，但求同年同月同日死。
	/// </summary>
	public void AddBecomeSwornBrotherOrSister(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(32);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 恩断义绝
	/// {0}在{1}与{2}割袍断义，再不复结义之情，所谓：不及黄泉，无相见也。
	/// </summary>
	public void AddSeverFriendship(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(33);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 收养义子
	/// {0}在{1}收养了{2}为义子。
	/// </summary>
	public void AddAdoptBoy(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(34);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 收养义女
	/// {0}在{1}收养了{2}为义女。
	/// </summary>
	public void AddAdoptGirl(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(35);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 拜认义父
	/// {0}在{1}拜认了{2}为义父。
	/// </summary>
	public void AddRecognizeFather(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(36);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 拜认义母
	/// {0}在{1}拜认了{2}为义母。
	/// </summary>
	public void AddRecognizeMother(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(37);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 春宵一刻
	/// {0}在{1}与{2}共度春宵。二人恩爱无已，情深无限。
	/// </summary>
	public void AddMakeLove(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(38);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 情难自已
	/// {0}在{1}情难自已，欲以卑劣手段欺侮{2}，但为{2}识破，最终并未成功。
	/// </summary>
	public void AddRapeFailure(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(39);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 喜得贵子
	/// {0}在{1}诞下一子。
	/// </summary>
	public void AddMotherGiveBirthToBoy(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(40);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 喜得千金
	/// {0}在{1}诞下一女。
	/// </summary>
	public void AddMotherGiveBirthToGirl(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(41);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 喜得贵子
	/// {0}的儿子出世了！
	/// </summary>
	public void AddFatherGetBoy(int charId)
	{
		int beginOffset = BeginAddingRecord(42);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 喜得千金
	/// {0}的女儿出世了！
	/// </summary>
	public void AddFatherGetGirl(int charId)
	{
		int beginOffset = BeginAddingRecord(43);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 异胎降生
	/// {0}的孩子在经历了三年零六个月的怀胎后终于降生了…
	/// </summary>
	public void AddGiveBirthToCricket(int charId)
	{
		int beginOffset = BeginAddingRecord(44);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 痛失骨肉
	/// {0}因身体不适，在{1}触动了胎气，以致痛失了腹中的胎儿。
	/// </summary>
	public void AddMotherLoseFetus(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(45);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 拜师学艺
	/// {0}前往{1}以求拜师学艺…
	/// </summary>
	public void AddGoToJoinOrganization(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(46);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 加入门派
	/// {0}加入了{1}，成为{1}的弟子。
	/// </summary>
	public void AddJoinOrganization(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(47);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 前往赴约
	/// {0}正在前往{1}赴约…
	/// </summary>
	public void AddGoToAppointment(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(48);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 等待赴约
	/// {0}正在{1}等待{2}赴约…
	/// </summary>
	public void AddWaitingForAppointment(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(49);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 未能赴约
	/// {0}在{1}苦候{2}多时，{2}却始终未能赴约…
	/// </summary>
	public void AddAppointmentExpired(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(50);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 无法赴约
	/// {0}在{1}放弃了与{2}原本的邀约…
	/// </summary>
	public void AddAppointmentCancelled(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(51);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 前往解救
	/// {0}得知{1}被{2}关押的消息，决定前往解救…
	/// </summary>
	public void AddGoToRescue(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(52);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 解救俘虏
	/// {0}将{1}从{2}的监禁中解救了出来。
	/// </summary>
	public void AddRescuePrisoner(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(53);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 释放俘虏
	/// {0}在{1}释放了{2}。
	/// </summary>
	public void AddReleasePrisoner(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(54);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 人物失踪
	/// {0}在{1}不知所踪…
	/// </summary>
	public void AddDisappear(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(55);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 前往复仇
	/// {0}决定去向{1}寻仇…
	/// </summary>
	public void AddGoToRevenge(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(56);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 前往保护
	/// {0}决定去保护{1}免受袭击…
	/// </summary>
	public void AddGoToProtect(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(57);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 保护亲友
	/// {0}将代{1}抵御{2}的袭击…
	/// </summary>
	public void AddProtectRelativeOrFriend(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(58);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 门派新任
	/// {0}成为了{1}{2}。
	/// </summary>
	public void AddSectUpgrade(int charId, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(59);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 市镇新任
	/// {0}成为了{1}{2}。
	/// </summary>
	public void AddCivilianSettlementUpgrade(int charId, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int beginOffset = BeginAddingRecord(60);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 派系新任
	/// {0}成为了{1}派系领袖。
	/// </summary>
	public void AddFactionUpgrade(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(61);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 窃取资源
	/// {0}在{1}试图窃取{2}的{3}，但并未成功。
	/// </summary>
	public void AddStealResourceFailure(int charId, Location location, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(62);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 窃取资源
	/// {0}在{1}窃取了{2}的部分{3}。
	/// </summary>
	public void AddStealResourceSuccess(int charId, Location location, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(63);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 唬骗资源
	/// {0}在{1}试图骗取{2}的{3}，但并未成功。
	/// </summary>
	public void AddCheatResourceFailure(int charId, Location location, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(64);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 抢夺资源
	/// {0}在{1}试图抢夺{2}的{3}，但并未成功。
	/// </summary>
	public void AddRobResourceFailure(int charId, Location location, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(65);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 盗掘资源
	/// {0}在{1}盗取了{2}坟墓中的部分{3}。
	/// </summary>
	public void AddDigResource(int charId, Location location, int charId1, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(66);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 窃取物品
	/// {0}在{1}试图窃取{2}的{3}，但并未成功。
	/// </summary>
	public void AddStealItemFailure(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(67);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 窃取物品
	/// {0}在{1}窃取了{2}的{3}。
	/// </summary>
	public void AddStealItemSuccess(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(68);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 唬骗物品
	/// {0}在{1}试图骗取{2}的{3}，但并未成功。
	/// </summary>
	public void AddCheatItemFailure(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(69);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 抢夺物品
	/// {0}在{1}试图抢夺{2}的{3}，但并未成功。
	/// </summary>
	public void AddRobItemFailure(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(70);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 盗掘物品
	/// {0}在{1}盗取了{2}坟墓中的{3}。
	/// </summary>
	public void AddDigItem(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(71);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 偷师技艺
	/// {0}在{1}试图偷学{2}的{3}，但并未有任何结果。
	/// </summary>
	public void AddStealLifeSkillFailure(int charId, Location location, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(72);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 偷师技艺
	/// {0}在{1}偷学了{2}的{3}。
	/// </summary>
	public void AddStealLifeSkillSuccess(int charId, Location location, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(73);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 骗取技艺
	/// {0}在{1}试图唬骗{2}以习得{3}，但并未成功。
	/// </summary>
	public void AddCheatLifeSkillFailure(int charId, Location location, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(74);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 偷师武艺
	/// {0}在{1}试图偷学{2}的{3}，但并未有任何结果。
	/// </summary>
	public void AddStealCombatSkillFailure(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(75);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 偷师武艺
	/// {0}在{1}偷学了{2}的{3}。
	/// </summary>
	public void AddStealCombatSkillSuccess(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(76);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 骗取武艺
	/// {0}在{1}试图唬骗{2}以习得{3}，但并未成功。
	/// </summary>
	public void AddCheatCombatSkillFailure(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(77);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 礼轻情重
	/// {0}在{1}将{2}赠送给{3}。
	/// </summary>
	public void AddGivePresentResource(int charId, Location location, sbyte resourceType, int charId1)
	{
		int beginOffset = BeginAddingRecord(78);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendResource(resourceType);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 物薄情厚
	/// {0}在{1}将{2}赠送给{3}。
	/// </summary>
	public void AddGivePresentItem(int charId, Location location, sbyte itemType, short itemTemplateId, int charId1)
	{
		int beginOffset = BeginAddingRecord(79);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 指点技艺
	/// {0}在{1}指点了{2}一些{3}的研习法门。
	/// </summary>
	public void AddTeachLifeSkillSuccess(int charId, Location location, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(80);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 指点技艺
	/// {0}在{1}有意指点{2}一些{3}的研习法门，但并未有任何结果。
	/// </summary>
	public void AddTeachLifeSkillFailure(int charId, Location location, int charId1, short lifeSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(81);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkill(lifeSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 指点武学
	/// {0}在{1}指点了{2}一些{3}的习练法门。
	/// </summary>
	public void AddTeachCombatSkillSuccess(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(82);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 指点武学
	/// {0}在{1}有意指点{2}一些{3}的习练法门，但并未有任何结果。
	/// </summary>
	public void AddTeachCombatSkillFailure(int charId, Location location, int charId1, short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(83);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奏乐娱人
	/// {0}在{1}聆听了{2}所奏的乐曲。
	/// </summary>
	public void AddAmuseOthersByMusic(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(84);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 对弈娱人
	/// {0}在{1}与{2}对弈谈天。
	/// </summary>
	public void AddAmuseOthersByChess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(85);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 诗书娱人
	/// {0}在{1}观赏了{2}所书的文章。
	/// </summary>
	public void AddAmuseOthersByPoem(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(86);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 绘画娱人
	/// {0}在{1}观赏了{2}所绘的画作。
	/// </summary>
	public void AddAmuseOthersByPainting(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(87);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 制造珍品
	/// {0}在{1}打造了世间罕有的{2}，声名扬于天下。
	/// </summary>
	public void AddMakeFamousItem(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(88);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 道法开悟
	/// {0}在{1}对{2}讲述道法奥妙，令{2}有所开悟，提升了{3}的资质。
	/// </summary>
	public void AddEnlightenedByDaoism(int charId, Location location, int charId1, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(89);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 佛学开悟
	/// {0}在{1}对{2}讲述佛法微理，令{2}有所开悟，提升了{3}的资质。
	/// </summary>
	public void AddEnlightenedByBuddhism(int charId, Location location, int charId1, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(90);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 受人占卜
	/// {0}在{1}占卜出了{2}所拥有的某件秘闻。
	/// </summary>
	public void AddPractiseDivination(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(91);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天降财宝
	/// {0}在{1}意外获得了十分珍稀的{2}。
	/// </summary>
	public void AddUnexpectedlyGetRareItem(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(92);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天降财宝
	/// {0}在{1}意外获得了{2}{3}。
	/// </summary>
	public void AddUnexpectedlyGetResource(int charId, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(93);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 不世奇遇
	/// {0}在{1}意外的获得了一部{2}的武诀秘籍。
	/// </summary>
	public void AddUnexpectedlyGetCombatSkill(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(94);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 不世奇遇
	/// {0}在{1}意外的获得了一部{2}的技艺秘籍。
	/// </summary>
	public void AddUnexpectedlyGetLifeSkill(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(95);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天助疗愈
	/// {0}在{1}梦到神奇的白鹿，恢复了{2}点健康。
	/// </summary>
	public void AddUnexpectedlyGetHealth(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(96);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天助疗愈
	/// {0}在{1}梦到神奇的白鹿，恢复了{2}点外伤。
	/// </summary>
	public void AddUnexpectedlyHealOuterInjury(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(97);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天助疗愈
	/// {0}在{1}梦到神奇的白鹿，恢复了{2}点内伤。
	/// </summary>
	public void AddUnexpectedlyHealInnerInjury(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(98);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天助疗愈
	/// {0}在{1}梦到神奇的白鹿，体内的{2}减轻了。
	/// </summary>
	public void AddUnexpectedlyHealPoison(int charId, Location location, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(99);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天助疗愈
	/// {0}在{1}梦到神奇的白鹿，内息得以平复。
	/// </summary>
	public void AddUnexpectedlyHealQi(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(100);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天降横祸
	/// {0}在{1}意外损失了十分珍稀的{2}。
	/// </summary>
	public void AddUnexpectedlyLoseRareItem(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(101);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天降横祸
	/// {0}在{1}意外损失了{2}{3}。
	/// </summary>
	public void AddUnexpectedlyLoseResource(int charId, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(102);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天损秘籍
	/// {0}在{1}意外的损失了一部{2}的武诀秘籍。
	/// </summary>
	public void AddUnexpectedlyLoseCombatSkill(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(103);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天损秘籍
	/// {0}在{1}意外的损失了一部{2}的技艺秘籍。
	/// </summary>
	public void AddUnexpectedlyLoseLifeSkill(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(104);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天降灾刑
	/// {0}在{1}梦到凶煞的恶鬼，损伤了{2}点健康。
	/// </summary>
	public void AddUnexpectedlyLoseHealth(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(105);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天降灾刑
	/// {0}在{1}梦到凶煞的恶鬼，受到了{2}点外伤。
	/// </summary>
	public void AddUnexpectedlySufferOuterInjury(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(106);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天降灾刑
	/// {0}在{1}梦到凶煞的恶鬼，受到了{2}点内伤。
	/// </summary>
	public void AddUnexpectedlySufferInneInjury(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(107);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天降灾刑
	/// {0}在{1}梦到凶煞的恶鬼，体内的{2}增加了。
	/// </summary>
	public void AddUnexpectedlySufferPoison(int charId, Location location, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(108);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天降灾刑
	/// {0}在{1}梦到凶煞的恶鬼，内息更加紊乱。
	/// </summary>
	public void AddUnexpectedlySufferDisorderOfQi(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(109);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 资源增长
	/// {0}的{1}的规模等级上升了。
	/// </summary>
	public void AddBuildingResourceIncreased(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(110);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 资源扩张
	/// {0}的{1}向周边地区扩张了。
	/// </summary>
	public void AddBuildingResourceSpread(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(111);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 建筑损坏
	/// {0}的{1}正在受损，规模等级正在下降。
	/// </summary>
	public void AddBuildingDamaged(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(112);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 建筑倾塌
	/// {0}的{1}倾塌毁坏成一片废墟了。
	/// </summary>
	public void AddBuildingRuined(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(113);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 建筑竣工
	/// {0}的{1}建造完毕了。
	/// </summary>
	public void AddBuildingConstructionCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(114);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 扩建完工
	/// {0}的{1}扩建完毕了。
	/// </summary>
	public void AddBuildingUpgradingCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(115);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 拆除建筑
	/// {0}的{1}拆除完毕了。
	/// </summary>
	public void AddBuildingDemolitionCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(116);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 建筑收获
	/// {0}的{1}有了新的收获。
	/// </summary>
	public void AddBuildingIncome(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(117);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 派遣就位
	/// 被派遣前往{0}的{1}已在{0}就位。
	/// </summary>
	public void AddDispatchInPlace(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(118);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 恶丐扰乱
	/// 听闻{0}有恶丐集聚…
	/// </summary>
	public void AddFindViciousBeggarsNest(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(119);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 贼人营寨
	/// 听闻{0}有贼人安营扎寨，为害一方…
	/// </summary>
	public void AddFindThievesCamp(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(120);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 悍匪劫道
	/// 听闻{0}有流匪出没，拦路抢劫…
	/// </summary>
	public void AddFindBanditsStronghold(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(121);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 叛徒结伙
	/// 听闻一伙叛徒在{0}聚集…
	/// </summary>
	public void AddFindTraitorsGang(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(122);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 恶人藏匿
	/// 听闻江湖中众多恶人在{0}藏匿…
	/// </summary>
	public void AddFindVillainsValley(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(123);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 迷香奇阵
	/// 听闻{0}时常传来靡靡之音，引诱路过此地的行人…
	/// </summary>
	public void AddFindMixiangzhen(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(124);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 乱葬邪岗
	/// 听闻{0}附近阴森恐怖，乱坟林立…
	/// </summary>
	public void AddFindMassGrave(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(125);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 异士幽居
	/// 听闻一群古怪的异士在{0}聚集…
	/// </summary>
	public void AddFindHereticHome(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(126);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 异疆邪教
	/// 听闻异疆之士群聚于{0}，设下邪术，以致当地一片死气…
	/// </summary>
	public void AddKidnappedByHeresy(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(127);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 修罗试炼
	/// 听闻{0}有妖邪乱人神智，前往围剿的侠士亦身陷险境…
	/// </summary>
	public void AddKidnappedByHeart(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(128);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 群魔聚集
	/// 听闻{0}忽现一处魔窟，秽气冲天，凶邪可怖…
	/// </summary>
	public void AddKidnappedBySoumoulou(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(129);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 乱心弃世
	/// 听闻{0}隐现绝命之阵，入阵者皆不知所踪…
	/// </summary>
	public void AddKidnappedByWorldWeary(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(130);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 新春集会
	/// 冬去春来，辞旧迎新，各地的商贾们纷纷举办起热闹的集会，随处可见赶集的百姓们。
	/// </summary>
	public void AddMarketAppeared(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(131);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 城镇比武
	/// 盛暑炎炎，夏练三伏，{0}正举办一场{1}，三教九流齐聚首，高台比武共血热。
	/// </summary>
	public void AddTownCombatAppeared(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(132);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 秋虫活跃
	/// 金秋伊始，处处均可听闻到促织的鸣叫声，正是：“切切暗窗下，喓喓深草里。秋天思妇心，雨夜愁人耳。”
	/// </summary>
	public void AddCricketsAppeared()
	{
		int beginOffset = BeginAddingRecord(133);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 促织大会
	/// 三年一届的促织大会正在{0}轰轰烈烈地举办！
	/// </summary>
	public void AddStartCricketContest(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(134);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 各地较艺
	/// 雪寒风冷，为民生息，{0}正举办一场{1}的较艺大会。
	/// </summary>
	public void AddLifeCompetitionAppeared(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(135);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 门派小较
	/// 传闻{0}正在举行低阶弟子齐聚的门派小较…
	/// </summary>
	public void AddStartSectJuniorContest(short settlementId)
	{
		int beginOffset = BeginAddingRecord(136);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 门派小较
	/// 传闻{0}正在举行高阶弟子齐聚的门派小较…
	/// </summary>
	public void AddStartSectIntermediateContest(short settlementId)
	{
		int beginOffset = BeginAddingRecord(137);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 门派大较
	/// 传闻{0}正在举办门派大较，门派高层尽皆参与其中…
	/// </summary>
	public void AddStartSectSeniorContest(short settlementId)
	{
		int beginOffset = BeginAddingRecord(138);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 比武招亲
	/// 一位没落的权贵正在{0}举行一场声势浩大的比武招亲…
	/// </summary>
	public void AddJoustForSpouse(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(139);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 青庐交拜
	/// {0}与{1}的婚礼正在{2}举行…
	/// </summary>
	public void AddMarryNotice(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(140);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 破冢而出
	/// 一名自称“相枢化身”的强敌自太吾村附近的“{0}”剑冢之中破冢而出！径直向太吾村而来！
	/// </summary>
	public void AddXiangshuAvatarAppeared(sbyte xiangshuAvatarId)
	{
		int beginOffset = BeginAddingRecord(141);
		AppendSwordTomb(xiangshuAvatarId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 莫女为祸
	/// 因莫女经过，{0}附近人物皆受其祸，{1}受伤中毒了！
	/// </summary>
	public void AddMonvBringDisaster(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(142);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 瑶常为祸
	/// 因大岳瑶常经过，{0}附近人物皆受其祸，{1}死去了！
	/// </summary>
	public void AddDayueYaochangBringDisaster(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(143);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 九寒为祸
	/// 因九寒经过，{0}附近的地格遭到了破坏！
	/// </summary>
	public void AddJiuhanvBringDisaster(Location location)
	{
		int beginOffset = BeginAddingRecord(144);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 凰儿为祸
	/// 因金凰儿经过，{0}附近的{1}遭受了横祸！
	/// </summary>
	public void AddJinHuangervBringDisaster(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(145);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 以侯为祸
	/// 因衣以侯经过，{0}附近人物皆心神哀恸，悲愤难平。
	/// </summary>
	public void AddYiYihouvBringDisaster(Location location)
	{
		int beginOffset = BeginAddingRecord(146);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 卫起为祸
	/// 卫起向{0}附近的{1}转移了全部损害！
	/// </summary>
	public void AddWeiQivBringDisaster(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(147);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 以向为祸
	/// 因以向经过，{0}附近人物的立场有所改变！
	/// </summary>
	public void AddYixiangvBringDisaster(Location location)
	{
		int beginOffset = BeginAddingRecord(148);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 血枫为祸
	/// 因血枫经过，{0}附近出现了更多相枢爪牙！
	/// </summary>
	public void AddXuefengBringDisaster(Location location)
	{
		int beginOffset = BeginAddingRecord(149);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 术方为祸
	/// 因术方经过，{0}附近的{1}年龄额外增长了！
	/// </summary>
	public void AddShuFangvBringDisaster(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(150);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 莫女救苦
	/// {0}在{1}受到一自称莫女的神秘人的治疗。
	/// </summary>
	public void AddMonvSaveSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(151);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 瑶常救苦
	/// 堕入相枢魔道的{0}在{1}被一自称大岳瑶常的神秘人擒获，最终伏诛…
	/// </summary>
	public void AddDayueYaochangSaveSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(152);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 九寒救苦
	/// {0}附近的地格在一自称九寒的神秘人的照料之下，资源尽皆恢复。
	/// </summary>
	public void AddJiuhanvSaveSuffering(Location location)
	{
		int beginOffset = BeginAddingRecord(153);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 凰儿救苦
	/// {0}在{1}看到金色的凤凰，随后获得了天赐横福。
	/// </summary>
	public void AddJinHuangervSaveSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(154);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 以侯救苦
	/// {0}附近的人物在见到一自称衣以侯的神秘人后，更易对他人倾情相待了。
	/// </summary>
	public void AddYiYihouvSaveSuffering(Location location)
	{
		int beginOffset = BeginAddingRecord(155);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 卫起救苦
	/// {0}在{1}被一自称卫起的神秘人救治，向{2}转移了损害。
	/// </summary>
	public void AddWeiQivSaveSuffering(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(156);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 以向救苦
	/// {0}附近的人物在一自称以向的神秘人感化之下，立场暂时转为仁善。
	/// </summary>
	public void AddYixiangvSaveSuffering(Location location)
	{
		int beginOffset = BeginAddingRecord(157);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 血枫救苦
	/// {0}在{1}受到了一自称血枫的神秘人的攻击。
	/// </summary>
	public void AddXuefengSaveSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(158);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 术方救苦
	/// {0}在{1}偶遇一自称术方的神秘人，随后似乎变年轻了！
	/// </summary>
	public void AddShuFangvSaveSuffering(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(159);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 平民失踪
	/// {0}在{1}失去了踪影，随后被证实死亡。
	/// </summary>
	public void AddCivilianDisappear(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(160);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队出发
	/// 位于{0}的&lt;color=#ffea8d&gt;{1}&lt;/color&gt;商队出发了。
	/// </summary>
	public void AddMerchantGoTravelling(short settlementId, sbyte merchantType)
	{
		int beginOffset = BeginAddingRecord(161);
		AppendSettlement(settlementId);
		AppendMerchantType(merchantType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 伤心欲绝
	/// {0}伤心地离开了太吾村…
	/// </summary>
	public void AddChickenEscaped(short chickenId)
	{
		int beginOffset = BeginAddingRecord(162);
		AppendChicken(chickenId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天灾无情
	/// 传闻在{0}发生了可怕的天灾，&lt;color=#red&gt;{1}&lt;/color&gt;人死于非命，&lt;color=#red&gt;{2}&lt;/color&gt;个地点毁于灾难！
	/// </summary>
	public void AddNaturalDisasterOccurred(Location location, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(163);
		AppendLocation(location);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 故人托梦
	/// {0}依稀在梦中见到已故的{1}指着{2}的方向，似有许多言语要向{0}诉说，然而阴阳相隔，生死有别，音讯不能相通，良久之后，{1}只得朝着所指的方向飘然而去。
	/// </summary>
	public void AddReincarnation(int charId, int charId1, short settlementId)
	{
		int beginOffset = BeginAddingRecord(164);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 威力消散
	/// {0}所积累的功法威力已完全消散…
	/// </summary>
	public void AddAccumulatedSkillPowerLost(short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(165);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 太吾村毁灭
	/// {0}的{1}倾塌毁坏成一片废墟了，一个巨大的妖魔从太吾村的废墟中突土而出！
	/// </summary>
	public void AddTaiwuVillageDestructed(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(166);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 玄石紫竹
	/// 太吾村附近出现了一棵生长在玄石上的紫竹，玄石不知从何而来，紫竹亦不知由何而生…
	/// </summary>
	public void AddRebirthAsJuniorXiangshu()
	{
		int beginOffset = BeginAddingRecord(167);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 宝典出世
	/// {0}在{1}获得了失传已久的{2}宝典。
	/// </summary>
	public void AddLegendaryBookAppeared(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(168);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 盟会失败
	/// 因各派要人无法齐聚一堂，天下武林盟会最终未能成功举办…
	/// </summary>
	public void AddWulinConferenceWithoutParticipant()
	{
		int beginOffset = BeginAddingRecord(169);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 筹备盟会
	/// 万众一心，共助太吾！江湖各派正积极筹办天下武林盟会中…
	/// </summary>
	public void AddWulinConferenceInPreparing()
	{
		int beginOffset = BeginAddingRecord(170);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天下武林盟会
	/// 天下武林盟会正在{0}轰轰烈烈地举办，各派要人齐聚一堂，共襄盛会…
	/// </summary>
	public void AddWulinConferenceInProgress(Location location)
	{
		int beginOffset = BeginAddingRecord(171);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 相枢夺命
	/// {0}有{1}人为抵抗妖魔乱世而丧命…
	/// </summary>
	public void AddXiangshuKilling(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(172);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 获得见闻
	/// 知悉新的见闻：{0}…
	/// </summary>
	public void AddMonthlyNormalInformation()
	{
		int beginOffset = BeginAddingRecord(173);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 获得秘闻
	/// 知悉新的秘闻：{0}…
	/// </summary>
	public void AddMonthlySecretInformation()
	{
		int beginOffset = BeginAddingRecord(174);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 秘闻即将失效
	/// 秘闻即将过期：{0}…
	/// </summary>
	public void AddSecretInformationWillExpire()
	{
		int beginOffset = BeginAddingRecord(175);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 秘闻失效
	/// 秘闻过期：{0}…
	/// </summary>
	public void AddSecretInformationExpired()
	{
		int beginOffset = BeginAddingRecord(176);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 异人现世
	/// 呼唤太吾：异人现世，众人皆在呼唤{0}返回太吾村…
	/// </summary>
	public void AddYirenAppearInTaiwuArea(int charId)
	{
		int beginOffset = BeginAddingRecord(177);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 持节而归
	/// 光阴无悔，历经三十年的磨难之后，茶马帮竟然又回到了太吾村…
	/// </summary>
	public void AddWesternMerchantBackAfterLong()
	{
		int beginOffset = BeginAddingRecord(178);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 音讯微茫
	/// 不知何故，茶马帮与太吾村失去了联系…
	/// </summary>
	public void AddWesternMerchantLoseContact()
	{
		int beginOffset = BeginAddingRecord(179);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 西域归来
	/// 茶马帮顺利返回了太吾村…
	/// </summary>
	public void AddWesternMerchantBackSucceed()
	{
		int beginOffset = BeginAddingRecord(180);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 获得威望
	/// 因来源于{0}的秘闻得到了传播，{0}获得了{1}威望…
	/// </summary>
	public void AddGainAuthority(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(181);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 比武招亲
	/// 太吾传人在{0}筹备的一场声势浩大的比武招亲已经宾客齐聚！
	/// </summary>
	public void AddFemaleJoustForSpouseReady(Location location)
	{
		int beginOffset = BeginAddingRecord(182);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 门派较武
	/// 传闻{0}正在举行一场弟子齐聚的门派较武…
	/// </summary>
	public void AddStartSectNormalCompetition(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(183);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 远走高飞
	/// 听闻{0}发生了一场门派争端，争端的内容似乎与「太吾」有关…
	/// </summary>
	public void AddEscapeWithForeverLover(Location location)
	{
		int beginOffset = BeginAddingRecord(184);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天材地宝
	/// 听闻一场天灾之后，{0}有异宝降世…
	/// </summary>
	public void AddDisasterAndPreciousMaterial(Location location)
	{
		int beginOffset = BeginAddingRecord(185);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 群侠卫道
	/// 听闻{0}出现堕入相枢魔道的失心之人，江湖诸多义士正试图除此灾祸！
	/// </summary>
	public void AddHeroesDefendMorality(Location location)
	{
		int beginOffset = BeginAddingRecord(186);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 群丐见闻
	/// {0}在{1}代{2}记录了{3}打探得到的见闻…
	/// </summary>
	public void AddIncomeFromNestViciousBeggars(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(187);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 营寨收入
	/// {0}在{1}代{2}收取了{3}近日的{4}银钱收入…
	/// </summary>
	public void AddIncomeFromNestThievesCamp(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(188);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 山砦当家
	/// {0}在{1}代{2}收取了{3}提供的{4}…
	/// </summary>
	public void AddIncomeFromNestBanditsStronghold(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(189);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 恶人扬威
	/// {0}在{1}监管{3}宣扬威名，使{2}获得了{4}威望…
	/// </summary>
	public void AddIncomeFromNestVillainsValley(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(190);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 聚义除恶
	/// {0}在{1}协助{3}处置恶人，使{2}获得了{4}历练…
	/// </summary>
	public void AddIncomeFromNestRighteousLow(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(191);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 扶危济困
	/// {0}在{1}协助{3}处理江湖纷争，使{2}获得了{4}%地区恩义…
	/// </summary>
	public void AddIncomeFromNestRighteousMiddle(int charId, Location location, int charId1, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(192);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 人手空缺
	/// {0}在管理{1}的{2}时不幸身亡，无法再继续为{3}工作了…
	/// </summary>
	public void AddBuildingWorkerDie(int charId, Location location, short buildingTemplateId, int charId1)
	{
		int beginOffset = BeginAddingRecord(193);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendBuilding(buildingTemplateId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 石屋救治
	/// 听闻堕入魔道的{1}已被送往{0}的石屋中关押…
	/// </summary>
	public void AddStoneHouseInfectedKidnapped(short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(194);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队迷路
	/// 从太吾村出发的茶马帮迷失道路，导致知名度下降...
	/// </summary>
	public void AddWesternMerchanLost()
	{
		int beginOffset = BeginAddingRecord(195);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 海市蜃楼
	/// 从太吾村出发的茶马帮遇到了海市蜃楼，知名度得以提升...
	/// </summary>
	public void AddWesternMerchanFindMirage()
	{
		int beginOffset = BeginAddingRecord(196);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现野人
	/// 从太吾村出发的茶马帮发现了野人，知名度得以提升…
	/// </summary>
	public void AddWesternMerchanFindBigfoot()
	{
		int beginOffset = BeginAddingRecord(197);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现植物
	/// 从太吾村出发的茶马帮发现了珍稀植物，知名度得以提升…
	/// </summary>
	public void AddWesternMerchanFindPlant()
	{
		int beginOffset = BeginAddingRecord(198);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现动物
	/// 从太吾村出发的茶马帮发现了珍稀动物，知名度得以提升…
	/// </summary>
	public void AddWesternMerchanFindAnimal()
	{
		int beginOffset = BeginAddingRecord(199);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 回传见闻
	/// 从太吾村出发的茶马帮回传了见闻，知名度得以提升…
	/// </summary>
	public void AddWesternMerchanGetInformation()
	{
		int beginOffset = BeginAddingRecord(200);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现聚落
	/// 从太吾村出发的茶马帮发现了聚落，知名度得以提升…
	/// </summary>
	public void AddWesternMerchanFindSettlement()
	{
		int beginOffset = BeginAddingRecord(201);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现天气
	/// 从太吾村出发的茶马帮遇到罕见天气，知名度得以提升…
	/// </summary>
	public void AddWesternMerchanFindWeather()
	{
		int beginOffset = BeginAddingRecord(202);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队残骸
	/// 从太吾村出发的茶马帮发现了商队遗骸，获得了一些货物...
	/// </summary>
	public void AddWesternMerchanFindWreckage()
	{
		int beginOffset = BeginAddingRecord(203);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 援助路人
	/// 从太吾村出发的茶马帮援助了路人，导致补给减少...
	/// </summary>
	public void AddWesternMerchanHelpPasserby()
	{
		int beginOffset = BeginAddingRecord(204);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 获得援助
	/// 从太吾村出发的茶马帮获得了援助，补给增加..
	/// </summary>
	public void AddWesternMerchanGetHelp()
	{
		int beginOffset = BeginAddingRecord(205);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 偶得野味
	/// 从太吾村出发的茶马帮发现了野味，补给增加...
	/// </summary>
	public void AddWesternMerchanFindVenison()
	{
		int beginOffset = BeginAddingRecord(206);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现果林
	/// 从太吾村出发的茶马帮发现了果林，可以搜寻补给...
	/// </summary>
	public void AddWesternMerchanFindFruit()
	{
		int beginOffset = BeginAddingRecord(207);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现村落
	/// 从太吾村出发的茶马帮发现了村落，可以交换补给...
	/// </summary>
	public void AddWesternMerchanFindVillage()
	{
		int beginOffset = BeginAddingRecord(208);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 路遇商队
	/// 从太吾村出发的茶马帮路遇商队，可以交换补给...
	/// </summary>
	public void AddWesternMerchanMeetMerchan()
	{
		int beginOffset = BeginAddingRecord(209);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遇见盗贼
	/// 从太吾村出发的茶马帮遇到了盗贼，遗失了部分货物...
	/// </summary>
	public void AddWesternMerchanMeetTheif()
	{
		int beginOffset = BeginAddingRecord(210);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 颠簸损坏
	/// 从太吾村出发的茶马帮路途颠簸，遗失了少量货物...
	/// </summary>
	public void AddWesternMerchanGoodsDamage()
	{
		int beginOffset = BeginAddingRecord(211);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 水土不服
	/// 从太吾村出发的茶马帮水土不服，导致补给减少...
	/// </summary>
	public void AddWesternMerchanUnacclimatized()
	{
		int beginOffset = BeginAddingRecord(212);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 缺少补给
	/// 从远方传来消息，从太吾村出发的茶马帮已经没有足够的补给完成旅行，队伍正在消亡...
	/// </summary>
	public void AddWesternMerchanLackReplenishment()
	{
		int beginOffset = BeginAddingRecord(213);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 寿元将尽
	/// {0}日渐消瘦，精神不振，似乎寿元将尽…
	/// </summary>
	public void AddAboutToDie(int charId)
	{
		int beginOffset = BeginAddingRecord(214);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 巢穴消亡
	/// {0}的{1}已消亡…
	/// </summary>
	public void AddEnemyNestDemise(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(215);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 秘闻公开
	/// 已废弃
	/// </summary>
	public void AddSecretInformationBroadcast()
	{
		int beginOffset = BeginAddingRecord(216);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 灵光一闪
	/// 阅读{0}时突然灵光一闪…
	/// </summary>
	public void AddReadingEvent(ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(217);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 巢穴强盛
	/// 奇书现世，引人执迷。{0}的外道巢穴，似乎也因奇书持有之人心性大变、四处探寻奇书奥秘而得窥奇书之一二，势力异常扩张…
	/// </summary>
	public void AddEnemyNestGrow(Location location)
	{
		int beginOffset = BeginAddingRecord(218);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 强敌滋长
	/// 奇书现世，引人执迷。{0}的外道与义士似乎也因奇书持有之人心性大变、四处探寻奇书奥秘而得窥奇书之一二，功力异常增强…
	/// </summary>
	public void AddRandomEnemyGrow(Location location)
	{
		int beginOffset = BeginAddingRecord(219);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 强敌衰减
	/// 奇书影踪，宿昔流转。因奇书易主，{0}的外道与义士似乎不再受到奇书的影响，功力恢复了正常…
	/// </summary>
	public void AddRandomEnemyDecay(Location location)
	{
		int beginOffset = BeginAddingRecord(220);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 相枢势汹
	/// 执迷奇书，终成堕魔。因奇书持有之人完全丧失心智，最终不仅失去了奇书，也堕至了玄石之境，奇书奥秘更为相枢一览无余…
	/// </summary>
	public void AddXiangshuGetStrengthened()
	{
		int beginOffset = BeginAddingRecord(221);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 执迷入邪
	/// {0}醉心于{2}宝典，一念之错，心性大变，竟在{1}执迷入邪…
	/// </summary>
	public void AddLegendaryBookShocked(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(222);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 执迷化魔
	/// {0}醉心于{2}宝典，神摇意夺，心与魔通，竟在{1}执迷入魔…
	/// </summary>
	public void AddLegendaryBookInsane(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(223);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 堕入魔道
	/// {0}醉心于{2}宝典，执迷不返，痴醉成狂，终在{1}受相枢吞噬、堕化成魔，为害人间…
	/// </summary>
	public void AddLegendaryBookConsumed(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(224);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书流转
	/// {2}的持有者——{0}——于{1}失去了{2}，不世宝典再次流落世间，不知去向…
	/// </summary>
	public void AddLegendaryBookLost(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(225);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书出世
	/// {1}影踪初现，众多正邪高手逐渐聚集在{0}，只为争夺那流落世间的稀世宝典…
	/// </summary>
	public void AddFightForNewLegendaryBook(Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(226);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书出世
	/// 因{0}放弃，{2}影踪重现，众多正邪高手逐渐聚集在{1}，只为争夺那已然无主的稀世宝典…
	/// </summary>
	public void AddFightForLegendaryBookAbandoned(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(227);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书出世
	/// 因{0}离世，{2}影踪重现，众多正邪高手逐渐聚集在{1}，只为争夺那已然无主的稀世宝典…
	/// </summary>
	public void AddFightForLegendaryBookOwnerDie(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(228);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书出世
	/// 因{0}堕魔，{2}影踪重现，众多正邪高手逐渐聚集在{1}，只为争夺那已然无主的稀世宝典…
	/// </summary>
	public void AddFightForLegendaryBookOwnerConsumed(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(229);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书出世
	/// 奇书现世，难寻其踪，却闻{0}在{1}获得了失传已久的{2}宝典，正欲探其奥秘…
	/// </summary>
	public void AddLegendaryBookAppear(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(230);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书挑战
	/// {0}在{1}向{2}发起挑战，赢取了其手中的{3}。
	/// </summary>
	public void AddChallengeForLegendaryBook(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(231);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 夺取奇书
	/// {0}在{1}夺取了{2}手中的{3}。
	/// </summary>
	public void AddRobLegendaryBook(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(232);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 不辞而别
	/// {0}留下一封仅有“奇书有志，我心难平，暂且别过，后会有期…”十六个字的书信后便离开了…
	/// </summary>
	public void AddVillagerLeftForLegendaryBook(int charId)
	{
		int beginOffset = BeginAddingRecord(233);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 庆贺生辰
	/// {0}已至，此时正是{1}之生月，或可为之庆贺…
	/// </summary>
	public void AddHappyBirthday(sbyte month, int charId)
	{
		int beginOffset = BeginAddingRecord(234);
		AppendMonth(month);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒侵身
	/// {0}身受骨错筋缠之毒，猛毒侵身，痛苦难熬，在{1}丢弃了行囊中的{2}…
	/// </summary>
	public void AddPoisonMakeLoss(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(235);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒害众
	/// {0}身受坏血断肠之毒，所中之腐毒在{1}扩散给了周遭他人…
	/// </summary>
	public void AddRottenPoisonDiffuse(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(236);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒毁形
	/// {0}身受骨中烧疽之毒，容貌备受摧残，如今已是毁形走相…
	/// </summary>
	public void AddPoisonDestroyFace(int charId)
	{
		int beginOffset = BeginAddingRecord(237);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒惑众
	/// {0}身受剧恶深苦之毒，所中之幻毒在{1}扩散给了周遭他人…
	/// </summary>
	public void AddIllusoryPoisonDiffuse(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(238);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒乱心
	/// {0}身受毒火焚心之毒，迷失心性，在{1}肆意为虐，竟出手袭击了{2}…
	/// </summary>
	public void AddPoisonDisturbMindAttckSuccess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(239);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒乱心
	/// {0}身受毒火焚心之毒，迷失心性，在{1}肆意为虐，竟对{2}施以了毒害…
	/// </summary>
	public void AddPoisonDisturbMindEmpoisonSuccess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(240);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒乱心
	/// {0}身受毒火焚心之毒，迷失心性，在{1}肆意为虐，竟暗中损伤了{2}…
	/// </summary>
	public void AddPoisonDisturbMindSneakAttckSuccess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(241);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒乱心
	/// {0}身受毒火焚心之毒，迷失心性，在{1}肆意为虐，竟以卑劣的手段欺辱了{2}…
	/// </summary>
	public void AddPoisonDisturbMindRapeSuccess(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(242);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒乱心
	/// {0}身受毒火焚心之毒，迷失心性，在{1}肆意为虐，出手袭击了{2}，却未能成功…
	/// </summary>
	public void AddPoisonDisturbMindAttckFalse(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(243);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒乱心
	/// {0}身受毒火焚心之毒，迷失心性，在{1}肆意为虐，意图对{2}施以毒害，却未能成功…
	/// </summary>
	public void AddPoisonDisturbMindEmpoisonFalse(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(244);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒乱心
	/// {0}身受毒火焚心之毒，迷失心性，在{1}肆意为虐，意图暗中损伤{2}，却未能成功…
	/// </summary>
	public void AddPoisonDisturbMindSneakAttckFalse(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(245);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 猛毒乱心
	/// {0}身受毒火焚心之毒，迷失心性，在{1}肆意为虐，意图欺辱{2}，却未能成功…
	/// </summary>
	public void AddPoisonDisturbMindRapeFalse(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(246);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 姬穸伤人
	/// 姬穸游荡至{0}，因饥饿吸食人血，致使{1}人死亡…
	/// </summary>
	public void AddSectMainStoryXuehouJixiKillsPeople(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(247);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 吸收魔性
	/// 已废弃
	/// </summary>
	public void AddSectMainStoryYuanshanAbsorbInfectedPeople(int charId)
	{
		int beginOffset = BeginAddingRecord(248);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 狮相绝艺
	/// 江湖传言，狮相门似乎举办一场“秘密绝艺”比试…
	/// </summary>
	public void AddSectMainStoryShixiangAdventure()
	{
		int beginOffset = BeginAddingRecord(249);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 姬穸之别
	/// 生者为过客，死者为归人，姬穸似已知晓故人逝去之事，身无牵挂，不知去了何处…
	/// </summary>
	public void AddSectMainStoryXuehouJixiGone()
	{
		int beginOffset = BeginAddingRecord(250);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 盟会胜者
	/// {0}力挫众门派，在此次武林盟会中拔得头筹，乃是当仁不让之胜者…
	/// </summary>
	public void AddWulinConferenceWinner(short settlementId)
	{
		int beginOffset = BeginAddingRecord(251);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 同门相残
	/// 听闻峨眉派的{0}不知何故，在{1}与同门大打出手…
	/// </summary>
	public void AddSectMainStoryEmeiInfighting(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(252);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 白猿归来
	/// 等待探究武学的白猿似已回到旧地，可前往峨眉断崖下一探…
	/// </summary>
	public void AddSectMainStoryWhiteGibbonReturns()
	{
		int beginOffset = BeginAddingRecord(253);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 姬穸之别
	/// 残宵梦终醒，物是人已非，故人既已心魂异变，姬穸似有所感，不知去了何处…
	/// </summary>
	public void AddSectMainStoryXuehouJixiGoneAgain()
	{
		int beginOffset = BeginAddingRecord(254);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 姬穸施救
	/// {0}身虚体弱，姬穸终不忍见，出手施救为其恢复了健康，重又化作幼童模样…
	/// </summary>
	public void AddSectMainStoryXuehouJixiRescue(int charId)
	{
		int beginOffset = BeginAddingRecord(255);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 姬穸无踪
	/// 此前姬穸不见踪影，至今仍未归返，{0}遍寻不得，方知她已不告而别，不知究竟去了何方…
	/// </summary>
	public void AddSectMainStoryXuehouJixiGoneFinal(int charId)
	{
		int beginOffset = BeginAddingRecord(256);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 古鼎医人
	/// 廖氏古鼎依照驱使前往{0}，治疗了此地区所有人物的内外伤势…
	/// </summary>
	public void AddSectMainStoryKongsangTripodVesselCures(Location location)
	{
		int beginOffset = BeginAddingRecord(257);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 古鼎医人
	/// 廖氏古鼎依照驱使前往{0}，祛除了此地区所有人物所中的毒素…
	/// </summary>
	public void AddSectMainStoryKongsangTripodVesselDetoxifies(Location location)
	{
		int beginOffset = BeginAddingRecord(258);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 古鼎医人
	/// 廖氏古鼎依照驱使前往{0}，消除了此地区所有人物的内息紊乱…
	/// </summary>
	public void AddSectMainStoryKongsangTripodVesselRemovesQiDisorder(Location location)
	{
		int beginOffset = BeginAddingRecord(259);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 古鼎医人
	/// 廖氏古鼎依照驱使前往{0}，恢复了此地区所有人物的健康…
	/// </summary>
	public void AddSectMainStoryKongsangTripodVesselRestoresHealth(Location location)
	{
		int beginOffset = BeginAddingRecord(260);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 故人托梦
	/// {0}依稀在梦中见到已故的{1}指着{2}的方向，似有许多言语要向{0}诉说，然而阴阳相隔，生死有别，音讯不能相通，良久之后，{1}只得朝着所指的方向飘然而去。
	/// </summary>
	public void AddReincarnationNewWithLocation(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(261);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 村民受伤
	/// 神木之周，鬼物狰狞，太吾村民舍身卫树。此月守卫神树的村民共有{0}人受伤！
	/// </summary>
	public void AddSectMainStoryWudangVillagersInjured(int value)
	{
		int beginOffset = BeginAddingRecord(262);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 村民死亡
	/// 神木之周，鬼物狰狞，太吾村民舍身卫树。太吾村民{0}在{1}因守卫神树而死亡！
	/// </summary>
	public void AddSectMainStoryWudangVillagerCasualty(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(263);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 扫除妖邪
	/// {0}在{1}击败了{2}，为江湖除了一害…
	/// </summary>
	public void AddKillHereticRandomEnemy(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(264);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 妖邪伤人
	/// {0}在{1}受到{2}的袭击，未能抵御其害，身受重创…
	/// </summary>
	public void AddDefeatedByHereticRandomEnemy(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(265);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 击败义士
	/// {0}在{1}击败了{2}，手中沾染了义士的鲜血…
	/// </summary>
	public void AddKillRighteousRandomEnemy(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(266);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 义士惩戒
	/// {0}在{1}受到{2}的讨伐，未能逃脱惩治，身受重创…
	/// </summary>
	public void AddDefeatedByRighteousRandomEnemy(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(267);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 制伏动物
	/// {0}在{1}制伏了{2}，将其逐回林野之中…
	/// </summary>
	public void AddKillAnimal(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(268);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 动物伤人
	/// {0}在{1}受到{2}的袭击，身受重创，险些命丧其口…
	/// </summary>
	public void AddDefeatedByAnimal(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(269);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 命丧巢穴
	/// 听闻{0}在{1}受困于{2}，最终未能脱身，死于非命…
	/// </summary>
	public void AddDieFromEnemyNest(int charId, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(270);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 姬穸伤人
	/// 姬穸游荡至{0}，因饥饿吸食人血，致使{1}人死亡…
	/// </summary>
	public void AddDummy0(Location location, int value)
	{
		int beginOffset = BeginAddingRecord(271);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 吸收魔性
	/// 临时文本临时图标：听闻三魔吸收了{0}的入魔值，得到增强
	/// </summary>
	public void AddDummy1(int charId)
	{
		int beginOffset = BeginAddingRecord(272);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 狮相绝艺
	/// 江湖传言，狮相门似乎举办一场“秘密绝艺”比试…
	/// </summary>
	public void AddDummy2()
	{
		int beginOffset = BeginAddingRecord(273);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 再入轮回
	/// 因{0}在{1}痛失骨肉，原本要轮回至此的{2}无处可往，只得另觅他人，再行轮回…
	/// </summary>
	public void AddMiscarriageAndReincarnation(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(274);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 再入轮回
	/// 因{0}在{1}生育时发生意外，以致香消玉殒，原本要轮回至此的{2}无处可往，只得另觅他人，再行轮回…
	/// </summary>
	public void AddMiscarriageAndReincarnationMotherDies(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(275);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 再入轮回
	/// 因{0}在{1}死亡，原本要轮回至此的{2}无处可往，只得另觅他人，再行轮回…
	/// </summary>
	public void AddMiscarriageAndReincarnationMotherKilled(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(276);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 小石之约
	/// 石候酒似已回到旧地，可前往峨眉断崖下一探…
	/// </summary>
	public void AddSectMainStoryEmeiShiReturns()
	{
		int beginOffset = BeginAddingRecord(277);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 峨眉之劫
	/// 峨眉派“正宗武学之争”已到生死关头，若视之不理，恐会万劫不复…
	/// </summary>
	public void AddSectMainStoryEmeiDoomOfEmei()
	{
		int beginOffset = BeginAddingRecord(278);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 逃离巢穴
	/// 听闻{0}在{1}受困于{2}，最终绝处逢生，幸免于难…
	/// </summary>
	public void AddEscapeFromEnemyNest(int charId, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(279);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 逃离巢穴
	/// 听闻{0}在{1}受困于{2}，幸而得到{3}解救，最终免于危难…
	/// </summary>
	public void AddSavedFromEnemyNest(int charId, Location location, int adventureCoreId, int charId1)
	{
		int beginOffset = BeginAddingRecord(280);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 民力凋敝
	/// {0}百业凋敝，地区文化降低，无力再为{1}提供{2}资源援助…
	/// </summary>
	public void AddCultureDecline(short settlementId, int charId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(281);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 神龙见首
	/// {0}有{1}现世，兴云吐雾，神力漫延，周遭地形亦随之变化…
	/// </summary>
	public void AddFiveLoongArise(Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(282);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 蛟池有异
	/// 在{0}收到来自蛟池的消息：因蛟池资源匮乏，{1}已不再成长…
	/// </summary>
	public void AddJiaoPoolAccident(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(283);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 长蛟回渊
	/// 在{0}收到来自蛟池的消息：蛟龙终非池中物，此日{1}终于不服驯养，逃出了蛟池，盘踞于太吾村附近…
	/// </summary>
	public void AddJiaoGoHome(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(284);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 长蛟破壳
	/// 在{0}收到来自蛟池的消息：经月苦心照料，{1}终于破壳而出，吼云舞浪，憨态可掬…
	/// </summary>
	public void AddJiaoBrokeThroughTheShell(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(285);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 长蛟育成
	/// 在{0}收到来自蛟池的消息：经月苦心育养，{1}终于长成，吼云舞浪，英姿飒飒…
	/// </summary>
	public void AddJiaoHasReachedAnAdultAge(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(286);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 囚牛笙歌
	/// {2}在{1}为{0}写作一曲，忘情奏乐，过路之人纷纷驻足聆听…
	/// </summary>
	public void AddDLCLoongRidingEffectQiuniu(int charId, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(287);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 睚眦必报
	/// {2}在{1}袭击了{0}…
	/// </summary>
	public void AddDLCLoongRidingEffectYazi(int charId, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(288);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 嘲风秘报
	/// 于{0}领悟了{1}分享的一则秘闻…
	/// </summary>
	public void AddDLCLoongRidingEffectChaofeng(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(289);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 蒲牢巨声
	/// 于{0}口中获得了一只{1}…
	/// </summary>
	public void AddDLCLoongRidingEffectPulao(int jiaoLoongId, short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(290);
		AppendJiaoLoong(jiaoLoongId);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 狻猊嬉斗
	/// {1}在{0}喷吐轻烟，解读了{2}的第{3}篇…
	/// </summary>
	public void AddDLCLoongRidingEffectSuanni(Location location, int jiaoLoongId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(291);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 霸下觅宝
	/// {2}在{1}寻得宝物，为{0}挖掘而归…
	/// </summary>
	public void AddDLCLoongRidingEffectBaxia(int charId, Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(292);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 狴犴持衡
	/// 因{1}注视，在{0}坦言了一件自己此前所为之事…
	/// </summary>
	public void AddDLCLoongRidingEffectBian(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(293);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 负屃舞文
	/// {1}在{0}灵光一闪，解读了{2}的第{3}篇…
	/// </summary>
	public void AddDLCLoongRidingEffectFuxi(Location location, int jiaoLoongId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(294);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 螭吻养内
	/// 因与{1}在{0}自在嬉戏，内力得到了恢复…
	/// </summary>
	public void AddDLCLoongRidingEffectChiwen(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(295);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 诞下蛟卵
	/// 在{0}收到来自蛟池的消息：日月运转，万物繁衍。此日{1}与{2}于蛟池诞下一枚蛟卵…
	/// </summary>
	public void AddJiaoLayEggs(Location location, int jiaoLoongId, int jiaoLoongId1)
	{
		int beginOffset = BeginAddingRecord(296);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		AppendJiaoLoong(jiaoLoongId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 潜蛟思渊
	/// 在{0}收到来自蛟池的消息：{1}不服驯养，竟有逃离蛟池之兆，或当及时查看并安抚一番…
	/// </summary>
	public void AddJiaoTamingPointsLow(Location location, int jiaoLoongId)
	{
		int beginOffset = BeginAddingRecord(297);
		AppendLocation(location);
		AppendJiaoLoong(jiaoLoongId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 寿终正寝
	/// {0}寿元已尽，在{1}安然离世…
	/// </summary>
	public void AddDieFromAge(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(298);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 残命难续
	/// {0}健康耗尽，在{1}离开了人世…
	/// </summary>
	public void AddDieFromPoorHealth(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(299);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 死于非命
	/// {0}在{1}被{2}夺去了性命…
	/// </summary>
	public void AddKilledInPubilc(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(300);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 邪祟缠身
	/// {0}身无病痛，却觉身处西域时，每日昏昏，手足无力，肩颈沉重如坠千斤之石…
	/// </summary>
	public void AddSectMainStoryJingangHaunted(int charId)
	{
		int beginOffset = BeginAddingRecord(301);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 鬼影随行
	/// {0}身无病痛，却觉每日昏昏，手足无力，想来应是高僧魂灵随行左右，阴翳不散…
	/// </summary>
	public void AddSectMainStoryJingangFollowedByGhost(int charId)
	{
		int beginOffset = BeginAddingRecord(302);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 恶煞金刚
	/// 无量金刚宗大肆追杀劫掠西域僧人，凡有窝藏僧人或隐其形迹的百姓，一并捉拿杀害。西方腥风血雨，一时人心惶惶…
	/// </summary>
	public void AddSectMainStoryJingangWrongdoing()
	{
		int beginOffset = BeginAddingRecord(303);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 求神拜佛
	/// 经世人口耳相传，西域高僧已声名远扬，仰慕高僧之人与日俱增…
	/// </summary>
	public void AddSectMainStoryJingangPray()
	{
		int beginOffset = BeginAddingRecord(304);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 高僧弘法
	/// 西域高僧感念{0}恩情，于{1}设坛讲经，弘扬{0}善心义举…
	/// </summary>
	public void AddSectMainStoryJingangFameDistribution(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(305);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 宿主死亡
	/// {0}因宿主在{1}死亡，自{2}体内脱逃而出，困于其墓中，或可设法将其掘回…
	/// </summary>
	public void AddWugKingParasitiferDead(sbyte itemType, short itemTemplateId, Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(306);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 王蛊死亡
	/// {0}体内的{1}寿终而亡，遗骸蠹蚀五脏，让宿主饱受摧残，人物特性受到损害…
	/// </summary>
	public void AddWugKingDead(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(307);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 王蛊死亡
	/// {0}体内的{1}寿终而亡…
	/// </summary>
	public void AddWugKingDeadSpecial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(308);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 拙僧扬名
	/// 无名僧人曲解宝经而去，四处讲经，竟大受信众追捧，不仅声名鹊起，更收取不少香火银钱…
	/// </summary>
	public void AddSectMainStoryJingangFamousFakeMonk()
	{
		int beginOffset = BeginAddingRecord(309);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 神像化魂
	/// 借“衣”僧现身于太吾村，于轮回台附近徘徊往复，从此长住村中…
	/// </summary>
	public void AddSectMainStoryJingangRockFleshed()
	{
		int beginOffset = BeginAddingRecord(310);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 五圣心毒
	/// {0}修习五圣心毒，五内哀郁，终致心毒入体…
	/// </summary>
	public void AddSectMainStoryWuxianParanoiaAppeared(int charId)
	{
		int beginOffset = BeginAddingRecord(311);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 百姓出逃
	/// 昆仑山受难村民不堪无量金刚宗压迫，纷纷出逃，无不感念{0}救苦之恩…
	/// </summary>
	public void AddSectMainStoryJingangVillagerFlee(int charId)
	{
		int beginOffset = BeginAddingRecord(312);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 三宗比武
	/// 时隔多年，三宗比武于然山再次举办…
	/// </summary>
	public void AddSectMainStoryRanshanSanZongBiWu()
	{
		int beginOffset = BeginAddingRecord(313);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// {0}与华居谈今论古，指点江山，立下大志。决意将{1}弃置于{2}，不复执迷。由此，不世宝典再次流落世间，不知去向…
	/// </summary>
	public void AddGiveUpLegendaryBookSuccessHuaJu(int charId, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(314);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// {0}跟随玄质纵马河山，诗酒江湖，快意非常。当下便将{1}弃置于{2}，不复执迷。由此，不世宝典再次流落世间，不知去向…
	/// </summary>
	public void AddGiveUpLegendaryBookSuccessXuanZhi(int charId, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(315);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// {0}对迎娇痴心一片，舍生忘死。无意间将{1}弃置于{2}，不复执迷。由此，不世宝典再次流落世间，不知去向…
	/// </summary>
	public void AddGiveUpLegendaryBookSuccessYingJiao(int charId, sbyte itemType, short itemTemplateId, Location location)
	{
		int beginOffset = BeginAddingRecord(316);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// {0}与华居相处数日，却始终放不下{1}，华居只得先行折返…
	/// </summary>
	public void AddGiveUpLegendaryBookFailureHuaJu(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(317);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// {0}与玄质相处数日，却始终放不下{1}，玄质只得先行折返…
	/// </summary>
	public void AddGiveUpLegendaryBookFailureXuanZhi(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(318);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// {0}与迎娇相处数日，却始终放不下{1}，迎娇只得先行折返…
	/// </summary>
	public void AddGiveUpLegendaryBookFailureYingJiao(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(319);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// 华居见{0}不复执迷于{1}，稍加开导后便先行折返…
	/// </summary>
	public void AddGiveUpLegendaryBookLoseBookHuaJu(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(320);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// 玄质见{0}不复执迷于{1}，稍加开导后便先行折返…
	/// </summary>
	public void AddGiveUpLegendaryBookLoseBookXuanZhi(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(321);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// 迎娇见{0}不复执迷于{1}，稍加开导后便先行折返…
	/// </summary>
	public void AddGiveUpLegendaryBookLoseBookYingJiao(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(322);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// 华居见{0}不知所踪，无奈只好先行折返…
	/// </summary>
	public void AddGiveUpLegendaryBookLoseTargetHuaJu(int charId)
	{
		int beginOffset = BeginAddingRecord(323);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// 玄质见{0}不知所踪，无奈只好先行折返…
	/// </summary>
	public void AddGiveUpLegendaryBookLoseTargetXuanZhi(int charId)
	{
		int beginOffset = BeginAddingRecord(324);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 奇书断执
	/// 迎娇见{0}不知所踪，无奈只好先行折返…
	/// </summary>
	public void AddGiveUpLegendaryBookLoseTargetYingJiao(int charId)
	{
		int beginOffset = BeginAddingRecord(325);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 八生八死
	/// 受到八生八死之法的影响，{0}的健康得到恢复…
	/// </summary>
	public void AddLifeLinkHealing(int charId)
	{
		int beginOffset = BeginAddingRecord(326);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 八生八死
	/// 受到八生八死之法的影响，{0}的健康受到损害…
	/// </summary>
	public void AddLifeLinkDamage(int charId)
	{
		int beginOffset = BeginAddingRecord(327);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 杀人夺心
	/// 传闻各地凶案频发，案首欲要杀人夺心，于{0}出没犯案，一时人人自危…
	/// </summary>
	public void AddSectMainStoryBaihuaLeukoKills(Location location)
	{
		int beginOffset = BeginAddingRecord(328);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 毁人神智
	/// 传闻各地怪事频发，不知何方妖邪作祟，于{0}出没毁人神智，一时人人自危…
	/// </summary>
	public void AddSectMainStoryBaihuaMelanoKills(Location location)
	{
		int beginOffset = BeginAddingRecord(329);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 巨鹰袭击
	/// 近日，太吾村边常见鸢飞戾天，似有猛禽往复徘徊，玄鸮受其袭扰，身已负伤…
	/// </summary>
	public void AddSectMainStoryBaihuaLeukoHelps()
	{
		int beginOffset = BeginAddingRecord(330);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 野兽嚎叫
	/// 近日，太吾村边常闻狼嗥鬼啸，似有猛兽横行出没，白鹿受其惊吓，终日惶惶…
	/// </summary>
	public void AddSectMainStoryBaihuaMelanoHelps()
	{
		int beginOffset = BeginAddingRecord(331);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 各地病症
	/// 忽有诡谲黑气现于{0}，传闻凡受黑气侵扰之人，未久便身患神秘疯症。百花谷得知此事遂遣弟子查探，试图施医救治…
	/// </summary>
	public void AddSectMainStoryBaihuaManicLow(Location location)
	{
		int beginOffset = BeginAddingRecord(332);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 死气来袭
	/// 忽有沉沉黑气现于{0}，传闻凡受黑气侵扰之人，立时便身患神秘骇人疯症。百花谷得知此事遂遣弟子查探，试图施医救治…
	/// </summary>
	public void AddSectMainStoryBaihuaManicHigh(Location location)
	{
		int beginOffset = BeginAddingRecord(333);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天人感应
	/// 运转{0}时突然天人相感…
	/// </summary>
	public void AddLoopingEvent(short combatSkillTemplateId)
	{
		int beginOffset = BeginAddingRecord(334);
		AppendCombatSkill(combatSkillTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 五行命气
	/// 八生八死之法所现五行命气已产生转变，其间人物的特性也随之改变…
	/// </summary>
	public void AddFiveElementsChange()
	{
		int beginOffset = BeginAddingRecord(335);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 资源采集
	/// {0}的{1}采集完毕了。
	/// </summary>
	public void AddResourcesCollectionCompleted(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(336);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 伏龙祭祀
	/// 赤明岛近日频发奇异天灾，伏龙坛上下皆道是天降祥瑞，为请真龙降世，已开始筹备祭龙盛典…
	/// </summary>
	public void AddSectMainStoryFulongSacrifice()
	{
		int beginOffset = BeginAddingRecord(337);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 鸡毛零落
	/// {0}因失去一缕最为美丽的羽毛，正在暗自神伤…
	/// </summary>
	public void AddSectMainStoryFulongFeatherDrop(short chickenId)
	{
		int beginOffset = BeginAddingRecord(338);
		AppendChicken(chickenId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 筹备春日集市
	/// 旧岁已尽，佳节将至，{2}个月后便是新春集会，各地商贾正为此四处张罗…
	/// </summary>
	public void AddMarketComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(339);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 筹备比武大会
	/// 日修夜短，阳气渐盛，各路武林豪杰云集于{0}，{2}个月后将于此召开{1}…
	/// </summary>
	public void AddTownCombatComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(340);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 筹备促织大会
	/// 虫鸣声中，光阴荏苒，三年一度的{1}即将于{2}个月后在{0}召开！
	/// </summary>
	public void AddCricketContestComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(341);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 筹备较艺大会
	/// 暑往寒来，万物生息，各地艺林翘楚汇集于{0}，{2}个月后将于此召开{1}…
	/// </summary>
	public void AddLifeCompetitionComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(342);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 筹备门派较武
	/// 传闻{0}将于{2}个月后举行{1}，一试门中弟子平日所学…
	/// </summary>
	public void AddSectNormalCompetitionComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(343);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 筹备比武招亲
	/// 听闻{0}有一位没落的权贵正觅求佳婿，{2}个月后将于城中举行{1}…
	/// </summary>
	public void AddJoustForSpouseComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(344);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 人物濒死
	/// 关注的{0}濒临死亡…
	/// </summary>
	public void AddDyingNotice(int charId)
	{
		int beginOffset = BeginAddingRecord(345);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 人物伤重
	/// 关注的{0}状态不佳…
	/// </summary>
	public void AddInjuredNotice(int charId)
	{
		int beginOffset = BeginAddingRecord(346);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 人物受困
	/// 关注的{0}受困于某地等待拯救…
	/// </summary>
	public void AddTrappedNotice(int charId)
	{
		int beginOffset = BeginAddingRecord(347);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 消灭狂徒
	/// {0}在{1}遭遇伏龙狂徒拦路勒索供奉，反手将其消灭…
	/// </summary>
	public void AddSectMainStoryFulongFightSucceed(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(348);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遭遇抢劫
	/// {0}在{1}遭遇伏龙狂徒拦路勒索供奉，反抗不成，遭到抢劫…
	/// </summary>
	public void AddSectMainStoryFulongFightFail(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(349);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遭遇抢劫
	/// {0}在{1}遭遇伏龙狂徒拦路勒索供奉，反抗不成，遭到抢劫…
	/// </summary>
	public void AddSectMainStoryFulongFamilyFightFail(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(350);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遭遇抢劫
	/// {0}在{1}遭遇伏龙狂徒拦路抢劫，束手就擒交出了供奉…
	/// </summary>
	public void AddSectMainStoryFulongRobbery(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(351);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遭遇抢劫
	/// {0}在{1}遭遇伏龙狂徒拦路抢劫，束手就擒交出了供奉…
	/// </summary>
	public void AddSectMainStoryFulongFamilyRobbery(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(352);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 骨肉分离
	/// {0}于{1}监牢诞下婴孩，但因无力抚养，只得将其托付至亲{2}，正是：骨肉离分，泪眼断肠…
	/// </summary>
	public void AddDeliverInPrison0(int charId, short settlementId, int charId1)
	{
		int beginOffset = BeginAddingRecord(353);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 骨肉分离
	/// {0}于{1}监牢诞下婴孩，但因无力抚养，只得将其交由{2}养育，正是：骨肉离分，泪眼断肠…
	/// </summary>
	public void AddDeliverInPrison1(int charId, short settlementId, int charId1)
	{
		int beginOffset = BeginAddingRecord(354);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 离开人世
	/// {0}于{1}监牢关押期间，离开了人世…
	/// </summary>
	public void AddDieInPrison(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(355);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遭到暗杀
	/// {0}在{1}监牢服刑期间，因遭到界青门的暗杀，离开了人世…
	/// </summary>
	public void AddAssassinatedInPrison(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(356);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 无影夺命
	/// {0}在{1}监牢服刑期间，因手持无影令遭到了界青门的刺杀，离开了人世…
	/// </summary>
	public void AddAssassinatedDueToKillerTokenInPrison(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(357);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 骨肉分离
	/// 因{0}身陷囹圄，无力抚养{1}，只得将其托付至亲{2}，正是：骨肉离分，泪眼断肠…
	/// </summary>
	public void AddImprisonAndAbandonBaby0(int charId, short settlementId, int charId1)
	{
		int beginOffset = BeginAddingRecord(358);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 骨肉分离
	/// 因{0}身陷囹圄，无力抚养{1}，只得将其交由{2}养育，正是：骨肉离分，泪眼断肠…
	/// </summary>
	public void AddImprisonAndAbandonBaby1(int charId, short settlementId, int charId1)
	{
		int beginOffset = BeginAddingRecord(359);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 资源迁移
	/// {0}于{1}叩石垦壤，终于顺利完成迁移，带着{2}返回了太吾村…
	/// </summary>
	public void AddResourceMigration(int charId, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(360);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 获得秘闻
	/// {0}所携的元鸡传回了消息：在{1}与众人闲谈时，偶然获悉了{2}知晓的一则秘闻…
	/// </summary>
	public void AddChickenSecretInformation(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(361);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 获得见闻
	/// {0}看守{1}时，潜心查探，终于获知了{2}的情况…
	/// </summary>
	public void AddXiangshuNormalInformation(int charId, sbyte xiangshuAvatarId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(362);
		AppendCharacter(charId);
		AppendSwordTomb(xiangshuAvatarId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天火寂灭
	/// 赤明岛上连绵天火，如今终于灭止…
	/// </summary>
	public void AddSectMainStoryFulongFireVanishes()
	{
		int beginOffset = BeginAddingRecord(363);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 伏龙搜刮
	/// 因求得真龙降世，伏龙坛派出使者宣扬真龙神威，威逼百姓献出珍宝，供奉真龙…
	/// </summary>
	public void AddSectMainStoryFulongLooting()
	{
		int beginOffset = BeginAddingRecord(364);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 神木长成
	/// 琪花瑶草傍生，白鹤青鸾翔舞，位于{0}的神木已然长成…
	/// </summary>
	public void AddSectMainStoryWudangTreesGrow(Location location)
	{
		int beginOffset = BeginAddingRecord(365);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 试剑大典
	/// 时隔多年，试剑大典于铸剑山庄再次举办…
	/// </summary>
	public void AddSectMainStoryZhujianSwordTestCeremony()
	{
		int beginOffset = BeginAddingRecord(366);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队移动
	/// {0}正前往{1}，还需{2}个月方能抵达终点…
	/// </summary>
	public void AddInvestedCaravanMove(sbyte merchant, short settlementId, int value)
	{
		int beginOffset = BeginAddingRecord(367);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队经过
	/// {0}已经抵达{1}，还需{2}个月方能到达目的地{3}。
	/// </summary>
	public void AddInvestedCaravanPassSettlement(sbyte merchant, short settlementId, int value, short settlementId1)
	{
		int beginOffset = BeginAddingRecord(368);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队经过
	/// {0}已经抵达{1}，还需{2}个月方能到达目的地{3}。此地文化值过低，商队意外收益率提升至{4}%。
	/// </summary>
	public void AddInvestedCaravanPassLowCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1)
	{
		int beginOffset = BeginAddingRecord(369);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队经过
	/// {0}已经抵达{1}，还需{2}个月方能到达目的地{3}。此地文化值较高，商队收益比例提升至{4}%。
	/// </summary>
	public void AddInvestedCaravanPassHighCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1)
	{
		int beginOffset = BeginAddingRecord(370);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队经过
	/// {0}已经抵达{1}，还需{2}个月方能到达目的地{3}。此地安定值过低，商队遇劫几率提升至{4}%。
	/// </summary>
	public void AddInvestedCaravanPassLowSafetySettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1)
	{
		int beginOffset = BeginAddingRecord(371);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队经过
	/// {0}已经抵达{1}，还需{2}个月方能到达目的地{3}。此地安定值较高，商队遇劫几率降低至{4}%。
	/// </summary>
	public void AddInvestedCaravanPassHighSafetySettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1)
	{
		int beginOffset = BeginAddingRecord(372);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队经过
	/// {0}已经抵达{1}，还需{2}个月方能到达目的地{3}。此地安定值过低，商队遇劫几率提升至{4}%。此地文化值过低，商队意外收益率提升至{5}%。
	/// </summary>
	public void AddInvestedCaravanPassLowSafetyLowCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(373);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队经过
	/// {0}已经抵达{1}，还需{2}个月方能到达目的地{3}。此地安定值过低，商队遇劫几率提升至{4}%。此地文化值较高，商队收益比例提升至{5}%。
	/// </summary>
	public void AddInvestedCaravanPassLowSafetyHighCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(374);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队经过
	/// {0}已经抵达{1}，还需{2}个月方能到达目的地{3}。此地安定值较高，商队遇劫几率降低至{4}%。此地文化值过低，商队意外收益率提升至{5}%。
	/// </summary>
	public void AddInvestedCaravanPassHighSafetyLowCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(375);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队经过
	/// {0}已经抵达{1}，还需{2}个月方能到达目的地{3}。此地安定值较高，商队遇劫几率降低至{4}%。此地文化值较高，商队收益比例提升至{5}%。
	/// </summary>
	public void AddInvestedCaravanPassHighSafetyHighCultureSettlement(sbyte merchant, short settlementId, int value, short settlementId1, int value1, int value2)
	{
		int beginOffset = BeginAddingRecord(376);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendSettlement(settlementId1);
		AppendInteger(value1);
		AppendInteger(value2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队到达
	/// {0}已经抵达终点{1}，太吾因投资获得{2}银钱收入，并增加{3}的好感…
	/// </summary>
	public void AddInvestedCaravanArrive(sbyte merchant, short settlementId, int value, sbyte merchantType)
	{
		int beginOffset = BeginAddingRecord(377);
		AppendMerchant(merchant);
		AppendSettlement(settlementId);
		AppendInteger(value);
		AppendMerchantType(merchantType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队遇劫
	/// {0}在{1}遭逢匪徒拦路抢劫，十分危险！
	/// </summary>
	public void AddInvestedCaravanIsRobbed(sbyte merchant, Location location)
	{
		int beginOffset = BeginAddingRecord(378);
		AppendMerchant(merchant);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 商队被劫
	/// {0}在{1}遭逢匪徒拦路抢劫，因无力反抗，收益比例下降至{2}%。
	/// </summary>
	public void AddInvestedCaravanIsRobbedAndFailed(sbyte merchant, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(379);
		AppendMerchant(merchant);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 扩建搁置
	/// {0}的{1}持续扩建中断…
	/// </summary>
	public void AddBuildingUpgradingHolded(short settlementId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(380);
		AppendSettlement(settlementId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 戒律失效
	/// 在{0}立下的戒律{1}因期满而失效…
	/// </summary>
	public void AddPunishmentLost0(short settlementId, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(381);
		AppendSettlement(settlementId);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 戒律失效
	/// 在{0}立下的戒律{1}无法维系而暂时失效…
	/// </summary>
	public void AddPunishmentLost1(short settlementId, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(382);
		AppendSettlement(settlementId);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 订购制品
	/// 托{1}的{0}订购的{2}已制成并送往了太吾村仓库…
	/// </summary>
	public void AddOutsiderMakeHarvest(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(383);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 完成制品
	/// 太吾村中代制已制成{0}…
	/// </summary>
	public void AddTaiwuVillageCraftObjectsFinished(sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(384);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 订购制品
	/// 托{1}的{0}订购的{2}已制成并送往了太吾村仓库…
	/// </summary>
	public void AddOutsiderMakeHarvest1(int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(385);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 人物离世
	/// 太吾村{1}{0}于{2}离世，并于传承名谱中归入过往名册…
	/// </summary>
	public void AddTaiwuVillagerDied(int charId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender, Location location)
	{
		int beginOffset = BeginAddingRecord(386);
		AppendCharacter(charId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 凶案骤减
	/// 也没有占位符
	/// </summary>
	public void AddSectMainStoryRemakeEmeiHomocideCase()
	{
		int beginOffset = BeginAddingRecord(387);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 妖物作乱
	/// 没有
	/// </summary>
	public void AddSectMainStoryRemakeEmeiRumor()
	{
		int beginOffset = BeginAddingRecord(388);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 人物死亡
	/// 关注的{0}在{1}与世长辞…
	/// </summary>
	public void AddDieNotice(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(389);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 人物悬赏
	/// 关注的{0}正被{1}悬赏…
	/// </summary>
	public void AddWantedNotice(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(390);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 绝魔大阵
	/// 大元山巅，千名元山弟子列阵以待，三才绝魔大阵开启在即…
	/// </summary>
	public void AddSectMainStoryYuanshanJuemo()
	{
		int beginOffset = BeginAddingRecord(391);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 采集心材
	/// 从资源点{0}中意外采集到了心材{1}…
	/// </summary>
	public void AddCoreMaterialIncome(short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(392);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 玄灰夺命
	/// 因受玄石火灰侵染，{0}时日无多，将于{1}个月后离世…
	/// </summary>
	public void AddFamilyGetInfected(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(393);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 玄灰绝命
	/// 因受玄石火灰侵染，{0}在{1}不幸离世…
	/// </summary>
	public void AddFamilyDieByInfected(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(394);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 玄灰夺命
	/// 因受玄石火灰侵染，关注的{0}时日无多，将于{1}个月后离世…
	/// </summary>
	public void AddFocusedGetInfected(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(395);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 玄灰绝命
	/// 因受玄石火灰侵染，关注的{0}在{1}不幸离世…
	/// </summary>
	public void AddFocusedDieByInfected(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(396);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 村民受伤
	/// 神木之周，鬼物狰狞，太吾村民舍身卫树。此月守卫神树的村民共有{0}人受伤！
	/// </summary>
	public void AddNormalVillagersInjured(int value)
	{
		int beginOffset = BeginAddingRecord(397);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 村民死亡
	/// 神木之周，鬼物狰狞，太吾村民舍身卫树。太吾村民{0}在{1}因守卫神树而死亡！
	/// </summary>
	public void AddNormalVillagerCasualty(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(398);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 神木长成
	/// 琪花瑶草傍生，白鹤青鸾翔舞，位于{0}的神木已然长成…
	/// </summary>
	public void AddNormalTreesGrow(Location location)
	{
		int beginOffset = BeginAddingRecord(399);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 完成制品
	/// 太吾村中{0}代制已制成{1}，并置入了{2}的行囊中…
	/// </summary>
	public void AddVillagerCraftFinished0(short buildingTemplateId, sbyte itemType, short itemTemplateId, int charId)
	{
		int beginOffset = BeginAddingRecord(400);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 完成制品
	/// 太吾村中{0}代制已制成{1}，并置入了太吾村私库中…
	/// </summary>
	public void AddVillagerCraftFinished1(short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(401);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 完成制品
	/// 太吾村中{0}代制已制成{1}，并置入了太吾村公库中…
	/// </summary>
	public void AddVillagerCraftFinished2(short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(402);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 完成制品
	/// 太吾村中{0}代制已制成{1}，并置入了太吾村货仓中…
	/// </summary>
	public void AddVillagerCraftFinished3(short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(403);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 订购制品
	/// 向{1}的{0}订购的代制{2}已制成，并送往了{3}的行囊中…
	/// </summary>
	public void AddNpcCraftFinished0(int charId, short settlementId, sbyte itemType, short itemTemplateId, int charId1)
	{
		int beginOffset = BeginAddingRecord(404);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 订购制品
	/// 向{1}的{0}订购的代制{2}已制成，并置入了太吾村私库中…
	/// </summary>
	public void AddNpcCraftFinished1(int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(405);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 订购制品
	/// 向{1}的{0}订购的代制{2}已制成，并置入了太吾村公库中…
	/// </summary>
	public void AddNpcCraftFinished2(int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(406);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 订购制品
	/// 向{1}的{0}订购的代制{2}已制成，并置入了太吾村货仓中…
	/// </summary>
	public void AddNpcCraftFinished3(int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(407);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天赐良缘
	/// 得天赐良缘，亲密无间，{0}{1}与本地{2}{3}结为夫妻…
	/// </summary>
	public void AddNpcLongDistanceMarriage0(short settlementId, int charId, short settlementId1, int charId1)
	{
		int beginOffset = BeginAddingRecord(408);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendSettlement(settlementId1);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天赐良缘
	/// 得天赐良缘，遥呼相应，{0}{1}与{2}{3}结为夫妻…
	/// </summary>
	public void AddNpcLongDistanceMarriage1(short settlementId, int charId, short settlementId1, int charId1)
	{
		int beginOffset = BeginAddingRecord(409);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendSettlement(settlementId1);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天赐良缘
	/// 既得天赐良缘，不顾千里遥迢，{0}{1}与远在{2}{3}结为夫妻…
	/// </summary>
	public void AddNpcLongDistanceMarriage2(short settlementId, int charId, short settlementId1, int charId1)
	{
		int beginOffset = BeginAddingRecord(410);
		AppendSettlement(settlementId);
		AppendCharacter(charId);
		AppendSettlement(settlementId1);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 宴席不合
	/// 由于太吾村「宴堂」中没有适合享用的菜肴，{0}受到冷落，心情和好感降低了…
	/// </summary>
	public void AddWithoutFood(int charId)
	{
		int beginOffset = BeginAddingRecord(411);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 逃脱关押
	/// {0}因堕入相枢魔道，抵抗意志异常强烈，在{1}摆脱了{2}的监禁逃走了…
	/// </summary>
	public void AddEscape0(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(412);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 逃脱关押
	/// {0}因持有{3}宝典，抵抗意志异常强烈，在{2}摆脱了{1}的监禁逃走了…
	/// </summary>
	public void AddEscape1(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(413);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 逃脱未果
	/// 被{0}关押的{1}试图逃脱，但未能成功…
	/// </summary>
	public void AddEscapeFailed(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(438);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 沾染玄灰
	/// {0}在{1}不幸沾染玄灰，{2}个月后将会离世…
	/// </summary>
	public void AddFirstGetInfected0(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(414);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 沾染玄灰
	/// 关注的{0}在{1}不幸沾染玄灰，{2}个月后将会离世…
	/// </summary>
	public void AddFirstGetInfected1(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(415);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 三才异变
	/// {0}体内邪气奔涌，若不及时导引相枢邪气，恐将化作三魔化身，反叛助敌…
	/// </summary>
	public void AddYuanshanSpiritCrisis(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(416);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 三魔异变
	/// {0}体内邪气溢散，若不及时吸纳相枢邪气，恐将化作三才化身，反叛助敌…
	/// </summary>
	public void AddYuanshanDemonCrisis(short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(417);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遭遇下毒
	/// {0}在{1}被{2}暗中毒害…
	/// </summary>
	public void AddPlotPoisonedEnemyEscaped(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(418);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遭遇损伤
	/// {0}在{1}被{2}暗中损伤…
	/// </summary>
	public void AddPlotHarmEnemyEscaped(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(419);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 赶赴邀约
	/// {0}应邀已在赴约途中，仍需{1}月到达{2}…
	/// </summary>
	public void AddGoingToAppointment(int charId, int value, Location location)
	{
		int beginOffset = BeginAddingRecord(420);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 汲取真气
	/// 废弃
	/// </summary>
	public void AddSectMainStoryXuehouJixiDrainPeople(Location location, int charId)
	{
		int beginOffset = BeginAddingRecord(421);
		AppendLocation(location);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 汲气失败
	/// 废弃
	/// </summary>
	public void AddSectMainStoryXuehouJixiDrainFail(int charId)
	{
		int beginOffset = BeginAddingRecord(422);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 转移五行
	/// 废弃
	/// </summary>
	public void AddSectMainStoryXuehouTaiwuTransferFiveElements(int charId)
	{
		int beginOffset = BeginAddingRecord(423);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 转移失败
	/// 废弃
	/// </summary>
	public void AddSectMainStoryXuehouTaiwuTransferFiveElementsFail(int charId)
	{
		int beginOffset = BeginAddingRecord(424);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 汲取真气
	/// 姬穸汲取了{0}的真气…
	/// </summary>
	public void AddSectMainStoryXuehouJixiDrainNeili(int charId)
	{
		int beginOffset = BeginAddingRecord(425);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 汲气失败
	/// 因{0}已无真气，姬穸无气可取，正独自游荡，寻觅目标…
	/// </summary>
	public void AddSectMainStoryXuehouJixiDrainNeiliFail(int charId)
	{
		int beginOffset = BeginAddingRecord(426);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 转移五行
	/// 姬穸运使血法，转移身处{0}的{1}五行内力传与{2}…
	/// </summary>
	public void AddSectMainStoryXuehouTaiwuTransFiveElements(Location location, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(427);
		AppendLocation(location);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 转移失败
	/// 姬穸行使血法却难寻{0}所在，故已无法将其五行内力转与{1}…
	/// </summary>
	public void AddSectMainStoryXuehouTaiwuTransFiveElementsFail(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(428);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 汲气失败
	/// 因{0}已入坟茔，姬穸无气可取，正独自游荡，寻觅目标…
	/// </summary>
	public void AddSectMainStoryXuehouJixiDrainNeiliFail1(int charId)
	{
		int beginOffset = BeginAddingRecord(429);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 汲气失败
	/// 因{0}失心入魔，姬穸难取其气，正独自游荡，寻觅目标…
	/// </summary>
	public void AddSectMainStoryXuehouJixiDrainNeiliFail2(int charId)
	{
		int beginOffset = BeginAddingRecord(430);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 汲气失败
	/// 因{0}身处奇遇，姬穸难辨其位，正独自游荡，寻觅目标…
	/// </summary>
	public void AddSectMainStoryXuehouJixiDrainNeiliFail3(int charId)
	{
		int beginOffset = BeginAddingRecord(431);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 外伤恶化
	/// 因玄狱设置-创伤恶化影响，收到了{0}点外伤。
	/// </summary>
	public void AddChallengeModeAdvanceMonthWorsenInjuryOuter(int value)
	{
		int beginOffset = BeginAddingRecord(432);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 内伤恶化
	/// 因玄狱设置-创伤恶化影响，收到了{0}点内伤。
	/// </summary>
	public void AddChallengeModeAdvanceMonthWorsenInjuryInner(int value)
	{
		int beginOffset = BeginAddingRecord(433);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 中毒加深
	/// 因玄狱设置-创伤恶化影响，体内的毒素加深了。
	/// </summary>
	public void AddChallengeModeAdvanceMonthWorsenPoison()
	{
		int beginOffset = BeginAddingRecord(434);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 羽翼丰满
	/// 太吾村中，元鸡生息安适，长势康健，而今尽皆羽翼丰满，正可采撷其羽……
	/// </summary>
	public void AddChickenFullyFledged()
	{
		int beginOffset = BeginAddingRecord(435);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 缺食少衣
	/// 因太吾村中资源匮乏，村民{0}对太吾的好感下降了…
	/// </summary>
	public void AddCostResourceNotEnough(int charId)
	{
		int beginOffset = BeginAddingRecord(436);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 村民出走
	/// 因太吾村中资源匮乏，村民{0}离开了太吾村…
	/// </summary>
	public void AddCostResourceNotEnoughResult(int charId)
	{
		int beginOffset = BeginAddingRecord(437);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 促织成长
	/// 在蛰室内的{0}的属性得到了提升……
	/// </summary>
	public void AddCricketGrowUp(short colorId, short partId, int nameId)
	{
		int beginOffset = BeginAddingRecord(439);
		AppendCricket(colorId, partId, nameId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 击败义士
	/// 太吾村民{0}在{1}击败了{2}，手中沾染了义士的鲜血…
	/// </summary>
	public void AddKillRighteousRandomEnemyVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(440);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 义士惩戒
	/// 太吾村民{0}在{1}受到{2}的讨伐，未能逃脱惩治，身受重创…
	/// </summary>
	public void AddDefeatedByRighteousRandomEnemyVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(441);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 扫除妖邪
	/// 太吾村民{0}在{1}击败了{2}，为江湖除了一害…
	/// </summary>
	public void AddKillHereticRandomEnemyVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(442);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 妖邪伤人
	/// 太吾村民{0}在{1}受到{2}的袭击，未能抵御其害，身受重创…
	/// </summary>
	public void AddDefeatedByHereticRandomEnemyVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(443);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 制伏动物
	/// 太吾村民{0}在{1}制伏了{2}，将其逐回林野之中…
	/// </summary>
	public void AddKillAnimalVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(444);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 动物伤人
	/// 太吾村民{0}在{1}受到{2}的袭击，身受重创，险些命丧其口…
	/// </summary>
	public void AddDefeatedByAnimalVillager(int charId, Location location, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(445);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 命丧巢穴
	/// 听闻太吾村民{0}在{1}受困于{2}，最终未能脱身，死于非命…
	/// </summary>
	public void AddDieFromEnemyNestVillager(int charId, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(446);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 逃离巢穴
	/// 听闻太吾村民{0}在{1}受困于{2}，最终绝处逢生，幸免于难…
	/// </summary>
	public void AddEscapeFromEnemyNestVillager(int charId, Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(447);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 逃离巢穴
	/// 听闻太吾村民{0}在{1}受困于{2}，幸而得到{3}解救，最终免于危难…
	/// </summary>
	public void AddSavedFromEnemyNestVillager(int charId, Location location, int adventureCoreId, int charId1)
	{
		int beginOffset = BeginAddingRecord(448);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 逃脱关押
	/// {0}因堕入相枢魔道，抵抗意志异常强烈，在{2}摆脱了{1}的监禁逃走了…
	/// </summary>
	public void AddInfectedKidnapedCharacterEscape(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(449);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 逃脱关押
	/// {0}因持有{3}宝典，抵抗意志异常强烈，在{2}摆脱了{1}的监禁逃走了…
	/// </summary>
	public void AddOwningBookKidnapedCharacterEscape(int charId, int charId1, Location location, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(450);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 神秘怪人
	/// 江湖传言，有一神秘怪人忽而造访峨眉，欲与峨眉弟子武斗决胜，峨眉弟子与之大战数十场，竟无一取胜……
	/// </summary>
	public void AddSectMainStoryEmeiStrangerAttack()
	{
		int beginOffset = BeginAddingRecord(451);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 弟子入魔
	/// 峨眉一派似生风波，传闻有峨眉弟子心志动摇，接连失心入魔，丢魂失魄……
	/// </summary>
	public void AddSectMainStoryEmeiInsaneMember()
	{
		int beginOffset = BeginAddingRecord(452);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 流言四起
	/// 自金顶比武之后，江湖流言四起，世人对峨眉正统渐生疑窦，门派名望亦因此受损……
	/// </summary>
	public void AddSectMainStoryEmeiRumors()
	{
		int beginOffset = BeginAddingRecord(453);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 声名渐复
	/// 经李自华四处奔走斡旋，峨眉派此前受损的声名渐复，其拥护者亦日渐增多……
	/// </summary>
	public void AddSectMainStoryEmeiReputation()
	{
		int beginOffset = BeginAddingRecord(454);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 祖师秘籍
	/// 峨眉派中，掌门正携诸多长老一同研读祖师秘籍，奈何眼下陷入瓶颈，迟迟未有进展……
	/// </summary>
	public void AddSectMainStoryEmeiSecretBook()
	{
		int beginOffset = BeginAddingRecord(455);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 星运入世
	/// 玉蝉将一段时日内所得星运尽数赠予了{0}……
	/// </summary>
	public void AddSectMainStoryJieqingUpgradeXingYun(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(456);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 邪蛟施毒
	/// 因邪仙无方客作祟，{0}途径其生出的{1}近旁时，遭到其暗中施毒…
	/// </summary>
	public void AddMainStoryImmortalWuFanKe(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(457);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 宝镜作祟
	/// 因邪仙颠反魔作祟，{0}途径其生出的{1}近旁时，被暗中摄去了部分周天真气…
	/// </summary>
	public void AddMainStoryImmortalDianFanMo(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(458);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 地区奇遇
	/// 九州风土殊异，各有奇谭，{0}似乎正发生一桩趣事…
	/// </summary>
	public void AddAdventureCapitalCity(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(459);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 集市出现
	/// 商人们三五成群，在{0}召开了一场小型集会。
	/// </summary>
	public void AddSmallMarketAppeared(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(460);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 节气奇遇
	/// {0}的百姓们正依照当地风俗，迎接{1}时节的到来。
	/// </summary>
	public void AddAdventureJieqi(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(461);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 茶会酒会
	/// {0}正在举办一场茶会，众多宾客齐聚于此…
	/// </summary>
	public void AddAdventureTeaParty(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(462);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 茶会酒会
	/// {0}正在举办一场酒宴，众多宾客齐聚于此…
	/// </summary>
	public void AddAdventureWineParty(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(463);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 义士堂
	/// 听闻{0}有义士聚首，行侠仗义，除暴安良…
	/// </summary>
	public void AddAdventureMartialHall(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(464);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 任侠会盟
	/// 听闻{0}古道之上镖队遇伏，杀机四起，生死难料…
	/// </summary>
	public void AddAdventureMissionReward(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(465);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 世外秘境
	/// 听闻{0}山林隐秘之处，似有一处玄异秘境…
	/// </summary>
	public void AddAdventureWorldSecretRealm(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(466);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 筹备节气奇遇
	/// {1}时节即将到来，{0}的居民们正在忙碌地筹备庆典…
	/// </summary>
	public void AddAdventureJieqiComing(Location location, int adventureCoreId, int value)
	{
		int beginOffset = BeginAddingRecord(467);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 赞美嘉许
	/// {0}在{2}赞美嘉许了{1}，使其心情及好感上升…
	/// </summary>
	public void AddBehaviorTypeAction1(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(468);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 侮辱谩骂
	/// {0}在{2}侮辱谩骂了{1}，使其心情及好感下降…
	/// </summary>
	public void AddBehaviorTypeAction2(int charId, int charId1, Location location)
	{
		int beginOffset = BeginAddingRecord(469);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 新春集会
	/// 冬去春来，辞旧迎新，{0}的商贾们纷纷举办起热闹的集会，随处可见赶集的百姓们。
	/// </summary>
	public void AddNewMarketAppeared(Location location, int adventureCoreId)
	{
		int beginOffset = BeginAddingRecord(470);
		AppendLocation(location);
		AppendAdventure(adventureCoreId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 天材地宝
	/// 听闻{0}有异宝降世…
	/// </summary>
	public void AddPreciousMaterial(Location location)
	{
		int beginOffset = BeginAddingRecord(471);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加奇遇准备的通知
	/// </summary>
	public void AddAdventurePrepareNotification(short notificationId, AdventureRuntime runtime)
	{
		if (notificationId >= 0)
		{
			int currDate = ExternalDataBridge.Context.CurrDate;
			AdventureParameterValue? autoCheckSatisfiedDate = runtime.GetParameterOrNull("ConchShipPresetKey_AutoCheckSatisfiedDate");
			if (autoCheckSatisfiedDate.HasValue && autoCheckSatisfiedDate.Value.Current > currDate)
			{
				int remainMonth = autoCheckSatisfiedDate.Value.Current - currDate;
				int beginOffset = BeginAddingRecord(notificationId);
				AppendLocation(runtime.MapLocation);
				AppendAdventure(runtime.CoreId);
				AppendInteger(remainMonth);
				EndAddingRecord(beginOffset);
			}
		}
	}

	/// <summary>
	/// 添加奇遇激活的通知
	/// </summary>
	public void AddAdventureActiveNotification(short notificationId, AdventureRuntime runtime)
	{
		if (notificationId >= 0)
		{
			int beginOffset = BeginAddingRecord(notificationId);
			AppendLocation(runtime.MapLocation);
			AppendAdventure(runtime.CoreId);
			EndAddingRecord(beginOffset);
		}
	}

	/// <summary>
	/// 添加指定行为配置的参数
	/// </summary>
	public void AddConfigMonthlyActionNotification(MonthlyActionsItem actionCfg, IRecordArgumentSource argSource)
	{
		short recordType = actionCfg.NotificationId;
		if (recordType < 0)
		{
			return;
		}
		MonthlyNotificationItem recordCfg = MonthlyNotification.Instance[recordType];
		int beginOffset = BeginAddingRecord(recordType);
		for (int i = 0; i < recordCfg.Parameters.Length; i++)
		{
			string paramTypeStr = recordCfg.Parameters[i];
			if (string.IsNullOrEmpty(paramTypeStr))
			{
				break;
			}
			switch (ParameterType.Parse(paramTypeStr))
			{
			case 0:
				AppendCharacter(argSource.GetCharacterArg());
				continue;
			case 1:
				AppendLocation(argSource.GetLocationArg());
				continue;
			case 5:
				AppendSettlement(argSource.GetSettlementArg());
				continue;
			case 10:
				AppendAdventure(argSource.GetAdventureArg());
				continue;
			case 27:
				AppendLifeSkillType(argSource.GetLifeSkillTypeArg());
				continue;
			}
			throw new Exception("Unsupported parameter type " + paramTypeStr + " detected for world action " + actionCfg.Name + ".");
		}
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加指定行为配置的预告
	/// </summary>
	public void AddConfigMonthlyActionAnnouncementNotification(MonthlyActionsItem actionCfg, IRecordArgumentSource argSource, int countDown)
	{
		short recordType = actionCfg.NotificationId;
		if (recordType < 0)
		{
			return;
		}
		short notificationId = recordType switch
		{
			139 => 344, 
			182 => 344, 
			183 => 343, 
			131 => 339, 
			132 => 340, 
			135 => 342, 
			134 => 341, 
			_ => -1, 
		};
		if (notificationId < 0)
		{
			return;
		}
		MonthlyNotificationItem recordCfg = MonthlyNotification.Instance[notificationId];
		int beginOffset = BeginAddingRecord(notificationId);
		for (int i = 0; i < recordCfg.Parameters.Length; i++)
		{
			string paramTypeStr = recordCfg.Parameters[i];
			if (string.IsNullOrEmpty(paramTypeStr))
			{
				break;
			}
			switch (ParameterType.Parse(paramTypeStr))
			{
			case 5:
				AppendSettlement(argSource.GetSettlementArg());
				continue;
			case 10:
				AppendAdventure(argSource.GetAdventureArg());
				continue;
			case 22:
				AppendInteger(countDown);
				continue;
			}
			throw new Exception("Unsupported parameter type " + paramTypeStr + " detected for world action " + actionCfg.Name + ".");
		}
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加死亡通知.
	/// 注意自动填充的角色参数为死亡者.
	/// </summary>
	public void AddDeathNotification(int charId, CharacterDeathTypeItem deathType, ref CharacterDeathInfo deathInfo)
	{
		int beginOffset = BeginAddingRecord(deathType.DefaultMonthlyNotification);
		bool selfCharIdAdded = false;
		MonthlyNotificationItem recordCfg = MonthlyNotification.Instance[deathType.DefaultMonthlyNotification];
		for (int i = 0; i < recordCfg.Parameters.Length; i++)
		{
			string paramTypeStr = recordCfg.Parameters[i];
			if (string.IsNullOrEmpty(paramTypeStr))
			{
				break;
			}
			switch (ParameterType.Parse(paramTypeStr))
			{
			case 0:
				if (!selfCharIdAdded)
				{
					selfCharIdAdded = true;
					AppendCharacter(charId);
				}
				else
				{
					AppendCharacter((deathInfo.KillerId >= 0) ? deathInfo.KillerId : charId);
				}
				break;
			case 10:
				AppendAdventure(deathInfo.AdventureId);
				break;
			case 1:
				AppendLocation(deathInfo.Location);
				break;
			default:
				throw new Exception("Unrecognized parameter type for death record " + recordCfg.Name);
			}
		}
		EndAddingRecord(beginOffset);
	}

	public void AddIdentityActionCommonSingleTarget(int selfCharId, int targetCharId, Location location, PlanningActionItem actionTemplate)
	{
		if (actionTemplate.MonthlyNotification >= 0)
		{
			MonthlyNotificationItem monthlyNotificationCfg = MonthlyNotification.Instance[actionTemplate.MonthlyNotification];
			if (monthlyNotificationCfg.Parameters.Length < 3 || monthlyNotificationCfg.Parameters[0] != "Character" || monthlyNotificationCfg.Parameters[1] != "Character" || monthlyNotificationCfg.Parameters[2] != "Location")
			{
				AdaptableLog.Warning($"Invalid monthly notification parameters for {monthlyNotificationCfg.Name}({monthlyNotificationCfg.TemplateId})");
				return;
			}
			int beginOffset = BeginAddingRecord(actionTemplate.MonthlyNotification);
			AppendCharacter(selfCharId);
			AppendCharacter(targetCharId);
			AppendLocation(location);
			EndAddingRecord(beginOffset);
		}
	}
}
