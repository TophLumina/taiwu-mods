using System.Collections.Generic;
using Config;

namespace GameData.Domains.Map;

public static class SharedMethods
{
	public static void GetAreaListInState(sbyte stateId, List<short> areaList)
	{
		if (stateId >= 0)
		{
			int regularAreasPerState = 3;
			areaList.Clear();
			for (int i = 0; i < regularAreasPerState; i++)
			{
				areaList.Add((short)(stateId * regularAreasPerState + i));
			}
			for (int j = 0; j < 6; j++)
			{
				areaList.Add((short)(45 + stateId * 6 + j));
			}
		}
	}

	public static void GetRegularAreaListInState(sbyte stateId, List<short> areaList)
	{
		if (stateId >= 0)
		{
			int regularAreasPerState = 3;
			areaList.Clear();
			for (int i = 0; i < regularAreasPerState; i++)
			{
				areaList.Add((short)(stateId * regularAreasPerState + i));
			}
		}
	}

	public static void GetBrokenAreaListInState(sbyte stateId, List<short> areaList)
	{
		if (stateId >= 0)
		{
			areaList.Clear();
			for (int i = 0; i < 6; i++)
			{
				areaList.Add((short)(45 + stateId * 6 + i));
			}
		}
	}

	public static IEnumerable<short> GetRegularAreaIdsInState(sbyte stateId)
	{
		if (stateId >= 0)
		{
			int regularAreasPerState = 3;
			for (int i = 0; i < regularAreasPerState; i++)
			{
				yield return (short)(stateId * regularAreasPerState + i);
			}
		}
	}

	public static sbyte GetAreaStyle(short areaTemplateId)
	{
		uint x = ExternalDataBridge.Context.WorldId;
		return (sbyte)(((areaTemplateId * 1103515245 + 12345) ^ x) % 3);
	}

