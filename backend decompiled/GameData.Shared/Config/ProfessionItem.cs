using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ProfessionItem : ConfigItem<ProfessionItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 志向名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 志向描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 志向立绘大
	/// </summary>
	public readonly string TextureBig;

	/// <summary>
	/// 志向立绘中
	/// </summary>
	public readonly string Texture;

	/// <summary>
	/// 志向立绘小
	/// </summary>
	public readonly string TextureSmall;

	/// <summary>
	/// 志向名称贴图
	/// </summary>
	public readonly string NameSprite;

	/// <summary>
	/// 志向技能
	/// </summary>
	public readonly int[] ProfessionSkills;

	/// <summary>
	/// 额外志向技能
	/// - 僧道专属
	/// </summary>
	public readonly int ExtraProfessionSkill;

	/// <summary>
	/// 志向加成技艺
	/// </summary>
	public readonly List<sbyte> BonusLifeSkills;

	/// <summary>
	/// 志向加成武学
	/// </summary>
	public readonly List<sbyte> BonusCombatSkills;

	/// <summary>
	/// 志向加成衣装
	/// </summary>
	public readonly short BonusClothing;

	/// <summary>
	/// 相斥志向
	/// - 切换志向时额外增加冷却时间
	/// </summary>
	public readonly List<int> ConflictingProfessions;

	/// <summary>
	/// 相合志向
	/// - 切换志向时额外减少冷却时间
	/// </summary>
	public readonly List<int> CompatibleProfessions;

	/// <summary>
	/// 是否禁酒
	/// </summary>
	public readonly bool ForbidWine;

	/// <summary>
	/// 是否禁肉
	/// </summary>
	public readonly bool ForbidMeat;

	/// <summary>
	/// 是否禁婚
	/// </summary>
	public readonly bool ForbidSex;

	/// <summary>
	/// 梦回重新初始化技能
	/// - 梦回后调用Initialize接口
	/// </summary>
	public readonly bool ReinitOnCrossArchive;

	/// <summary>
	/// 资历获取tips
	/// </summary>
	public readonly string[] SeniorityGainTips;

	/// <summary>
	/// 资历获取tips绑定的dlc
	/// - 每个tips绑定哪个dlc，如没有就写0，必须保持长度一致。
	/// </summary>
	public readonly uint[] SeniorityGainTipsDlcId;

	/// <summary>
	/// 9到1品级Npc每月增长资历
	/// </summary>
	public readonly int[] ProfessionSeniorityPerMonth;

	/// <summary>
	/// 请教资历事件文本
	/// </summary>
	public readonly string DemandTeachingText;

	/// <summary>
	/// 请教资历完成事件文本
	/// </summary>
	public readonly string DemandTeachingFinishText;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">志向名称</param>
	/// <param name="desc">志向描述</param>
	/// <param name="textureBig">志向立绘大</param>
	/// <param name="texture">志向立绘中</param>
	/// <param name="textureSmall">志向立绘小</param>
	/// <param name="nameSprite">志向名称贴图</param>
	/// <param name="professionSkills">志向技能</param>
	/// <param name="extraProfessionSkill">额外志向技能 - 僧道专属</param>
	/// <param name="bonusLifeSkills">志向加成技艺</param>
	/// <param name="bonusCombatSkills">志向加成武学</param>
	/// <param name="bonusClothing">志向加成衣装</param>
	/// <param name="conflictingProfessions">相斥志向 - 切换志向时额外增加冷却时间</param>
	/// <param name="compatibleProfessions">相合志向 - 切换志向时额外减少冷却时间</param>
	/// <param name="forbidWine">是否禁酒</param>
	/// <param name="forbidMeat">是否禁肉</param>
	/// <param name="forbidSex">是否禁婚</param>
	/// <param name="reinitOnCrossArchive">梦回重新初始化技能 - 梦回后调用Initialize接口</param>
	/// <param name="seniorityGainTips">资历获取tips</param>
	/// <param name="seniorityGainTipsDlcId">资历获取tips绑定的dlc - 每个tips绑定哪个dlc，如没有就写0，必须保持长度一致。</param>
	/// <param name="professionSeniorityPerMonth">9到1品级Npc每月增长资历</param>
	/// <param name="demandTeachingText">请教资历事件文本</param>
	/// <param name="demandTeachingFinishText">请教资历完成事件文本</param>
	public ProfessionItem(int templateId, string name, string desc, string textureBig, string texture, string textureSmall, string nameSprite, int[] professionSkills, int extraProfessionSkill, List<sbyte> bonusLifeSkills, List<sbyte> bonusCombatSkills, short bonusClothing, List<int> conflictingProfessions, List<int> compatibleProfessions, bool forbidWine, bool forbidMeat, bool forbidSex, bool reinitOnCrossArchive, string[] seniorityGainTips, uint[] seniorityGainTipsDlcId, int[] professionSeniorityPerMonth, string demandTeachingText, string demandTeachingFinishText)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		TextureBig = textureBig;
		Texture = texture;
		TextureSmall = textureSmall;
		NameSprite = nameSprite;
		ProfessionSkills = professionSkills;
		ExtraProfessionSkill = extraProfessionSkill;
		BonusLifeSkills = bonusLifeSkills;
		BonusCombatSkills = bonusCombatSkills;
		BonusClothing = bonusClothing;
		ConflictingProfessions = conflictingProfessions;
		CompatibleProfessions = compatibleProfessions;
		ForbidWine = forbidWine;
		ForbidMeat = forbidMeat;
		ForbidSex = forbidSex;
		ReinitOnCrossArchive = reinitOnCrossArchive;
		SeniorityGainTips = seniorityGainTips;
		SeniorityGainTipsDlcId = seniorityGainTipsDlcId;
		ProfessionSeniorityPerMonth = professionSeniorityPerMonth;
		DemandTeachingText = demandTeachingText;
		DemandTeachingFinishText = demandTeachingFinishText;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ProfessionItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		TextureBig = null;
		Texture = null;
		TextureSmall = null;
		NameSprite = null;
		ProfessionSkills = new int[0];
		ExtraProfessionSkill = 0;
		BonusLifeSkills = new List<sbyte>();
		BonusCombatSkills = new List<sbyte>();
		BonusClothing = 0;
		ConflictingProfessions = new List<int>();
		CompatibleProfessions = new List<int>();
		ForbidWine = false;
		ForbidMeat = false;
		ForbidSex = false;
		ReinitOnCrossArchive = true;
		SeniorityGainTips = new string[0];
		SeniorityGainTipsDlcId = new uint[0];
		ProfessionSeniorityPerMonth = null;
		DemandTeachingText = null;
		DemandTeachingFinishText = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ProfessionItem(int templateId, ProfessionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		TextureBig = other.TextureBig;
		Texture = other.Texture;
		TextureSmall = other.TextureSmall;
		NameSprite = other.NameSprite;
		ProfessionSkills = other.ProfessionSkills;
		ExtraProfessionSkill = other.ExtraProfessionSkill;
		BonusLifeSkills = other.BonusLifeSkills;
		BonusCombatSkills = other.BonusCombatSkills;
		BonusClothing = other.BonusClothing;
		ConflictingProfessions = other.ConflictingProfessions;
		CompatibleProfessions = other.CompatibleProfessions;
		ForbidWine = other.ForbidWine;
		ForbidMeat = other.ForbidMeat;
		ForbidSex = other.ForbidSex;
		ReinitOnCrossArchive = other.ReinitOnCrossArchive;
		SeniorityGainTips = other.SeniorityGainTips;
		SeniorityGainTipsDlcId = other.SeniorityGainTipsDlcId;
		ProfessionSeniorityPerMonth = other.ProfessionSeniorityPerMonth;
		DemandTeachingText = other.DemandTeachingText;
		DemandTeachingFinishText = other.DemandTeachingFinishText;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ProfessionItem Duplicate(int templateId)
	{
		return new ProfessionItem(templateId, this);
	}
}
