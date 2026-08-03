using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Finger;

public class ChiShuShi : CombatSkillEffectBase
{
	private const sbyte ChangePowerUnit = 20;

	private readonly Dictionary<CombatSkillKey, int> _changePowerDict = new Dictionary<CombatSkillKey, int>();

	public ChiShuShi()
	{
	}

	public ChiShuShi(CombatSkillKey skillKey)
		: base(skillKey, 7103, -1)
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
		if (interrupted || Config.CombatSkill.Instance[skillId].EquipType != 1)
		{
			return;
		}
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillId);
		bool num;
		if (base.EffectCount > 0)
		{
			if (!base.IsDirect)
			{
				if (isAlly != base.CombatChar.IsAlly)
				{
					num = PowerMatchAffectRequire(power, 1);
					goto IL_007a;
				}
			}
			else if (charId == base.CharacterId)
			{
				num = !PowerMatchAffectRequire(power, 1);
				goto IL_007a;
			}
		}
		goto IL_0133;
		IL_0133:
		bool num2;
		if (_changePowerDict.ContainsKey(skillKey))
		{
			if (!base.IsDirect)
			{
				if (isAlly != base.CombatChar.IsAlly)
				{
					num2 = !PowerMatchAffectRequire(power, 1);
					goto IL_0180;
				}
			}
			else if (charId == base.CharacterId)
			{
				num2 = PowerMatchAffectRequire(power, 1);
				goto IL_0180;
			}
		}
		goto IL_01a7;
		IL_007a:
		if (num)
		{
			int changePower = (base.IsDirect ? 20 : (-20));
			if (_changePowerDict.ContainsKey(skillKey))
			{
				_changePowerDict[skillKey] += changePower;
			}
			else
			{
				_changePowerDict.Add(skillKey, changePower);
			}
			if (AffectDatas != null && AffectDatas.ContainsKey(new AffectedDataKey(charId, 199, -1)))
			{
				DomainManager.SpecialEffect.InvalidateCache(context, charId, 199);
			}
			else
			{
				AppendAffectedData(context, charId, 199, EDataModifyType.AddPercent, -1);
			}
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
		}
		goto IL_0133;
		IL_01a7:
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
		return;
		IL_0180:
		if (num2)
		{
			_changePowerDict.Remove(skillKey);
			DomainManager.SpecialEffect.InvalidateCache(context, charId, 199);
		}
		goto IL_01a7;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		CombatSkillKey skillKey = new CombatSkillKey(dataKey.CharId, dataKey.CombatSkillId);
		if (dataKey.FieldId == 199 && _changePowerDict.ContainsKey(skillKey))
		{
			return _changePowerDict[skillKey];
		}
		return 0;
	}
}
