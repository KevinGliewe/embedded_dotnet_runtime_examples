unameOut="$(uname -s)"
case "${unameOut}" in
    Linux*)     machine=linux;;
    Darwin*)    machine=macos;;
    CYGWIN*)    machine=cygwin;;
    MINGW*)     machine=mingw;;
    *)          machine="UNKNOWN:${unameOut}"
esac

if [ -f "dotnet_runtime/bin/${machine}/x64/dotnet" ]; then
    echo "runtime alrady installed"
else 
    echo "runtime not installed"
    cd dotnet_runtime
    dotnet tool restore
    dotnet runtimedl --version-pattern "^5\.0\.3$" --output "bin"
    cd ..
fi

dotnet build Host.sln

mkdir build
cd build
cmake ../Host
make
./Host ../