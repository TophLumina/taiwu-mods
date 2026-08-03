using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Blade;

public class LongYaSiZhan : CombatSkillEffectBase
{
	private const sbyte AddDamageUnit = 10;

	private CombatSkillItem Defend => Config.CombatSkill.Instance[base.CurrEnemyChar.GetAffectingDefendSkillId()];

	private int AddDamagePercent => (Defend != null) ? (10 * (Defend.Grade + 1)) : 0;

	public LongYaSiZhan()
	{
	}

	public LongYaSiZhan(CombatSkillKey skillKey)
		: base(skillKey, 14202, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(69, EDataModifyType.AddPercent, base.SkillTemplateId);
		CreateAffectedAllEnemyData(284, EDataModifyType.Custom, -1);
		if (base.EnemyChar.GetAffectingDefendSkillId() < 0)
		{
			TryCastDefend(context);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			RemoveSelf(context);
		}
	}

	private void TryCastDefend(DataContext context)
	{
		CombatCharacter enemyChar = base.EnemyChar;
		int enemyCharId = enemyChar.GetId();
		List<short> skillRandomPool = ObjectPool<List<short>>.Instance.Get();
		skillRandomPool.Clear();
		skillRandomPool.AddRange(from id in enemyChar.GetDefenceSkillList()
			where DomainManager.Combat.TryGetCombatSkillData(enemyCharId, id, out var combatSkillData) && combatSkillData.GetCanUse()
			select id);
		if (skillRandomPool.Count > 0)
		{
			short skillId = skillRandomPool.GetRandom(context.Random);
			DomainManager.Combat.StartPrepareSkill(context, skillId, enemyChar.IsAlly);
			ShowSpecialEffectTips(0);
		}
		ObjectPool<List<short>>.Instance.Return(skillRandomPool);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 69 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			return AddDamagePercent;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		bool result = fieldId != 284 && dataValue;
		if (1 == 0)
		{
		}
		return result;
	}
}
