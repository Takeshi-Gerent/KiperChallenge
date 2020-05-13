# Imagem de Origem
FROM node:13-alpine
# Diret�rio de trabalho(� onde a aplica��o ficar� dentro do container).
WORKDIR /app
# Adicionando `/app/node_modules/.bin` para o $PATH
ENV PATH /app/node_modules/.bin:$PATH
# Instalando depend�ncias da aplica��o e armazenando em cache.
COPY package.json /app/package.json
RUN npm install --silent
RUN npm install react-scripts@3.3.1 -g --silent

COPY . ./app
COPY . ./

# start app
CMD ["npm", "start"]