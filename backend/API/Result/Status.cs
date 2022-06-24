namespace API.Result;

public enum Status
{
    ResourceNotFound = 404,
    Forbidden = 403,
    Unauthorized = 401,
    BadRequest = 400,
    Ok = 200,
    Created = 201
}