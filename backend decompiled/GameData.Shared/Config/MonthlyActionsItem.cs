using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class MonthlyActionsItem : ConfigItem<MonthlyActionsItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly List<sbyte> EnterMonthList;

	public readonly sbyte MapState;

	public readonly sbyte MapArea;

	public readonly List<short> MapBlockSubType;

	public readonly sbyte CharacterSearchRange;

	public readonly bool MajorTargetMoveVisible;

	public readonly CharacterFilterRequirement[] MajorTargetFilterList;

	public readonly CharacterFilterRequirement[] ParticipateTargetFilterList;

	public readonly short AdventureId;

	public readonly short NotificationId;

	public readonly bool IsEnemyNest;

	public readonly bool AllowTemporaryMajorCharacter;

	public readonly bool AllowTemporaryParticipateCharacter;

	public readonly bool WillConvertTemporaryMajorCharacters;

	public readonly bool WillConvertTemporaryParticipateCharacters;

	public readonly bool CanActionBeforehand;

	public readonly sbyte PreparationDuration;

	public readonly sbyte PreannouncingTime;

	public readonly sbyte MinInterval;

	public readonly short MinFailureInterval;

	public AdventureItem Adventure
	{
		[return: MaybeNull]
		get
		{
			return Config.Adventure.Instance.GetItemOrDefault(AdventureId);
		}
	}

	public MonthlyNotificationItem Notification
	{
		[return: MaybeNull]
		get
		{
			return MonthlyNotification.Instance.GetItemOrDefault(NotificationId);
		}
	}

	public MonthlyActionsItem(short templateId, string name, List<sbyte> enterMonthList, sbyte mapState, sbyte mapArea, List<short> mapBlockSubType, sbyte characterSearchRange, bool majorTargetMoveVisible, CharacterFilterRequirement[] majorTargetFilterList, CharacterFilterRequirement[] participateTargetFilterList, short adventureId, short notificationId, bool isEnemyNest, bool allowTemporaryMajorCharacter, bool allowTemporaryParticipateCharacter, bool willConvertTemporaryMajorCharacters, bool willConvertTemporaryParticipateCharacters, bool canActionBeforehand, sbyte preparationDuration, sbyte preannouncingTime, sbyte minInterval, short minFailureInterval)
	{
		TemplateId = templateId;
		Name = name;
		EnterMonthList = enterMonthList;
		MapState = mapState;
		MapArea = mapArea;
		MapBlockSubType = mapBlockSubType;
		CharacterSearchRange = characterSearchRange;
		MajorTargetMoveVisible = majorTargetMoveVisible;
		MajorTargetFilterList = majorTargetFilterList;
		ParticipateTargetFilterList = participateTargetFilterList;
		AdventureId = adventureId;
		NotificationId = notificationId;
		IsEnemyNest = isEnemyNest;
		AllowTemporaryMajorCharacter = allowTemporaryMajorCharacter;
		AllowTemporaryParticipateCharacter = allowTemporaryParticipateCharacter;
		WillConvertTemporaryMajorCharacters = willConvertTemporaryMajorCharacters;
		WillConvertTemporaryParticipateCharacters = willConvertTemporaryParticipateCharacters;
		CanActionBeforehand = canActionBeforehand;
		PreparationDuration = preparationDuration;
		PreannouncingTime = preannouncingTime;
		MinInterval = minInterval;
		MinFailureInterval = minFailureInterval;
	}

	public MonthlyActionsItem()
	{
		TemplateId = 0;
		Name = null;
		EnterMonthList = new List<sbyte>();
		MapState = 0;
		MapArea = 0;
		MapBlockSubType = new List<short>();
		CharacterSearchRange = 0;
		MajorTargetMoveVisible = false;
		MajorTargetFilterList = new CharacterFilterRequirement[0];
		ParticipateTargetFilterList = new CharacterFilterRequirement[0];
		AdventureId = 0;
		NotificationId = 0;
		IsEnemyNest = false;
		AllowTemporaryMajorCharacter = false;
		AllowTemporaryParticipateCharacter = false;
		WillConvertTemporaryMajorCharacters = false;
		WillConvertTemporaryParticipateCharacters = false;
		CanActionBeforehand = true;
		PreparationDuration = 0;
		PreannouncingTime = 0;
		MinInterval = 0;
		MinFailureInterval = 0;
	}

	public MonthlyActionsItem(short templateId, MonthlyActionsItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		EnterMonthList = other.EnterMonthList;
		MapState = other.MapState;
		MapArea = other.MapArea;
		MapBlockSubType = other.MapBlockSubType;
		CharacterSearchRange = other.CharacterSearchRange;
		MajorTargetMoveVisible = other.MajorTargetMoveVisible;
		MajorTargetFilterList = other.MajorTargetFilterList;
		ParticipateTargetFilterList = other.ParticipateTargetFilterList;
		AdventureId = other.AdventureId;
		NotificationId = other.NotificationId;
		IsEnemyNest = other.IsEnemyNest;
		AllowTemporaryMajorCharacter = other.AllowTemporaryMajorCharacter;
		AllowTemporaryParticipateCharacter = other.AllowTemporaryParticipateCharacter;
		WillConvertTemporaryMajorCharacters = other.WillConvertTemporaryMajorCharacters;
		WillConvertTemporaryParticipateCharacters = other.WillConvertTemporaryParticipateCharacters;
		CanActionBeforehand = other.CanActionBeforehand;
		PreparationDuration = other.PreparationDuration;
		PreannouncingTime = other.PreannouncingTime;
		MinInterval = other.MinInterval;
		MinFailureInterval = other.MinFailureInterval;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MonthlyActionsItem Duplicate(int templateId)
	{
		return new MonthlyActionsItem((short)templateId, this);
	}
}
