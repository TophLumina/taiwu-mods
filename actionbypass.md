# NPC 行动屏蔽审查记录

本文记录对 `backend decompiled/GameData.ActionPlanning.ActionImpl`、`PlanningAction`、`PlanningGoal`、`PlanningState` 以及原版 planner 相关源码的审查结果，用于后续评估是否重新开放部分 NPC 行为。

## 结论

当前没有发现通过负权重或全局零权重隐藏行动的证据。更明确的屏蔽机制来自配置层：部分已经有 ActionImpl 实现的行为，在 `PlanningAction` 或 `PlanningGoal` 中引用了 `EPlanningStateSensorType.None` 的状态条件，因此会在 `CharacterActionPlanner.CheckNodeReachable` 初始化阶段被直接判为不可达。

这类行为不是低概率执行，而是不会进入 planning graph。

## 原版屏蔽机制

### 权重路径

行动权重由 `PlanningActionNode.GetWeight` 计算：

- 如果 `PlanningActionItem.PersonalityType >= 0`，加入角色对应 personality 数值。
- 如果 `BehaviorTypeWeights` 存在，加入 `BehaviorTypeWeights[character.GetBehaviorType()]`。
- `WeightBasedPathfinder` 只接受 `weight > 0` 的节点。

因此，单个行为类型权重为 0 只会屏蔽某类性格/行为类型的角色，并不等于该行为全局屏蔽。此次检查未发现负权重，也未发现“行为权重全 0 且无 personality 加成”的全局屏蔽行动。

相关源码：

- `GameData/GameData/ActionPlanning/MonthlyAI/Node/PlanningActionNode.cs`
- `GameData.ActionPlanning/GameData/ActionPlanning/WeightBasedPathfinder.cs`

### 可达性路径

`CharacterActionPlanner.CheckNodeReachable` 会检查 action/goal 的前提和目标条件：

- node preconditions
- goal target character conditions A/B/C
- action self restrictions
- action target character conditions

只要其中任意条件使用的 `PlanningStateItem.SensorType == EPlanningStateSensorType.None`，该 node 会直接 `return false`。

这意味着相关 action/goal 在 planner 初始化后就是不可达状态，后续 NPC 月行动规划不会选择它。

相关源码：

- `GameData/GameData/ActionPlanning/MonthlyAI/CharacterActionPlanner.cs`
- `GameData.Shared/Config/PlanningState.cs`
- `GameData.Shared/Config/PlanningAction.cs`
- `GameData.Shared/Config/PlanningGoal.cs`

## 疑似被屏蔽的 Action

以下 action 有明确实现类，但其配置前提引用了 `SensorType.None` 状态，因此会被 `CheckNodeReachable` 剪掉。

### LifeSkillCraftingAction

涉及 action：

- `A14 LifeSkillCraftingAction`，配置名键：`PlanningAction_language/RefuseAppointment_14`
- `A15 LifeSkillCraftingAction`，配置名键：`PlanningAction_language/RefuseAppointment_15`
- `A16 LifeSkillCraftingAction`，配置名键：`PlanningAction_language/RefuseAppointment_16`
- `A17 LifeSkillCraftingAction`，配置名键：`PlanningAction_language/RefuseAppointment_17`
- `A18 LifeSkillCraftingAction`，配置名键：`PlanningAction_language/RefuseAppointment_18`
- `A19 LifeSkillCraftingAction`，配置名键：`PlanningAction_language/RefuseAppointment_19`
- `A20 LifeSkillCraftingAction`，配置名键：`PlanningAction_language/RefuseAppointment_20`
- `A21 LifeSkillCraftingAction`，配置名键：`PlanningAction_language/RefuseAppointment_21`
- `A22 LifeSkillCraftingAction`，配置名键：`PlanningAction_language/RefuseAppointment_22`
- `A23 LifeSkillCraftingAction`，配置名键：`PlanningAction_language/RefuseAppointment_23`

共同实现：

- `GameData.ActionPlanning.ActionImpl/GameData/ActionPlanning/ActionImpl/LifeSkillCraftingAction.cs`

配置位置：

- `GameData.Shared/Config/PlanningAction.cs`

触发屏蔽的状态：

