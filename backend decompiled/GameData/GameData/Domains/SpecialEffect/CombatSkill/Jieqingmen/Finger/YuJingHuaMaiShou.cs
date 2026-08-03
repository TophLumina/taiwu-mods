using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Finger;

public class YuJingHuaMaiShou : CombatSkillEffectBase
{
	private const sbyte BaseNeiliAllocation = 3;

	private const sbyte ExtraNeiliAllocation = 3;

	private const sbyte ExtraCostNeiliAllocation = 3;

	public YuJingHuaMaiShou()
	{
	}

	public YuJingHuaMaiShou(CombatSkillKey skillKey)
		: base(skillKey, 13102, -1)
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
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				DoAffect(context);
			}
			RemoveSelf(context);
		}
	}

	private void DoAffect(DataContext context)
	{
		byte type = RandomNeiliAllocationType(context);
		if (type != byte.MaxValue && base.CombatChar.AbsorbNeiliAllocation(context, base.CurrEnemyChar, type, 3))
		{
			ShowSpecialEffectTips(0);
			NeiliAllocation selfNeiliAllocation = base.CombatChar.GetNeiliAllocation();
			NeiliAllocation enemyNeiliAllocation = base.CurrEnemyChar.GetNeiliAllocation();
			NeiliAllocation selfOriginNeiliAllocation = base.CombatChar.GetOriginNeiliAllocation();
			NeiliAllocation enemyOriginNeiliAllocation = base.CurrEnemyChar.GetOriginNeiliAllocation();
			bool selfLessOrigin = selfNeiliAllocation[type] < selfOriginNeiliAllocation[type];
			bool enemyMoreOrigin = enemyNeiliAllocation[type] > enemyOriginNeiliAllocation[type];
			if (!(base.IsDirect ? (!selfLessOrigin) : (!enemyMoreOrigin)))
			{
				base.CombatChar.AbsorbNeiliAllocation(context, base.CurrEnemyChar, type, 3);
				base.CurrEnemyChar.ChangeNeiliAllocation(context, type, -3);
				ShowSpecialEffectTips(1);
			}
		}
	}

	private byte RandomNeiliAllocationType(DataContext context)
	{
		NeiliAllocation selfNeiliAllocation = base.CombatChar.GetNeiliAllocation();
		NeiliAllocation enemyNeiliAllocation = base.CurrEnemyChar.GetNeiliAllocation();
		List<byte> pool = ObjectPool<List<byte>>.Instance.Get();
		short value = (short)(base.IsDirect ? short.MaxValue : 0);
		pool.Clear();
		for (byte type = 0; type < 4; type++)
		{
			if (base.IsDirect ? (selfNeiliAllocation[type] < value) : (enemyNeiliAllocation[type] > value))
			{
				pool.Clear();
				pool.Add(type);
				value = (base.IsDirect ? selfNeiliAllocation[type] : enemyNeiliAllocation[type]);
			}
			else if (base.IsDirect ? (selfNeiliAllocation[type] == value) : (enemyNeiliAllocation[type] == value))
			{
				pool.Add(type);
			}
		}
		byte neiliAllocationType = ((pool.Count > 0) ? pool[context.Random.Next(0, pool.Count)] : byte.MaxValue);
		ObjectPool<List<byte>>.Instance.Return(pool);
		return neiliAllocationType;
	}
}
