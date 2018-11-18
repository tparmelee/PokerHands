####### Create Image to Build Static Files #######
FROM node:10 as builder

# Create and move into source directory
RUN mkdir /usr/src/app
WORKDIR /usr/src/app
ENV PATH /usr/src/app/node_modules/.bin:$PATH

# Install app dependencies
COPY package.json /usr/src/app/
COPY package-lock.json /usr/src/app/
RUN npm install

# Move source over
# done as separate step to reuse built image with dependencies 
# installed
COPY . /usr/src/app/
RUN npm run build

####### Create production image #######
FROM nginx:1.13.12-alpine
COPY --from=builder /usr/src/app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
