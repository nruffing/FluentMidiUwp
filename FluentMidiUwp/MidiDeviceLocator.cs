using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.Midi;

namespace FluentMidi
{
    /// <summary>
    /// A collection of static methods for querying and selecting MIDI devices
    /// connected to the current system.
    /// </summary>
    public static class MidiDeviceLocator
    {
        /// <summary>
        /// Retrieves a <see cref="IMidiOutputDevice"/> for the device with the
        /// specified identifier.
        /// </summary>
        /// <param name="deviceId">The identifier for requested MIDI output device.</param>
        /// <returns>A <see cref="IMidiOutputDevice"/> for the device with the
        /// specified identifier.</returns>
        public static IMidiOutputDevice SelectForOutput(string deviceId)
            => new MidiOutputDevice(deviceId);

        /// <summary>
        /// Retrieves a collection of all MIDI output devices on the current system.
        /// </summary>
        /// <returns>A collection of all MIDI output devices on the current system.</returns>
        public async static Task<IEnumerable<IMidiOutputDevice>> GetAllOutputDevicesAsync()
        {
            DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(MidiOutPort.GetDeviceSelector());

            List<IMidiOutputDevice> result = new List<IMidiOutputDevice>(devices.Count);
            foreach (DeviceInformation device in devices)
            {
                result.Add(new MidiOutputDevice(device.Id, device.Name));
            }
            
            return result;
        }
    }
}