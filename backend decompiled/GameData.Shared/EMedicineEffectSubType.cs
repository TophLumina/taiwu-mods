/// <summary>
/// Medicine -&gt; EffectSubType
/// </summary>
public enum EMedicineEffectSubType
{
	/// <summary>
	/// Invalid
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 随机治愈外伤
	/// </summary>
	RandomRecoverOuterInjury,
	/// <summary>
	/// 随机治愈内伤
	/// </summary>
	RandomRecoverInnerInjury,
	/// <summary>
	/// 恢复固定值健康
	/// </summary>
	RecoverHealthValue,
	/// <summary>
	/// 调理固定值内息
	/// </summary>
	ChangeDisorderOfQiValue,
	/// <summary>
	/// 解固定值烈毒
	/// </summary>
	DetoxPoisonHotValue,
	/// <summary>
	/// 解固定值郁毒
	/// </summary>
	DetoxPoisonGloomyValue,
	/// <summary>
	/// 解固定值寒毒
	/// </summary>
	DetoxPoisonColdValue,
	/// <summary>
	/// 解固定值赤毒
	/// </summary>
	DetoxPoisonRedValue,
	/// <summary>
	/// 解固定值腐毒
	/// </summary>
	DetoxPoisonRottenValue,
	/// <summary>
	/// 解固定值幻毒
	/// </summary>
	DetoxPoisonIllusoryValue,
	/// <summary>
	/// 固定值烈毒
	/// </summary>
	ApplyPoisonHotValue,
	/// <summary>
	/// 固定值郁毒
	/// </summary>
	ApplyPoisonGloomyValue,
	/// <summary>
	/// 固定值寒毒
	/// </summary>
	ApplyPoisonColdValue,
	/// <summary>
	/// 固定值赤毒
	/// </summary>
	ApplyPoisonRedValue,
	/// <summary>
	/// 固定值腐毒
	/// </summary>
	ApplyPoisonRottenValue,
	/// <summary>
	/// 固定值幻毒
	/// </summary>
	ApplyPoisonIllusoryValue,
	/// <summary>
	/// 恢复百分比健康
	/// </summary>
	RecoverHealthPercentage,
	/// <summary>
	/// 调理百分比内息
	/// </summary>
	ChangeDisorderOfQiPercentage,
	/// <summary>
	/// 解百分比烈毒
	/// </summary>
	DetoxPoisonHotPercentage,
	/// <summary>
	/// 解百分比郁毒
	/// </summary>
	DetoxPoisonGloomyPercentage,
	/// <summary>
	/// 解百分比寒毒
	/// </summary>
	DetoxPoisonColdPercentage,
	/// <summary>
	/// 解百分比赤毒
	/// </summary>
	DetoxPoisonRedPercentage,
	/// <summary>
	/// 解百分比腐毒
	/// </summary>
	DetoxPoisonRottenPercentage,
	/// <summary>
	/// 解百分比幻毒
	/// </summary>
	DetoxPoisonIllusoryPercentage,
	/// <summary>
	/// 增加固定值属性
	/// </summary>
	PropertyAddValue,
	/// <summary>
	/// 增加百分比属性
	/// </summary>
	PropertyAddPercentage,
	Count
}
