using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Music;

public class GuangHanGe : CombatSkillEffectBase
{
	private const sbyte AddPower = 40;

	private const sbyte AddTrickOrMarkCount = 3;

	private const int NeiliAllocationPercent = 20;

	public GuangHanGe()
	{
	}

	public GuangHanGe(CombatSkillKey skillKey)
		: base(skillKey, 8306, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatDomain combatDomain = DomainManager.Combat;
		bool selfAnyTeammate = combatDomain.AnyTeammateChar(base.CombatChar.IsAlly);
		bool enemyAnyTeammate = combatDomain.AnyTeammateChar(!base.CombatChar.IsAlly);
		bool addPower = (base.IsDirect ? (!enemyAnyTeammate) : (!selfAnyTeammate));
		bool addNeiliAllocation = ((!base.IsDirect) ? (selfAnyTeammate && !enemyAnyTeammate) : (enemyAnyTeammate && !selfAnyTeammate));
		if (addPower)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
			ShowSpecialEffectTips(0);
		}
		if (addNeiliAllocation)
		{
			CombatCharacter targetChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
			int[] characterList = combatDomain.GetCharacterList(base.IsDirect ? (!base.CombatChar.IsAlly) : base.CombatChar.IsAlly);
			List<int> teammateCharIds = ObjectPool<List<int>>.Instance.Get();
			for (int i = 1; i < characterList.Length; i++)
			{
				if (characterList[i] >= 0)
				{
					teammateCharIds.Add(characterList[i]);
				}
			}
			int teammateCharId = teammateCharIds.GetRandom(context.Random);
			CombatCharacter teammateChar = combatDomain.GetElement_CombatCharacterDict(teammateCharId);
			ObjectPool<List<int>>.Instance.Return(teammateCharIds);
			NeiliAllocation teammateNeiliAllocation = teammateChar.GetNeiliAllocation();
			for (byte type = 0; type < 4; type++)
			{
				int addValue = teammateNeiliAllocation[type] * 20 / 100;
				if (addValue > 0)
				{
					targetChar.ChangeNeiliAllocation(context, type, base.IsDirect ? addValue : (-addValue));
				}
			}
			ShowSpecialEffectTips(2);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.AddTrick(context, base.CurrEnemyChar, 20, 3, addedByAlly: false);
			}
			else
			{
				AddPowerDamageMind(context, base.CurrEnemyChar);
			}
			ShowSpecialEffectTips(1);
		}
		RemoveSelf(context);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 40;
		}
		return 0;
	}
}
