using System.Collections.Generic;
using GameData.Adventure;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇参与者拓展方法集
/// </summary>
public static class AdventureParticipantExtensions
{
	/// <summary>
	/// 状态自动倒计时
	/// </summary>
	public static bool TickState(this IAdventureParticipant participant, int deltaTime)
	{
		IReadOnlyList<AdventureParameterData> parameters = participant.Parameters;
		if (parameters == null || parameters.Count <= 0 || deltaTime <= 0)
		{
			return false;
		}
		bool anyChanged = false;
		foreach (AdventureParameterData data in parameters)
		{
			if (data.Type == EAdventureParameterType.State)
			{
				AdventureParameterValue value = participant.GetParameter(data.Key);
				if (value.Current != 0)
				{
					anyChanged = true;
					value.Change(-deltaTime);
					participant.SetParameter(data.Key, value);
				}
			}
		}
		return anyChanged;
	}
}
