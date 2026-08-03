using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Throw;

public class JinChanWuDuSha : CombatSkillEffectBase
{
	private const int PropertyReducePercent = 20;

	private int _reduceProperty;

	public JinChanWuDuSha()
	{
	}

	public JinChanWuDuSha(CombatSkillKey skillKey)
		: base(skillKey, 15404, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			OuterAndInnerInts penetrations = base.CurrEnemyChar.GetCharacter().GetPenetrations();
			_reduceProperty = -(base.IsDirect ? penetrations.Outer : penetrations.Inner) * 20 / 100;
			AppendAffectedData(context, base.CurrEnemyChar.GetId(), (ushort)(base.IsDirect ? 46 : 47), EDataModifyType.Add, -1);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CurrEnemyChar.GetId())
		{
			return 0;
		}
		if (dataKey.FieldId == (base.IsDirect ? 46 : 47))
		{
			return _reduceProperty;
		}
		return 0;
	}
}
