using System;

namespace GameData.Common;

[AttributeUsage(AttributeTargets.Method)]
public class DataUpgraderAttribute : Attribute
{
	public string Version;

	public string Date;
}
