using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.ModuloExemplo
{
    // TEMPLATE - duplicar esta pasta para cada mod original novo e
    // renomear namespace/classe/ModuloId. Registrar a instância em
    // Core/ModuleRegistry.cs (lista TodosOsModulos).
    public class ModuloExemplo : IModule
    {
        public string ModuloId => "modulo-exemplo";

        // Nome do assembly (.dll, sem extensão) do mod original real -
        // conferir no dnSpy ou na pasta de mods instalados
        public string AssemblyDoModOriginal => "NomeDoAssemblyDoModOriginal";

        public void AplicarPatches(Harmony harmony)
        {
            // Cada classe de patch deste módulo é registrada explicitamente
            // aqui (em vez de um PatchAll global, que pegaria patches de
            // outros módulos também). Ver PatchExemplo.cs.
            harmony.CreateClassProcessor(typeof(PatchExemplo)).Patch();
        }
    }
}
