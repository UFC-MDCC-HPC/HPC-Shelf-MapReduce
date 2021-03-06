<?xml version="1.0" encoding="utf-8"?>
<Project DefaultTargets="Build" ToolsVersion="4.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProductVersion>8.0.30703</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{EED2576B-7B84-4749-B5F1-1B58FD57AEA0}</ProjectGuid>
    <OutputType>Library</OutputType>
    <RootNamespace>br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitterRead</RootNamespace>
    <AssemblyName>br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypeSplitterRead</AssemblyName>
    <SignAssembly>true</SignAssembly>
    <AssemblyOriginatorKeyFile>..\..\br.ufc.mdcc.hpcshelf.mapreduce.task.splitter.TaskBindingSplitterRead\TaskBindingSplitterRead.snk</AssemblyOriginatorKeyFile>
    <TargetFrameworkVersion>v4.5</TargetFrameworkVersion>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug</OutputPath>
    <DefineConstants>DEBUG;</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <ConsolePause>false</ConsolePause>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>full</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release</OutputPath>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <ConsolePause>false</ConsolePause>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="System" />
    <Reference Include="DGAC">
      <HintPath>..\..\..\..\..\..\..\usr\lib\mono\DGAC\DGAC.dll</HintPath>
    </Reference>
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="..\src\1.0.0.0\BaseITaskPortTypeSplitterRead.cs">
      <Link>BaseITaskPortTypeSplitterRead.cs</Link>
    </Compile>
    <Compile Include="..\src\1.0.0.0\ITaskPortTypeSplitterRead.cs">
      <Link>ITaskPortTypeSplitterRead.cs</Link>
    </Compile>
  </ItemGroup>
  <Import Project="$(MSBuildBinPath)\Microsoft.CSharp.targets" />
  <ItemGroup>
    <ProjectReference Include="..\..\br.ufc.mdcc.hpc.storm.binding.task.TaskPortType\br.ufc.mdcc.hpc.storm.binding.task.TaskPortType\br.ufc.mdcc.hpc.storm.binding.task.TaskPortType.csproj">
      <Project>{B785892B-10B1-43BA-897F-E6F02CC932D0}</Project>
      <Name>br.ufc.mdcc.hpc.storm.binding.task.TaskPortType</Name>
    </ProjectReference>
  </ItemGroup>
</Project>