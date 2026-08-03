using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.ZiWuXiao;

public class HuiWangQiJueZhi : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 30;

	private int _addPower;

	public HuiWangQiJueZhi()
	{
	}

	public HuiWangQiJueZhi(CombatSkillKey skillKey)
		: base(skillKey, 17114, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		SkillEffectKey effectKey = new SkillEffectKey(883, isDirect: true);
		Dictionary<SkillEffectKey, short> effectDict = base.CombatChar.GetSkillEffectCollection().EffectDict;
		_addPower = ((effectDict != null && effectDict.TryGetValue(effectKey, out var value)) ? (30 * value) : 0);
		if (_addPower > 0)
		{
			CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
			DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, effectKey, (short)(-effectDict[effectKey]));
			ShowSpecialEffectTips(0);
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
			SkillEffectKey effectKey = new SkillEffectKey(884, isDirect: true);
			Dictionary<SkillEffectKey, short> effectDict = base.CombatChar.GetSkillEffectCollection().EffectDict;
			if (effectDict != null && effectDict.ContainsKey(effectKey))
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, 887);
				ShowSpecialEffectTips(1);
			}
			else
			{
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
				IReadOnlyDictionary<int, sbyte> trickDict = enemyChar.GetTricks().Tricks;
				List<NeedTrick> removeTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
				removeTricks.Clear();
				foreach (sbyte trickType in trickDict.Values)
				{
					if (!enemyChar.IsTrickUseless(trickType))
					{
						removeTricks.Add(new NeedTrick(trickType, 1));
					}
				}
				DomainManager.Combat.RemoveTrick(context, enemyChar, removeTricks, removedByAlly: false);
				ObjectPool<List<NeedTrick>>.Instance.Return(removeTricks);
				ShowSpecialEffectTips(2);
			}
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
			return _addPower;
		}
		return 0;
	}
}
