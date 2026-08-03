using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Finger;

public class BaiHuaSha : CombatSkillEffectBase
{
	private List<sbyte> _bodyPartList;

	public BaiHuaSha()
	{
	}

	public BaiHuaSha(CombatSkillKey skillKey)
		: base(skillKey, 3107, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		if (_bodyPartList != null)
		{
			ObjectPool<List<sbyte>>.Instance.Return(_bodyPartList);
		}
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		SortedDictionary<sbyte, List<FlawOrAcupointEntry>> bodyPartDict = (base.IsDirect ? base.CurrEnemyChar.GetAcupointCollection() : base.CurrEnemyChar.GetFlawCollection()).BodyPartDict;
		_bodyPartList = ObjectPool<List<sbyte>>.Instance.Get();
		_bodyPartList.Clear();
		for (sbyte type = 0; type < 7; type++)
		{
			if (bodyPartDict[type].Count > 0)
			{
				_bodyPartList.Add(type);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			Injuries injuries = base.CurrEnemyChar.GetInjuries();
			int innerOdds = base.SkillInstance.GetCurrInnerRatio();
			bool anyInjuryAdded = false;
			foreach (sbyte type in _bodyPartList)
			{
				(sbyte, sbyte) injury = injuries.Get(type);
				if (injury.Item1 < 6 || injury.Item2 < 6)
				{
					bool inner = injury.Item1 >= 6 || (injury.Item2 < 6 && context.Random.CheckPercentProb(innerOdds));
					base.CurrEnemyChar.AddInjury(context, type, inner, 1, updateDefeatMark: false, changeToOld: true);
					anyInjuryAdded = true;
				}
			}
			if (anyInjuryAdded)
			{
				DomainManager.Combat.UpdateBodyDefeatMark(context, base.CurrEnemyChar);
				ShowSpecialEffectTips(0);
			}
		}
		RemoveSelf(context);
	}
}
