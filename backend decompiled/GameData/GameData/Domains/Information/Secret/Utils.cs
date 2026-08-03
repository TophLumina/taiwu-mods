namespace GameData.Domains.Information.Secret;

public static class Utils
{
	public static byte[] QueryParameters(this SecretInformation secret, out SecretOccurence occurence)
	{
		SecretOccurence secretOccurence = DomainManager.Information.QuerySecretOccurence(secret.Id);
		if (secretOccurence != null)
		{
			occurence = secretOccurence;
			return occurence.PackedParameters;
		}
		occurence = null;
		return null;
	}
}
