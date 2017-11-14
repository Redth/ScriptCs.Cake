OBSOLETE
========

You should now just use [Cake.Bridge](https://github.com/devlead/Cake.Bridge/) for accessing a Cake Context from ScriptCS.


ScriptCs.Cake
=============

A ScriptCs Script Pack which creates a new Cake Context.

There are many useful aliases in http://cakebuild.net which make simple tasks much easier.  I wanted to bring some of these over to my ScriptCs scripts and merge the two worlds a bit.  This isn't perfect but it's a simple way to gain access to some of the great aliases in Cake.

## Install

Use the normal installation procedure for scriptcs:
```
scriptcs -install ScriptCs.Cake
```

In your script, use `Require<CakeBuild> ()` to obtain an instance of `ICakeContext`:
```csharp
var cake = Require<CakeBuild> ();
```

You now have access to everything in `ICakeContext`.  Most of Cake's Alias methods are built as extension methods, so while some of the default cake namespaces are automatically imported for you, you may need to import additional namespaces if a method is not found.  

You can access aliases now like this:

```csharp
var files = cake.GetFile ("./**/*.sln");

foreach (var f in files) {
    cake.NuGetRestore (f);
    cake.DotNetBuild (f);
}
```

Enjoy!
