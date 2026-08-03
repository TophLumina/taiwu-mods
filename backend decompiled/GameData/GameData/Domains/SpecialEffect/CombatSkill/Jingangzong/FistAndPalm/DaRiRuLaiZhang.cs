using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.FistAndPalm;

public class DaRiRuLaiZhang : CombatSkillEffectBase
{
	private const sbyte StateAddPercent = 100;

	private const sbyte StateReducePercent = -50;

	public DaRiRuLaiZhang()
	{
	}

	public DaRiRuLaiZhang(CombatSkillKey skillKey)
		: base(skillKey, 11107, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
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
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (base.IsDirect)
			{
				AppendAffectedData(context, base.CharacterId, 155, EDataModifyType.TotalPercent, -1);
			}
			else
			{
				AppendAffectedAllEnemyData(context, 155, EDataModifyType.TotalPercent, -1);
			}
			InvalidateCombatStateCache(context);
			ShowSpecialEffectTips(0);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
			InvalidateCombatStateCache(context);
		}
	}

	private void InvalidateCombatStateCache(DataContext context)
	{
		if (base.IsDirect)
		{
			DomainManager.Combat.InvalidateCombatStateCache(context, base.CombatChar, 1);
			DomainManager.Combat.InvalidateCombatStateCache(context, base.CombatChar, 2);
			return;
		}
		int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		for (int i = 0; i < charList.Length; i++)
		{
			if (charList[i] >= 0)
			{
				CombatCharacter enemyChar = DomainManager.Combat.GetElement_CombatCharacterDict(charList[i]);
				DomainManager.Combat.InvalidateCombatStateCache(context, enemyChar, 1);
				DomainManager.Combat.InvalidateCombatStateCache(context, enemyChar, 2);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 155)
		{
			return (dataKey.CharId != base.CharacterId) ? ((dataKey.CustomParam0 == 1) ? (-50) : 100) : ((dataKey.CustomParam0 == 1) ? 100 : (-50));
		}
		return 0;
	}
}
