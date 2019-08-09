# FluentMidiUwp
A fluent library for sending MIDI control and patch change events from a Universal Windows Platform (UWP) application.

```c#
/*
  Find all MIDI output devices on the current system.
*/
IEnumerable<IMidiOutputDevice> devices = MidiDeviceLocator.GetAllOutputDevices();

/*
  Send a control change event.
*/
MidiDeviceLocator.SelectForOutput("DeviceId")
  .SetDefaultChannel(1) 
  .ComposeControlChange()
    .WithControlNumber(63)
    .WithValue(127)
    .Send();

/*
  Send a patch change event.
*/
MidiDeviceLocator.SelectForOutput("DeviceId")
  .SetDefaultChannel(1) 
  .ComposePatchChange()
    .WithPatchNumber(12)
    .Send();
```
