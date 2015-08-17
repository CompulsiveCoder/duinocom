#!/bin/bash

sketchbookPath=$(grep --only-matching --perl-regex "(?<=sketchbook.path\=).*" ~/.arduino/preferences.txt)

echo "Copying library files to:"
echo "$sketchbookPath"

cp duinocom/src/duinocom $sketchbookPath -rf

echo "Finished!"
