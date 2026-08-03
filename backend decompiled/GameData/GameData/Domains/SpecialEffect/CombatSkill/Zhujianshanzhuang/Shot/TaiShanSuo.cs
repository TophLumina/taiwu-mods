using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Shot;

public class TaiShanSuo : CombatSkillEffectBase
{
	private const sbyte AddAcupointLevel = 1;

	private readonly sbyte[] _directBodyParts = new sbyte[2] { 5, 6 };

	private readonly sbyte[] _reverseBodyParts = new sbyte[2] { 3, 4 };

	public TaiShanSuo()
	{
	}

	public TaiShanSuo(CombatSkillKey skillKey)
		: base(skillKey, 9405, -1)
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
		byte trickCount = base.CombatChar.GetTrickCount(12);
		if (PowerMatchAffectRequire(power) && trickCount > 0)
		{
			CombatCharacter enemyChar = base.CurrEnemyChar;
			List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
			sbyte[] affectParts = (base.IsDirect ? _directBodyParts : _reverseBodyParts);
			byte[] acupointCounts = enemyChar.GetAcupointCount();
			int maxCount = enemyChar.GetMaxAcupointCount();
			bodyPartRandomPool.Clear();
			foreach (sbyte bodyPart in affectParts)
			{
				int canAddCount = maxCount - acupointCounts[bodyPart];
				for (int j = 0; j < canAddCount; j++)
				{
					bodyPartRandomPool.Add(bodyPart);
				}
			}
			if (bodyPartRandomPool.Count > 0)
			{
				int addCount = Math.Min(trickCount, bodyPartRandomPool.Count);
				int keepFrames = GlobalConfig.Instance.FlawBaseKeepTime[1];
				for (int k = 0; k < addCount; k++)
				{
					sbyte bodyPart2 = bodyPartRandomPool[context.Random.Next(0, bodyPartRandomPool.Count)];
					bodyPartRandomPool.Remove(bodyPart2);
					enemyChar.AddOrUpdateFlawOrAcupoint(context, bodyPart2, isFlaw: false, 1, raiseEvent: true, keepFrames, keepFrames);
				}
				DomainManager.Combat.AddToCheckFallenSet(enemyChar.GetId());
			}
			DomainManager.Combat.RemoveTrick(context, base.CombatChar, 12, trickCount);
			ShowSpecialEffectTips(0);
			ObjectPool<List<sbyte>>.Instance.Return(bodyPartRandomPool);
		}
		RemoveSelf(context);
	}
}
