# Vidswitch - MultiMonitor Rotation

This console application allows you to easily rotate the display of one or multiple monitors on your computer. It can be used to temporarily change the display orientation for a specific program or task, and then automatically revert back to the original settings once the program has quit.

## Features

- Rotate the display of one or multiple monitors.
- Choose from the following rotation options: 0, 90, 180, 270 degrees.
- Automatically revert back to original settings after the program quits.
- Easy to use command-line interface.

## Usage

1. Run the application from the command line, specifying the target display number, rotation, and program.
`vidswitch.exe 2 90 "c:\windows\system32\notepad.exe"`
2. The program will launch and the display of the specified monitor will be rotated.
3. Once the program quits, the display will automatically revert back to the original rotation.

## Parameters

- **Display Number**: The number of the display you want to rotate.
- **Rotation**: The degree of rotation you want to apply to the display. Can be 0, 90, 180, or 270.
- **Application to start and wait for quit**: The full path to the program you want to launch and wait for it to quit before restoring the original display settings.

## Example

`vidswitch 2 90 "c:\windows\system32\notepad.exe"` Launches Notepad.exe on display 2, rotates the monitor 90 degrees and maximizes Notepad. After Notepad closes, it returns the monitor back to its starting orientation.

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or later

## Compatibility

This application has been tested on Windows 10 and Windows Server 2019 and above. It should work on older versions of Windows, but compatibility is not guaranteed.

Please note that some programs may not work correctly when the display is rotated. Use this application at your own risk and test it thoroughly before using it in a production environment.

## Contribute

This application is open-source and actively maintained, feel free to contribute by submitting a pull request or reporting an issue.

## Conclusion

This console application makes it easy to temporarily rotate the display of one or multiple monitors on your computer, and then automatically revert back to the original settings once the program quits. It's a simple and effective solution for those who need to change the display orientation for a specific program or task.

