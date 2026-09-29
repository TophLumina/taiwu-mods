using System;

namespace Config.Common;

public interface IFormulaArgTypeSource<out TArgType> where TArgType : Enum
{
	TArgType[] ArgTypes { get; }
}
