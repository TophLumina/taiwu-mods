using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.WeiQi;

public class LongTunShi : CombatSkillEffectBase
{
	private const sbyte CostNeiliAllocation = 18;

	private DataUid _injuriesUid;

	public LongTunShi()
	{
	}

	public LongTunShi(CombatSkillKey skillKey)
		: base(skillKey, 17050, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		if (IsSrcSkillPerformed)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_injuriesUid, base.DataHandlerKey);
		}
	}

	private unsafe void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		NeiliAllocation neiliAllocation = enemyChar.GetNeiliAllocation();
		List<byte> typeRandomPool = ObjectPool<List<byte>>.Instance.Get();
		typeRandomPool.Clear();
		for (byte type = 0; type < 4; type++)
		{
			if (neiliAllocation.Items[(int)type] >= 18)
			{
				typeRandomPool.Add(type);
			}
		}
		if (!IsSrcSkillPerformed)
		{
			if (typeRandomPool.Count > 0 && PowerMatchAffectRequire(power))
			{
				byte type2 = typeRandomPool[context.Random.Next(typeRandomPool.Count)];
				enemyChar.ChangeNeiliAllocation(context, type2, -18);
				if (CheckAndHealInjury(context))
				{
					RemoveSelf(context);
				}
				else
				{
					IsSrcSkillPerformed = true;
					AddMaxEffectCount();
					_injuriesUid = new DataUid(8, 10, (ulong)base.CharacterId, 29u);
					GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_injuriesUid, base.DataHandlerKey, OnInjuriesChanged);
				}
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (typeRandomPool.Count > 0 && PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
		ObjectPool<List<byte>>.Instance.Return(typeRandomPool);
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	private void OnInjuriesChanged(DataContext context, DataUid dataUid)
	{
		if (CheckAndHealInjury(context))
		{
			ReduceEffectCount();
		}
	}

	private bool CheckAndHealInjury(DataContext context)
	{
		Injuries injuries = base.CombatChar.GetInjuries();
		List<sbyte> partRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		partRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			(sbyte, sbyte) injury = injuries.Get(part);
			if (injury.Item1 >= 6 || injury.Item2 >= 6)
			{
				partRandomPool.Add(part);
			}
		}
		bool affected = partRandomPool.Count > 0;
		if (affected)
		{
			sbyte part2 = partRandomPool[context.Random.Next(partRandomPool.Count)];
			(sbyte, sbyte) injury2 = injuries.Get(part2);
			if (injury2.Item1 > 0)
			{
				base.CombatChar.RemoveInjury(context, part2, inner: false, injury2.Item1);
			}
			if (injury2.Item2 > 0)
			{
				base.CombatChar.RemoveInjury(context, part2, inner: true, injury2.Item2);
			}
			ShowSpecialEffectTips(0);
		}
		ObjectPool<List<sbyte>>.Instance.Return(partRandomPool);
		return affected;
	}
}
