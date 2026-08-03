using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Finger;

public class LiHeZhi : CombatSkillEffectBase
{
	private const int DirectBaseOdds = 10;

	private const int DirectExtraOdds = 5;

	private const int ReverseBaseOdds = 10;

	private const int ReverseExtraOdds = 5;

	private const int MaxExtraCount = 2;

	private IEnumerable<CombatCharacter> CurrChars
	{
		get
		{
			yield return DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			yield return base.CombatChar;
		}
	}

	public LiHeZhi()
	{
	}

	public LiHeZhi(CombatSkillKey skillKey)
		: base(skillKey, 7104, -1)
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
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			DoAffect(context);
			RemoveSelf(context);
		}
	}

	private void DoAffect(DataContext context)
	{
		int baseOdds = (base.IsDirect ? CalcDirectOdds() : CalcReverseOdds());
		if (!context.Random.CheckPercentProb(baseOdds))
		{
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		DomainManager.Combat.AddGoneMadInjury(context, enemyChar, base.SkillTemplateId);
		ShowSpecialEffectTips(0);
		int extraOdds = (base.IsDirect ? CalcDirectOdds(isExtra: true) : CalcReverseOdds(isExtra: true));
		if (!context.Random.CheckPercentProb(extraOdds))
		{
			return;
		}
		List<short> pool = ObjectPool<List<short>>.Instance.Get();
		pool.Clear();
		pool.AddRange(enemyChar.GetBannedSkillIds());
		foreach (short skillId in RandomUtils.GetRandomUnrepeated(context.Random, 2, pool))
		{
			DomainManager.Combat.AddGoneMadInjury(context, enemyChar, skillId);
		}
		if (pool.Count > 0)
		{
			ShowSpecialEffectTips(1);
		}
		ObjectPool<List<short>>.Instance.Return(pool);
	}

	private int CalcDirectOdds(bool isExtra = false)
	{
		return (from character in CurrChars
			let ratio = isExtra ? 5 : 10
			select character.GetTrickCount(20) * ratio).Sum();
	}

	private int CalcReverseOdds(bool isExtra = false)
	{
		return (from character in CurrChars
			let ratio = isExtra ? 5 : 10
			select (character.GetDefeatMarkCollection().MindMarkList?.Count ?? 0) * ratio).Sum();
	}
}
