using System;
using GameData.Combat.Math;

namespace Config.ConfigCells;

/// <summary>
/// 属性的类型、值、变化类型
/// </summary>
[Serializable]
public struct PropertyAndValueAndModifyType
{
	/// <summary>
	/// 属性 ID
	/// </summary>
	public readonly ECharacterPropertyReferencedType Type;

	/// <summary>
	/// 属性值
	/// </summary>
	public readonly int Value;

	/// <summary>
	/// 变化类型。0—A类、1—B类、2—C类
	/// </summary>
	public readonly EDataModifyType Modify;

	/// <summary>
	/// 角色的属性及其值
	/// </summary>
	public PropertyAndValueAndModifyType(short type, int value, EDataModifyType modify)
	{
		Type = (ECharacterPropertyReferencedType)type;
		Value = value;
		Modify = modify;
	}

	/// <summary>
	/// 角色的属性及其值
	/// </summary>
	public PropertyAndValueAndModifyType(short propertyId, int value, sbyte modifyType)
		: this(propertyId, value, (EDataModifyType)modifyType)
	{
	}

	/// <summary>
	/// 配置使用的构造方法
	/// </summary>
	public PropertyAndValueAndModifyType(short propertyId, int value, bool percent)
		: this(propertyId, value, percent ? EDataModifyType.AddPercent : EDataModifyType.Add)
	{
	}

	public static implicit operator CValueModifyDelta(PropertyAndValueAndModifyType pvm)
	{
		return new CValueModifyDelta(pvm.Modify, pvm.Value);
	}
}
