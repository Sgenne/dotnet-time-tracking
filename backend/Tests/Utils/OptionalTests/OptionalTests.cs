using API.Utils.Optional;

namespace Tests.Utils.OptionalTests;

public class OptionalTests
{
    [Fact]
    public void Some_Empty()
    {
        Optional<string> optional = Optional<string>.Empty();

        Assert.Throws<InvalidOperationException>(
            () => optional.Some(v => v)
        );
    }
}