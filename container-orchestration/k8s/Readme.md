# Playing with Kubernetes

1. Deploy

```powershell
kubectl apply -f .\sqlserver -f .\api
```

2. Verify on Kubernetes

```powershell
kubectl get all
```

3. Verify api

- Open the browser with url `http://localhost:5003/api/people`

4. Verify sqlserver

- We can use **SQL Server Management Studio** to access the sqlserver container with the following information
  - Server address: localhost,14334
  - Password for sa account: P@ssw0rd123

## Resources

[Kubernetes in a nutshell — tutorial for beginners](https://medium.com/swlh/kubernetes-in-a-nutshell-tutorial-for-beginners-caa442dfd6c0)

[Understand Kubernetes object init](https://www.handsonarchitect.com/2018/08/understand-kubernetes-object-init.html)