- `S402`，未暴露 `DefKey` 常量名，`Item` 父状态，`Bool`，`SensorType.None`
- `S403`，未暴露 `DefKey` 常量名，`Item` 父状态，`Bool`，`SensorType.None`
- `S404`，未暴露 `DefKey` 常量名，`Item` 父状态，`Bool`，`SensorType.None`
- `S405`，未暴露 `DefKey` 常量名，`Item` 父状态，`Bool`，`SensorType.None`
- `S406`，未暴露 `DefKey` 常量名，`Item` 父状态，`Bool`，`SensorType.None`
- `S407`，未暴露 `DefKey` 常量名，`Item` 父状态，`Bool`，`SensorType.None`
- `S408`，未暴露 `DefKey` 常量名，`Item` 父状态，`Bool`，`SensorType.None`

这些状态在 `PlanningState` 中属于 `Item` / `Inventory` 相关状态，但 `SensorType` 被设为 `None`。因此它们作为 precondition 出现时，会让对应 action 初始化不可达。

从实现看，`LifeSkillCraftingAction` 本身逻辑完整，包含：

- `OfflineInitActionData`
- `CheckValid`
- `PostExecute`
- 序列化/反序列化

因此它不像未完成空壳，更像被配置条件屏蔽。

### GainExpByReadingAction

涉及 action：

- `A59 GainExpByReadingAction`，配置名键：`PlanningAction_language/RefuseAppointment_59`

实现：

- `GameData.ActionPlanning.ActionImpl/GameData/ActionPlanning/ActionImpl/GainExpByReadingAction.cs`

配置位置：

- `GameData.Shared/Config/PlanningAction.cs`

触发屏蔽的状态：

- `S599`，未暴露 `DefKey` 常量名，`Item` 父状态，`Bool`，`SensorType.None`

`599` 在 `PlanningState` 中同样是 `Item` 父状态下的 `SensorType.None` 状态。`A59` 将它放入 self restriction，导致 action 初始化不可达。

从实现看，`GainExpByReadingAction` 逻辑也完整，包含：

- 选择可用于获得历练的已读书籍
- 扣除书籍耐久
- 增加角色历练
- 写入生平记录

因此它也更像被配置层屏蔽，而不是代码未完成。

## 疑似被屏蔽的 Goal

以下 goal 使用了 `SensorType.None` 条件，因此也会被 `CheckNodeReachable` 判为不可达。

涉及 goal：

- `G12`，配置名键：`PlanningGoal_language/Name_12`，前提状态：`S434/S435/S436/S437`
- `G13`，配置名键：`PlanningGoal_language/Name_13`，前提状态：`S438/S439`
- `G206`，配置名键：`PlanningGoal_language/Name_206`，前提状态：`S438`
- `G207`，配置名键：`PlanningGoal_language/Name_207`，前提状态：`S439`
- `G214`，配置名键：`PlanningGoal_language/Name_214`，前提状态：`S434`
- `G215`，配置名键：`PlanningGoal_language/Name_215`，前提状态：`S435`
- `G216`，配置名键：`PlanningGoal_language/Name_216`，前提状态：`S437`
- `G217`，配置名键：`PlanningGoal_language/Name_217`，前提状态：`S436`
- `G218`，配置名键：`PlanningGoal_language/Name_218`，前提状态：`S440`

触发屏蔽的状态：

- `S434`，未暴露 `DefKey` 常量名，`Bool`，`SensorType.None`，`InputParamType=11(ItemTemplate)`；由 `A14 LifeSkillCraftingAction` 作为 effect 产生，被 `G12/G214` 作为前提引用。
- `S435`，未暴露 `DefKey` 常量名，`Bool`，`SensorType.None`，`InputParamType=11(ItemTemplate)`；由 `A15 LifeSkillCraftingAction` 作为 effect 产生，被 `G12/G215` 作为前提引用。
- `S436`，未暴露 `DefKey` 常量名，`Bool`，`SensorType.None`，`InputParamType=11(ItemTemplate)`；由 `A16 LifeSkillCraftingAction` 作为 effect 产生，被 `G12/G217` 作为前提引用。
- `S437`，未暴露 `DefKey` 常量名，`Bool`，`SensorType.None`，`InputParamType=11(ItemTemplate)`；由 `A17 LifeSkillCraftingAction` 作为 effect 产生，被 `G12/G216` 作为前提引用。
- `S438`，未暴露 `DefKey` 常量名，`Bool`，`SensorType.None`，`InputParamType=11(ItemTemplate)`；由 `A19/A20/A21/A22 LifeSkillCraftingAction` 作为 effect 产生，被 `G13/G206` 作为前提引用。
- `S439`，未暴露 `DefKey` 常量名，`Bool`，`SensorType.None`，`InputParamType=11(ItemTemplate)`；由 `A23 LifeSkillCraftingAction` 作为 effect 产生，被 `G13/G207` 作为前提引用。
- `S440`，未暴露 `DefKey` 常量名，`Bool`，`SensorType.None`，`InputParamType=11(ItemTemplate)`；由 `A18 LifeSkillCraftingAction` 作为 effect 产生，被 `G218` 作为前提引用。

