using System.Collections.Generic;
using System.Linq;

namespace GameData.Domains.Combat.Ai.Selector;

public class CombatSkillSelector
{
	private static readonly List<CombatSkillSelectorContext> ContextCache = new List<CombatSkillSelectorContext>();

	private readonly sbyte _equipType;

	private readonly CombatSkillSelectorPredicate _predicate;

	private readonly CombatSkillSelectorComparison _comparison;

	private AiMemoryNew _updatingMemory;

	private static bool IsValid(short skillId)
	{
		return skillId >= 0;
	}

	public CombatSkillSelector(sbyte equipType)
		: this(equipType, null, null)
	{
	}

	public CombatSkillSelector(sbyte equipType, CombatSkillSelectorPredicate predicate, CombatSkillSelectorComparison comparison)
	{
		_equipType = equipType;
		_predicate = predicate;
		_comparison = comparison;
	}

	private int Comparison(CombatSkillSelectorContext contextA, CombatSkillSelectorContext contextB)
	{
		EAiPriority priorityA = _updatingMemory.GetPriority(contextA.TemplateId);
		EAiPriority priorityB = _updatingMemory.GetPriority(contextB.TemplateId);
		if (priorityA != priorityB)
		{
			int num = (int)priorityA;
			return num.CompareTo((int)priorityB);
		}
		int result = _comparison?.Invoke(contextA, contextB) ?? 0;
		if (result != 0)
		{
			return result;
		}
		if (contextA.Template.Grade != contextB.Template.Grade)
		{
			return contextB.Template.Grade.CompareTo(contextA.Template.Grade);
		}
		return contextA.TemplateId.CompareTo(contextB.TemplateId);
	}

	private bool Predicate(CombatSkillSelectorContext context)
	{
		return _predicate?.Invoke(context) ?? true;
	}

	public short Select(AiMemoryNew memory, CombatCharacter combatChar)
	{
		_updatingMemory = memory;
		int charId = combatChar.GetId();
		IEnumerable<short> skillList = combatChar.GetCombatSkillList(_equipType).Where(IsValid);
		foreach (short filteringSkillId in skillList.Where(combatChar.AiCanCast))
		{
			CombatSkillSelectorContext context = new CombatSkillSelectorContext((charId: charId, skillId: filteringSkillId));
			if (Predicate(context))
			{
				ContextCache.Add(new CombatSkillSelectorContext((charId: combatChar.GetId(), skillId: filteringSkillId)));
			}
		}
		ContextCache.Sort(Comparison);
		short skillId = (short)((ContextCache.Count > 0) ? ContextCache[0].SkillKey.SkillTemplateId : (-1));
		ContextCache.Clear();
		_updatingMemory = null;
		return skillId;
	}
}
