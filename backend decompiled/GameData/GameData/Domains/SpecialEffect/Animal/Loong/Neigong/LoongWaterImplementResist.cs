using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongWaterImplementResist : ISpecialEffectImplement, ISpecialEffectModifier
{
	private const int ReducePoisonResist = -50;

	public CombatSkillEffectBase EffectBase { get; set; }

	public void OnEnable(DataContext context)
	{
		EffectBase.CreateAffectedAllEnemyData(245, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsMainCharacter(EffectBase.CombatChar))
		{
			EffectBase.ShowSpecialEffectTips(1);
		}
	}

	public int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == EffectBase.CharacterId || dataKey.FieldId != 245)
		{
			return 0;
		}
		return DomainManager.Combat.IsMainCharacter(EffectBase.CombatChar) ? (-50) : 0;
	}
}
