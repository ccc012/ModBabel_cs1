namespace ModBabel.Core
{
    // Cada mod original suportado implementa esta interface dentro de
    // src/Modules/[NomeDoModulo]/. Ver 06_TEMPLATE_HARMONY_PATCH.md
    // (vault) para o padrão de patches dentro de AplicarPatches().
    public interface IModule
    {
        // Identificador único do módulo - usado também como nome da
        // pasta em Translations/[ModuloId]/
        string ModuloId { get; }

        // Nome do assembly (.dll) do mod original, sem extensão -
        // usado para checar se o jogador tem esse mod instalado
        string AssemblyDoModOriginal { get; }

        // Registrado a partir daqui os [HarmonyPatch] deste módulo -
        // só é chamado se AssemblyDoModOriginal estiver presente
        void AplicarPatches(HarmonyLib.Harmony harmony);
    }
}
