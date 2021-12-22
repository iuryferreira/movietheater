## Desenvolvendo Api's gRPC no .NET

Há algum tempo o REST vem dominando o panorama moderno das APIs, especialmente quando se trata de aplicativos da web e infraestruturas baseadas em microsserviços. 

Porém, REST não é a única arquitetura de API disponível e, em alguns casos, o uso do modelo gRPC pode ter um papel crucial.

Quer saber mais sobre o gRPC e se ele pode ser uma alternativa às APIs REST em seu próximo projeto de desenvolvimento?

Antes de entrarmos rapidamente no gRPC, devemos ver o que são chamadas de procedimento remoto.

### RPC

O **RPC** é uma forma de comunicação cliente-servidor que usa uma chamada de função em vez de uma chamada HTTP normal.

Ele usa *IDL (Interface Definition Language)* como forma de contrato sobre as funções a serem chamadas e sobre o tipo de dado. 

### gRPC

Se vocês ainda não perceberam, RPC em gRPC significa Remote Procedure Call. E sim, o gRPC replica esse estilo arquitetônico de comunicação cliente-servidor por meio de chamadas de função.

Portanto, o gRPC não é tecnicamente um conceito novo. Em vez disso, foi adotado a partir dessa técnica antiga e aprimorado, tornando-se muito popular em apenas 5 anos. 


O **gRPC** é uma estrutura poderosa para trabalhar com *Remote Procedures Calls* (RPCs). Um aplicativo cliente pode chamar diretamente um método em um aplicativo de servidor em uma máquina diferente como se fosse um objeto local, facilitando a criação de aplicativos e serviços distribuídos.

 Como em muitos sistemas RPC, o **gRPC** é baseado na ideia de **definir um serviço**, especificando os métodos que podem ser chamados remotamente com seus parâmetros e tipos de retorno. No lado do servidor, o servidor implementa essa interface e executa um servidor gRPC para lidar com as chamadas do cliente. No lado do cliente, o cliente tem um stub (referido apenas como um cliente em alguns idiomas) que fornece os mesmos métodos que o servidor. 