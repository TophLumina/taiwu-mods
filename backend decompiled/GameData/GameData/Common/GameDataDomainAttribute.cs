using System;

namespace GameData.Common;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class GameDataDomainAttribute : Attribute
{
	public readonly ushort Id;

	public bool ArchiveAttached;

	public bool CustomArchiveModuleCode;

	public GameDataDomainAttribute(ushort id)
	{
		Id = id;
		ArchiveAttached = true;
		CustomArchiveModuleCode = false;
	}
}
