Katacoda DotNet Example: Hosting Nancy and Mono inside a Docker container
=========================================================================

Run
-------------

```
  $ docker build -t katacoda/dotnet-nancy-example .
  $ docker run -d --name nancy-demo -p 8080:8080 katacoda/dotnet-nancy-example
  $ docker port nancy-demo 8080 | xargs curl
```

If you're using via boot2docker then specify the VM IP as part of the curl command

```
  $ curl $(boot2docker ip):8080
```
