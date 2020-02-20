# dnc-k8s-helm

An extremely simple .NET Core web api within EntityFrameworkCore which will be deployed in k8s by both kubectl and helm

## Build the docker image

```powershell
docker-compose build
```

## Starting Containers

### By docker-compose

[Follow this](container-orchestration/compose/Readme.md)

### Kubernetes

[Follow this](container-orchestration/k8s/Readme.md)

### Helm

[Follow this](container-orchestration/k8s-helm/Readme.md)