# ☁️ CloudDrive - Backend (Clone do Google Drive)

> **Status:** MVP Funcional | Arquitetura para Alta Escala
> **Propósito:** Projeto de portfólio focado em arquitetura de sistemas, armazenamento de objetos e boas práticas de Go (ou a linguagem que você está usando).

## 📦 Sobre o Projeto
Este é o backend de um serviço de armazenamento em nuvem. O sistema gerencia uploads, downloads, pastas e sincronização de arquivos. 
A grande sacada do projeto está na **abstração do Object Storage**: o código foi escrito inteiramente contra uma *interface*, permitindo trocar de provedor (Cloudflare R2, AWS S3, MinIO local) com zero alteração na lógica de negócio.

## 🧠 O que esse projeto NÃO é (e o que ELE É)
- **Não** é uma aplicação rodando com 20 milhões de usuários (isso seria inviável para um portfólio).
- **É** uma aplicação com modelagem de dados para suportar esse crescimento, utilizando índices eficientes, estratégias de particionamento lógico e *Resumable Uploads*.

## 🎯 Metas Arquiteturais (Design Goals)
| Métrica | Valor | Justificativa |
| :--- | :--- | :--- |
| Usuários | Até 20M | Escalabilidade horizontal via stateless API |
| Espaço Gratuito | 10 GB/user | Planejamento de capacidade (190 PB totais) |
| Uploads/dia | 3M (média 50MB) | Pico de 35 escritas/segundo no Banco |
| Tamanho máximo | 15 GB por arquivo | Suporte a *Multipart Upload* com retomada |

## 🏗️ Arquitetura e Decisões Técnicas

- **Banco de Dados (PostgreSQL):** Armazena somente metadados (usuários, pastas, arquivos). Com 35 escritas/segundo, um bom banco relacional com índices em `user_id` e `updated_at` aguenta tranquilamente.
- **Object Storage (Cloudflare R2):** Escolhido para o portfolio por ser S3-compatible e ter custo baixo. O código possui uma camada de interface (`StorageProvider`) que permite migrar para AWS S3 ou Google Cloud Storage trocando apenas 1 linha de injeção de dependência.
- **Autenticação:** JWT (stateless) para manter a API escalável.

## 🚀 Como Rodar o Projeto (Local)
