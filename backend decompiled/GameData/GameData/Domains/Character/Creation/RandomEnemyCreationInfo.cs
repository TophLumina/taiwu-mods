namespace GameData.Domains.Character.Creation;

public struct RandomEnemyCreationInfo
{
	public sbyte Gender = -1;

	public bool Transgender = false;

	public DeadCharacter DeadCharacter = null;

	public short RandomEnemyTemplateId = -1;

	public RandomEnemyCreationInfo()
	{
	}
}
