using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Sword;

public class FuMuCongZiJian : CombatSkillEffectBase
{
	private const int BounceAddPercent = 200;

	private const int FightBackAddPercent = 50;

	private int _waitingNormalAttackCharId;

	public FuMuCongZiJian()
	{
	}

	public FuMuCongZiJian(CombatSkillKey skillKey)
		: base(skillKey, 7204, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_waitingNormalAttackCharId = -1;
		CreateAffectedAllEnemyData((ushort)(base.IsDirect ? 103 : 104), EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker.GetId() == _waitingNormalAttackCharId)
		{
			_waitingNormalAttackCharId = -1;
		}
		if (attacker.GetId() == base.CharacterId && !attacker.GetIsFightBack())
		{
			TryInvokeEnemyAttack();
		}
	}

	private void TryInvokeEnemyAttack()
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		if (base.EffectCount > 0 && !DomainManager.Combat.IsCharacterFallen(enemyChar) && _waitingNormalAttackCharId < 0)
		{
			if (enemyChar.StateMachine.GetCurrentStateType() != CombatCharacterStateType.PrepareAttack)
			{
				enemyChar.NormalAttackFree();
			}
			_waitingNormalAttackCharId = enemyChar.GetId();
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != _waitingNormalAttackCharId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			103 => 200, 
			104 => 50, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
