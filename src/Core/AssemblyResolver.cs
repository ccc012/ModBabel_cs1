using System.Linq;
using System.Reflection;
using ColossalFramework.Plugins;

namespace ModBabel.Core
{
    // Resolve a cópia CORRETA de uma DLL compartilhada (ex: AlgernonCommons.dll)
    // pertencente a um mod específico.
    //
    // Frameworks como o AlgernonCommons (usado por vários mods do
    // algernon-A) não são um "shared project" compilado dentro de cada
    // mod (como o ModsCommon) - são uma DLL de verdade, distribuída como
    // arquivo separado dentro da pasta de cada mod que o usa. Se o
    // jogador tiver 2+ mods desse autor instalados, existem 2+ cópias
    // carregadas de "AlgernonCommons.dll" ao mesmo tempo no jogo - uma
    // busca ingênua tipo AppDomain.CurrentDomain.GetAssemblies()
    // .FirstOrDefault(a => a.GetName().Name == "AlgernonCommons") pega
    // uma cópia QUALQUER (não necessariamente a do mod que queremos
    // traduzir), e patchar essa cópia errada não afeta o mod certo.
    //
    // A forma correta é perguntar ao PluginManager quais assemblies
    // foram carregados JUNTO com o mod principal (mesma pasta) - cada
    // PluginInfo sabe exatamente quais DLLs vieram dali via
    // GetAssemblies().
    public static class AssemblyResolver
    {
        // Encontra a assembly chamada "nomeAssemblyIrma" que foi
        // carregada na MESMA pasta/mod que a assembly principal
        // "nomeAssemblyPrincipal" (ex: encontrar a cópia de
        // "AlgernonCommons" que pertence especificamente ao
        // "EnlightenYourMouse", não a de outro mod do mesmo autor).
        public static Assembly EncontrarAssemblyIrma(string nomeAssemblyPrincipal, string nomeAssemblyIrma)
        {
            foreach (var pluginInfo in PluginManager.instance.GetPluginsInfo())
            {
                Assembly[] assemblies;
                try
                {
                    assemblies = pluginInfo.GetAssemblies().ToArray();
                }
                catch
                {
                    continue; // plugin com erro de carregamento - ignora e segue
                }

                var temAssemblyPrincipal = assemblies.Any(a => a.GetName().Name == nomeAssemblyPrincipal);
                if (!temAssemblyPrincipal)
                    continue;

                var irma = assemblies.FirstOrDefault(a => a.GetName().Name == nomeAssemblyIrma);
                if (irma != null)
                    return irma;
            }

            return null;
        }
    }
}
