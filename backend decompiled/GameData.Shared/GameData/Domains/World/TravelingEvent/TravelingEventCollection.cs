using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.World.TravelingEvent;

/// <summary>
/// 旅行事件的集合 - 添加旅行事件
/// </summary>
public class TravelingEventCollection : WriteableRecordCollection
{
	/// <summary>
	/// 获取所有旅行事件的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public void GetRenderInfos(List<TravelingEventRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			TravelingEventRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定位置上的记录类型（即旅行事件模板ID）
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
	/// 获取指定索引的旅行事件的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public new unsafe TravelingEventRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = *(short*)(pCurrData + 1);
			pCurrData += 3;
			TravelingEventItem config = Config.TravelingEvent.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			TravelingEventRenderInfo info = new TravelingEventRenderInfo(recordType, config.Desc, offset);
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
	/// 添加旅行事件 - 京畿材料
	/// {0}于京畿，助镖队通关过隘，获赠{1}…
	/// </summary>
	public int AddJingjiMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(0);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 巴蜀材料
	/// {0}于巴蜀，助樵人砍柴植树，获赠{1}…
	/// </summary>
	public int AddBashuMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(1);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广南材料
	/// {0}于广南，助土医摘草寻药，获赠{1}…
	/// </summary>
	public int AddGuangnanMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(2);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆北材料
	/// {0}于荆北，助篾匠劈竹伐藤，获赠{1}…
	/// </summary>
	public int AddJingBeiMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(3);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山西材料
	/// {0}于山西，助农户烹肉炊食，获赠{1}…
	/// </summary>
	public int AddShanxiMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(4);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广东材料
	/// {0}于广东，助石工搬运凿磨，获赠{1}…
	/// </summary>
	public int AddGuangdongMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(5);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山东材料
	/// {0}于山东，助织女挑花结本，获赠{1}…
	/// </summary>
	public int AddShandongMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(6);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆南材料
	/// {0}于荆南，助采者踏水捞玉，获赠{1}…
	/// </summary>
	public int AddJingnanMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(7);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 福建材料
	/// {0}于福建，助铁匠锻石冶铁，获赠{1}…
	/// </summary>
	public int AddFujianMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(8);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 辽东材料
	/// {0}于辽东，助怪医寻珍觅药，获赠{1}…
	/// </summary>
	public int AddLiaodongMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(9);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 西域材料
	/// {0}于西域，助牧人采毛鞣皮，获赠{1}…
	/// </summary>
	public int AddXiyuMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(10);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 云南材料
	/// {0}于云南，助乌蛮探寻毒蛊，获赠{1}…
	/// </summary>
	public int AddYunnanMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(11);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 淮南材料
	/// {0}于淮南，助隐者看田护园，获赠{1}…
	/// </summary>
	public int AddHuainanMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(12);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江南材料
	/// {0}于江南，助渔家摆渡摇橹，获赠{1}…
	/// </summary>
	public int AddJiangnanMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(13);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江北材料
	/// {0}于江北，助异士掘地寻宝，获赠{1}…
	/// </summary>
	public int AddJiangbeiMaterial(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(14);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 京畿资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddJingjiResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(15);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 巴蜀资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddBashuResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(16);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广南资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddGuangnanResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(17);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆北资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddJingBeiResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(18);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山西资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddShanxiResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(19);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广东资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddGuangdongResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(20);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山东资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddShandongResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(21);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆南资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddJingnanResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(22);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 福建资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddFujianResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(23);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 辽东资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddLiaodongResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(24);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 西域资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddXiyuResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(25);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 云南资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddYunnanResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(26);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 淮南资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddHuainanResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(27);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江南资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddJiangnanResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(28);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江北资源
	/// 路过物产丰富的所在，获得了{1}{2}…
	/// </summary>
	public int AddJiangbeiResource(int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(29);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 京畿食物
	/// 京畿美食融汇四方，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddJingjiFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(30);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 巴蜀食物
	/// 蜀地滋味尤好辛香，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddBashuFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(31);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广南食物
	/// 广南饮食以稻为主，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddGuangnanFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(32);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆北食物
	/// 荆北常以熬煮为食，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddJingBeiFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(33);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山西食物
	/// 山西五谷食之宜人，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddShanxiFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(34);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广东食物
	/// 广东四季瓜果繁多，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddGuangdongFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(35);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山东食物
	/// 山东旧时多产贡果，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddShandongFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(36);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆南食物
	/// 荆南百姓喜食鱼肉，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddJingnanFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(37);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 福建食物
	/// 福建滨海多恃鱼盐，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddFujianFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(38);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 辽东食物
	/// 辽东善骑射喜食肉，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddLiaodongFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(39);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 西域食物
	/// 西域喜食牛羊酥酪，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddXiyuFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(40);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 云南食物
	/// 云南林中常植芳果，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddYunnanFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(41);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 淮南食物
	/// 淮南盛产豆腐等物，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddHuainanFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(42);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江南食物
	/// 江南素称鱼米之乡，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddJiangnanFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(43);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江北食物
	/// 淮扬受誉食精脍细，{0}路过此地，获赠{1}…
	/// </summary>
	public int AddJiangbeiFood(int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(44);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 疗愈外伤
	/// 路遇药泉，治愈了{1}点外伤…
	/// </summary>
	public int AddHealOuterInjury(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(45);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 疗愈内伤
	/// 路遇药泉，治愈了{1}点内伤…
	/// </summary>
	public int AddHealInnerInjury(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(46);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 驱毒
	/// 路遇药泉，体内的{1}减轻了…
	/// </summary>
	public int AddHealPoison(int charId, sbyte poisonType)
	{
		int beginOffset = BeginAddingRecord(47);
		AppendCharacter(charId);
		AppendPoisonType(poisonType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 内息
	/// 遇空旷山谷，呼引清气，内息得以调整…
	/// </summary>
	public int AddHealDisorderOfQi(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(48);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 健康
	/// 遇洞天福地，感应天人，健康得以恢复…
	/// </summary>
	public int AddHealLifeSpan(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(49);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 亲友资源
	/// 路经{1}时，受到{2}的招待，并获赠{3}{4}…
	/// </summary>
	public int AddFriendResource(int charId, Location location, int charId1, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(50);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 亲友食物
	/// 路经{1}时，受到{2}的招待，并获赠{3}…
	/// </summary>
	public int AddFriendFood(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(51);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 亲友茶酒
	/// 路经{1}时，受到{2}的招待，并获赠{3}…
	/// </summary>
	public int AddFriendTeaWine(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(52);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 亲友药品
	/// 路经{1}时，{2}见{0}身有伤病，赠送{3}助其疗愈…
	/// </summary>
	public int AddFriendMedicine(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(53);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 人物资源
	/// 路经{1}时，受到{2}的接待，并获赠{3}{4}…
	/// </summary>
	public int AddFameResource(int charId, Location location, int charId1, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(54);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 人物食物
	/// 路经{1}时，受到{2}的接待，并获赠{3}…
	/// </summary>
	public int AddFameFood(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(55);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 人物茶酒
	/// 路经{1}时，受到{2}的接待，并获赠{3}…
	/// </summary>
	public int AddFameTeaWine(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(56);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 人物药品
	/// 路经{1}时，{2}见{0}身有伤病，赠送{3}助其疗愈…
	/// </summary>
	public int AddFameMedicine(int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(57);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 恢复膂力
	/// 在{1}祛浊壮骨，恢复了{2}点膂力…
	/// </summary>
	public int AddRecoverStrength(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(58);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 恢复灵敏
	/// 在{1}观风听雨，恢复了{2}点灵敏…
	/// </summary>
	public int AddRecoverDexterity(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(59);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 恢复定力
	/// 在{1}宁神静坐，恢复了{2}点定力…
	/// </summary>
	public int AddRecoverConcentration(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(60);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 恢复体质
	/// 在{1}舒展筋骨，恢复了{2}点体质…
	/// </summary>
	public int AddRecoverVitality(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(61);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 恢复根骨
	/// 在{1}吸风饮露，恢复了{2}点根骨…
	/// </summary>
	public int AddRecoverEnergy(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(62);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 恢复悟性
	/// 在{1}感灵悟道，恢复了{2}点悟性…
	/// </summary>
	public int AddRecoverIntelligence(int charId, Location location, int value)
	{
		int beginOffset = BeginAddingRecord(63);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 互动友好
	/// 在{1}偶遇{2}，二人相谈甚欢…
	/// </summary>
	public int AddAreaInteractGood(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(64);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 互动一般
	/// 在{1}偶遇{2}，二人有所交流…
	/// </summary>
	public int AddAreaInteractNormal(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(65);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 互动不和
	/// 在{1}偶遇{2}，二人不欢而散…
	/// </summary>
	public int AddAreaInteractBad(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(66);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 互动无视
	/// 在{1}偶遇{2}，但并未与之交流…
	/// </summary>
	public int AddAreaInteractIgnored(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(67);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 京畿成功
	/// 消耗{2}帮助{1}举办斋会，获得了{3}%地区恩义…
	/// </summary>
	public int AddJingjiAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(68);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 巴蜀成功
	/// 消耗{2}帮助{1}疏浚河道，获得了{3}%地区恩义…
	/// </summary>
	public int AddBashuAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(69);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广南成功
	/// 消耗{2}帮助{1}奏独弦琴，获得了{3}%地区恩义…
	/// </summary>
	public int AddGuangnanAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(70);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆北成功
	/// 消耗{2}帮助{1}修缮城墙，获得了{3}%地区恩义…
	/// </summary>
	public int AddJingBeiAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(71);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山西成功
	/// 消耗{2}帮助{1}祭祀祈福，获得了{3}%地区恩义…
	/// </summary>
	public int AddShanxiAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(72);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广东成功
	/// 消耗{2}帮助{1}探查海域，获得了{3}%地区恩义…
	/// </summary>
	public int AddGuangdongAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(73);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山东成功
	/// 消耗{2}帮助{1}破解棋局，获得了{3}%地区恩义…
	/// </summary>
	public int AddShandongAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(74);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆南成功
	/// 消耗{2}帮助{1}记录胜景，获得了{3}%地区恩义…
	/// </summary>
	public int AddJingnanAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(75);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 福建成功
	/// 消耗{2}帮助{1}立棚施粥，获得了{3}%地区恩义…
	/// </summary>
	public int AddFujianAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(76);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 辽东成功
	/// 消耗{2}帮助{1}举办骑射，获得了{3}%地区恩义…
	/// </summary>
	public int AddLiaodongAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(77);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 西域成功
	/// 消耗{2}帮助{1}建窟立佛，获得了{3}%地区恩义…
	/// </summary>
	public int AddXiyuAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(78);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 云南成功
	/// 消耗{2}帮助{1}沟通部落，获得了{3}%地区恩义…
	/// </summary>
	public int AddYunnanAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(79);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 淮南成功
	/// 消耗{2}帮助{1}立碑题字，获得了{3}%地区恩义…
	/// </summary>
	public int AddHuainanAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(80);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江南成功
	/// 消耗{2}帮助{1}建造货栈，获得了{3}%地区恩义…
	/// </summary>
	public int AddJiangnanAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(81);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江北成功
	/// 消耗{2}帮助{1}装点画舫，获得了{3}%地区恩义…
	/// </summary>
	public int AddJiangbeiAreaSpiritualDebtSucceed(int charId, short settlementId, short characterPropertyReferencedType, float floatValue)
	{
		int beginOffset = BeginAddingRecord(82);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendCharacterPropertyReferencedType(characterPropertyReferencedType);
		AppendFloat(floatValue);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 地区无视
	/// 匆匆经过，并未参与{1}的活动…
	/// </summary>
	public int AddAreaSpiritualDebtIgnored(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(83);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 战斗大胜
	/// 与{1}一战大获全胜…
	/// </summary>
	public int AddTravelBattlePerfectWin(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(84);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 战斗取胜
	/// 与{1}一战获胜，有所损伤…
	/// </summary>
	public int AddTravelBattleWin(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(85);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 战斗落败
	/// 与{1}一战落败，遭受损伤…
	/// </summary>
	public int AddTravelBattleLose(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(86);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 接受同道
	/// 接受{1}的引荐，令{2}加入了太吾村…
	/// </summary>
	public int AddGroupMemberAccept(int charId, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(87);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拒绝同道
	/// 婉言拒绝{1}的引荐…
	/// </summary>
	public int AddGroupMemberRefuse(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(88);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 忽略同道
	/// 并未留意{1}的引荐…
	/// </summary>
	public int AddGroupMemberIgnored(int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(89);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 膂力帮助
	/// 搬运山石，获得了{1}历练…
	/// </summary>
	public int AddConsumeStrengthSucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(90);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 灵敏帮助
	/// 排除凶险，获得了{1}历练…
	/// </summary>
	public int AddConsumeDexteritySucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(91);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 定力帮助
	/// 解除迷阵，获得了{1}历练…
	/// </summary>
	public int AddConsumeConcentrationSucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(92);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 体质帮助
	/// 照顾难民，获得了{1}历练…
	/// </summary>
	public int AddConsumeVitalitySucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(93);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 根骨帮助
	/// 祭祀祈祷，获得了{1}历练…
	/// </summary>
	public int AddConsumeEnergySucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(94);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 悟性帮助
	/// 解读碑文，获得了{1}历练…
	/// </summary>
	public int AddConsumeIntelligenceSucceed(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(95);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 未耗属性
	/// 决定继续赶路…
	/// </summary>
	public int AddNoConsumeMainAttribute(int charId)
	{
		int beginOffset = BeginAddingRecord(96);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 绕道而行
	/// 路遇坎坷，绕道而行，额外耗费了{1}时间…
	/// </summary>
	public int AddRoadBlockAndDetour(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(97);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 无视坎坷
	/// 路遇坎坷，坚持前行，{1}的耐久减少了…
	/// </summary>
	public int AddRoadBlockAndIgnore(int charId, ulong itemKey)
	{
		int beginOffset = BeginAddingRecord(98);
		AppendCharacter(charId);
		AppendItemKey(itemKey);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 京畿互动
	/// {0}路过园林旧址，赏玩石山云水，偶遇{2}…
	/// </summary>
	public int AddJingjiInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(99);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 巴蜀互动
	/// {0}林中发现猫熊，观其憨态可掬，偶遇{2}…
	/// </summary>
	public int AddBashuInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(100);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广南互动
	/// {0}恰逢歌圩之会，参与对唱山歌，偶遇{2}…
	/// </summary>
	public int AddGuangnanInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(101);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆北互动
	/// {0}山中寻访道观，险地四处求索，偶遇{2}…
	/// </summary>
	public int AddJingBeiInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(102);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山西互动
	/// {0}参观摩崖石窟，观其巍峨高峻，偶遇{2}…
	/// </summary>
	public int AddShanxiInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(103);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广东互动
	/// {0}恰逢渔民归家，观看舞草龙庆，偶遇{2}…
	/// </summary>
	public int AddGuangdongInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(104);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山东互动
	/// {0}路过圣人故地，参拜先贤石像，偶遇{2}…
	/// </summary>
	public int AddShandongInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(105);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆南互动
	/// {0}恰逢潇湘胜景，追思当地传说，偶遇{2}…
	/// </summary>
	public int AddJingnanInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(106);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 福建互动
	/// {0}参观旧日番船，思其构筑精妙，偶遇{2}…
	/// </summary>
	public int AddFujianInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(107);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 辽东互动
	/// {0}路逢台堡墩营，循路参观长城，偶遇{2}…
	/// </summary>
	public int AddLiaodongInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(108);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 西域互动
	/// {0}穿过广袤草原，亲近羊马鹿群，偶遇{2}…
	/// </summary>
	public int AddXiyuInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(109);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 云南互动
	/// {0}夜闻芦笙歌曲，见人秉烛夜游，偶遇{2}…
	/// </summary>
	public int AddYunnanInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(110);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 淮南互动
	/// {0}观赏当地伎艺，围观花鼓琴书，偶遇{2}…
	/// </summary>
	public int AddHuainanInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(111);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江南互动
	/// {0}恰逢节庆游乐，品尝路边茶点，偶遇{2}…
	/// </summary>
	public int AddJiangnanInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(112);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江北互动
	/// {0}路过南北码头，见人舍舟登陆，偶遇{2}…
	/// </summary>
	public int AddJiangbeiInteract(int charId, Location location, int charId1)
	{
		int beginOffset = BeginAddingRecord(113);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 京畿恩义
	/// 京畿{1}欲举办斋会，布施百姓…
	/// </summary>
	public int AddJingjiAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(114);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 巴蜀恩义
	/// 巴蜀{1}欲疏浚河道，以惠民生…
	/// </summary>
	public int AddBashuAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(115);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广南恩义
	/// 广南{1}欲弹奏匏琴，以传佳音…
	/// </summary>
	public int AddGuangnanAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(116);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆北恩义
	/// 荆北{1}欲修缮城墙，加强守备…
	/// </summary>
	public int AddJingBeiAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(117);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山西恩义
	/// 山西{1}欲祭祀后土，祈求丰登…
	/// </summary>
	public int AddShanxiAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(118);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 广东恩义
	/// 广东{1}欲探查海域，以测天气…
	/// </summary>
	public int AddGuangdongAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(119);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 山东恩义
	/// 山东{1}欲举办雅集，以效先贤…
	/// </summary>
	public int AddShandongAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(120);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 荆南恩义
	/// 荆南{1}欲记览胜景，以传后世…
	/// </summary>
	public int AddJingnanAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(121);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 福建恩义
	/// 福建{1}欲立棚施粥，以养乞儿…
	/// </summary>
	public int AddFujianAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(122);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 辽东恩义
	/// 辽东{1}将比赛骑射，欲引群兽…
	/// </summary>
	public int AddLiaodongAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(123);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 西域恩义
	/// 西域{1}欲建窟立佛，供人告祷…
	/// </summary>
	public int AddXiyuAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(124);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 云南恩义
	/// 云南{1}欲沟通部落，以求和睦…
	/// </summary>
	public int AddYunnanAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(125);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 淮南恩义
	/// 淮南{1}欲题文胜地，以显风雅…
	/// </summary>
	public int AddHuainanAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(126);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江南恩义
	/// 江南{1}欲建造邸店，赁与客旅…
	/// </summary>
	public int AddJiangnanAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(127);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 江北恩义
	/// 江北{1}欲构造画舫，以取新意…
	/// </summary>
	public int AddJiangbeiAreaSpiritualDebt(int charId, short settlementId)
	{
		int beginOffset = BeginAddingRecord(128);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访少林
	/// 途经{1}，见佛塔凭山而立，乃近少林派…
	/// </summary>
	public int AddVisitShaolin(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(129);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访峨眉
	/// 途经{1}，见金顶祥光普照，乃近峨眉派…
	/// </summary>
	public int AddVisitEmei(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(130);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访百花
	/// 途经{1}，见花海十色五光，乃近百花谷…
	/// </summary>
	public int AddVisitBaihua(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(131);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访武当
	/// 途经{1}，见翠峰道观星列，乃近武当派…
	/// </summary>
	public int AddVisitWudang(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(132);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访元山
	/// 途经{1}，见群山巍峨对峙，乃近元山派…
	/// </summary>
	public int AddVisitYuanshan(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(133);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访狮相
	/// 途经{1}，见殿堂石狮威武，乃近狮相门…
	/// </summary>
	public int AddVisitShixiang(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(134);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访然山
	/// 途经{1}，见山崖高阁矗立，乃近然山派…
	/// </summary>
	public int AddVisitRanshan(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(135);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访璇女
	/// 途经{1}，见玉峰积冰飞雪，乃近璇女派…
	/// </summary>
	public int AddVisitXuannv(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(136);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访铸剑
	/// 途经{1}，见山中泉清水冽，乃近铸剑山庄…
	/// </summary>
	public int AddVisitZhujian(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(137);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访空桑
	/// 途经{1}，见晴山积雪如银，乃近空桑派…
	/// </summary>
	public int AddVisitKongsang(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(138);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访金刚
	/// 途经{1}，见金柱屏峙四方，乃近无量金刚宗…
	/// </summary>
	public int AddVisitJingang(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(139);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访五仙
	/// 途经{1}，见山寨石多图腾，乃近五仙教…
	/// </summary>
	public int AddVisitWuxian(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(140);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访界青
	/// 途经{1}，见悬崖深不见底，乃近界青门…
	/// </summary>
	public int AddVisitJieqing(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(141);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访伏龙
	/// 途经{1}，见海中火光映天，乃近伏龙坛…
	/// </summary>
	public int AddVisitFulong(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(142);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 拜访血犼
	/// 途经{1}，见狭谷红雾弥漫，乃近血犼教…
	/// </summary>
	public int AddVisitXuehou(int charId, Location location)
	{
		int beginOffset = BeginAddingRecord(143);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 外道袭击
	/// 途经险要之地，遭遇{1}袭击！
	/// </summary>
	public int AddEnemyAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(144);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 任侠袭击
	/// 途经险要之地，遭遇{1}袭击！
	/// </summary>
	public int AddRighteousAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(145);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 爪牙袭击
	/// 途经险要之地，遭遇{1}袭击！
	/// </summary>
	public int AddXiangshuMinionAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(146);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 少林袭击
	/// {0}多行不义，恶名远播，今日路遇{1}，正邪不能两立，于是大打出手！
	/// </summary>
	public int AddShaolinAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(147);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 峨眉袭击
	/// {0}多行不义，恶名远播，今日路遇{1}，正邪不能两立，于是大打出手！
	/// </summary>
	public int AddEmeiAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(148);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 百花袭击
	/// {0}多行不义，恶名远播，今日路遇{1}，正邪不能两立，于是大打出手！
	/// </summary>
	public int AddBaihuaAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(149);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 武当袭击
	/// {0}多行不义，恶名远播，今日路遇{1}，正邪不能两立，于是大打出手！
	/// </summary>
	public int AddWudangAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(150);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 元山袭击
	/// {0}多行不义，恶名远播，今日路遇{1}，正邪不能两立，于是大打出手！
	/// </summary>
	public int AddYuanshanAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(151);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 金刚袭击
	/// {0}除恶扬善，侠名远播，今日路遇{1}，正邪不能两立，于是大打出手！
	/// </summary>
	public int AddJingangAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(152);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 五仙袭击
	/// {0}除恶扬善，侠名远播，今日路遇{1}，正邪不能两立，于是大打出手！
	/// </summary>
	public int AddWuxianAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(153);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 界青袭击
	/// {0}除恶扬善，侠名远播，今日路遇{1}，正邪不能两立，于是大打出手！
	/// </summary>
	public int AddJieqingAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(154);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 伏龙袭击
	/// {0}除恶扬善，侠名远播，今日路遇{1}，正邪不能两立，于是大打出手！
	/// </summary>
	public int AddFulongAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(155);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 血犼袭击
	/// {0}除恶扬善，侠名远播，今日路遇{1}，正邪不能两立，于是大打出手！
	/// </summary>
	public int AddXuehouAttack(int charId, short charTemplateId)
	{
		int beginOffset = BeginAddingRecord(156);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 亲友同道
	/// 路经{1}时，{2}推荐其好友{3}加入太吾村…
	/// </summary>
	public int AddFriendGroupMember(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(157);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 人物同道
	/// 路经{1}时，{2}推荐其好友{3}加入太吾村…
	/// </summary>
	public int AddFameGroupMember(int charId, Location location, int charId1, int charId2)
	{
		int beginOffset = BeginAddingRecord(158);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 消耗膂力
	/// 路遇山石阻塞道路，可消耗{1}点膂力，搬运山石…
	/// </summary>
	public int AddConsumeStrength(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(159);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 消耗灵敏
	/// 路遇贼寇暗设机关，可消耗{1}点灵敏，排除凶险…
	/// </summary>
	public int AddConsumeDexterity(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(160);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 消耗定力
	/// 路遇妖人布下迷阵，可消耗{1}点定力，守心固神…
	/// </summary>
	public int AddConsumeConcentration(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(161);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 消耗体质
	/// 路遇难民艰难远徙，可消耗{1}点体质，照顾难民…
	/// </summary>
	public int AddConsumeVitality(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(162);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 消耗根骨
	/// 路遇筹备祭祀典礼，可消耗{1}点根骨，祭祀祈祷…
	/// </summary>
	public int AddConsumeEnergy(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(163);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 消耗悟性
	/// 路遇古代无名石碑，可消耗{1}点悟性，解读古文…
	/// </summary>
	public int AddConsumeIntelligence(int charId, int value)
	{
		int beginOffset = BeginAddingRecord(164);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加旅行事件 - 道路坎坷
	/// 前方道路坎坷，由此地通行将损耗载具耐久…
	/// </summary>
	public int AddRoadBlock(int charId)
	{
		int beginOffset = BeginAddingRecord(165);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <inheritdoc />
	public unsafe override void FillEventArgBox(int offset, IVariantCollection<string> eventArgBox)
	{
		string keyPrefix = "TravelingEvent_arg";
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			short recordType = *(short*)(pCurrData + 1);
			pCurrData += 3;
			string[] parameters = Config.TravelingEvent.Instance[recordType].Parameters;
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

	/// <summary>
	/// 检查参数的有效性
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="parameters"></param>
	public void CheckParameters(short templateId, params string[] parameters)
	{
		string[] configParams = Config.TravelingEvent.Instance[templateId].Parameters;
		for (int i = 0; i < configParams.Length; i++)
		{
			if (parameters.Length <= i)
			{
				Tester.Assert(string.IsNullOrEmpty(configParams[i]));
			}
			else
			{
				Tester.Assert(configParams[i] == parameters[i]);
			}
		}
	}

	/// <summary>
	/// 添加地区材料类事件
	/// </summary>
	public int AddType_AreaMaterial(short templateId, int charId, sbyte itemType, short itemTemplateId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AreaMaterial);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加地区资源类事件
	/// </summary>
	public int AddType_AreaResource(short templateId, int charId, int value, sbyte resourceType)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AreaResource);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加地区食物类事件
	/// </summary>
	public int AddType_AreaFood(short templateId, int charId, sbyte itemType, short itemTemplateId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AreaFood);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物赠礼类事件 - 资源
	/// </summary>
	public int AddType_CharacterGiftResource(short templateId, int charId, Location location, int charId1, int value, sbyte resourceType)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.CharacterGiftResource);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加人物赠礼类事件 - 物品
	/// </summary>
	public int AddType_CharacterGiftItem(short templateId, int charId, Location location, int charId1, sbyte itemType, short itemTemplateId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.CharacterGiftItem);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加恢复属性类事件
	/// </summary>
	public int AddType_AttributeRegen(short templateId, int charId, Location location, int value)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AttributeRegen);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加地区互动类事件
	/// </summary>
	public int AddType_AreaInteraction(short templateId, int charId, Location location, int charId1)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AreaInteraction);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加地区恩义类事件
	/// </summary>
	public int AddType_SpiritualDebt(short templateId, int charId, short settlementId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.SpiritualDebt);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加门派拜访类事件
	/// </summary>
	public int AddType_SectVisit(short templateId, int charId, Location location)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.SectVisit);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加战斗类事件
	/// </summary>
	public int AddType_Combat(short templateId, int charId, short charTemplateId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.Combat);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加门派战斗类事件
	/// </summary>
	public int AddType_SectCombat(short templateId, int charId, short charTemplateId)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.SectCombat);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendCharacterTemplate(charTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加推荐村民类事件
	/// </summary>
	public int AddType_CharacterRecommendVillager(short templateId, int charId, Location location, int charId1, int charId2)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.CharacterRecommendVillager);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendCharacter(charId1);
		AppendCharacter(charId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加主要属性损耗类事件
	/// </summary>
	public int AddType_AttributeCost(short templateId, int charId, int value)
	{
		Tester.Assert(Config.TravelingEvent.Instance[templateId].Type == ETravelingEventType.AttributeCost);
		int beginOffset = BeginAddingRecord(templateId);
		AppendCharacter(charId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
