using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class AddBreakBodyFeature : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 20;

	protected sbyte[] AffectBodyParts;

	private int _addPower;

	protected AddBreakBodyFeature()
	{
	}

	protected AddBreakBodyFeature(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		List<short> featureIds = base.CurrEnemyChar.GetCharacter().GetFeatureIds();
		foreach (short featureId in featureIds)
		{
			if ((base.IsDirect ? BreakFeatureHelper.AllCrashFeature : BreakFeatureHelper.AllHurtFeature).Exist(featureId))
			{
				_addPower += 20;
			}
		}
		if (_addPower > 0)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
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
		GameData.Domains.Character.Character enemyChar = base.CurrEnemyChar.GetCharacter();
		short featureId = (base.IsDirect ? BreakFeatureHelper.BodyPart2CrashFeature : BreakFeatureHelper.BodyPart2HurtFeature)[AffectBodyParts[0]];
		Injuries injuries = enemyChar.GetInjuries();
		bool hasAnyInjury = false;
		for (int i = 0; i < AffectBodyParts.Length; i++)
		{
			if (injuries.Get(AffectBodyParts[i], !base.IsDirect) > 0)
			{
				hasAnyInjury = true;
				break;
			}
		}
		if (PowerMatchAffectRequire(power) && hasAnyInjury && !enemyChar.GetFeatureIds().Contains(featureId))
		{
			enemyChar.AddFeature(context, featureId);
			DomainManager.SpecialEffect.Add(context, enemyChar.GetId(), SpecialEffectDomain.BreakBodyFeatureEffectClassName[featureId]);
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
			return _addPower;
		}
		return 0;
	}
}
