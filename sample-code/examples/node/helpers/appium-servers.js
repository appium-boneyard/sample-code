
exports.local = {
  host: 'localhost',
  port: 4723
};

exports.sauce = {
  host: 'ondemand.saucelabs.com',
  port: 80,
  username: process.env.npm_package_config_username,
  password: process.env.npm_package_config_key
};