	public static string MapBlockSubTypeName(EMapBlockSubType subType)
	{
		return subType switch
		{
			EMapBlockSubType.TaiwuCun => MapBlock.DefValue.Taiwucun.Name, 
			EMapBlockSubType.Jingcheng => MapBlock.DefValue.Jingcheng.Name, 
			EMapBlockSubType.Chengdu => MapBlock.DefValue.Chengdu.Name, 
			EMapBlockSubType.Guizhou => MapBlock.DefValue.Guizhou.Name, 
			EMapBlockSubType.Xiangyang => MapBlock.DefValue.Xiangyang.Name, 
			EMapBlockSubType.Taiyuan => MapBlock.DefValue.Taiyuan.Name, 
			EMapBlockSubType.Guangzhou => MapBlock.DefValue.Guangzhou.Name, 
			EMapBlockSubType.Qingzhou => MapBlock.DefValue.Qingzhou.Name, 
			EMapBlockSubType.Jiangling => MapBlock.DefValue.Jiangling.Name, 
			EMapBlockSubType.Fuzhou => MapBlock.DefValue.Fuzhou.Name, 
			EMapBlockSubType.Liaoyang => MapBlock.DefValue.Liaoyang.Name, 
			EMapBlockSubType.Qinzhou => MapBlock.DefValue.Qinzhou.Name, 
			EMapBlockSubType.Dali => MapBlock.DefValue.Dali.Name, 
			EMapBlockSubType.Shouchun => MapBlock.DefValue.Shouchun.Name, 
			EMapBlockSubType.Hangzhou => MapBlock.DefValue.Hangzhou.Name, 
			EMapBlockSubType.Yangzhou => MapBlock.DefValue.Yangzhou.Name, 
			EMapBlockSubType.Zhulu => MapBlock.DefValue.BambooHouse1.Name, 
			EMapBlockSubType.ShaolinPai => MapBlock.DefValue.Shaolin.Name, 
			EMapBlockSubType.EmeiPai => MapBlock.DefValue.Emei.Name, 
			EMapBlockSubType.BaihuaGu => MapBlock.DefValue.Baihua.Name, 
			EMapBlockSubType.WudangPai => MapBlock.DefValue.Wudang.Name, 
			EMapBlockSubType.YuanshanPai => MapBlock.DefValue.Yuanshan.Name, 
			EMapBlockSubType.ShixiangMen => MapBlock.DefValue.Shixiang.Name, 
			EMapBlockSubType.RanshanPai => MapBlock.DefValue.Ranshan.Name, 
			EMapBlockSubType.XuannvPai => MapBlock.DefValue.Xuannv.Name, 
			EMapBlockSubType.ZhujianShanzhuang => MapBlock.DefValue.Zhujian.Name, 
			EMapBlockSubType.KongsangPai => MapBlock.DefValue.Kongsang.Name, 
			EMapBlockSubType.JingangZong => MapBlock.DefValue.Jingang.Name, 
			EMapBlockSubType.WuxianJiao => MapBlock.DefValue.Wuxian.Name, 
			EMapBlockSubType.JieqingMen => MapBlock.DefValue.Jieqing.Name, 
			EMapBlockSubType.FulongTan => MapBlock.DefValue.Fulong.Name, 
			EMapBlockSubType.XuehouJiao => MapBlock.DefValue.Xuehou.Name, 
			EMapBlockSubType.Farmland => MapBlock.DefValue.Farmland1.Name, 
			EMapBlockSubType.Gardens => MapBlock.DefValue.Gardens1.Name, 
			EMapBlockSubType.StoneForest => MapBlock.DefValue.StoneForest1.Name, 
			EMapBlockSubType.MulberryField => MapBlock.DefValue.MulberryField1.Name, 
			EMapBlockSubType.HerbalGarden => MapBlock.DefValue.HerbalGarden1.Name, 
			EMapBlockSubType.JadeMountain => MapBlock.DefValue.JadeMountain1.Name, 
			EMapBlockSubType.Mountain => MapBlock.DefValue.Mountain1.Name, 
			EMapBlockSubType.BigMountain => MapBlock.DefValue.BigMountain1.Name, 
			EMapBlockSubType.Canyon => MapBlock.DefValue.Canyon1.Name, 
			EMapBlockSubType.BigCanyon => MapBlock.DefValue.BigCanyon1.Name, 
			EMapBlockSubType.Hill => MapBlock.DefValue.Hill1.Name, 
			EMapBlockSubType.BigHill => MapBlock.DefValue.BigHill1.Name, 
			EMapBlockSubType.Field => MapBlock.DefValue.Field1.Name, 
			EMapBlockSubType.BigField => MapBlock.DefValue.BigField1.Name, 
			EMapBlockSubType.Woodland => MapBlock.DefValue.Woodland1.Name, 
			EMapBlockSubType.BigWoodland => MapBlock.DefValue.BigWoodland1.Name, 
			EMapBlockSubType.RiverBeach => MapBlock.DefValue.RiverBeach1.Name, 
			EMapBlockSubType.BigRiverBeach => MapBlock.DefValue.HeGu1.Name, 
			EMapBlockSubType.Lake => MapBlock.DefValue.Lake1.Name, 
			EMapBlockSubType.Jungle => MapBlock.DefValue.Jungle1.Name, 
			EMapBlockSubType.Cave => MapBlock.DefValue.Cave1.Name, 
			EMapBlockSubType.Swamp => MapBlock.DefValue.Swamp1.Name, 
			EMapBlockSubType.TaoYuan => MapBlock.DefValue.TaoYuan1.Name, 
			EMapBlockSubType.Valley => MapBlock.DefValue.Valley1.Name, 
			EMapBlockSubType.Wild => MapBlock.DefValue.Wild1.Name, 
			EMapBlockSubType.Ruin => MapBlock.DefValue.Ruin1.Name, 
			EMapBlockSubType.DarkPool => MapBlock.DefValue.Abyss.Name, 
			EMapBlockSubType.Block => MapBlock.DefValue.Block.Name, 
			EMapBlockSubType.None => MapBlock.DefValue.None.Name, 
			EMapBlockSubType.Village => MapBlock.DefValue.Village.Name, 
			EMapBlockSubType.Town => MapBlock.DefValue.Town.Name, 
			EMapBlockSubType.WalledTown => MapBlock.DefValue.Stockade.Name, 
			EMapBlockSubType.Station => MapBlock.DefValue.Station.Name, 
			EMapBlockSubType.Scenery_1 => LocalStringManager.Get(LanguageKey.LK_CommonSortAndFilter_Filter_MapBlock_Type_8), 
			EMapBlockSubType.SwordTomb => LocalStringManager.Get(LanguageKey.LK_CommonSortAndFilter_Filter_MapBlock_SwordTomb), 
			EMapBlockSubType.DLCLoong => LocalStringManager.Get(LanguageKey.LK_CommonSortAndFilter_Filter_MapBlock_Loong), 
			_ => "-", 
		};
	}
}
