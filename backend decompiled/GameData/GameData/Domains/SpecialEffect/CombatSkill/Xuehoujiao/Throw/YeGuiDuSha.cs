using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Throw;

public class YeGuiDuSha : CombatSkillEffectBase
{
	private const sbyte ChangeTrickCount = 2;

	public YeGuiDuSha()
	{
	}

	public YeGuiDuSha(CombatSkillKey skillKey)
		: base(skillKey, 15400, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
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
			CombatCharacter trickChar = (base.IsDirect ? base.CombatChar : DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
			TrickCollection tricks = trickChar.GetTricks();
			IReadOnlyDictionary<int, sbyte> trickDict = tricks.Tricks;
			List<int> indexRandomPool = ObjectPool<List<int>>.Instance.Get();
			indexRandomPool.Clear();
			foreach (KeyValuePair<int, sbyte> trickEntry in trickDict)
			{
				if (base.IsDirect == trickChar.IsTrickUseless(trickEntry.Value))
				{
					indexRandomPool.Add(trickEntry.Key);
				}
			}
			while (indexRandomPool.Count > 2)
			{
				indexRandomPool.RemoveAt(context.Random.Next(0, indexRandomPool.Count));
			}
			if (indexRandomPool.Count > 0)
			{
				for (int i = 0; i < indexRandomPool.Count; i++)
				{
					tricks.ReplaceTrick(indexRandomPool[i], 14);
				}
				trickChar.SetTricks(tricks, context);
				ShowSpecialEffectTips(0);
			}
			ObjectPool<List<int>>.Instance.Return(indexRandomPool);
		}
		RemoveSelf(context);
	}
}
