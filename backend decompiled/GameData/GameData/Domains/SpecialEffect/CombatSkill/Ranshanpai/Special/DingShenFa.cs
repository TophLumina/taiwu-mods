using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Special;

public class DingShenFa : CurseSilenceCombatSkill
{
	private const int ReduceDamagePercent = -40;

	private readonly HashSet<CombatSkillKey> _reducingSkillKeys = new HashSet<CombatSkillKey>();

	protected override sbyte TargetEquipType => 1;

	public DingShenFa()
	{
	}

	public DingShenFa(CombatSkillKey skillKey)
		: base(skillKey, 7301)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedAllEnemyData(69, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillId);
		_reducingSkillKeys.Remove(skillKey);
	}

	protected override void OnSilenceBegin(DataContext context, CombatSkillKey skillKey)
	{
		_reducingSkillKeys.Add(skillKey);
	}

	protected override void OnSilenceEnd(DataContext context, CombatSkillKey skillKey)
	{
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = ((fieldId != 69 || !_reducingSkillKeys.Contains(dataKey.SkillKey)) ? base.GetModifyValue(dataKey, currModifyValue) : (-40));
		if (1 == 0)
		{
		}
		return result;
	}
}
