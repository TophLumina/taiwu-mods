namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 事件输入框输入类型
/// </summary>
public class EventInputDataType
{
	/// <summary>
	/// 输入类型为标准字符串类型，将会设置键盘类型为Standard，结果存储为string
	/// </summary>
	public const sbyte String = 0;

	/// <summary>
	/// 输入类型为整数类型，将会设置键盘类型为IntegerNumber，结果存储为int
	/// </summary>
	public const sbyte IntegerNumber = 1;

	/// <summary>
	/// 输入类型为角色姓名，将会设置键盘类型为Name类型，结果存储为string
	/// </summary>
	public const sbyte Name = 2;

	/// <summary>
	/// 输入类型为角色名，需要组合姓氏成为最终角色名，将会设置键盘类型为Name类型，结果存储为string
	/// </summary>
	public const sbyte GivenName = 3;

	/// <summary>
	/// 输入类型为角色姓氏，需要组合名字成为最终角色名，将会设置键盘类型为Name类型，结果存储为string
	/// </summary>
	public const sbyte SurName = 4;

	/// <summary>
	/// 输入类型为角色姓氏 和 名字，将会设置键盘类型为Name类型，结果存储为string
	/// </summary>
	public const sbyte SurNameAndGivenName = 5;

	/// <summary>
	/// 界青暗杀，非中文时允许输入空格
	/// </summary>
	public const sbyte JieqingAssassination = 6;
}
