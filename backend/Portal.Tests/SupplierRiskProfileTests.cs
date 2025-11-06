using Portal.Domain.ValueObjects;
using Xunit;

namespace Portal.Tests;

public class SupplierRiskProfileTests
{
    [Theory]
    [InlineData(10, "Low")]
    [InlineData(55, "Medium")]
    [InlineData(90, "High")]
    public void RiskLevel_ComputesExpectedLabels(decimal score, string expectedLevel)
    {
        var profile = new SupplierRiskProfile { RiskScore = score };

        Assert.Equal(expectedLevel, profile.RiskLevel);
    }
}