这些状态同样在 `PlanningState` 中定义为 `SensorType.None`，并被 goal preconditions 或 target conditions 引用。

注意：部分 goal 的 `BasePriority == 0` 不能直接视为屏蔽。Goal 优先级还会叠加 `PriorityDelta` 和 `MoralityPriority[behaviorType]`，且有些 goal 可能由触发器或 prioritized goal 逻辑创建。

## 不应误判的情况

### `ImplementationPath == null`

`PlanningAction` 中有大量 action 的 `ImplementationPath` 为 `null`。这些 action 不会被加载为可执行实现，但不一定都是被人为屏蔽的成品行为。很多可能是：

- planning graph 中间状态
- 抽象转移节点
- 仅通过 effects/deeffects 推动状态的配置节点
- 废弃配置残留

因此不能仅凭 `ImplementationPath == null` 判定为“被隐藏的行动”。

### 默认 `OnExecutePhase` 返回 false

`ICharacterActionImpl` 默认：

- `PhaseCount => 0`
- `OnExecutePhase(...) => false`

如果 action 没有设置 `PhaseCount > 0`，执行时不会进入 phase loop，而是直接执行 `PostExecute` 和配置变更。因此不能因为某个 action 没有实现 `OnExecutePhase` 就认为它必然失败。

### `CheckLifeRecords`

部分 action 实现了静态 `CheckLifeRecords(PlanningActionItem config)`。原版会在加载 action implementation 时调用它，如果返回 false，则不加载该 action。

从代码看，这主要用于校验生平记录配置是否完整，避免执行时写入无效 life record。它可能导致 action 不可用，但更像配置防错机制，不像刻意屏蔽开关。

## 重新开放时的风险点

### 需要替换或实现 Sensor

若要重新开放上述 action/goal，核心不是改权重，而是处理 `SensorType.None` 条件。

可选方向：

1. 将这些 `PlanningStateItem` 的 `SensorType.None` 替换为可计算的 sensor。
2. 修改 `CharacterActionPlanner.CheckNodeReachable`，允许特定白名单状态跳过 `None` 剪枝。
3. 在 action/goal 配置层移除这些 `None` 条件，并依赖 ActionImpl 自身的 `OfflineInitActionData` / `CheckValid` 做最终判断。

第三种最容易让行为进入 graph，但也最可能改变 planning 搜索空间，需要测试性能和行为结果。

### LifeSkillCraftingAction

重新开放后需要重点验证：

- NPC 背包扫描成本
- 材料/工具选择是否安全
- 制造结果是否可能异常
- 是否会大量生成高品物品或改变经济循环
- 是否会在过月中显著增加 ItemDomain / Inventory 写入压力

从实现看，`OfflineInitActionData` 中有随机选择、背包枚举、工具/材料检查、资源消耗检查，因此它会增加 planning 初始化成本。

### GainExpByReadingAction

重新开放后需要重点验证：

- NPC 是否会大量消耗旧书耐久
- 是否会显著增加历练获得
- 是否影响书籍保存体积和物品状态变更
- 是否提高过月 Item/Inventory 写入频率

该 action 会遍历角色背包并检查技能书状态，理论上比简单状态行动更重。

## 当前判断

最明确的疑似屏蔽对象是：

- `A14-A23 LifeSkillCraftingAction`
- `A59 GainExpByReadingAction`
- `G12/G13/G206/G207/G214-G218` 对应的 goal 路径

它们不是通过可疑低权重被降低概率，而是通过 `SensorType.None` 条件在 planning graph 初始化阶段被排除。

如果后续要重新开放，建议先做白名单实验项，并增加诊断日志：

- action/goal 是否从 unreachable 变为 reachable
- 每月进入候选的次数
- `OfflineInitActionData` 成功/失败次数
- `CheckValid` 成功/失败次数
- 实际执行次数
- 对 CharacterActionPlanning 总耗时的影响

这样可以区分“开放后仍极少触发”和“开放后成为新热点”。
