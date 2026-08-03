using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.FistAndPalm;

public class FengMoZuiQuan : CombatSkillEffectBase
{
	private const sbyte AutoCastBaseOdds = 30;

	private const sbyte DrunkAddAutoCastOdds = 60;

	private const sbyte AutoCastOddsReduce = 15;

	private const sbyte PrepareProgressPercent = 50;

	private int _autoCastOdds;

	private int _addDamage;

	private bool _autoCasting;

	public FengMoZuiQuan()
	{
	}

	public FengMoZuiQuan(CombatSkillKey skillKey)
		: base(skillKey, 14103, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _autoCasting)
		{
			_addDamage = base.CombatChar.GetCharacter().GetDisorderOfQi() / 100;
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power) && !interrupted)
			{
				TryAutoCast(context);
				return;
			}
			_addDamage = 0;
			_autoCasting = false;
		}
	}

	private void TryAutoCast(DataContext context)
	{
		if (_autoCasting)
		{
			_autoCastOdds -= 15;
			if (context.Random.CheckPercentProb(_autoCastOdds) && DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true))
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(0);
			}
			else
			{
				_addDamage = 0;
				_autoCasting = false;
			}
		}
		else
		{
			_autoCastOdds = 30 + (CharObj.GetEatingItems().ContainsWine() ? 60 : 0);
			if (context.Random.CheckPercentProb(_autoCastOdds) && DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true))
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				_autoCasting = true;
				ShowSpecialEffectTips(0);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 69 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			return _addDamage;
		}
		return 0;
	}
}
