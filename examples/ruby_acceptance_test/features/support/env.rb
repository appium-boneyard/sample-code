require 'appium_lib'
require 'rspec/expectations'
require 'page-object'
require 'test/unit/assertions'

# caps = Appium.load_appium_txt file: File.expand_path('../', __FILE__), verbose: true

APP_PATH = '../../apps/TestApp/build/release-iphonesimulator/TestApp.app'

max_wait_in_seconds = 10

World PageObject::PageFactory
World Test::Unit::Assertions  # need this for 'assert' method

desired_caps = {
  	caps:       {
    	platformName:  'iOS',
    	versionNumber: '9.3',
    	deviceName:    'iPhone 6',
    	app:           APP_PATH,
  	},
  	appium_lib: {
	    sauce_username:   nil, # don't run on Sauce
	    sauce_access_key: nil
	  }
	}

def start_appium
	system "appium --log-level error &"
end

def shutdown_appium
	process = `ps -e | grep 'appium.*error$' | awk '{print $1}'`
	if process.length > 0
		system "kill #{process}"
	end
end

Before do
	if !$global_setup
		start_appium
		$global_setup = true
		sleep 5
	end
	@driver = Appium::Driver.new(desired_caps)

  # need to type @browser to be able to use PageObject (OMG!!!), just '@driver.start_driver' doesn't work
	@browser = @driver.start_driver
	@driver.set_wait max_wait_in_seconds
end

After do
  @driver.driver_quit
end

at_exit do
  shutdown_appium
end


