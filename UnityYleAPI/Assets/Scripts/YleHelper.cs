public static class YleHelper
{
    public static string YleProgramsUri { get; } = "https://external.api.yle.fi/v1/programs/items.json";

    public static string AppKey { get; } = "39148d6bac1d9cfdbdda66ebcdca1b44";
    public static string AppId { get; } = "c412b69f";
    public static string SecretKey { get; } = "90c5f51cb6455f61";

    public static string GetYleProgramSearchUri(int limit = 10, string query = null, int offset = 0)
    {
        return string.IsNullOrEmpty(query) 
            ? $"{YleProgramsUri}?limit={limit}&offset={offset}&app_id={AppId}&app_key={AppKey}" 
            : $"{YleProgramsUri}?limit={limit}&offset={offset}&q={query}&app_id={AppId}&app_key={AppKey}";
    }
}
