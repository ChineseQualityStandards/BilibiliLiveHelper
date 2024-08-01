using BilibiliLiveHelper.Modules.ModuleName.ViewModels;
using BilibiliLiveHelper.Services.Interfaces;
using Moq;
using Prism.Regions;
using Xunit;

namespace BilibiliLiveHelper.Modules.ModuleName.Tests.ViewModels
{
    public class ViewAViewModelFixture
    {
       
        Mock<IRegionManager> _regionManagerMock;
        const string MessageServiceDefaultMessage = "Some Value";

        public ViewAViewModelFixture()
        {
            
            
            _regionManagerMock = new Mock<IRegionManager>();
        }

        [Fact]
        public void MessagePropertyValueUpdated()
        {
            
        }

        [Fact]
        public void MessageINotifyPropertyChangedCalled()
        {
            
        }
    }
}
