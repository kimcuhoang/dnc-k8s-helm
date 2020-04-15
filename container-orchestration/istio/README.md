# Apply Istio

## Prerequisites:

- [Helm 3.1.2 for window](https://get.helm.sh/helm-v3.1.2-windows-amd64.zip) must be installed. Refer [this guide](../k8s-helm/Readme.md#Install Helm) if you don't have.

## Install Istio

- Download [Istio 1.5.1 for Window](https://github.com/istio/istio/releases/download/1.5.1/istio-1.5.1-win.zip)
- Extract to desired location, for example `C:\Dev\Istio-151`
- Add `C:\Dev\Istio-151\bin` to the **PATH**
- Verify

    ```powershell
    λ  istioctl version
    ```

- Start installing

    ```powershell
    λ  cd c:\Dev\istio-1.5.1\install\kubernetes\helm
    ```

- Create **istio-system** namespace

    ```powershell
    λ  kubectl create namespace istio-system
    ```

    ```powershell
    namespace/istio-system created
    ```

- Install [Istio's Custom Resource Definitions (CRD)](https://kubernetes.io/docs/concepts/extend-kubernetes/api-extension/custom-resources/#customresourcedefinitions)

    ```powershell
    λ  helm install istio-init -n istio-system .\istio-init\
    ```

    ```powershell
    NAME: istio-init
    LAST DEPLOYED: Wed Apr 15 14:09:02 2020
    NAMESPACE: istio-system
    STATUS: deployed
    REVISION: 1
    TEST SUITE: None
    ```

- Verify that all CRDs were successfully installed

    ```powershell
    λ  kubectl get crds -n istio-system
    ```

    ```powershell
    NAME                                      CREATED AT
    adapters.config.istio.io                  2020-04-12T05:36:28Z
    attributemanifests.config.istio.io        2020-04-12T05:36:23Z
    authorizationpolicies.security.istio.io   2020-04-12T05:36:27Z
    clusterrbacconfigs.rbac.istio.io          2020-04-12T05:36:23Z
    destinationrules.networking.istio.io      2020-04-12T05:36:24Z
    envoyfilters.networking.istio.io          2020-04-12T05:36:24Z
    gateways.networking.istio.io              2020-04-12T05:36:25Z
    handlers.config.istio.io                  2020-04-12T05:36:29Z
    httpapispecbindings.config.istio.io       2020-04-12T05:36:25Z
    httpapispecs.config.istio.io              2020-04-12T05:36:25Z
    instances.config.istio.io                 2020-04-12T05:36:28Z
    meshpolicies.authentication.istio.io      2020-04-12T05:36:26Z
    policies.authentication.istio.io          2020-04-12T05:36:26Z
    quotaspecbindings.config.istio.io         2020-04-12T05:36:26Z
    quotaspecs.config.istio.io                2020-04-12T05:36:26Z
    rbacconfigs.rbac.istio.io                 2020-04-12T05:36:27Z
    rules.config.istio.io                     2020-04-12T05:36:27Z
    serviceentries.networking.istio.io        2020-04-12T05:36:27Z
    servicerolebindings.rbac.istio.io         2020-04-12T05:36:28Z
    serviceroles.rbac.istio.io                2020-04-12T05:36:28Z
    sidecars.networking.istio.io              2020-04-12T05:36:22Z
    templates.config.istio.io                 2020-04-12T05:36:29Z
    virtualservices.networking.istio.io       2020-04-12T05:36:28Z
    ```

- Install **istio** and enable **grafana**

    ```powershell
    λ  helm install istio -n istio-system .\istio\ --set grafana.enabled=true
    ```

    ```powershell
    NAME: istio
    LAST DEPLOYED: Wed Apr 15 14:10:41 2020
    NAMESPACE: istio-system
    STATUS: deployed
    REVISION: 1
    TEST SUITE: None
    NOTES:
    Thank you for installing Istio.

    Your release is named Istio.

    To get started running application with Istio, execute the following steps:
    1. Label namespace that application object will be deployed to by the following command (take default namespace as an example)

    $ kubectl label namespace default istio-injection=enabled
    $ kubectl get namespace -L istio-injection

    2. Deploy your applications

    $ kubectl apply -f <your-application>.yaml

    For more information on running Istio, visit:
    https://istio.io/
    ```

- Verify that the **Istio** services, pods and **Grafana** are running

    ```powershell
    λ  kubectl get svc,po -n istio-system
    ```

    ```powershell
    NAME                             TYPE           CLUSTER-IP       EXTERNAL-IP   PORT(S)                                                                                                                                      AGE
    service/grafana                  ClusterIP      10.96.110.95     <none>        3000/TCP                                                                                                                                     2m55s
    service/istio-citadel            ClusterIP      10.109.210.148   <none>        8060/TCP,15014/TCP                                                                                                                           2m54s
    service/istio-galley             ClusterIP      10.108.157.233   <none>        443/TCP,15014/TCP,9901/TCP                                                                                                                   2m54s
    service/istio-ingressgateway     LoadBalancer   10.102.24.73     localhost     15020:31567/TCP,80:31380/TCP,443:31390/TCP,31400:31400/TCP,15029:31945/TCP,15030:32108/TCP,15031:30166/TCP,15032:31591/TCP,15443:30329/TCP   2m54s
    service/istio-pilot              ClusterIP      10.107.161.123   <none>        15010/TCP,15011/TCP,8080/TCP,15014/TCP                                                                                                       2m55s
    service/istio-policy             ClusterIP      10.100.57.93     <none>        9091/TCP,15004/TCP,15014/TCP                                                                                                                 2m54s
    service/istio-sidecar-injector   ClusterIP      10.100.64.181    <none>        443/TCP,15014/TCP                                                                                                                            2m55s
    service/istio-telemetry          ClusterIP      10.107.71.138    <none>        9091/TCP,15004/TCP,15014/TCP,42422/TCP                                                                                                       2m54s
    service/prometheus               ClusterIP      10.102.101.74    <none>        9090/TCP                                                                                                                                     2m54s

    NAME                                          READY   STATUS      RESTARTS   AGE
    pod/grafana-698d64686d-4zjfj                  1/1     Running     0          2m53s
    pod/istio-citadel-cfd789b4d-rtxdd             1/1     Running     0          2m53s
    pod/istio-galley-6db44f6bfc-skbbr             1/1     Running     0          2m53s
    pod/istio-ingressgateway-bdbf9f7d5-lcl7f      1/1     Running     0          2m53s
    pod/istio-init-crd-all-1.5.1-hslct            0/1     Completed   0          4m34s
    pod/istio-init-crd-mixer-1.5.1-sls9l          0/1     Completed   0          4m34s
    pod/istio-pilot-7dd54fd8d6-ggwmq              2/2     Running     1          2m53s
    pod/istio-policy-5b6ccb5599-zg4sg             2/2     Running     2          2m53s
    pod/istio-sidecar-injector-65d4d5866c-7fzmh   1/1     Running     1          2m53s
    pod/istio-telemetry-567d9ccd69-dgttr          2/2     Running     2          2m53s
    pod/prometheus-5bc799fd4c-wx924               1/1     Running     0          2m53s
    ```

- We'll use the **default** namespace to create our application objects, so we'll apply the **istio-injection=enabled** label to that namespace to enable automatic sidecar injection

    ```powershell
    λ  kubectl label namespace default istio-injection=enabled
    ```

- Verify that the **istio-injection** was enabled for the default namespace

    ```powershell
    λ  kubectl get namespace -L istio-injection
    ```

    ```powershell
    NAME              STATUS   AGE    ISTIO-INJECTION
    default           Active   4d6h   enabled
    docker            Active   4d6h
    istio-system      Active   77m
    kube-node-lease   Active   4d6h
    kube-public       Active   4d6h
    kube-system       Active   4d6h
    ```

## Install our services

### Install people-api & people-api-database

- If these services haven't been installed please refer to [this guide](../k8s-helm/Readme.md) to install by Helm.
- If these services have been installed before **install istio**, it means that **istio-injection** has not been applied for them. We can check as below

    ```powershell
    λ  kubectl get svc,po
    ```

    ```powershell
    NAME                          TYPE           CLUSTER-IP       EXTERNAL-IP   PORT(S)          AGE
    service/kubernetes            ClusterIP      10.96.0.1        <none>        443/TCP          3d4h
    service/people-api            LoadBalancer   10.102.21.106    localhost     5004:32361/TCP   8m
    service/people-api-database   LoadBalancer   10.110.123.231   localhost     1433:30206/TCP   47m

    NAME                                       READY   STATUS    RESTARTS   AGE
    pod/people-api-7794bf6466-7z4lp            1/1     Running   0          8m
    pod/people-api-database-599669df64-mv72b   1/1     Running   0          47m
    ```
- We can see their **pods** have only 1 container per each. In order to apply **istio-injection**, we have to rollout and restart theis **deployment** 

    - Get the deployments

        ```powershell
        λ  kubectl get deploy
        ```

        ```powershell
        NAME                  READY   UP-TO-DATE   AVAILABLE   AGE
        people-api            1/1     1            1           48m
        people-api-database   1/1     1            1           50m
        ```
    - Rollout and restart **people-api-database**

        ```powershell
        λ  kubectl rollout restart deployment/people-api-database
        ```
        
        ```powershell
        deployment.extensions/people-api-database restarted
        ```
    - Rollout and restart **people-api**

        ```powershell
        λ  kubectl rollout restart deployment/people-api
        ```
        
        ```powershell
        deployment.extensions/people-api restarted
        ```
    - Now, we verify again; there are 2 container per service
        
        ```powershell
        λ  kubectl get svc,po
        ```

        ```powershell
        NAME                          TYPE           CLUSTER-IP       EXTERNAL-IP   PORT(S)          AGE
        service/kubernetes            ClusterIP      10.96.0.1        <none>        443/TCP          3d4h
        service/people-api            LoadBalancer   10.102.21.106    localhost     5004:32361/TCP   14m
        service/people-api-database   LoadBalancer   10.110.123.231   localhost     1433:30206/TCP   53m

        NAME                                       READY   STATUS    RESTARTS   AGE
        pod/people-api-597d8f54dd-bqs6r            2/2     Running   0          38s
        pod/people-api-database-7c75fb947b-h795c   2/2     Running   0          104s
        ```


### Install istio objects

```powerhsell
λ  kubectl apply -f .\api-istio\
```

```powershell
gateway.networking.istio.io/people-api-gateway created
virtualservice.networking.istio.io/people-api-virtualservice created
```

### Install grafana

```powershell
λ  kubectl apply -f .\grafana\
```

```powershell
destinationrule.networking.istio.io/grafana created
gateway.networking.istio.io/grafana-gateway created
virtualservice.networking.istio.io/grafana-vs created
```

## Verify

### people-api-database

- Open SQL Server Management Studio with the following information
    - Address: **localhost**
    - Login: **sa**
    - Password: **P@ssword**

### people-api

- Open the browser at `http://localhost/api/people`
- Notes:
    - You may have to Stop IIS since it's using port **80**

### grafana

- Open the browser at `http://localhost:15031`

## Cleanup

### Uninstall istio objects

```powershell
λ  kubectl delete -f .\api-istio\
```

```powershell
gateway.networking.istio.io "people-api-gateway" deleted
virtualservice.networking.istio.io "people-api-virtualservice" deleted
```

### Uninstall grafana

```powershell
λ  kubectl delete -f .\grafana\
```

```powershell
destinationrule.networking.istio.io "grafana" deleted
gateway.networking.istio.io "grafana-gateway" deleted
virtualservice.networking.istio.io "grafana-vs" deleted
```

### Uninstall people-api and people-api-database

```powershell
λ  helm uninstall people-api people-api-database
```

```powershell
release "people-api" uninstalled
release "people-api-database" uninstalled
```

### Uninstall istio by Helm

```powershell
λ  cd c:\Dev\istio-1.5.1\install\kubernetes\helm
```

```powershell
λ  helm uninstall istio-init istio -n istio-system
```

```powershell
release "istio-init" uninstalled
release "istio" uninstalled
```

### Turn off sidecar auto-injection, if enabled

```powershell
λ  kubectl label namespace default istio-injection=disabled --overwrite

```powershell
namespace/default labeled
```

### Delete istio-system namespace

```powershell
λ  kubectl delete namespace istio-system
```

```powershell
namespace "istio-system" deleted
```

## Resources

https://www.digitalocean.com/community/tutorials/how-to-install-and-use-istio-with-kubernetes\

- [Deploying Istio with Kubernetes](https://www.linode.com/docs/kubernetes/how-to-deploy-istio-with-kubernetes/) - Updated on Tuesday, January 21, 2020.
- [kubectl Cheat Sheet](https://kubernetes.io/docs/reference/kubectl/cheatsheet/)
- [Debugging Helm Chart](https://www.alibabacloud.com/blog/helm-chart-and-template-basics---part-1_595489)

    ```powershell
    λ  helm install test-people-api-database  .\people-api-database\ --debug --dry-run
    ```