using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Sword;

public class JueYiJian : CombatSkillEffectBase
{
	private const int AddShaCount = 9;

	private const int ChangeFavorabilityValue = -10000;

	private static readonly short[] AddDamage = new short[4] { 20, 40, 80, 160 };

	private bool _affected;

	private int _addDamage;

	public JueYiJian()
	{
	}

	public JueYiJian(CombatSkillKey skillKey)
		: base(skillKey, 13201, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		short favor = DomainManager.Character.GetFavorability(base.CurrEnemyChar.GetId(), base.CharacterId);
		sbyte favorType = FavorabilityType.GetFavorabilityType(favor);
		if (favorType >= 3)
		{
			_addDamage = AddDamage[favorType - 3];
			AppendAffectedData(context, 69, EDataModifyType.AddPercent, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
			if (favorType >= 4)
			{
				_affected = true;
				DomainManager.Combat.AddTrick(context, base.IsDirect ? base.CombatChar : base.EnemyChar, 19, 9, base.IsDirect);
				ShowSpecialEffectTips(1);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (_affected)
			{
				_affected = false;
				MakeRelation(context);
				ChangeFavorability(context);
			}
			RemoveSelf(context);
		}
	}

	private void MakeRelation(DataContext context)
	{
		if (RelationTypeHelper.AllowAddingRelation(base.CurrEnemyChar.GetId(), base.CharacterId, 32768))
		{
			InformationDomain informationDomain = DomainManager.Information;
			DomainManager.Character.AddRelation(context, base.CurrEnemyChar.GetId(), base.CharacterId, 32768);
			SecretInformationId secretInformationMetaDataId = informationDomain.AddSecretInformation(context, informationDomain.GetSecretInformationCollection().AddBecomeEnemy(base.CharacterId, base.CurrEnemyChar.GetId()), withInitialDistribute: false);
			informationDomain.ReceiveSecretInformation(context, secretInformationMetaDataId, base.CharacterId);
			informationDomain.ReceiveSecretInformation(context, secretInformationMetaDataId, base.CurrEnemyChar.GetId());
			ShowSpecialEffectTips(2);
		}
	}

	private void ChangeFavorability(DataContext context)
	{
		GameData.Domains.Character.Character srcChar = base.CurrEnemyChar.GetCharacter();
		byte creatingType = srcChar.GetCreatingType();
		if ((uint)creatingType <= 1u)
		{
			GameData.Domains.Character.Character dstChar = base.CombatChar.GetCharacter();
			creatingType = dstChar.GetCreatingType();
			if ((uint)creatingType <= 1u)
			{
				DomainManager.Character.DirectlyChangeFavorabilityOptional(context, srcChar, dstChar, -10000, -1);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			return _addDamage;
		}
		return 0;
	}
}
