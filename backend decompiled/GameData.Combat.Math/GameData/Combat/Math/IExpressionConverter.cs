namespace GameData.Combat.Math;

public interface IExpressionConverter
{
	int GetPersonalityValue(int personalityType);

	int GetConsummateLevel();

	int GetBehaviorType();
}
