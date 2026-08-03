using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.DefenseAndAssist;

public class QiYuanJieEDaFa : DefenseSkillBase
{
	private const sbyte ReduceDamageUnit = -10;

	private const sbyte AddDamageUnit = 20;

	private const sbyte RequireEquipType = 1;

	private static readonly CValuePercent ChangeEffectCountPercent = 25;

	private bool _affectedDirect;

	private bool _affectedBounce;

	public QiYuanJieEDaFa()
	{
	}

	public QiYuanJieEDaFa(CombatSkillKey skillKey)
		: base(skillKey, 13506)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(102, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(70, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_BounceInjury(OnBounceInjury);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.RegisterHandler_AttackSkillAttackHit(OnAttackSkillAttackHit);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_BounceInjury(OnBounceInjury);
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.UnRegisterHandler_AttackSkillAttackHit(OnAttackSkillAttackHit);
		base.OnDisable(context);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (defender == base.CombatChar)
		{
			AutoShowAffectTips();
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.Defender == base.CombatChar)
		{
			AutoShowAffectTips();
		}
	}

	private void OnBounceInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount)
	{
		if (attackerId == base.CharacterId)
		{
			AutoShowAffectTips();
		}
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightback, bool isMind)
	{
		if (!(defender.GetId() != base.CharacterId || pursueIndex != 0 || !hit || isMind))
		{
			sbyte bodyPart = attacker.NormalAttackBodyPart;
			DoAffect(context, bodyPart);
		}
	}

	private void OnAttackSkillAttackHit(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId, int index, bool critical)
	{
		if (defender.GetId() == base.CharacterId)
		{
			sbyte bodyPart = attacker.SkillAttackBodyPart;
			DoAffect(context, bodyPart);
		}
	}

	private void AutoShowAffectTips()
	{
		if (_affectedDirect)
		{
			ShowSpecialEffectTips(0);
		}
		if (_affectedBounce)
		{
			ShowSpecialEffectTips(1);
		}
		_affectedDirect = (_affectedBounce = false);
	}

	private void DoAffect(DataContext context, sbyte bodyPart)
	{
		bool flag = ((bodyPart < 0 || bodyPart >= 7) ? true : false);
		if (!flag && base.CombatChar.HasBreakInjury(bodyPart))
		{
			CombatCharacter target = (base.IsDirect ? base.CombatChar : base.EnemyChar);
			CValuePercent percent = (base.IsDirect ? ChangeEffectCountPercent : (-ChangeEffectCountPercent));
			if (DomainManager.Combat.ChangeSkillEffectRandom(context, target, percent, 1, 1))
			{
				ShowSpecialEffectTips(2);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!base.CanAffect)
		{
			return 0;
		}
		int brokenPartCount = base.CombatChar.CalcBreakBodyPartCount();
		if (brokenPartCount == 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 102)
		{
			_affectedDirect = true;
			return -10 * brokenPartCount;
		}
		if (dataKey.FieldId == 70)
		{
			_affectedBounce = true;
			return 20 * brokenPartCount;
		}
		return 0;
	}
}
