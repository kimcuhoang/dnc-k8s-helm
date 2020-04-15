# Playing with Kubernetes and Helm

## Install Helm

- Download [Helm 3.1.2 for window](https://get.helm.sh/helm-v3.1.2-windows-amd64.zip)
- Extract the zip file, for example, `C:\Helm-3.1.0`
- Add the `C:\Helm-3.1.2` to the **PATH**
- Verify

    ```powershell
    helm version
    ```

    ```json
    version.BuildInfo{Version:"v3.1.2", GitCommit:"d878d4d45863e42fd5cff6743294a11d28a9abce", GitTreeState:"clean", GoVersion:"go1.13.8"}
    ```

## Deploy by using Helm

### Configure volume mount

- Create a new folder in order to mount sqlserver database physical files, for example `E:\temp`
- Modify **hostPath** at `k8s-helm\people-api-database\values.yaml`

  ```yaml
  database:
    password: P@ssword
    persistentVolume:
      hostPath: "/E/temp"
      capacity: "20Gi"
  ```

### Install people-api-database

```powershell
λ  helm install people-api-database .\people-api-database
```

```powershell
NAME: people-api-database
LAST DEPLOYED: Wed Apr  8 15:00:50 2020
NAMESPACE: default
STATUS: deployed
REVISION: 1
NOTES:
1. Get the application URL by running these commands:
     NOTE: It may take a few minutes for the LoadBalancer IP to be available.
           You can watch the status of by running 'kubectl get --namespace default svc -w people-api-database'
  export SERVICE_IP=$(kubectl get svc --namespace default people-api-database --template "{{ range (index .status.loadBalancer.ingress 0) }}{{.}}{{ end }}")
  echo http://$SERVICE_IP:1433
```

### Install people-api

```powershell
λ  helm install people-api .\people-api
```

```powershell
NAME: people-api
LAST DEPLOYED: Wed Apr  8 15:01:48 2020
NAMESPACE: default
STATUS: deployed
REVISION: 1
NOTES:
1. Get the application URL by running these commands:
     NOTE: It may take a few minutes for the LoadBalancer IP to be available.
           You can watch the status of by running 'kubectl get --namespace default svc -w people-api'
  export SERVICE_IP=$(kubectl get svc --namespace default people-api --template "{{ range (index .status.loadBalancer.ingress 0) }}{{.}}{{ end }}")
  echo http://$SERVICE_IP:5004
```

### Verify helm packages

```powershell
λ  helm list
```

```powershell
NAME                    NAMESPACE       REVISION        UPDATED                                 STATUS          CHART                           APP VERSION
people-api              default         1               2020-04-08 15:01:48.3085737 +0700 +07   deployed        people-api-0.1.0                1.16.0
people-api-database     default         1               2020-04-08 15:00:50.1347003 +0700 +07   deployed        people-api-database-0.1.0       1.16.0
```

### Verify services and pods

```powershell
λ  kubectl get svc,po
```

```powershell
NAME                          TYPE           CLUSTER-IP      EXTERNAL-IP   PORT(S)          AGE
service/kubernetes            ClusterIP      10.96.0.1       <none>        443/TCP          79m
service/people-api            LoadBalancer   10.109.195.93   localhost     5004:32411/TCP   2m47s
service/people-api-database   LoadBalancer   10.96.49.122    localhost     1433:30976/TCP   3m45s

NAME                                       READY   STATUS    RESTARTS   AGE
pod/people-api-66447d89f-gkxwd             1/1     Running   4          2m47s
pod/people-api-database-57c69d5446-k64sp   1/1     Running   0          3m45s
```

## Verify application

### Api

- Endpoint: `http://localhost:5004/api/people`

### Sqlserver

- We can use **SQL Server Management Studio** with the following information
  - Address: **localhost**
  - Login: **sa**
  - Password: **P@ssword**

## Cleanup

### Remove all helm packages

```powershell
λ  helm uninstall people-api-database people-api
```

```powershell
release "people-api-database" uninstalled
release "people-api" uninstalled
```

## Resources

- [Getting Started](https://helm.sh/docs/chart_template_guide/getting_started/)
- [Template everything with Helm](https://medium.com/@maorfr/template-everything-with-helm-48e5a32ff72d)
- [Helm Chart for mssql-linux](https://github.com/helm/charts/tree/master/stable/mssql-linux)
- [kubectl Cheat Sheet](https://kubernetes.io/docs/reference/kubectl/cheatsheet/)