using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Helper;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.TianDi;

public class WanShiShenJu : CombatSkillEffectBase, IHeavenlyEmperorHandler
{
	private const int SilenceFrame = 600;

	private const sbyte PrepareProgressPercent = 100;

	private const int RequireEffectCount = 3;

	private readonly List<short> _waitPrepareSkillIds = new List<short>();

	private readonly HeavenlyEmperorHelper _helper;

	public WanShiShenJu()
	{
		_helper = new HeavenlyEmperorHelper(this);
	}

	public WanShiShenJu(CombatSkillKey skillKey)
		: base(skillKey, -1, -1)
	{
		_helper = new HeavenlyEmperorHelper(this);
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_waitPrepareSkillIds.Clear();
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!(!SkillKey.IsMatch(charId, skillId) || interrupted))
		{
			if (PowerMatchAffectRequire(power))
			{
				DoAffect(context);
			}
			DomainManager.Combat.SilenceSkill(context, base.CombatChar, skillId, 600, -1);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && _waitPrepareSkillIds.Remove(skillId))
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 100 / 100);
		}
	}

	private void DoAffect(DataContext context)
	{
		DoAffect(context, make: true);
		DoAffect(context, make: false);
	}

	private void DoAffect(DataContext context, bool make)
	{
		int effectCount = (make ? _helper.MakeDamageEffectCount : _helper.AcceptDamageEffectCount);
		if (effectCount <= 3)
		{
			if (make)
			{
				_helper.ChangeMakeDamageEffectCount(context, 3);
			}
			else
			{
				_helper.ChangeAcceptDamageEffectCount(context, 3);
			}
			ShowSpecialEffectTipsOnceInFrame(1);
			return;
		}
		short skillId = (short)(make ? 945 : 944);
		if (DomainManager.Combat.CanCastSkill(base.CombatChar, skillId, costFree: true))
		{
			_waitPrepareSkillIds.AddUnique(skillId);
			DomainManager.Combat.CastSkillFree(context, base.CombatChar, skillId);
			ShowSpecialEffectTipsOnceInFrame(0);
		}
	}
}
