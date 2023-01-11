# Build the app with node and generate the static files

FROM node:latest as build

RUN mkdir /usr/src/app

WORKDIR /usr/src/app

ENV PATH /usr/src/app/node_modules/.bin:$PATH

COPY package.json /usr/src/app/package.json

RUN npm install

COPY . /usr/src/app

ENV NODE_OPTIONS=--openssl-legacy-provider

RUN npm run generate

# Production image, copy all the files and run nginx

FROM nginx:stable-alpine

COPY --from=build /usr/src/app/dist /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]