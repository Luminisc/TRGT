### Installation
1. VS 2022 Preview + MAUI Android + MAUI Win
2. dotnet tool install -g Redth.Net.Maui.Check
   maui-check
3. dotnet workload install maui-android
   dotnet workload install maui-windows
4. https://marketplace.visualstudio.com/items?itemName=egvijayanand.maui-templates

After VS update:
1. dotnet workload update --from-previous-sdk
2. dotnet restore
3. dotnet clean

### Preparations
1. Enable developer mode
	https://docs.microsoft.com/en-us/windows/apps/get-started/enable-your-device-for-development


### Just links
1. I hate permissions and Android
	https://stackoverflow.com/a/53201077/5077919
	https://stackoverflow.com/a/66366102/5077919 - Need to read about new permissions approach