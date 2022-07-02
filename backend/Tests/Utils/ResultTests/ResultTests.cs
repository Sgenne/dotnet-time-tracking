using API.Utils.Result;

namespace Tests.Utils.ResultTests;

public class ResultTests
{
    [Fact]
    public void Match_ErrorResultExecutesErrorHandler()
    {
        Result<int> result = Result<int>.Error("message", Status.ResourceNotFound);

        int SuccessHandler(int _) =>
            throw new Exception("SuccessHandler was used when calling Match on an error Result.");

        int ErrorHandler(string _, Status __) => 1;

        result.Match(SuccessHandler, ErrorHandler);
    }

    [Fact]
    public void Match_SuccessResultExecutesSuccessHandler()
    {
        Result<int> result0 = Result<int>.Success(1, "message", Status.Ok);
        Result<int> result1 = Result<int>.Success(1);

        int SuccessHandler(int i) => i;
        
        int ErrorHandler(string _, Status __) =>
            throw new Exception("ErrorHandler was used when calling Match on a Success Result");

        result0.Match(SuccessHandler, ErrorHandler);
        result1.Match(SuccessHandler, ErrorHandler);
    }

    [Fact]
    public void GetContained_Success()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public void GetContained_Error()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public void HandleSuccess_Success()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public void HandleSuccess_Error()
    {
        throw new NotImplementedException();
    }


}