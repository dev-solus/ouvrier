FROM node:16-alpine3.15 as build-env
WORKDIR /app

# copy and cahe
COPY package.json .
COPY package-lock.json .

# RUN npm ci --force --no-optional
RUN npm i --legacy-peer-deps --no-optional

# RUN ./node_modules/.bin/ngcc --properties es2015
# RUN npm run ngcc

COPY . .

RUN npm run prod
RUN npm run zip
# RUN ls -al

FROM nginx:alpine
WORKDIR /usr/share/nginx/html

RUN rm -rf ./*
COPY ./ngx.conf /etc/nginx/conf.d/default.conf

COPY --from=build-env /app/dist .
# COPY ./dist .

ENTRYPOINT [ "nginx", "-g", "daemon off;" ]
