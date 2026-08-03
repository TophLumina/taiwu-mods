using System;

namespace Config.ConfigCells.Character;

/// <summary>
/// 角色的属性及其值
/// </summary>
[Serializable]
public struct PropertyAndValue
{
	/// <summary>
	/// 角色属性 ID
	/// </summary>
	public readonly short PropertyId;

	/// <summary>
	/// 属性值
	/// </summary>
	public readonly short Value;

	/// <summary>
	/// 角色的属性及其值
	/// </summary>
	/// <param name="propertyId"></param>
	/// <param name="value"></param>
	public PropertyAndValue(short propertyId, short value)
	{
		PropertyId = propertyId;
		Value = value;
	}
}
