using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Special;

public class RuYiBaoShuChu : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 10;

	private static readonly CValuePercent StatePowerChangePercent = 75;

	private int _addPower;

	public RuYiBaoShuChu()
	{
	}

	public RuYiBaoShuChu(CombatSkillKey skillKey)
		: base(skillKey, 11306, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		SkillEffectKey effectKey = DomainManager.Combat.GetUsingWeaponData(base.CombatChar).GetPestleEffect();
		_addPower = ((effectKey.SkillId >= 0) ? (10 * (Config.CombatSkill.Instance[effectKey.SkillId].Grade + 1)) : 0);
		if (_addPower > 0)
		{
			ShowSpecialEffectTips(0);
		}
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
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
		if (!interrupted)
		{
			if (PowerMatchAffectRequire(power))
			{
				sbyte stateType = (sbyte)(base.IsDirect ? 1 : 2);
				CombatStateCollection stateCollection = base.CombatChar.GetCombatStateCollection(stateType);
				if (stateCollection.StateDict.Count > 0)
				{
					List<short> stateIdList = ObjectPool<List<short>>.Instance.Get();
					stateIdList.Clear();
					stateIdList.AddRange(stateCollection.StateDict.Keys);
					for (int i = 0; i < stateIdList.Count; i++)
					{
						short stateId = stateIdList[i];
						int changePower = stateCollection.StateDict[stateId].power * StatePowerChangePercent;
						if (changePower > 0)
						{
							DomainManager.Combat.AddCombatState(context, base.CombatChar, stateType, stateId, base.IsDirect ? changePower : (-changePower), reverse: false, applyEffect: false);
						}
					}
					ObjectPool<List<short>>.Instance.Return(stateIdList);
					ShowSpecialEffectTips(1);
				}
			}
			DomainManager.Combat.GetUsingWeaponData(base.CombatChar).RemovePestleEffect(context);
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
