if [ -f "dotnet_runtime/bin/linux/x64/dotnet" ]; then
    echo "runtime alrady installed"
else 
    echo "runtime not installed"
    cd dotnet_runtime
    dotnet tool restore
    dotnet runtimedl --version-pattern "^5\.0\.3$" --output "bin"
    cd ..
fi


mkdir build
cd build
cmake ../Host
make
./Host ../