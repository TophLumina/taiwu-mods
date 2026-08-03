/// <summary>
/// PlanningState -&gt; SensorType
/// </summary>
public enum EPlanningStateSensorType
{
	/// <summary>
	/// 无
	/// </summary>
	None = -1,
	/// <summary>
	/// 触发式状态
	/// </summary>
	TriggerStateSensor,
	/// <summary>
	/// 人物通用状态
	/// </summary>
	CharacterStateSensor,
	/// <summary>
	/// 人物功法状态
	/// </summary>
	CombatSkillStateSensor,
	/// <summary>
	/// 人物技艺状态
	/// </summary>
	LifeSkillStateSensor,
	/// <summary>
	/// 人物主要属性状态
	/// </summary>
	MainAttributeStateSensor,
	/// <summary>
	/// 人物志向状态
	/// </summary>
	ProfessionStateSensor,
	/// <summary>
	/// 人物资源状态
	/// </summary>
	ResourceStateSensor,
	/// <summary>
	/// 人物行囊状态
	/// </summary>
	InventoryStateSensor,
	/// <summary>
	/// 人物组织状态
	/// </summary>
	OrganizationStateSensor,
	/// <summary>
	/// 对方状态
	/// </summary>
	TargetStateSensor,
	/// <summary>
	/// 需求参数状态
	/// </summary>
	GoalArgumentStateSensor,
	/// <summary>
	/// 关系状态
	/// </summary>
	RelationStateSensor,
	Count
}
