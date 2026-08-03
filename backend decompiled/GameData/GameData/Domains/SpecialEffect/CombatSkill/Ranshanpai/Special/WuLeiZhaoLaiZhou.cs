using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Special;

public class WuLeiZhaoLaiZhou : CombatSkillEffectBase
{
	private static bool IsTarget(ItemKey key)
	{
		bool flag = key.IsValid();
		bool flag2 = flag;
		if (flag2)
		{
			sbyte itemType = key.ItemType;
			bool flag3 = (uint)itemType <= 2u;
			flag2 = flag3;
		}
		return flag2 && ItemTemplateHelper.GetResourceType(key.ItemType, key.TemplateId) == 2;
	}

	public WuLeiZhaoLaiZhou()
	{
	}

	public WuLeiZhaoLaiZhou(CombatSkillKey skillKey)
		: base(skillKey, 7303, -1)
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

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
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
		ItemKey[] equipments = (base.IsDirect ? base.CurrEnemyChar.GetCharacter() : CharObj).GetEquipment();
		HashSet<sbyte> affectTypes = ObjectPool<HashSet<sbyte>>.Instance.Get();
		affectTypes.Clear();
		ItemKey[] array = equipments;
		for (int i = 0; i < array.Length; i++)
		{
			ItemKey key = array[i];
			if (IsTarget(key))
			{
				affectTypes.Add(key.ItemType);
			}
		}
		int injuryCount = affectTypes.Count;
		if (injuryCount > 0)
		{
			if (base.IsDirect)
			{
				AddPowerDamageFatal(context, base.CurrEnemyChar, injuryCount);
			}
			else
			{
				AddPowerDamageMind(context, base.CurrEnemyChar, injuryCount);
			}
			ShowSpecialEffectTips(0);
		}
		ObjectPool<HashSet<sbyte>>.Instance.Return(affectTypes);
	}
}
