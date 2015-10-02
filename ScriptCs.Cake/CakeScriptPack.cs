using System;
using ScriptCs.Contracts;
using System.Linq;

namespace ScriptCs.CakePack
{
    public class CakeScriptPack : IScriptPack
    {                
        void IScriptPack.Initialize(IScriptPackSession session)
        {
            var refs = new [] {
                "Cake.Core",
                "Cake.Common",
            }.ToList ();

            refs.ForEach (session.AddReference);
                
            var ns = new [] {
                "Cake",
                "Cake.Core",
                "Cake.Core.IO",
                "Cake.Core.Diagnostics",
                "Cake.Common",
                "Cake.Common.IO",
                "Cake.Common.Tools",
                "Cake.Common.Tools.NuGet"
            }.ToList ();

            ns.ForEach (session.ImportNamespace);
        }       

        public IScriptPackContext GetContext ()
        {
            return new CakeBuild ();
        }

        public void Terminate ()
        {
        }
    }
}

