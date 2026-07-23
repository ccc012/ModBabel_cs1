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

| Mod original | Status | Idiomas |
|---|---|---|
| _(a definir - Fase 3 do planejamento)_ | planejado | pt-BR |

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
