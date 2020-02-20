# Playing with Kubernetes and Helm

## Install Helm

- Download [Helm 3.1.0 for window](https://get.helm.sh/helm-v3.1.0-windows-amd64.zip)
- Extract the zip file, for example, `C:\Helm-3.1.0`
- Add the `C:\Helm-3.1.0` to the **PATH**
- Open the **Window PowerShell** as **Administrator**; then starting init helm

    ```powershell
    helm init
    ```

- Verify

    ```powershell
    helm version
    ```

    ```json
    version.BuildInfo{Version:"v3.1.0", GitCommit:"b29d20baf09943e134c2fa5e1e1cab3bf93315fa", GitTreeState:"clean", GoVersion:"go1.13.7"}
    ```

## Deploy by using Helm

### Generate sqlserver helm package

```powershell
helm package .\sqlserver .\api\charts
```

### Verify dependencies of api

```powershell
helm dep list .\api
```

### Install api helm package

```powershell
helm install people-api .\api
```

### Verify

```powershell
helm list
```

## Verify application

### Api

- Endpoint: `http://localhost:5004/api/people`

### Sqlserver

- We can use **SQL Server Management Studio** to access the sqlserver container with the following information
  - Server address: localhost,14335
  - Password for sa account: P@ssw0rd123

## Resources

[Getting Started](https://helm.sh/docs/chart_template_guide/getting_started/)

[Template everything with Helm](https://medium.com/@maorfr/template-everything-with-helm-48e5a32ff72d)