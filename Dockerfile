# Base of your container
FROM microsoft/aspnet:latest

RUN apt-get update && apt-get install -y \
	make

# Copy the project into folder and then restore packages
COPY *.cs lib/* data.json Makefile /usr/src/app/
WORKDIR /usr/src/app