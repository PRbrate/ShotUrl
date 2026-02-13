# ShotUrl 🚀

Projeto de encurtador de URLs — uma aplicação simples com foco em **arquitetura escalável e desempenho**.

ShotUrl permite encurtar links longos, gerar URLs curtas únicas e fazer o redirecionamento de forma eficiente. Este projeto foi pensado não apenas como código, mas como uma oportunidade de aplicar boas práticas de arquitetura, caches e estratégias de escalabilidade.

---

## 📌 Visão Geral

O encurtador recebe uma URL longa e gera uma versão curta que redireciona para a original quando acessada.

Diferente de soluções que geram códigos aleatórios (que podem causar colisões depois de milhões de inserções), este projeto utiliza uma **sequence determinística + codificação Base62** para gerar URLs curtas únicas sem colisão.

Além disso, considerando grandes volumes de acessos (como 100 milhões de GETs por dia), foi implementada uma camada de **cache com Redis** para evitar leitura constante no banco, acelerando redirecionamentos e reduzindo sobrecarga.

---

## 🧠 Arquitetura

A estrutura principal do projeto inclui:

- 🎯 **Gerador de IDs sequencial** para evitar conflitos
- 🔡 **Conversão Base62** para gerar URLs curtas (letras + números)
- ⚡ **Redis** para cache de URLs mais acessadas
- 🗄️ **PostgreSQL** como banco de dados confiável com alta performance
- ⚙️ Backend com endpoints para criação e redirecionamento de URLs
- 🖥️ Frontend em React para interface simples de usuário

---

## 🚀 Funcionalidades

- ✔️ Encerrar qualquer link válido
- ✔️ Gerar códigos únicos sem colisão
- ✔️ Cache em Redis para aceleração de redirecionamentos
- ✔️ Frontend simples em React
- ✔️ API REST para integração

---

## 🧪 Tecnologias Utilizadas

- **Backend:** .NET (API)  
- **Frontend:** React  
- **Banco de Dados:** PostgreSQL  
- **Cache:** Redis  
- **Deploy:** Docker + Vercel ou outro serviço de sua escolha

---

## 📥 Pré-Requisitos

Antes de rodar o projeto, instale:

- 🐘 PostgreSQL
- 🧠 Redis
- 🐳 Docker (opcional, mas recomendado)
- 📦 Node.js
- 🧩 .NET SDK

---

## 🛠️ Como Rodar Localmente

1. Clone o repositório

```bash
  git clone https://github.com/PRbrate/ShotUrl.git
  cd ShotUrl

```
2. Configure variáveis de ambiente (ex: .env)

DATABASE_URL=postgres://...
REDIS_URL=redis://...
FRONTEND_URL=http://localhost:3000

3. Inicie os servicos
   ```bash
   docker compose up

4. 
