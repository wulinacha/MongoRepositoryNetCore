# MongoRepositoryNetCore

该项目目前是有Net45升级为netstandard2.0以支持netcore2版本，如果需要支持netcore3版本，需要对它进行升级到netstandard2.1。
修改项目文件MongoRepository.NetCore.csproj如下：
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MongoDB.Bson" Version="2.10.2" />
    <PackageReference Include="MongoDB.Driver" Version="2.10.2" />
  </ItemGroup>

</Project>


