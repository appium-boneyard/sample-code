= Successfully make appium start up by itself before the test if it's not running in the background
= Things to do:
+ See how to use appium to manually get location of an element using terminal and GUI
+ Run locally --> Done after 2 days (Day 1: To connect appium and cucumber and phone)
Day 2: Fix Appium Inspector (by reinstall appium after deleting the old one)
+ Run on CI: how to set it up???
Fork the project on Github (to make it your project). Then clone into your machine. Then make change and push the code.
Travis CI support open Git hub project, and the setting up is pretty easy
+ Run on Saucelab
+ Choose different test tags to run on different environment


Note:
=== If at command line, type 'appium --version' and it says 'command not found'
--> should uninstall appium (delete appium in Applications) and install appium
again using package, choosing the most update one (don't install via npm
as there will be dependency and it's hard to detect). For example, at the moment
it is appium 1.5.2: https://bitbucket.org/appium/appium.app/downloads/appium-1.5.2.dmg

This problem can leads to error message like: Appium Inspector not working
+ When launching Appium Inspector: The error message would be like:
Could not start a new session
Be sure the Appium server is running with an application opened by using the "App Path"
parameter in Appium.app (along with package and activity for Android)...

although App Path is correctly added via Appium GUI and also in conf file

=== To kill an appium process:
'ps -A | grep appium'
'kill <process id>

==> Do the same thing for Android

==> Hoi anh giang cho nghe Rakefile

==> Questions:
+ Why app restart twice whenever it runs?
+ Why app automatically shut down after 1 minute?
+ Can we get an element by name? Or should we just use 'id' or 'xpath'?