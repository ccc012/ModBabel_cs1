# ModBabel

Mod para **Cities: Skylines 1** que traduz outros mods do Steam Workshop
para múltiplos idiomas. Um único mod cobre vários mods originais e
vários idiomas ao mesmo tempo — não é um tradutor de um mod só.

Não modifica, não republica e não é afiliado a nenhum dos mods
originais que traduz. Funciona como um add-on separado, interceptando
em tempo de execução (via [Harmony](https://github.com/pardeike/Harmony))
os textos que cada mod original desenha na interface.

## Idiomas suportados

17 idiomas, incluindo os 10 idiomas oficiais do jogo:

| Idioma | Código | Idioma oficial do jogo? |
|---|---|---|
| Português (Brasil) | `pt-BR` | ✅ — **verificado tela por tela em jogo** |
| Inglês | `en` | ✅ (referência/fallback) |
| Francês | `fr` | ✅ |
| Alemão | `de` | ✅ |
| Espanhol (Espanha) | `es` | ✅ |
| Polonês | `pl` | ✅ |
| Russo | `ru` | ✅ |
| Chinês simplificado | `zh-CN` | ✅ |
| Coreano | `ko` | ✅ |
| Japonês | `ja` | ✅ |
| Italiano | `it` | — |
| Chinês tradicional | `zh-TW` | — |
| Árabe | `ar` | — |
| Ucraniano | `uk` | — |
| Grego | `el` | — |
| Holandês | `nl` | — |
| Turco | `tr` | — |

O ModBabel não depende do idioma configurado no próprio jogo — você
escolhe o idioma preferido separadamente na tela de opções do mod, e
todos os módulos (mods traduzidos) respeitam essa escolha.

**Regra do projeto:** todo módulo novo (mod original suportado) precisa
cobrir todos os idiomas desta tabela antes de ser considerado completo.
Idiomas além do pt-BR ainda são rascunhos de tradução não verificados
tela por tela em jogo (ver status por módulo abaixo).

## Como funciona

- Cada mod original suportado vira um **módulo** dentro do ModBabel
  (`src/Modules/`). Se você não tiver aquele mod instalado, o módulo
  correspondente simplesmente não faz nada.
- As traduções ficam em arquivos separados por idioma
  (`Translations/[mod-original]/pt-BR.xml`, `en.xml`, etc.) — não
  ficam hardcoded no código. Adicionar um idioma novo é só adicionar
  um arquivo.
- Você escolhe o idioma preferido na tela de opções do próprio
  ModBabel (Content Manager → Mods → ModBabel → Options).
- O ModBabel sempre registra suas ações no log padrão do jogo
  (`Debug.Log`/`Debug.LogError`, o mesmo output_log.txt que qualquer
  mod usa - nada escondido). Opcionalmente, dá pra ligar "Habilitar log
  detalhado" na mesma tela de opções, que grava um arquivo próprio
  (`ModBabel.log`, na pasta do mod) - fica desligado por padrão, só
  liga se você quiser reportar um bug sem precisar caçar no log gigante
  do jogo inteiro.

## Requisitos

- Cities: Skylines 1
- Mod "Harmony" (dependência, via Workshop)
- O(s) mod(s) original(is) que você quer traduzir, instalados e ativos

## Mods suportados

| Mod original | Autor | Status | Idiomas |
|---|---|---|---|
| [Rainfall](https://steamcommunity.com/sharedfiles/filedetails/?id=698395457) ([código-fonte](https://github.com/yenyang/rainfall)) | [SSU]yenyang | pt-BR verificado tela por tela em jogo; demais idiomas são rascunhos ainda não verificados visualmente | 17/17 (ver tabela acima) |
| [Play It!](https://steamcommunity.com/sharedfiles/filedetails/?id=2741726428) ([código-fonte](https://github.com/keallu/CSL-PlayIt)) | Keallu | feito sem o mod instalado nesta máquina - compila, mas **nunca foi aberto em jogo** | pt-BR apenas (rascunho não verificado) |
| [Advanced Stop Selection](https://steamcommunity.com/sharedfiles/filedetails/?id=2862973068) ([código-fonte](https://github.com/MacSergey/ImprovedStopSelection)) | BloodyPenguin, macsergey | **mod instalado nesta máquina** - compila, aguardando teste em jogo | pt-BR apenas (rascunho não verificado) |
| [Auto Line Budget 21](https://steamcommunity.com/sharedfiles/filedetails/?id=2349240408) ([código-fonte](https://github.com/jakeluba/AutoLineBudget21)) | jakeluba | **mod instalado nesta máquina** - compila, aguardando teste em jogo | pt-BR apenas (rascunho não verificado) |
| [Better Budget](https://steamcommunity.com/sharedfiles/filedetails/?id=420972688) ([código-fonte](https://github.com/un0btanium/BetterBudget)) | unobtanium, airenelias | **mod instalado nesta máquina** - compila, aguardando teste em jogo | pt-BR apenas (rascunho não verificado) |
| [Better Education Toolbar](https://steamcommunity.com/sharedfiles/filedetails/?id=2810536248) ([código-fonte](https://github.com/t1a2l/BetterEducationToolbar)) | t1a2l, Chamëleon TBN | **mod instalado nesta máquina** - compila, aguardando teste em jogo | pt-BR apenas (rascunho não verificado) |
| [Better HealthCare Toolbar](https://steamcommunity.com/sharedfiles/filedetails/?id=2559042012) ([código-fonte](https://github.com/t1a2l/BetterHealthCareToolbar)) | t1a2l | **mod instalado nesta máquina** - compila, aguardando teste em jogo | pt-BR apenas (rascunho não verificado) |
| [Better Train Boarding](https://steamcommunity.com/sharedfiles/filedetails/?id=2773460744) ([código-fonte](https://github.com/Vectorial1024/BetterTrainBoarding)) | Vectorial1024 | **mod instalado nesta máquina** - compila, aguardando teste em jogo | pt-BR apenas (rascunho não verificado) |
| [Birdcage - More Chirper controls](https://steamcommunity.com/sharedfiles/filedetails/?id=649147853) ([código-fonte](https://github.com/SexyFishHorse/CitiesSkylines-Birdcage)) | SexyFishHorse | **mod instalado nesta máquina** - só a descrição, tela de opções fora de escopo por ora (ver notas) | pt-BR apenas (rascunho não verificado) |
| [Breakdown](https://steamcommunity.com/sharedfiles/filedetails/?id=2439120274) ([código-fonte](https://github.com/whyoh/CitiesBreakdown)) | whyoh | **mod instalado nesta máquina** - compila, aguardando teste em jogo | pt-BR apenas (rascunho não verificado) |
| [Broken Nodes Detector](https://steamcommunity.com/sharedfiles/filedetails/?id=1777173984) ([código-fonte](https://github.com/CitiesSkylinesMods/BrokenNodeDetector)) | CitiesSkylinesMods | **mod instalado** - só a descrição, telas de cada ferramenta fora de escopo por ora | pt-BR apenas (rascunho não verificado) |
| [Building Spawn Points](https://steamcommunity.com/sharedfiles/filedetails/?id=2511258910) ([código-fonte](https://github.com/MacSergey/BuildingSpawnPoints)) | MacSergey | **mod instalado** - já tinha pt-PT mas não pt-BR; UI principal traduzida, nomes de veículo individuais fora de escopo por ora | pt-BR apenas (rascunho não verificado) |
| [Bulldoze It!](https://steamcommunity.com/sharedfiles/filedetails/?id=1627986403) ([código-fonte](https://github.com/keallu/CSL-BulldozeIt)) | Keallu | **mod instalado nesta máquina** - compila, aguardando teste em jogo | pt-BR apenas (rascunho não verificado) |
| [Check Road Access for Growables](https://steamcommunity.com/sharedfiles/filedetails/?id=2454302667) ([código-fonte](https://github.com/DaEgi01/CitiesSkylines-CheckRoadAccessForGrowables)) | egi | **mod instalado nesta máquina** - compila, aguardando teste em jogo | pt-BR apenas (rascunho não verificado) |
| [Commuter Destination](https://steamcommunity.com/sharedfiles/filedetails/?id=2475986859) ([código-fonte](https://github.com/Jameskmonger/CSL-ShowCommuterDestination)) | Jameskmonger | **mod instalado nesta máquina** - compila, aguardando teste em jogo | pt-BR apenas (rascunho não verificado) |

**Mods instalados sem módulo próprio, porque já vêm com pt-BR oficial embutido** (nada a fazer no ModBabel):
- [81 Tiles 2](https://github.com/algernon-A/EightyOne2) - `Translations/pt-BR.csv` completo no próprio mod
- [ACME](https://github.com/algernon-A/ACME) - idem

### Notas sobre o módulo Play It!

- Diferente do Rainfall, o Play It! não usa o `UIHelper` padrão do jogo
  pra montar a maior parte da sua UI: ele cria um `UIPanel` próprio do
  zero (painel flutuante com abas World/Weather/Advanced + relógio
  flutuante), com todos os textos hardcoded direto no código C#.
- Como não tem um dicionário/campo interceptável como no Rainfall, a
  estratégia foi um Postfix genérico que roda depois do método que monta
  a UI e percorre a árvore de componentes já pronta, traduzindo cada
  `UILabel`/`UIButton`/tooltip/`UIDropDown.items` encontrado (ver
  `src/Core/UiTreeTranslator.cs`, reutilizável por futuros módulos com o
  mesmo padrão de UI customizada).
- A aba do mod no Content Manager (`ModInfo.OnSettingsUI`) tem textos
  hardcoded também - ali a solução foi pular o método original (Prefix
  retornando `false`) e remontar a mesma tela já traduzida.
- **Feito sem o mod instalado** - a extração de strings foi só por
  leitura do código-fonte público (aberto, sem licença explícita no
  repo). Compila com 0 erros, mas nunca foi aberto no jogo. Pendências
  antes de considerar "verificado": abrir o painel flutuante e a aba do
  Content Manager em jogo, comparando cada texto.
- Limitação conhecida: o texto "Game"/"System" do relógio flutuante
  (alternado com duplo-clique) não foi traduzido nesta versão.

### Notas sobre o módulo Advanced Stop Selection

- Diferente dos outros dois, este mod já usa um framework próprio de
  localização (ModsCommon, compartilhado entre vários mods do mesmo
  autor - Node Controller, Intersection Marking Tool etc.), com
  arquivos `.resx` e fallback por `CultureInfo`. Já vem com inglês e
  russo prontos.
- Como o ModsCommon é um "shared project" (`.projitems`), cada mod
  compila sua própria cópia do tipo `ModsCommon.LocalizeManager` dentro
  do próprio assembly - não é uma DLL compartilhada entre mods
  instalados. O patch busca esse tipo especificamente dentro do
  assembly `AdvancedStopSelection` (não com uma busca global por nome),
  pra não pegar a cópia de outro mod do mesmo autor instalado junto.
- O texto específico deste mod é pequeno: só a descrição (Content
  Manager) e as mensagens de "O que há de novo" de cada versão. O
  patch traduz pela **chave do recurso** (ex: `Mod_Description`), não
  pelo texto em si - mais estável entre idiomas.
- Fora de escopo por ora: as strings genéricas do próprio framework
  ModsCommon (abas "General"/"Notifications" etc.) - são muitas e
  compartilhadas entre vários mods do autor, ficam sem tradução por
  enquanto (fallback automático pro texto original).
- Feito sem testar em jogo ainda, apesar do mod estar instalado nesta
  máquina - falta abrir o Content Manager e conferir a descrição/texto
  de changelog.

### Notas sobre o módulo Auto Line Budget

- Mod bem simples e sem tela de opções - só ajusta o orçamento das
  linhas de transporte automaticamente. O único texto traduzido é a
  descrição no Content Manager (`IUserMod.Description`), interceptada
  com uma chave sintética (`Mod_Description`) em vez do texto em si,
  porque o texto original tem quebras de linha e um atributo XML
  normaliza qualquer quebra de linha pra espaço (regra do padrão XML) -
  usar o texto multi-linha como chave nunca bateria em tempo de
  execução.
- Duas mensagens de Chirper geradas dentro do loop principal (quando o
  orçamento de uma linha muda bastante) não foram traduzidas - são
  montadas e usadas na hora, sem passar por nenhum campo interceptável,
  e patchar `MessageManager.TryCreateMessage` (usado por dezenas de
  sistemas do próprio jogo) só pra essas duas frases seria frágil demais
  pro ganho.

### Notas sobre Better Budget, Better Education Toolbar e Better HealthCare Toolbar

- **Better Budget**: sem sistema de tradução, monta 3 painéis
  customizados do zero (mesmo padrão do Play It! - método público
  `initialize(...)` que constrói tudo), reaproveitando o
  `UiTreeTranslator` genérico.
- **Better Education/HealthCare Toolbar** (mesmo autor, t1a2l, código
  quase idêntico entre os dois): `Mod.Description` é implementação
  **explícita** de interface (`string IUserMod.Description => ...`) -
  o método compilado se chama `ICities.IUserMod.get_Description`, não
  `get_Description`, porque é assim que o compilador C# nomeia
  implementações explícitas de interface (confirmado via reflection
  contra a DLL instalada). Os tooltips dos botões de categoria vêm de
  um método `GetTooltip(enum)` que devolve texto no formato
  "NomeDaCategoria - descrição" - a chave de tradução é extraída do
  próprio texto (antes do " - "), evitando o risco de declarar um
  parâmetro de enum interno (não referenciado em tempo de compilação)
  na assinatura do Postfix do Harmony.

### Notas sobre Better Train Boarding, Birdcage e Breakdown

- **Better Train Boarding** e **Breakdown**: mods pequenos, só patches
  Harmony sem tela de opções - único texto traduzido é a descrição no
  Content Manager.
- **Birdcage**: `Description` é um `override` normal de uma classe base
  (`UserModBase`) vinda de outro assembly de fato separado
  (`SexyFishHorse.CitiesSkylines.Infrastructure.dll`, ao contrário do
  ModsCommon/AlgernonCommons que são "shared projects" compilados
  dentro do próprio mod). **Pendência**: a tela de opções (Appearance/
  Behaviour/Debugging) usa um wrapper próprio do autor
  (`IStronglyTypedUIHelper`) em vez do `ICities.UIHelperBase` direto -
  os textos são literais passados direto pros métodos desse wrapper,
  sem campo interceptável. Traduzir exigiria reimplementar o método
  inteiro via reflection encadeada - desproporcional pro tamanho da
  tela (5 checkboxes/botões) nesta primeira passada, fica pra depois.

### Notas sobre o lote Broken Nodes Detector, Building Spawn Points, Bulldoze It!, Check Road Access for Growables e Commuter Destination

- **Broken Nodes Detector**: mod grande com 8 ferramentas de diagnóstico
  independentes, cada uma com textos hardcoded espalhados em arquivos
  diferentes. Só a descrição foi traduzida por ora - as telas de cada
  ferramenta ficam pendentes (baixo uso, mod usado ocasionalmente).
- **Building Spawn Points**: mesmo framework ModsCommon do Advanced Stop
  Selection (mesmo autor). Diferente do Advanced Stop Selection, este
  mod já tinha **pt-PT** (português europeu) embutido, mas não pt-BR -
  primeiro caso de "framework bom, só falta o idioma específico".
  Traduzida a UI principal do painel (Panel_*/Tool_*/Property_*/
  Settings_*/PointType_*/VehicleTypeGroup_*); os 46 nomes individuais de
  veículo (VehicleType_*) e o changelog de cada versão ficam de fora por
  ora.
- **Bulldoze It!** (Keallu): mesmo padrão do Play It! - `OnSettingsUI`
  com textos hardcoded no `UIHelper` padrão, sem UIPanel customizado
  desta vez. Prefix reimplementa a tela inteira traduzida.
- **Check Road Access for Growables**: `OnSettingsUI` monta UI diferente
  se está em jogo ou não, em métodos privados separados - Postfix com o
  `UiTreeTranslator` genérico em cada um, evitando reimplementar lógica
  real do jogo (SimulationManager/BuildingManager).
- **Commuter Destination**: mod composto por 2 DLLs
  (`CommuterDestination.Core.dll` + `CommuterDestination.CS1.dll`) -
  detectamos pela presença da segunda. UI simples (grupo "Integrations"
  com 1 label dinâmico), coberta pelo `UiTreeTranslator`.

### Notas sobre o módulo Rainfall

- Mod é open-source (MIT), mas o build instalado via Steam Workshop foi
  **decompilado com ilspycmd** para confirmar tudo contra o binário real
  (o namespace real é `Rainfall`, não `Rainfall.UI` como o código-fonte
  público no GitHub sugeria - a estrutura interna mudou entre a versão
  publicada no repo e a instalada).
- O autor confirmou publicamente (comentários do Workshop) que nunca
  fez localização própria para o mod - confirma a necessidade da
  Rota 2 (Harmony patch).
- **Descoberta importante**: `OptionHandler.SetUpOptions` faz um cast
  direto do parâmetro `helper` para `UIHelper` concreto (não pela
  interface) para montar a tabstrip nativa, e cria instâncias de
  `UIHelper` novas internamente para cada aba. Isso invalidou a primeira
  tentativa (envolver o `helper` recebido num wrapper tradutor) - a
  abordagem final intercepta cada `Create(UIHelperBase)` das 5 classes
  de item de opção (`OptionsCheckbox`, `OptionsDropdown`, `OptionsButton`,
  `OptionsSlider`, `OptionResetButton`) via reflection (`Traverse`, já
  que essas classes são `internal` e não são referenciadas em tempo de
  compilação), e traduz o dicionário estático `fullOptionGroupNames`
  (nomes completos de grupo/aba) uma única vez. Ver
  `src/Modules/Rainfall/Patches/`.
- **Build verificado nesta máquina** (2026-07-23): `dotnet build` compila
  com 0 erros/0 avisos, e a DLL + traduções já foram copiadas para
  `%LOCALAPPDATA%\Colossal Order\Cities_Skylines\Addons\Mods\ModBabel\`.
- Pendências conhecidas / limitações assumidas:
  - Mensagens do Chirper (avisos de previsão do tempo, tipo "it's
    raining" etc.) usam grandes listas de frases aleatórias
    (`mildQuotes`, `normalQuotes`, `heavyQuotes`, `extremeQuotes`) em
    outro arquivo - **fora do escopo desta primeira versão**, só a tela
    de Opções do mod foi traduzida
  - Rodar o checklist completo de `07_TESTES_ESTRATEGIA.md` (vault) -
    isso só pode ser feito abrindo o jogo de verdade

## Como compilar

```
# Definir o caminho da pasta Managed do CS1 (ajustar se instalado em
# outro lugar) e compilar:
CSKY_MANAGED="C:\Program Files (x86)\Steam\steamapps\common\Cities_Skylines\Cities_Data\Managed" dotnet build
```

A DLL final e as traduções ficam em `bin/Debug/net35/` (ou `Release/`
com `-c Release`), prontas para copiar para a pasta de mods do jogo:
`%LOCALAPPDATA%\Colossal Order\Cities_Skylines\Addons\Mods\ModBabel\`

## Documentação de planejamento

A documentação completa (arquitetura, metodologia de extração de
strings, estratégia de testes) fica no vault de notas, não neste
repositório:

`G:\Meu Drive\Documentos obi\Projeto\Tradutor_CS1\`

## Licença

O código deste repositório é licenciado sob MIT (ver `LICENSE`). Isso
cobre apenas o código do ModBabel — nunca o código ou assets dos mods
originais traduzidos, que permanecem sob a licença/direitos de seus
respectivos autores.
