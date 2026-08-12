using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public abstract class ReduceEnemyNeiliAllocation : CombatSkillEffectBase
{
	private const int ReduceValueAboveOrigin = 30;

	private const int ReduceValueBelowOrigin = 10;

	private const int StealValueAboveOrigin = 15;

	private const int StealValueBelowOrigin = 5;

	private bool EnemyBelowOrigin => base.CurrEnemyChar.GetNeiliAllocation()[AffectNeiliAllocationType] < base.CurrEnemyChar.GetOriginNeiliAllocation()[AffectNeiliAllocationType];

	private int DirectReduceValue => EnemyBelowOrigin ? 10 : 30;

	private int ReverseStealValue => EnemyBelowOrigin ? 5 : 15;

	protected abstract byte AffectNeiliAllocationType { get; }

	protected ReduceEnemyNeiliAllocation()
	{
	}

	protected ReduceEnemyNeiliAllocation(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			CombatCharacter enemyChar = base.CurrEnemyChar;
			int changeValue = (base.IsDirect ? DirectReduceValue : ReverseStealValue);
			if (base.IsDirect)
			{
				enemyChar.ChangeNeiliAllocation(context, AffectNeiliAllocationType, -changeValue);
			}
			else
			{
				base.CombatChar.AbsorbNeiliAllocation(context, enemyChar, AffectNeiliAllocationType, changeValue);
			}
			ShowSpecialEffectTips(0);
		}
		RemoveSelf(context);
	}
}
