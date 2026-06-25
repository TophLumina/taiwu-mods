return {
	BackendPlugins = {
		[1] = "TaiwuOptimization.dll",
	},
	FrontendPlugins = {
		[1] = "TaiwuOptimizationFront.dll",
	},
	Title = "[天幕心帷]过月性能优化",
	Version = "0.3.0.0",
	Author = "man!",
	Description = " [h1] 过月性能优化 [/h1]\n\n后期存档中，密闻 UpdateInformation 阶段通常可从秒级下降到百毫秒级；实测样本中，秘闻代谢相关阶段曾由约 1.5s 降至数十毫秒。具体收益取决于秘闻数量、人口规模和当前存档的实际瓶颈。\n\n当前主要优化改为密闻月结热路径替换：为密闻传播、持有人计数和代谢清理建立反查表，减少原版反复全表扫描带来的过月耗时。\n\n当前版本已经取消跨帧延迟结算、pending 队列和 sidecar 文件，不再把区域月结任务推迟到下个月，也不接管/延迟/新增原版保存。\n\n可选实验项：降低未受保护远区 NPC 的每月主/副目标行动点增长，以减少远区 NPC 行动循环压力。保护快照会在游玩帧中按预算构建；若过月时快照尚未就绪，则本次行动点削减会保守跳过。\n\n诊断项可输出密闻月结与 SaveWorld 写盘细分耗时，用于判断瓶颈在过月计算、密闻、domain 序列化、working.db 复制还是压缩写盘。\n\n[b]不修改存档结构；使用 Harmony Patch，可能与修改密闻月结、NPC 月行动点或存档写入诊断相关方法的 mod 冲突。[/b]\n\n[spoiler]PS: 这版的方向从“延迟更多任务”转回“找原版热路径中的重复扫描”。目前密闻阶段收益高、风险低，也更接近不改变原版语义的优化方式。[/spoiler] ",
	Source = 0,
	HasArchive = false,
	NeedRestartWhenSettingChanged = false,
	ChangeConfig = false,
	TagList = {
		[1] = "Compatible Mods",
		[2] = "Optimizations",
	},
	GameVersion = "1.0.24.0",
	DefaultSettings = {
		[1] = {
			SettingType = "Toggle",
			Key = "AdvanceMonthOptimizationEnabled",
			DisplayName = "启用过月优化",
			Description = "总开关。开启后启用密闻月结反查表优化，并允许实验性 NPC 行动点调整读取保护快照。",
			GroupName = "通用配置",
			DefaultValue = true,
		},
		[2] = {
			SettingType = "Toggle",
			Key = "ProtectNeighborStatesForAdvanceMonthOptimization",
			DisplayName = "保护相邻州域",
			Description = "开启后，当前州域和相邻州域都视为保护区域。实验性 NPC 行动点调整不会影响这些区域。",
			GroupName = "通用配置",
			DefaultValue = true,
		},
		[3] = {
			SettingType = "Slider",
			Key = "AdvanceMonthOptimizationFrameBudgetMs",
			DisplayName = "保护快照帧预算",
			Description = "每帧用于构建 NPC 行动点保护快照的时间预算。数值越高，快照越快就绪；数值越低，越不容易影响帧率。",
			GroupName = "通用配置",
			MinValue = 1,
			MaxValue = 4,
			StepSize = 1,
			DefaultValue = 2,
		},
		[4] = {
			SettingType = "Toggle",
			Key = "ReduceRemoteNpcOfflineCurrentGoalActionPointGain",
			DisplayName = "实验：降低远区NPC行动点增长",
			Description = "实验性选项。开启后，未受保护的远区 NPC 每月主/副目标行动点增长会被削减，使其行动推进更慢；不改变行动点上限。",
			GroupName = "实验性：NPC行动点",
			DefaultValue = false,
		},
		[5] = {
			SettingType = "Slider",
			Key = "RemoteNpcOfflineCurrentGoalActionPointGainReduction",
			DisplayName = "行动点增长削减值",
			Description = "每月主/副目标行动点增长各自减少该数值。原版每月各增长 40，上限 60；默认削减 10。",
			GroupName = "实验性：NPC行动点",
			MinValue = 0,
			MaxValue = 20,
			StepSize = 5,
			DefaultValue = 10,
		},
		[6] = {
			SettingType = "Toggle",
			Key = "ProtectTaiwuVillageResidentsFromOfflineActionPointReduction",
			DisplayName = "保护太吾村居民",
			Description = "开启后，太吾村居民始终保留原版行动点增长，不受远区 NPC 行动点削减影响。",
			GroupName = "实验性：NPC行动点",
			DefaultValue = true,
		},
		[7] = {
			SettingType = "Toggle",
			Key = "ProtectSectMembersFromOfflineActionPointReduction",
			DisplayName = "保护门派成员",
			Description = "开启后，门派成员始终保留原版行动点增长。更保守，但会降低实验项收益。",
			GroupName = "实验性：NPC行动点",
			DefaultValue = false,
		},
		[8] = {
			SettingType = "Toggle",
			Key = "AdvanceMonthOptimizationDiagnosticsEnabled",
			DisplayName = "启用过月诊断日志",
			Description = "测试用选项，默认关闭。开启后会在后端 Logs/GameData_*.log 中输出密闻月结和 SaveWorld 写盘细分耗时，便于判断过月/保存热点。",
			GroupName = "过月诊断日志",
			DefaultValue = false,
		},
	},
	FileId = 3750430637,
	Visibility = 0,
	SettingGroups = {
		[1] = "通用配置",
		[2] = "实验性：NPC行动点",
		[3] = "过月诊断日志",
	},
	UpdateLogList = {
		[1] = {
			Timestamp = 1782234802,
		},
		[2] = {
			Timestamp = 1782235028,
		},
		[3] = {
			Timestamp = 1782247859,
		},
		[4] = {
			Timestamp = 1782248233,
		},
		[5] = {
			Timestamp = 1782248252,
		},
		[6] = {
			Timestamp = 1782257461,
		},
		[7] = {
			Timestamp = 1782258542,
		},
		[8] = {
			Timestamp = 1782288454,
		},
		[9] = {
			Timestamp = 1782288500,
		},
		[10] = {
			Timestamp = 1782288782,
		},
	},
	Cover = "c04bb314ab8daa46832bb42193ddebfb.jpg",
	WorkshopCover = "c04bb314ab8daa46832bb42193ddebfb.jpg",
}
