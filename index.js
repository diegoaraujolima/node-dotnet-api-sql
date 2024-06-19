const dotnet = require('node-api-dotnet');
console.log(__dirname)
dotnet.load(__dirname + '\\CL\\CL\\bin\\debug\\net8.0\\CL.dll')
console.log(dotnet)
dotnet.CL.Example.InitAssembly();
const test = new dotnet.CL.Example();
console.log(test.Connect());