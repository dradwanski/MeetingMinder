namespace Application
{
    public class Token
    {
        public Token(string accessToken, string expireDate)
        {
            AccessToken = accessToken;
            ExpireDate = expireDate;
        }

        public string AccessToken { get; init; }
        public string ExpireDate { get; init; }
    }
}
