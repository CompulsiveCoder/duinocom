echo "Starting build for duinocom project"
echo "Dir: $PWD"

MODE=$1

if [ -z "$MODE" ]; then
    MODE="Release"
fi

echo "Mode: $MODE"

msbuild src/duinocom.sln /p:Configuration=$MODE
