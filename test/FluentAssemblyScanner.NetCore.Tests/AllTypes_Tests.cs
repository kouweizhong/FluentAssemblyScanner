using System.Linq;
using System.Reflection;

using FluentAssemblyScanner.NetCore.Tests.SpecClasses;

using FluentAssertions;

using Xunit;

namespace FluentAssemblyScanner.NetCore.Tests
{
    public class AllTypes_Tests
    {
        [Fact]
        public void AllTypes_should_be_return_greater_than_zero()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            Assembly thisAssembly = Assembly.GetEntryAssembly();

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssembly(thisAssembly);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.GetAllTypes().Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void AllTypes_should_be_scan_all_classes_in_given_assembly()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            Assembly thisAssembly = Assembly.Load(new AssemblyName("FluentAssemblyScanner.NetCore.Tests"));

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            FromAssemblyDefiner instance = AssemblyScanner.FromAssembly(thisAssembly);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            instance.GetAllTypes().Should().Contain(typeof(SecurityService));
            instance.GetAllTypes().Should().Contain(typeof(ISecurityService));
            instance.GetAllTypes().Should().Contain(typeof(Product));
            instance.GetAllTypes().Should().Contain(typeof(SampleDbContext));
            instance.GetAllTypes().Should().Contain(typeof(AbstractDbContext));
        }
    }
}
