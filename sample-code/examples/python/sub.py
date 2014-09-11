import subprocess

p1 = subprocess.Popen(['./sc/bin/sc -u $SAUCE_USERNAME -k $SAUCE_ACCESS_KEY -i AppiumTest'],
                      shell=True, stdout=subprocess.PIPE)

print p1.stdout.readlines()