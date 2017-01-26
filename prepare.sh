echo "Preparing for duinocom project"
echo "Dir: $PWD"

sudo apt-get update
sudo apt-get install -y git wget mono-complete

sudo python -c "$(curl -fsSL https://raw.githubusercontent.com/platformio/platformio/master/scripts/get-platformio.py)"