echo "Enter platform id: \n1: osx-arm64 \n2: osx-x64 \n3: linux-arm64 \n4: linux-x64 \nor type in the runtime identifier."
read -p "Enter number: " num

if [ "$num" -eq 1 ]; then
    rid="osx-arm64"
elif [ "$num" -eq 2 ]; then
    rid="osx-x64"
elif [ "$num" -eq 3 ]; then
    rid="linux-arm64"
elif [ "$num" -eq 4 ]; then
    rid="linux-x64"
else
    rid=$num
fi

echo "Publishing AngkorAPI for $rid ..."

dotnet publish -p AngkorAPI -c Release -p:PublishSingleFile=true -r $rid --self-contained true -p:EnableCompressionInSingleFile=true 