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

## Requisitos

- Cities: Skylines 1
- Mod "Harmony" (dependência, via Workshop)
- O(s) mod(s) original(is) que você quer traduzir, instalados e ativos

## Mods suportados

| Mod original | Autor | Status | Idiomas |
|---|---|---|---|
| [Rainfall](https://steamcommunity.com/sharedfiles/filedetails/?id=698395457) ([código-fonte](https://github.com/yenyang/rainfall)) | [SSU]yenyang | pt-BR verificado tela por tela em jogo; demais idiomas são rascunhos ainda não verificados visualmente | 17/17 (ver tabela acima) |
| [Play It!](https://steamcommunity.com/sharedfiles/filedetails/?id=2741726428) ([código-fonte](https://github.com/keallu/CSL-PlayIt)) | Keallu | feito sem o mod instalado nesta máquina - compila, mas **nunca foi aberto em jogo** | pt-BR apenas (rascunho não verificado) |

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
