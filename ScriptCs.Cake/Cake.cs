using System;
using ScriptCs.Contracts;
using Cake.Core;
using Cake.Core.IO;
using System.Collections.Generic;
using Cake.Core.Diagnostics;

namespace ScriptCs.CakePack
{
    public class CakeBuild : IScriptPackContext, ICakeContext, ICakeLog
    {
        global::Cake.Core.IO.IFileSystem fileSystem;
        ICakeEnvironment environment;
        IGlobber globber;
        ICakeArguments arguments;
        IProcessRunner processRunner;
        IRegistry registry;

        public CakeBuild ()
        {
            fileSystem = new FileSystem ();
            environment = new CakeEnvironment ();
            globber = new Globber (fileSystem, environment);
            arguments = new NullCakeArguments ();
            processRunner = new ProcessRunner (environment, this);
            registry = new WindowsRegistry ();
        }

        #region ICakeContext implementation
        public global::Cake.Core.IO.IFileSystem FileSystem { get { return fileSystem; } }
        public ICakeEnvironment Environment { get { return environment; } }
        public IGlobber Globber { get { return globber; } }
        public ICakeLog Log { get { return this; } }
        public ICakeArguments Arguments { get { return arguments; } }
        public IProcessRunner ProcessRunner { get { return processRunner; } }
        public IRegistry Registry { get { return registry; } }
        #endregion

        #region ICakeLog implementation
        public void Write (Verbosity verbosity, global::Cake.Core.Diagnostics.LogLevel level, string format, params object[] args)
        {
            Console.WriteLine (format, args);
        }

        public Verbosity Verbosity { get { return Verbosity.Diagnostic; } }
        #endregion

        class NullCakeArguments : ICakeArguments
        {
            public IDictionary<string, string> Arguments { get { return null; } }

            public NullCakeArguments ()
            {        
            }

            public void SetArguments(IDictionary<string, string> arguments)
            {
            }

            public bool HasArgument(string name)
            {
                return false;
            }

            public string GetArgument(string name)
            {
                return null;      
            }
        }
    }
}