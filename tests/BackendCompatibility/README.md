# 后端注入点与行为回归

在仓库根目录执行：

```powershell
.\tests\BackendCompatibility\Run.ps1
# 自定义游戏目录：
.\tests\BackendCompatibility\Run.ps1 -GameBackendDir 'D:\Games\Taiwu\Backend'
```

需要 .NET 8 或更高版本 SDK、.NET 8 x64 运行时、当前游戏后端 DLL 和仓库自带的 zlib-ng2.dll。

脚本构建两个后端 mod 到 `.validation/`，在独立进程中加载当前游戏 DLL，开启可选补丁组后逐类安装 Harmony 补丁，同时检查反射成员、字段引用及三个 IL 替换点。两个 mod 会同时保持挂载，以检查组合安装。测试不调用插件 Initialize，不启动诊断服务器，也不读写游戏存档。

回归检查包含：

- 408 次真实 `MatchTargetCharacterByConditions` 调用，确保关系候选预过滤不丢失原版接受的目标。
- 原版与优化版群体选择的未遍历、部分遍历、完整遍历，比较穿插随机调用后的目标及随机流。
- 两个目标选择补丁在设置关闭时的安装与回退，以及规划图缓存总开关。
- 11 组物品行动识别：A27 请求淬毒、A166 索取解毒药、编号变化、实现变化、选择器变化。
- 检查 CopyFrom / CopyTo 缓冲区及目标 matcher 的实际 IL 替换次数均为 1。
- 空输入、多块数据、Flush 后续写入的并行 DEFLATE，经当前游戏的解压器还原并比较字节。

结果写入 `.validation/patch-audit.log`。任何补丁安装失败、空目标、反射失败或回归失败都会返回非零退出码。

这是 DLL 兼容性及内存夹具回归，不替代真实存档上的完整过月、存读档和性能 A/B 验证。
