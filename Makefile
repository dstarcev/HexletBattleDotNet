all: clean build run

clean:
	rm -rf *.exe

build:
	mcs -r:nunit.framework.dll,Newtonsoft.Json.dll -out:Solution.exe Program.cs Solution.cs

run:
	cat data.json | mono Solution.exe