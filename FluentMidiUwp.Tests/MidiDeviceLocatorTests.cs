using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMidi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentMidiUwp.Tests
{
    [TestClass]
    public class MidiDeviceLocatorTests 
    {
        [TestMethod]
        public async Task GetAllOutputDevicesAsync()
        {
            IEnumerable<IMidiOutputDevice> devices = await MidiDeviceLocator.GetAllOutputDevicesAsync();
            Assert.IsTrue(devices.Any());
            foreach (IMidiOutputDevice device in devices)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(device.DeviceId));
                Assert.IsFalse(string.IsNullOrWhiteSpace(device.Name));
            }
        }
    }
}