namespace Config.Common;

/// <summary>
/// 装备品配置数据基类
/// </summary>
public abstract class EquipmentTemplateBase : ItemTemplateBase
{
	/// <summary>
	/// 装备类型 <see cref="T:GameData.Domains.Character.EquipmentType" />
	/// </summary>
	public readonly sbyte EquipmentType;

	/// <summary>
	/// 装备效果 ID (配置值, 实际值可能不同)
	/// </summary>
	public readonly short EquipmentEffectId;

	/// <summary>
	/// 制造类型
	/// </summary>
	public readonly short MakeItemSubType;
}
