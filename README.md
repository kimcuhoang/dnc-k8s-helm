# dnc-k8s-helm

An extremely simple .NET Core web api within EntityFrameworkCore which will be deployed in k8s by both kubectl and helm

## Build the docker image

```powershell
docker-compose build
```

## Starting with docker-compose

[Follow this](container-orchestration/compose/Readme.md)

## Starting with Kubernetes

- Here are [step-by-step](container-orchestration/k8s/Readme.md) to deploy our services to Kubernetes.

## Starting with Helm

- Here are [step-by-step](container-orchestration/k8s-helm/Readme.md) from install [Helm](https://helm.sh/) and then deploy our services includes **sqlserver**

## More

- After deployed to K8s by Helm chart, we may want to play with [istio](https://istio.io/). Here are [step-by-step](container-orchestration/istio/README.md) from installation to deployment (includes [grafana](https://grafana.com/))
