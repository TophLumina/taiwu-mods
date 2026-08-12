namespace AiEditor;

/// <summary>
/// Ai 配置元组，用于蓝图编辑器
/// </summary>
public interface IAiConfigTuple
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	int TemplateId { get; }

	/// <summary>
	/// 组 ID
	/// </summary>
	int GroupId { get; }

	/// <summary>
	/// 名称
	/// </summary>
	string Name { get; }

	/// <summary>
	/// 描述
	/// </summary>
	string Desc { get; }
}
