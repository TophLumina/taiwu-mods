using System;

namespace Config.Common;

/// <summary>
/// 公式参数类型源
/// </summary>
/// <typeparam name="TArgType"></typeparam>
public interface IFormulaArgTypeSource<out TArgType> where TArgType : Enum
{
	/// <summary>
	/// 获取参数类型数组
	/// </summary>
	TArgType[] ArgTypes { get; }
}
