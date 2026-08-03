using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.Map;
using GameData.Domains.Story.MainStory;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class QiXieDunFa : TwelveImmortalsBase
{
	private const int PoisonValue = 600;

	private const sbyte PoisonLevel = 3;

	private const int AddMixPoisonCanAffectCount = 200;

	public QiXieDunFa()
	{
	}

	public QiXieDunFa(CombatSkillKey skillKey)
		: base(skillKey, 18006)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		AppendAffectedData(context, 343, EDataModifyType.TotalPercent, -1);
		AppendAffectedAllEnemyData(context, 343, EDataModifyType.TotalPercent, -1);
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (!base.IsDirect || (attackerId != base.CharacterId && defenderId != base.CharacterId) || outerMarkCount + innerMarkCount <= 0)
		{
			return;
		}
		foreach (MapBlockData block in base.TwelveImmortalsConfig.GetImpactRangeBlocks(CharObj))
		{
			HashSet<int> fixedCharacterSet = block.FixedCharacterSet;
			if (fixedCharacterSet == null || fixedCharacterSet.Count <= 0)
			{
				continue;
			}
			foreach (int charId in block.FixedCharacterSet)
			{
				if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
				{
					short templateId = character.GetTemplateId();
					if (TwelveImmortalsConstants.JiaoCharacterToPoisonTypes.TryGetValue(templateId, out var poisonType))
					{
						DomainManager.Combat.AddPoison(context, base.CombatChar, base.EnemyChar, poisonType, 3, 600, -1);
						ShowSpecialEffectTipsOnceInFrame(0);
					}
				}
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if ((dataKey.CharId == base.CharacterId && base.IsDirect) || dataKey.FieldId != 343)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return 200;
	}
}
