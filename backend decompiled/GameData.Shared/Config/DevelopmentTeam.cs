using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DevelopmentTeam : ConfigData<DevelopmentTeamItem, short>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static DevelopmentTeam Instance = new DevelopmentTeam();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Title", "TeamInfo", "TemplateId" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new DevelopmentTeamItem(0, LocalStringManager.GetConfig("DevelopmentTeam_language", "Title_0"), new string[1] { LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_0_0") }));
		_dataArray.Add(new DevelopmentTeamItem(1, LocalStringManager.GetConfig("DevelopmentTeam_language", "Title_1"), new string[18]
		{
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_0"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_1"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_2"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_3"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_4"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_5"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_6"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_7"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_8"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_9"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_10"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_11"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_12"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_13"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_14"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_15"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_16"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_1_17")
		}));
		_dataArray.Add(new DevelopmentTeamItem(2, LocalStringManager.GetConfig("DevelopmentTeam_language", "Title_2"), new string[18]
		{
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_0"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_1"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_2"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_3"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_4"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_5"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_6"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_7"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_8"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_9"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_10"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_11"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_12"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_13"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_14"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_15"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_16"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_2_17")
		}));
		_dataArray.Add(new DevelopmentTeamItem(3, LocalStringManager.GetConfig("DevelopmentTeam_language", "Title_3"), new string[18]
		{
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_0"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_1"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_2"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_3"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_4"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_5"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_6"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_7"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_8"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_9"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_10"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_11"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_12"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_13"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_14"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_15"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_16"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_3_17")
		}));
		_dataArray.Add(new DevelopmentTeamItem(4, LocalStringManager.GetConfig("DevelopmentTeam_language", "Title_4"), new string[18]
		{
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_0"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_1"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_2"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_3"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_4"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_5"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_6"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_7"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_8"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_9"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_10"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_11"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_12"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_13"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_14"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_15"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_16"),
			LocalStringManager.GetConfig("DevelopmentTeam_language", "TeamInfo_4_17")
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DevelopmentTeamItem>(5);
		CreateItems0();
	}
}
