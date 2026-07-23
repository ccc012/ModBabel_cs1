# ModBabel

Mod para **Cities: Skylines 1** que traduz outros mods do Steam Workshop
para múltiplos idiomas — começando por **Português do Brasil (pt-BR)**.

Não modifica, não republica e não é afiliado a nenhum dos mods
originais que traduz. Funciona como um add-on separado, interceptando
em tempo de execução (via [Harmony](https://github.com/pardeike/Harmony))
os textos que cada mod original desenha na interface.

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
| [Rainfall](https://steamcommunity.com/sharedfiles/filedetails/?id=698395457) ([código-fonte](https://github.com/yenyang/rainfall)) | [SSU]yenyang | strings extraídas, patch escrito, **não testado no jogo ainda** | pt-BR |

### Notas sobre o módulo Rainfall

- Mod é open-source (MIT) - strings extraídas direto do código-fonte,
  sem necessidade de decompilar.
- O autor confirmou publicamente (comentários do Workshop) que nunca
  fez localização própria para o mod - confirma a necessidade da
  Rota 2 (Harmony patch).
- Todas as strings do mod ficam em um único lugar
  (`Source/UI/OptionHandler.cs`, a tela de opções do mod), o que
  permitiu uma estratégia mais simples que o template genérico: um
  único patch que envolve o `UIHelperBase` recebido por
  `SetUpOptions` num wrapper tradutor (`TranslatingUIHelper`), em vez
  de um patch por string/painel.
- Pendências conhecidas antes de considerar "testado":
  - Confirmar no dnSpy (contra a `.dll` instalada) que
    `Rainfall.UI.OptionHandler.SetUpOptions` é o nome/assinatura real
    (extraído do código-fonte público, pode ter mudado em alguma
    atualização não sincronizada com o GitHub)
  - Confirmar a assinatura exata de `ICities.UIHelperBase` contra o
    `ICities.dll` instalado
  - O botão "Reset [nome do grupo]" usa um texto montado
    dinamicamente por grupo - ainda não capturado no XML de tradução
  - Rodar o checklist completo de `07_TESTES_ESTRATEGIA.md` (vault)

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
