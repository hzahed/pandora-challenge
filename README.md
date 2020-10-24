## Contact Info
![Full Name](https://icons.iconarchive.com/icons/custom-icon-design/pretty-office-8/16/User-blue-icon.png)
**Hossein Zahed Banisi**

![Email](https://icons.iconarchive.com/icons/dtafalonso/android-l/16/Gmail-icon.png)
[hossein.zahed@gmail.com](mailto:hossein.zahed@gmail.com)

![LinkedIn](https://icons.iconarchive.com/icons/limav/flat-gradient-social/16/Linkedin-icon.png)
[linkedin.com/in/hosseinzahed/](https://www.linkedin.com/in/hosseinzahed/)

# Pandora Challenge

There are three projects inside the solution:
- WebApi
- WebApi.Tests
- WebUI

You may run the Angular and WebApi projects together to check the outcome. Swagger is also added to WebApi to make it easier to test.

Mainly, there is a background queue that stores the incoming texts from post requests. There is also a background worker service which is executed every 500ms to check the queue and save the pending texts to the text file.

There are also two settings inside the appsettings.json:
- FileName: Defines the name of the text file
- Delimiter: Defines how text items are sepearated from each other. Default value is new line but can be changed to tab or comma separated as well.

I just spent around 4 hours for the development so didn't have more time to write more unit tests.

Docker compose support is also enabled for both projects.
