# APP-Analytics-Performance

APP Analytics Performance is an Add-On for Fiddler to generate a report of application connections to API, validating access time and size of HTTP packets without requiring a change in backend or frontend.

## Objectives

* Check API response time.
* Verify API being called exaggeratedly by the application.
* Check average call length.
* Get a real profile of the application's calls during common usage.

## How to install

Add the "AppPerformance.dll" DLL to the "C:\Program Files(x86)\Fiddler2\Scripts" folder for Windows 64bits or "C:\Program Files\Fiddler2\Scripts" for Windows 32bits.

## How to use

1. Configure the Fiddler for your device.
    * Android: http://docs.telerik.com/fiddler/Configure-Fiddler/Tasks/ConfigureForAndroid
    * IOS: http://docs.telerik.com/fiddler/Configure-Fiddler/Tasks/ConfigureForiOS
    * WP: http://docs.telerik.com/fiddler/Configure-Fiddler/Tasks/MonitorWindowsPhone7
2. Open the APP Analytics Performance setup by opening the "Tools", "APP Analytics Performance" and "Config" menu.

![Open config](/Screenshots/OpenConfig.png)

3. Enter the API base you want to report.

![Config Window](/Screenshots/Config.png)

4. Click "Save".
5. Start "APP Analytics Performance" from the "Tools" menu, "APP Analytics Performance" and "Run APP Analytics".
6. Choose a location for the report file.
7. Make use of the application for as long as you want.
8. Stop "APP Analytics Performance".
9. Open the file with the report.

![Report File](/Screenshots/ExcelFile.png)