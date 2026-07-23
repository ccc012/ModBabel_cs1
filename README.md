# 🌍 ModBabel para Cities: Skylines 1

O **ModBabel** é a solução definitiva para jogar Cities: Skylines no seu idioma favorito. Ele traduz automaticamente outros mods da Steam Workshop para múltiplos idiomas ao mesmo tempo. 

Você não precisa baixar uma tradução separada para cada mod. O ModBabel funciona como um "tradutor universal" em tempo real, cobrindo vários mods simultaneamente.

---

💖 **Gostou do mod? Ajude a manter o projeto vivo!**
O desenvolvimento do ModBabel exige dezenas de horas de programação e testes. Se este mod melhorou sua jogabilidade, considere me pagar um café! Qualquer valor (até mesmo centavos) ajuda demais a continuar trazendo suporte para novos mods.
👉 **[Apoie via Ko-fi (Cartão/PayPal) - SEU LINK AQUI]**
👉 **[Apoie via LivePix (PIX) - SEU LINK AQUI]**

---

## ✨ Como funciona para o jogador

* **Zero complicação:** Você escolhe o idioma preferido na tela de opções do próprio ModBabel (Content Manager → Mods → ModBabel → Options). Pra maioria dos mods suportados, a troca já aparece na hora, sem precisar reiniciar o jogo nem ativar/desativar nada.
* **Independente do jogo:** O idioma do ModBabel não depende do idioma base do Cities: Skylines. Você pode ter o jogo em Inglês e os mods em Português, se quiser.
* **Leve e seguro:** Se você não tiver um mod original instalado, o ModBabel simplesmente ignora a tradução dele. Ele não modifica e não afeta os arquivos originais de nenhum outro criador.

## 📥 Requisitos e Instalação

1. Inscreva-se no mod **Harmony** (dependência obrigatória na Steam Workshop).
2. Inscreva-se no **ModBabel**.
3. Inscreva-se nos mods originais que você deseja usar.
4. Ative todos no *Content Manager* do jogo e selecione seu idioma nas opções do ModBabel.

---

## 🌐 Idiomas Suportados

Atualmente suportamos 17 idiomas. O **Português (Brasil)** é o idioma principal e está totalmente verificado em jogo. Os demais idiomas estão em fase de implementação/rascunho.

| Idioma                                                                                                                  | Código  | Status                                       |
| ----------------------------------------------------------------------------------------------------------------------- | ------- | -------------------------------------------- |
| Português (Brasil)                                                                                                      | `pt-BR` | ✅ Verificado em jogo                         |
| Inglês                                                                                                                  | `en`    | ✅ Referência base                            |
| Francês, Alemão, Espanhol, Polonês, Russo, Chinês, Coreano, Japonês, Italiano, Árabe, Ucraniano, Grego, Holandês, Turco | Vários  | 🚧 Em rascunho / Não verificados visualmente |

---

## 🛠️ Mods Suportados Atualmente

Abaixo está a lista de mods que o ModBabel já consegue traduzir. 

| Mod original                        | Autor                             | Status no ModBabel                               |
| ----------------------------------- | --------------------------------- | ------------------------------------------------ |
| **Rainfall**                        | [SSU]yenyang                      | pt-BR verificado em jogo.                        |
| **Play It!**                        | Keallu                            | Suporte implementado (aguardando testes finais). |
| **Advanced Stop Selection**         | BloodyPenguin, macsergey          | Suporte implementado (aguardando testes finais). |
| **Auto Line Budget 21**             | jakeluba                          | Suporte implementado (aguardando testes finais). |
| **Better Budget**                   | unobtanium, airenelias            | Suporte implementado (aguardando testes finais). |
| **Better Education Toolbar**        | t1a2l, Chamëleon TBN              | Suporte implementado (aguardando testes finais). |
| **Better HealthCare Toolbar**       | t1a2l | Suporte implementado (aguardando testes finais). |
| **Better Train Boarding**           | Vectorial1024                     | Suporte implementado (aguardando testes finais). |
| **Birdcage**                        | SexyFishHorse                     | Descrição traduzida. (Opções pendentes).         |
| **Breakdown**                       | whyoh                             | Suporte implementado (aguardando testes finais). |
| **Broken Nodes Detector**           | CitiesSkylinesMods                | Descrição traduzida. (Ferramentas pendentes).    |
| **Building Spawn Points**           | MacSergey                         | Interface principal traduzida em pt-BR.          |
| **Bulldoze It!**                    | Keallu                            | Suporte implementado (aguardando testes finais). |
| **Check Road Access for Growables** | egi                               | Suporte implementado (aguardando testes finais). |
| **Commuter Destination**            | Jameskmonger                      | Suporte implementado (aguardando testes finais). |

*Nota: Mods como **81 Tiles 2** e **ACME** não precisam do ModBabel, pois já possuem pt-BR nativo.*

---

## 💻 Para Desenvolvedores (Notas Técnicas)

O ModBabel não modifica, não republica e não é afiliado a nenhum dos mods originais. Ele funciona como um add-on separado, interceptando em tempo de execução (via Harmony) os textos que cada mod original desenha na interface.

* **Arquitetura:** Cada mod suportado vira um módulo em `src/Modules/`. As traduções ficam em arquivos XML separados (`Translations/[mod-original]/pt-BR.xml`). 
* **Logs:** As ações são registradas no `Debug.Log` padrão. O log detalhado (`ModBabel.log`) pode ser ativado nas opções.
* **Compilação:** Defina o caminho `CSKY_MANAGED` e use `dotnet build`. A DLL gerada vai para `bin/Debug/net35/`.

**Notas de Implementação por Módulo:**

* **Troca de idioma ao vivo:** Todo componente traduzido pelo `UiTreeTranslator` (ou registrado manualmente nos patches que remontam telas do zero) fica salvo no `TranslatedComponentRegistry` junto com o texto original em inglês. Trocar o idioma reaplica a tradução em cada componente já existente, sem precisar que o jogo reconstrua nada. Cobre Play It!, Better Budget, Check Road Access for Growables, Commuter Destination e Bulldoze It!. Rainfall e os módulos baseados em ModsCommon/AlgernonCommons (Advanced Stop Selection, Building Spawn Points) ainda exigem reiniciar o jogo pra aplicar a troca.
* **Play It! / Better Budget:** Utilizam painéis customizados (`UIPanel`) construídos do zero. O ModBabel aplica um Postfix genérico (`UiTreeTranslator`) após a montagem da UI para traduzir `UILabel`, `UIButton`, etc.
* **Advanced Stop Selection / Building Spawn Points:** Mods que utilizam o framework *ModsCommon*. O patch busca o tipo `LocalizeManager` isolado no próprio assembly para não conflitar com outros mods do mesmo autor.
* **Rainfall:** Intercepta cada `Create(UIHelperBase)` das classes internas de opção via reflection, já que o mod recria abas nativas internamente.
* **Auto Line Budget / Better Train Boarding:** Mods simples. Apenas a descrição (`IUserMod.Description`) foi interceptada.

**Documentação completa:** Disponível no vault interno do projeto.

---

**Licença:** MIT (Cobre apenas o código do ModBabel. Códigos e assets dos mods originais permanecem com seus respectivos autores).

💡 **Apoie o projeto:** Se você leu até aqui e gosta de código aberto, considere deixar uma contribuição no **[SEU LINK DO PIX/KO-FI AQUI]**!
