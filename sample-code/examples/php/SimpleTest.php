<?php
// To run this test, install Sausage (see http://github.com/jlipps/sausage-bun
// to get the curl one-liner to run in this directory), then run:
//     vendor/bin/phpunit SimpleTest.php

require_once "vendor/autoload.php";
define("APP_PATH", realpath(dirname(__FILE__).'/../../apps/TestApp/build/release-iphonesimulator/TestApp.app'));
if (!APP_PATH) {
    die("App did not exist!");
}


class SimpleTest extends Sauce\Sausage\WebDriverTestCase
{
    protected $numValues = array();

    public static $browsers = array(
        array(
            'local' => true,
            'port' => 4723,
            'browserName' => '',
            'desiredCapabilities' => array(
                'deviceName' => '=iPhone 5s',
                'version' => '8.4 Simulator',
                'platformName' => 'iOS',
                'app' => APP_PATH
            )
        )
    );

    public function elemsByTag($tag)
    {
        return $this->elements($this->using('class name')->value($tag));
    }

    protected function populate()
    {
        $elems = $this->elemsByTag('UIATextField');
        foreach ($elems as $elem) {
            $randNum = rand(0, 10);
            $elem->value($randNum);
            $this->numValues[] = $randNum;
        }
    }

    public function testUiComputation()
    {
        $this->populate();
        $buttons = $this->elemsByTag('UIAButton');
        $buttons[0]->click();
        $texts = $this->elemsByTag('UIAStaticText');
        $this->assertEquals(array_sum($this->numValues), (int)($texts[0]->text()));
    }
}
