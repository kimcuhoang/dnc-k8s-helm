# Playing with docker-compose

1. Starting containers

- Create a folder `D:\temp` in order to mount volume from container
- Uses `docker-compose` command to start containers
  
    ```powershell
    docker-compose up
    ```

2. Verify service

- Open the browser and access the url `http://localhost:5002/api/people`

3. Verify sqlserver

- We can use **SQL Server Management Studio** to access the sqlserver container with the following information
  - Server address: localhost,14333
  - Password for sa account: P@ssw0rd123