# Dictionary

## Installing dictionary

1\. Install [Docker Desktop](https://docs.docker.com/get-docker/) on your computer.

2\. Create a new `dictionary` folder for storing application files:

```bash
cd
mkdir dictionary
```

3\. Create `docker-compose.yml` file inside `dictionary` folder with the following content:

```yaml
version: "3.8"
services:
  dictionary:
    image: registry.gitlab.com/mialkin/dict-mialkin-ru:latest
    ports:
      - "5000:80"
    volumes:
      - .:/app/SQLite-files
    restart: unless-stopped
    environment:
      - ADMIN_USERNAME=admin
      - ADMIN_PASSWORD=password123
    container_name: dictionary
```

If you want, you can change port 5000 as well as admin username and password to your own.

4\. Go to `dictionary` folder and run `docker-compose up -d` command:

```bash
cd dictionary
docker-compose up -d
```

5\. Make sure that your container started successfully by running:

```bash
docker ps -a
```

6\. In your browser navigate to http://localhost:5000/login and enter username and password from `docker-compose.yml` file in order to log in to be able to add new words.

## Backing up dictionary with Backuper

You can set up automatic backup of SQLite database that dictionary uses internally for storing its data by using [Backuper](https://github.com/mialkin/backuper). You have to have an account on [Yandex.Disk](https://disk.yandex.com) to be able to use Backuper.

After [running](https://github.com/mialkin/backuper) Backuper as a Docker container set up a cron job that does backup once a day. Open up the cron settings file by running:

```bash
crontab -e
```

Insert the following line at the end of the file:

```text
0 0 * * * sudo docker exec backuper dotnet /app/Backuper.dll
```

Command above is going to run Backuper's console application inside of the container once a day at midnight UTC. Here we assume that Backuper's container  name is "backuper".

Save the file. On Ubuntu you should see right after that the following message:

```text
crontab: installing new crontab
```

Make sure that cron settings were modified by running:

```bash
crontab -l
```
