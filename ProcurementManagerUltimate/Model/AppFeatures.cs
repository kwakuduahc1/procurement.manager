namespace ProcurementManagerUltimate.Model;

public class AppFeatures
{
    public string AppName { get; }

    public string Issuer { get; }

    public string Validator { get; }

    public string RandomKey { get; }

    public string Audience { get; }

    public string SMS_Key { get; }

    public AppFeatures(IConfiguration config)
    {
        var cnf = config.GetSection(nameof(AppFeatures));
        AppName = cnf.GetSection(nameof(AppName)).Value;
        Issuer = cnf.GetSection(nameof(Issuer)).Value;
        Validator = cnf.GetSection(nameof(Validator)).Value;
        RandomKey = cnf.GetSection(nameof(RandomKey)).Value;
        Audience = cnf.GetSection(nameof(Audience)).Value;
        SMS_Key = cnf.GetSection(nameof(SMS_Key)).Value;
    }
}
