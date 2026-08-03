using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.World.TeaHorseCaravanEvent;

/// <summary>
/// 过月通知的集合 - 添加过月通知
/// </summary>
/// <summary>
/// 过月通知的集合 - 添加过月通知
/// </summary>
public class TeaHorseCaravanEventCollection : WriteableRecordCollection
{
	/// <summary>
	/// 开始添加过月通知
	/// </summary>
	/// <param name="startMonthAndDistanceToTaiwuVillage">占位数据，暂时无意义</param>
	/// <param name="date">事件日期</param>
	/// <param name="type">事件类型</param>
	/// <returns>当前过月通知的起始偏移</returns>
	private unsafe int BeginAddingRecord(int startMonthAndDistanceToTaiwuVillage, int date, short type)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = startMonthAndDistanceToTaiwuVillage;
			((int*)(num + 1))[1] = date;
			((short*)(num + 1 + 4))[2] = type;
		}
		return offset;
	}

	/// <summary>
	/// 添加过月通知 - 遇到海市蜃楼
	/// 遇到了海市蜃楼，漫灭虚幻，知名度提升了{0}…
	/// </summary>
	public void AddFindMirage(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 0);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现野人
	/// 发现了身形高大，毛发覆身的野人行踪，知名度提升了{0}…
	/// </summary>
	public void AddFindBigfoot(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现动物
	/// 发现中原罕见的珍稀动物，知名度提升了{0}…
	/// </summary>
	public void AddFindAnimal(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 2);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现植物
	/// 于人迹罕至处发现了珍稀植物，知名度提升了{0}…
	/// </summary>
	public void AddFindPlant(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 3);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 回传见闻
	/// 回传了西域见闻，引人惊叹，知名度提升了{0}…
	/// </summary>
	public void AddGetInformation(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 4);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现聚落
	/// 发现神秘聚落，知名度提升了{0}…
	/// </summary>
	public void AddFindSettlement(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 5);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现天气
	/// 遭遇罕见天气，人马未损，知名度提升了{0}…
	/// </summary>
	public void AddFindWeather(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 6);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 迷路了
	/// 地图损毁，迷失道路，知名度下降了{0}…
	/// </summary>
	public void AddLost(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 7);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 不应显示
	/// 不应显示
	/// </summary>
	public void AddMeetTheif(int startMonthAndDistanceToTaiwuVillage, int date)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 8);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遇到盗贼
	/// 路遇盗贼，防范不力，遗失了货物：{0}…
	/// </summary>
	public void AddMeetTheif1(int startMonthAndDistanceToTaiwuVillage, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 9);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遇到盗贼
	/// 路遇盗贼，防范不力，遗失了货物：{0}、{1}…
	/// </summary>
	public void AddMeetTheif2(int startMonthAndDistanceToTaiwuVillage, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 10);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 遇到盗贼
	/// 路遇盗贼，防范不力，遗失了货物：{0}、{1}、{2}…
	/// </summary>
	public void AddMeetTheif3(int startMonthAndDistanceToTaiwuVillage, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 11);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 颠簸损坏
	/// 路途颠簸，绑缚的包袱松散，遗失了货物：{0}…
	/// </summary>
	public void AddGoodsDamage(int startMonthAndDistanceToTaiwuVillage, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 12);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现商队残骸
	/// 发现了商队遗骸，将其妥善掩埋，获得了货物：{0}…
	/// </summary>
	public void AddFindWreckage(int startMonthAndDistanceToTaiwuVillage, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 13);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 援助路人
	/// 援助迷途的路人，减少了{0}补给，知名度提升了{1}…
	/// </summary>
	public void AddHelpPasserby(int startMonthAndDistanceToTaiwuVillage, int date, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 14);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 水土不服
	/// 水土不服，人困马乏，减少了{0}补给…
	/// </summary>
	public void AddUnacclimatized(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 15);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 获得援助
	/// 获得附近聚落的援助，增加了{0}补给…
	/// </summary>
	public void AddGetHelp(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 16);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 偶得野味
	/// 捕获野味，增加了{0}补给…
	/// </summary>
	public void AddFindVenison(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 17);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现果林
	/// 发现了果林，甘美可口，可以搜索至多{0}补给…
	/// </summary>
	public void AddFindFruit(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 18);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 发现村落
	/// 发现了村落，人烟凑集，可以交换至多{0}补给…
	/// </summary>
	public void AddFindVillage(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 19);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	/// <summary>
	/// 添加过月通知 - 路遇商队
	/// 路遇资材充实的商队，可以交换至多{0}补给…
	/// </summary>
	public void AddMeetMerchan(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 20);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}
}
