[![NuGet](https://img.shields.io/nuget/dt/StringCommandParser.svg?style=for-the-badge)](https://www.nuget.org/packages/StringCommandParser)
[![NuGet](https://img.shields.io/nuget/v/StringCommandParser.svg?style=for-the-badge)](https://www.nuget.org/packages/StringCommandParser)

# StringCommandParser for .Net 5.0

The StringCommandParser library gives an easy way to define verbs and methods for use in any situations where a string args situation for example Discord, Teams or Slack bot where you are taking user input and running a method based on the input.

```Install-Package StringCommandParser```

## Features

- No dependencies
- Automatic help text generation
- Compatible with .Net 5.0

## Quick start

First create or inject and instance of Parser:

```csharp
IParser parser = new Parser
```

Define the verbs and methods you want to be accessible from the parser:

```csharp
[Verb(Verb:"debug", HelpText:"Contains debugging methods")]
public class Debug {
	
	[Command(Method:"env",HelpText:"Returns environment information")]
	public void PrintEnv(){
		//Do something
	}
	
	[Command(Method:"echo",HelpText:"Returns the parameter")]
	public string PrintEnv(string echoText){
		return echoText
	}
}
```

Split the input string and pass it into the parser:

```csharp
var input = "debug env" // this will call the Debug.PrintEnv() method
var args = input.Split(" ");

var help = parser.ParseArgs<Debug>(args) //Multiple types can be provided here <T1,T2,T3...etc>
			.ExecuteMethod(x =>
            {
	        //Lambda is used here to allow for role processing etc, e.g:
		if(!isAdmin && x.Verb == "Admin") return false;
	            
                x.Method.Invoke(null, x.Args); //If the method isn't static, replace null with an instance of the class
                return true;
            })
            .CatchParseError(); // If the ParseArgs method fails to find a matching verb, command, or there's a parameter mismatch the help text will be returned by this method
```
The syntax of a parser command is:

```
<verb> <command> <arg1> <arg2> <arg3> etc 
```
