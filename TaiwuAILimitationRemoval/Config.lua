return {
	BackendPlugins = {
		[1] = "TaiwuRemoveAILimitation.dll",
	},
	Title = "[天幕心斋]NPC行为解除限制",
	Version = "0.1.0.0",
	Author = "man!",
	Description = "第一版：对白名单内原版未接通 sensor 的 NPC 行为进行解除限制。当前包含生活技艺制造类行为与旧书读书涨经验行为。该 Mod 属于玩法补全，不保证严格等价于原版默认行为。",
	Source = 0,
	HasArchive = false,
	NeedRestartWhenSettingChanged = false,
	ChangeConfig = false,
	TagList = {
		[1] = "Gameplay",
		[2] = "Optimizations",
	},
	GameVersion = "1.0.32.0",
	DefaultSettings = {
		[1] = {
			SettingType = "Toggle",
			Key = "EnableNpcActionLimitationRemoval",
			DisplayName = "启用NPC行为解除限制",
			Description = "开启后允许白名单内原版未接通 sensor 的 NPC 行为进入规划：生活技艺制造类行为与旧书读书涨经验行为。最终是否执行仍由原版 action 初始化和有效性检查决定。",
			GroupName = "NPC行为解除限制",
			DefaultValue = true,
		},
		[2] = {
			SettingType = "Toggle",
			Key = "EnableNpcActionLimitationRemovalLog",
			DisplayName = "输出解除限制行为日志",
			Description = "测试用，默认关闭。开启后会在后端 GameData_*.log 中输出白名单行为的可达性放行、action 创建成功/失败和实际执行完成情况。",
			GroupName = "诊断日志",
			DefaultValue = false,
		},
		[3] = {
			SettingType = "Toggle",
			Key = "EnableNpcActionReachabilityDiagnostics",
			DisplayName = "输出NPC行为可达性诊断",
			Description = "测试用，默认关闭。开启后会在 CharacterActionPlanner 初始化后输出 action/goal 可达性汇总，包括 SensorType.None、无 effect producer、未加载 implementation 等原因，用于判断还有哪些 NPC 行为被配置层剪掉。",
			GroupName = "诊断日志",
			DefaultValue = false,
		},
	},
	SettingGroups = {
		[1] = "NPC行为解除限制",
		[2] = "诊断日志",
	},
}
