using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AnimalItem : ConfigItem<AnimalItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 对应人物列表
	/// </summary>
	public readonly short[] CharacterIdList;

	/// <summary>
	/// 资源包名
	/// - Asset文件名：该动物建模的动画资源的文件名
	/// </summary>
	public readonly string AssetFileName;

	/// <summary>
	/// 动画名前缀
	/// - 此动物建模动画资源的Unity内的动画前缀
	/// </summary>
	public readonly string AniPrefix;

	/// <summary>
	/// 普攻距离
	/// - 依次为第1~3把武器效果
	/// </summary>
	public readonly List<sbyte> AttackDistances;

	/// <summary>
	/// 普攻特效
	/// </summary>
	public readonly List<string> AttackParticles;

	/// <summary>
	/// 普攻音效
	/// </summary>
	public readonly List<string> AttackSounds;

	/// <summary>
	/// 招架音效
	/// </summary>
	public readonly string BlockSound;

	/// <summary>
	/// 蓄力移动特效
	/// </summary>
	public readonly List<string> JumpMoveParticles;

	/// <summary>
	/// 移动脚步音效
	/// - 此处为常规移动，非蓄力移动音效
	/// </summary>
	public readonly List<string> StepSound;

	/// <summary>
	/// 同道指令出场音效
	/// - 按顺序对应最多三个同道指令，相同动物的同道指令顺序必须完全相同
	/// </summary>
	public readonly List<string> TeammateCommandBackCharEnterSound;

	/// <summary>
	/// 捕获时的人物表现
	/// </summary>
	public readonly short CatchEffect;

	/// <summary>
	/// 捕获后获得的坐骑
	/// - Carrier表中的模板ID
	/// </summary>
	public readonly short CarrierId;

	/// <summary>
	/// 失败特效
	/// </summary>
	public readonly string FailParticle;

	/// <summary>
	/// 失败音效
	/// </summary>
	public readonly string FailSound;

	/// <summary>
	/// 是否精英
	/// - 用于特效效果判定
	/// </summary>
	public readonly bool IsElite;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="characterIdList">对应人物列表</param>
	/// <param name="assetFileName">资源包名 - Asset文件名：该动物建模的动画资源的文件名</param>
	/// <param name="aniPrefix">动画名前缀 - 此动物建模动画资源的Unity内的动画前缀</param>
	/// <param name="attackDistances">普攻距离 - 依次为第1~3把武器效果</param>
	/// <param name="attackParticles">普攻特效</param>
	/// <param name="attackSounds">普攻音效</param>
	/// <param name="blockSound">招架音效</param>
	/// <param name="jumpMoveParticles">蓄力移动特效</param>
	/// <param name="stepSound">移动脚步音效 - 此处为常规移动，非蓄力移动音效</param>
	/// <param name="teammateCommandBackCharEnterSound">同道指令出场音效 - 按顺序对应最多三个同道指令，相同动物的同道指令顺序必须完全相同</param>
	/// <param name="catchEffect">捕获时的人物表现</param>
	/// <param name="carrierId">捕获后获得的坐骑 - Carrier表中的模板ID</param>
	/// <param name="failParticle">失败特效</param>
	/// <param name="failSound">失败音效</param>
	/// <param name="isElite">是否精英 - 用于特效效果判定</param>
	public AnimalItem(sbyte templateId, short[] characterIdList, string assetFileName, string aniPrefix, List<sbyte> attackDistances, List<string> attackParticles, List<string> attackSounds, string blockSound, List<string> jumpMoveParticles, List<string> stepSound, List<string> teammateCommandBackCharEnterSound, short catchEffect, short carrierId, string failParticle, string failSound, bool isElite)
	{
		TemplateId = templateId;
		CharacterIdList = characterIdList;
		AssetFileName = assetFileName;
		AniPrefix = aniPrefix;
		AttackDistances = attackDistances;
		AttackParticles = attackParticles;
		AttackSounds = attackSounds;
		BlockSound = blockSound;
		JumpMoveParticles = jumpMoveParticles;
		StepSound = stepSound;
		TeammateCommandBackCharEnterSound = teammateCommandBackCharEnterSound;
		CatchEffect = catchEffect;
		CarrierId = carrierId;
		FailParticle = failParticle;
		FailSound = failSound;
		IsElite = isElite;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AnimalItem()
	{
		TemplateId = 0;
		CharacterIdList = null;
		AssetFileName = null;
		AniPrefix = null;
		AttackDistances = null;
		AttackParticles = null;
		AttackSounds = null;
		BlockSound = null;
		JumpMoveParticles = null;
		StepSound = null;
		TeammateCommandBackCharEnterSound = null;
		CatchEffect = 0;
		CarrierId = 0;
		FailParticle = null;
		FailSound = null;
		IsElite = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AnimalItem(sbyte templateId, AnimalItem other)
	{
		TemplateId = templateId;
		CharacterIdList = other.CharacterIdList;
		AssetFileName = other.AssetFileName;
		AniPrefix = other.AniPrefix;
		AttackDistances = other.AttackDistances;
		AttackParticles = other.AttackParticles;
		AttackSounds = other.AttackSounds;
		BlockSound = other.BlockSound;
		JumpMoveParticles = other.JumpMoveParticles;
		StepSound = other.StepSound;
		TeammateCommandBackCharEnterSound = other.TeammateCommandBackCharEnterSound;
		CatchEffect = other.CatchEffect;
		CarrierId = other.CarrierId;
		FailParticle = other.FailParticle;
		FailSound = other.FailSound;
		IsElite = other.IsElite;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AnimalItem Duplicate(int templateId)
	{
		return new AnimalItem((sbyte)templateId, this);
	}
}
