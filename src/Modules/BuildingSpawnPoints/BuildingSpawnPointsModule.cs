using HarmonyLib;

namespace ModBabel.Modules.BuildingSpawnPoints
{
    // Mod original: "Building Spawn Points" por MacSergey
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2511258910
    // Código-fonte: https://github.com/MacSergey/BuildingSpawnPoints (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName = "BuildingSpawnPoints"
    // - Mesmo framework ModsCommon do Advanced Stop Selection (mesmo
    //   autor) - já vem com pt-PT (português europeu) e mais 20 idiomas,
    //   mas SEM pt-BR (diferente do Advanced Stop Selection, que não
    //   tinha nenhum português). Mesma estratégia: Postfix em
    //   ModsCommon.LocalizeManager.GetString(chave, cultura), buscando o
    //   tipo especificamente dentro do assembly BuildingSpawnPoints (não
    //   globalmente) - ver AdvancedStopSelection/Patches/
    //   LocalizeManagerGetStringPatch.cs pro raciocínio completo.
    // - Traduzidas nesta primeira passada: descrição do mod + todas as
    //   chaves Panel_*/Tool_*/Property_*/Settings_*/PointType_*
    //   (a UI principal do painel de pontos de spawn) e
    //   VehicleTypeGroup_* (10 categorias). FORA DE ESCOPO por ora:
    //   VehicleType_* (46 nomes individuais de veículo - "Bus", "Taxi"
    //   etc, várias chaves de baixo esforço mas alto volume) e
    //   Mod_WhatsNewMessage* (changelog histórico de cada versão).
    public class BuildingSpawnPointsModule : Core.IModule
    {
        public string ModuloId => "buildingspawnpoints";

        public string AssemblyDoModOriginal => "BuildingSpawnPoints";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.LocalizeManagerGetStringPatch)).Patch();
        }
    }
}
