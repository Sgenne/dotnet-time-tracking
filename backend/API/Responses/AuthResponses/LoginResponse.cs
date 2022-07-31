namespace API.Responses.AuthResponses;

public class LoginResponse
{
    public string AccessToken { get; }

    public LoginResponse(string accessToken)
    {
        AccessToken = accessToken;
    }
}