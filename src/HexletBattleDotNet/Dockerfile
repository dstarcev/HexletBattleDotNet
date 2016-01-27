# Base of your container
FROM microsoft/aspnet:latest

# Copy the project into folder and then restore packages
COPY . /usr/src/app
WORKDIR /usr/src/app
RUN ["dnu","restore"]