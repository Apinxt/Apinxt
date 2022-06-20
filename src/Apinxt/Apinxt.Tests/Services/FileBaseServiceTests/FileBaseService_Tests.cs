using Apinxt.Services;
using Apinxt.Tests.Fixtures;
using FluentAssertions;

namespace Apinxt.Tests.Services.FileBaseServiceTests
{
    public class FileBaseService_Tests
    {
        [Fact]
        public async Task ShouldSaveFile()
        {
            var fileName = "DummyClass";
            var fileService = new FileBaseService<DummyClass>(new Config.FileConfiguration { }, fileName);

            var dummyInstance = new DummyClass { StringProperty = "test" };
            
            await fileService.Save(dummyInstance);

            var fileInfo = new FileInfo(fileService.FullPathWithFileName);

            fileInfo.Exists.Should().BeTrue();

            fileInfo.Length.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task ShouldLoadFile()
        {
            var fileName = "DummyClass";
            var fileService = new FileBaseService<DummyClass>(new Config.FileConfiguration { }, fileName);

            var dummyInstance = new DummyClass { StringProperty = "test", BoolProperty = true, IntProperty = 10 };

            await fileService.Save(dummyInstance);

            var dummyFromFile = await fileService.Load();


            dummyFromFile.Should().BeEquivalentTo(dummyInstance);
        }
    }
}
