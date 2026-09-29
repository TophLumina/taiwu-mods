namespace GameData.Domains.Taiwu;

public interface ITaiwuSkill
{
	sbyte GetBookPageReadingProgress(byte index);

	void SetBookPageReadingProgress(byte index, sbyte progress);

	sbyte[] GetAllBookPageReadingProgress();
}
