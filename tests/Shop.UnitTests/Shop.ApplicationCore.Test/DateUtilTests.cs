using Shop.ApplicationCore.Utils;
using Xunit;

namespace Shop.UnitTests;

public class DateUtilTests
{
    [Fact]
    public void GetCurrentDate_ReturnCorrectDate()
    {
        var currentDate = DateUtil.GetCurrentDate();
        
        Assert.True(currentDate.Year >= 2021);
    }
}