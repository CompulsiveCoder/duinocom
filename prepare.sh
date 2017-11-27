echo "Preparing for duinocom project"
echo "Dir: $PWD"

sudo apt-get update

if ! type "git" > /dev/null; then
  sudo apt-get install -y git
fi

if ! type "wget" > /dev/null; then
  sudo apt-get install -y wget
fi

# mono
if ! type "mono" > /dev/null; then
  sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
  echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list

  sudo apt-get update && sudo apt-get install -y mono-devel mono-complete python python-pip
fi

# platform.io
if ! type "pio" > /dev/null; then
  #sudo python -c "$(curl -fsSL https://raw.githubusercontent.com/platformio/platformio/master/scripts/get-platformio.py)"
  sudo python -c "$(curl -fsSL https://raw.githubusercontent.com/platformio/platformio/develop/scripts/get-platformio.py)"
fi

# docker
if ! type "docker" > /dev/null; then
  sudo curl -sSL https://get.docker.com/ | sudo sh
fi
