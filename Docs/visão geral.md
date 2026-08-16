Copia do backend do Google Drive

## REQUISITOS FUNCIONAIS
 - Upload de arquivos: Os usuarios devem ser capazes de fazer uploads dos seus arquivos.
 - Download de arquivos: Os usuarios devem ser capazes de baixar seus arquivos.
 - Sincronização de arquivos: Os usuarios devem ser capazes de sincronizar arquivos locais com o ambiente remoto e vice-versa
 - A aplicação deve suportar cadastro do usuario e autenticação através de um token JWT.

---

## REQUISITOS NÃO FUNCIONAIS
 - O Sistema deve suportar 20 milhões de usuarios cadastrados.
 - O Sistema deve fornecer 10 GB de espaço gratuito para cada usuario.
 - Cada upload pode ter até 15GB de tamanho.
 - O Sistema deve suportar 3 milhões de uploads/dia
 - Os uploads devem ser retomaveis (se a internet cair a operação deve continuar de onde parou)
 - O Sistema deve operar em modo de alta disponibilidade (24/7), ser resiliente e tolerante a falhas.

--- 

## Estimativas 
 - Armazenamento total: 20 milhões de usuarios cadastrados * 10GB = 190,73 PB
 - Armazenamento diario médio: 3 milhões de uploads/dia * 50MB (Média) = 150TB média/dia
 - Operações de escrita no banco de dados: 3 milhoes / 24/60/60 = 35 escritas por segundo.

---

## Entidades Principais
 - File Metada - metadados do arquivo.
 - Folder - pastas relacionadas a um usuario.
 - User - usuario propriamente dito.

---

## Postgres como banco de dados.
 - PostgreSQL é mais que suficiente para lidar com 35 escritas por segundo. irá armanezar somente os metadados dos arquivos e das transações.

---

## R2 Object Storage.
 - Optei por utilizar Cloudflare R2 como meu Object Storage porque este projeto serve para compor portfolio. se um dia subir para aplicação de uso real, usar amazon S3 ou expandir os limites de uso do R2. este sistema foi construido esperando essa troca e visa eliminar o atrito quase que há zero, na troca dos serviços via interface e injeção de dependencias

---

## Endpoints 
 //Enpoint para criar um diretorio
 - POST: user/folders
  {
    "folder_name": "meus-arquivos",
    "parent_id": null // serve para mapear o encadeamento de pastas dentro do object storage.
  }

 //Enpoint de upload de arquivos
 - POST user/files
  {
    "folder_id": "7984UGBJNEBE892BU2BF",
    "filename": "nome_do_arquivo.png",
    "mimeType": "image/png", // exemplo usando .png
    "size": 1048576, // tamanho em bytes
    "uploaded_at": TIMESTAMP // será registrado no banco de dados
  } 

 // Endpoint para download dos arquivos
 - GET user/files/:{file_id}/download

 - GET /files/changes?since={timestamp}

--- 
 