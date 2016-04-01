echo "Preparing for duinocom project"
echo "Dir: $PWD"

DIR=$PWD

sudo apt-get update
sudo apt-get install -y git wget mono-complete arduino python-configobj python-setuptools git python-jinja2 python-serial python-pip
sudo pip install glob2
sudo apt-get install picocom

cd lib
git clone git://github.com/amperka/ino.git
cd ino
sudo make install

cd $DIR

mozroots --import --sync
