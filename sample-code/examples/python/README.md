Python samples
==============

These are simple samples of how to use Python to run Appium tests. It is suggested that you use a test runner such as pytest or nose.

Sauce Labs examples require at least version 0.12 of the Appium Python Client, which includes the `appium.SauceTestCase` base class.

Install appium client library:

```shell
pip install Appium-Python-Client
pip install pytest
```

Usage:

```shell
py.test ios_simple.py
py.test -n2 --boxed ios_simple.py
```
