using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Helper;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.TianDi;

public class DengShiKunShan : CombatSkillEffectBase, IHeavenlyEmperorHandler
{
	private const int SilenceFrame = 1800;

	private const int ChangeEffectCount = 3;

	private readonly HeavenlyEmperorHelper _handler;

	public DengShiKunShan()
	{
		_handler = new HeavenlyEmperorHelper(this);
	}

	public DengShiKunShan(CombatSkillKey skillKey)
		: base(skillKey, -1, -1)
	{
		_handler = new HeavenlyEmperorHelper(this);
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter _, short skillId)
	{
		if (!SkillKey.IsMatch(attacker.GetId(), skillId))
		{
			return;
		}
		int silenceSkillCount = _handler.MakeDamageEffectCount;
		CombatCharacter enemyChar = base.EnemyChar;
		for (int i = 0; i < silenceSkillCount; i++)
		{
			short banSkillId = enemyChar.GetRandomBanableSkillId(context.Random, null, -1);
			if (banSkillId < 0)
			{
				break;
			}
			DomainManager.Combat.SilenceSkill(context, enemyChar, banSkillId, 1800);
			ShowSpecialEffectTipsOnceInFrame(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool _, short skillId, sbyte power, bool interrupted)
	{
		if (!(!SkillKey.IsMatch(charId, skillId) || interrupted))
		{
			_handler.ChangeMakeDamageEffectCount(context, 3);
			ShowSpecialEffectTips(1);
		}
	}
}
